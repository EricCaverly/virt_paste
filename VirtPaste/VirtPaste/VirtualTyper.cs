/*****************************
    * Project  : Virt_Paste 
    * File     : VirtualTyper.cs
    * Authors  : Eric Caverly (eric@ericc.ninja)
    * Description:
    *   Contains code for sending virtual key presses within a seperate thread.
    *   Also uses delegates to update Form1
    * Change log:
    *  [2/26/2025] - Initial Copy
******************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace VirtPaste {
    internal class VirtualTyper {

        /*
         * Win32.h / user32.dll C-style function prototypes and data types
         * Required to interact with low-level Windows API functionality
         * For more information visit Micorosoft's official documentation
         */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern short VkKeyScan(char ch);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern uint SendInput(int cInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }
        public struct INPUT {
            public int type;
            public InputUnion u;
        }
        [Flags]
        public enum KeyEventF {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }
        [Flags]
        public enum InputType {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        /***** My Code Starts Here ***********/

        static ushort[] modifiersList = {
            0x08, // Backspace
            0x09, // Tab
            0x0D, // Return
            0xA0, // L Shift
            0xA1, // R Shift
            0x10, // Shift
            0xA4, // L Alt
            0xA5, // R Alt
            0x12, // Alt
            0xA2, // L Ctrl
            0xA3, // R Ctrl
            0x11, // CTRL
            0x5B, // L Win
            0x5C, // R Win
        };

        // State control - tracks what the program is currently doing
        static public bool Typing { get; set; }

        // Used to do slow operations without locking the main Form thread
        static Thread pasteThread = null;

        // Delegates for data transfer and UI updates in main thread
        static public Action<bool> ToggleConduit { get; set; }
        static public Action<int> UpdateProgress { get; set; }

        /********************************
         * Method  : StartTyping
         * Purpose : Begin sending virtual key presses in a seperate thread
         * Params  :
         *   settings -> Settings of application
         *   clipboard -> string of current clipboard text
         ********************************/
        public static void StartTyping(Settings settings, string clipboard) {
            // Confirm the clipboard has text content
            if (clipboard == string.Empty)
                return;

            // Disable controls, and set state to typing
            ToggleConduit?.Invoke(false);
            Typing = true;

            // Define logic for pasting
            pasteThread = new Thread(() => {
                // Store all keys that will need to be pressed
                Queue<KeyboardInput> inputQueue = new Queue<KeyboardInput>();

                // Raise all modifier keys
                foreach (ushort m in modifiersList) {
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = m,
                        dwFlags = (uint)KeyEventF.KeyUp
                    });
                }

                // Raise the hotkey key
                inputQueue.Enqueue(new KeyboardInput() {
                    wVk = (ushort)settings.hotkeyKey,
                    dwFlags = (uint)KeyEventF.KeyUp
                });

                // Add backspace if requested
                if (settings.sendBackspaces) {
                    for (int i = 0; i < 7; ++i) {
                        inputQueue.Enqueue(new KeyboardInput() {
                            wVk = 0x08,
                            dwFlags = (uint)KeyEventF.KeyDown
                        });
                        inputQueue.Enqueue(new KeyboardInput() {
                            wVk = 0x08,
                            dwFlags = (uint)KeyEventF.KeyUp
                        });
                    }
                }

                // If override caps lock is on, check if capslock is on
                bool turnCapsOn = false;
                if (settings.overrideCaps && Control.IsKeyLocked(Keys.CapsLock)) {
                    turnCapsOn = true;
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = 0x14,
                        dwFlags = (uint)KeyEventF.KeyDown
                    });
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = 0x14,
                        dwFlags = (uint)KeyEventF.KeyUp
                    });
                }

                // Add all keys within clipboard text
                foreach (char c in clipboard) {
                    // If the user has chosen to remove return characters, ignore them
                    if (c == '\r' && settings.removeReturn)
                        continue;

                    // Scan the character into windows key codes
                    short keycode = VkKeyScan(c);
                    
                    // Determine if the shift key is required or not
                    int shift_required = keycode >> 8;

                    // Get the key (without shift key)
                    char virtual_key_code = (char)(keycode&0x00FF);

                    // If the shift key is required, add it to queue
                    if (shift_required == 1)
                        inputQueue.Enqueue(new KeyboardInput() {
                            wVk = 0x10,
                            dwFlags = (uint)KeyEventF.KeyDown
                        });

                    // Add the key itself, down and up
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = virtual_key_code,
                        dwFlags = (uint)KeyEventF.KeyDown
                    });
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = virtual_key_code,
                        dwFlags = (uint)KeyEventF.KeyUp
                    });

                    // If shift was needed, lift it up again
                    if (shift_required == 1)
                        inputQueue.Enqueue(new KeyboardInput() {
                            wVk = 0x10,
                            dwFlags = (uint)KeyEventF.KeyUp
                        });
                }

                // Check if we need to toggle the caps lock key. This will only be true if we originally toggled it before all text
                if (turnCapsOn) {
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = 0x14,
                        dwFlags = (uint)KeyEventF.KeyDown
                    });
                    inputQueue.Enqueue(new KeyboardInput() {
                        wVk = 0x14,
                        dwFlags = (uint)KeyEventF.KeyUp
                    });
                }

                /*
                 * Meat and potatos loop - what takes the most time
                 * For each keyboard input queued above, build an array of unions (needed by Win32.h) and pass to sendinput
                 * Sends a single KEY ACTION between delays, this is the most tollerant of poor connections
                 */
                // Variables used for progress bar
                int index = 0;
                int total = inputQueue.Count;
                foreach (KeyboardInput kinput in inputQueue) {
                    // Allow the user to stop at any point
                    if (Typing == false)
                        break;

                    // Generate the array with a single key action
                    INPUT[] inputs = new INPUT[] {
                        new INPUT {
                            type = (int)InputType.Keyboard,
                            u = new InputUnion {
                                ki = kinput
                            }
                        }
                    };

                    // Send, update progress bar on Form1, then wait
                    SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT)));
                    UpdateProgress?.Invoke(++index * 100 / total);
                    Thread.Sleep(settings.delayMs);
                }

                // Reset UI and state variables
                StopTyping();
            });

            // Start the pasting thread in the background
            pasteThread.IsBackground = true;
            pasteThread.Start();

        }


        /*************************
         * Method  : StopTyping
         * Purpose : Called by stop button, ESC key, or by the thread ending. Resets UI / kills thread gracefully
         *************************/
        public static void StopTyping() {
            // Re-enable controls, and set state to no longer typing. Has the effect of stopping the paste thread if it is still running
            ToggleConduit?.Invoke(true);
            Typing = false;
        }
    }
}
