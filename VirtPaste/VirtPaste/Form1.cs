/*****************************
    * Project  : Virt_Paste 
    * File     : Form1.cs
    * Authors  : Eric Caverly (eric@ericc.ninja)
    * Description:
    *   Contains code for main Graphical UI along with registering and unregistering hotkeys.
    *   Eventually will contain code for systray
    * Change log:
    *  [2/26/2025] - Initial Copy
    *  [2/27/2025] - Added fast typing - new default. Added System Tray function
******************************/

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VirtPaste {

    public enum KeyModifier {       // Used to register hotkeys
        None = 0,
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Super = 8
    }

    public struct Settings {        // Stores active session information
        public bool active;
        public bool slowTyping;
        public bool removeReturn;
        public bool overrideCaps;
        public bool sendBackspaces;
        public int delayMs;
        public Keys hotkeyKey;
        public short hotkeyModifiers;
    }

    public partial class Form1 : Form {
        // IDs for registered hotkeys
        const int PASTE_HOTKEY_ID = 1;
        const int CANCEL_HOTKEY_ID = 2;

        /* Win32 Register Hotkey prototypes */
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        // Default | Class global settings
        public Settings settings = new Settings {
            active = true,
            slowTyping = false,
            removeReturn = true,
            overrideCaps = true,
            sendBackspaces = false,
            delayMs = 30,
            hotkeyModifiers = (short)(KeyModifier.Ctrl | KeyModifier.Shift),
            hotkeyKey = Keys.V
        };


        // Form constructor
        public Form1() {
            InitializeComponent();

            // Set delegates for Virtual Typer class
            VirtualTyper.ToggleConduit = ToggleControls;
            VirtualTyper.UpdateProgress = (value) => Invoke(new Action(() => { UI_PB_Progress.Value = value; }));

            // Make UI reflect default settings
            SettingsToUI();

            // Bind default hotkey
            BindHotkey();
            RegisterHotKey(Handle, CANCEL_HOTKEY_ID, 0, (int)Keys.Escape);

            // Bind event handlers for changes to UI for hotkey
            UI_CB_MOD_Alt.CheckedChanged += HotkeyChangedEvent;
            UI_CB_MOD_Ctrl.CheckedChanged += HotkeyChangedEvent;
            UI_CB_MOD_Shift.CheckedChanged += HotkeyChangedEvent;
            UI_CB_MOD_Win.CheckedChanged += HotkeyChangedEvent;
            UI_TB_Hotkey.TextChanged += HotkeyChangedEvent;

            // Bind active checkbox handler
            UI_CB_Active.CheckedChanged += UI_CB_Active_CheckedChanged;

            // Bind other settings handlers
            UI_CB_RemoveCapslock.CheckedChanged += CompatChangedEvent;
            UI_CB_RemoveReturn.CheckedChanged += CompatChangedEvent;
            UI_CB_SendBackspaces.CheckedChanged += CompatChangedEvent;
            UI_TRB_Delay.ValueChanged += CompatChangedEvent;
            UI_CB_SlowType.CheckedChanged += CompatChangedEvent;

            // Bind stop button handler
            UI_BTN_Stop.Click += UI_BTN_Stop_Click;

            // Bind SysTray Functionality
            UI_NI_SysTray.DoubleClick += (sender, e) => {
                Show();
                WindowState = FormWindowState.Normal;
            };
            UI_BTN_Hide.Click += (sender, e) => Hide();
            UI_CMSBTN_ShowSettings.Click += (sender, e) => Show();
            UI_CMSBTN_Quit.Click += (sender, e) => Environment.Exit(0);

        }


        /*********************
         * Method  : UI_BTN_Stop_Click
         * Purpose : If the virtual typer is typing, tell it to stop
         ********************/
        private void UI_BTN_Stop_Click(object sender, EventArgs e) {
            if (VirtualTyper.Typing)
                VirtualTyper.StopTyping();
        }


        /*****************************
         * Method  : HotkeyChangedEvent
         * Purpose : Consolidated event handler. Detect when the UI has been interected with on any hotkey settings. Rebind hotkeys with new settings
         *****************************/
        private void HotkeyChangedEvent(object sender, EventArgs e) {
            UnregisterHotKey(Handle, PASTE_HOTKEY_ID);
            UnregisterHotKey(Handle, CANCEL_HOTKEY_ID);

            // Ensure a character is present in key selection box
            if (UI_TB_Hotkey.Text.Length == 0) {
                MessageBox.Show("You must have a key specified");
                return;
            }

            // Get the key in the key selection box
            settings.hotkeyKey = (Keys)char.ToUpper(UI_TB_Hotkey.Text[0]);

            // Get a mask of all selected modifiers
            settings.hotkeyModifiers = 0;
            settings.hotkeyModifiers |= (short)(UI_CB_MOD_Alt.Checked ? KeyModifier.Alt : 0);
            settings.hotkeyModifiers |= (short)(UI_CB_MOD_Ctrl.Checked ? KeyModifier.Ctrl : 0);
            settings.hotkeyModifiers |= (short)(UI_CB_MOD_Shift.Checked ? KeyModifier.Shift : 0);
            settings.hotkeyModifiers |= (short)(UI_CB_MOD_Win.Checked ? KeyModifier.Super : 0);

            // Ensure there is at least 1 modifier
            if (settings.hotkeyModifiers == 0) {
                MessageBox.Show("Must have at least 1 modifier selected");
                return;
            }

            // Re-bind hotkeys
            BindHotkey();
            RegisterHotKey(Handle, CANCEL_HOTKEY_ID, 0, (int)Keys.Escape);
        }


        /**************************
         * Method  : CompatChangedEvent
         * Purpose : Change settings based on UI changes
         *************************/
        private void CompatChangedEvent(object sender, EventArgs e) {
            settings.delayMs = UI_TRB_Delay.Value;
            settings.overrideCaps = UI_CB_RemoveCapslock.Checked;
            settings.removeReturn = UI_CB_RemoveReturn.Checked;
            settings.sendBackspaces = UI_CB_SendBackspaces.Checked;
            settings.slowTyping = UI_CB_SlowType.Checked;

            if (settings.slowTyping)
                UI_TRB_Delay.Enabled = true;
            else
                UI_TRB_Delay.Enabled = false;
        }


        /**************************
         * Method  : UI_CB_Active_CheckedChanged
         * Purpose : Toggle functionality based on active checkbox
         **************************/
        private void UI_CB_Active_CheckedChanged(object sender, EventArgs e) {
            settings.active = UI_CB_Active.Checked;
        }


        /*****************************
         * Method  : SettingsToUI
         * Purpose : Takes a settings argument and sets the WinForms UI to reflect them
         * Params  :
         *   s -> Settings to show on UI
         ****************************/
        internal void SettingsToUI() {
            UI_CB_RemoveCapslock.Checked = settings.overrideCaps;
            UI_CB_RemoveReturn.Checked = settings.removeReturn;
            UI_CB_SendBackspaces.Checked = settings.sendBackspaces;
            UI_TRB_Delay.Value = settings.delayMs;
            if ((settings.hotkeyModifiers & (short)KeyModifier.Alt) != 0)
                UI_CB_MOD_Alt.Checked = true;
            if ((settings.hotkeyModifiers & (short)KeyModifier.Shift) != 0)
                UI_CB_MOD_Shift.Checked = true;
            if ((settings.hotkeyModifiers & (short)KeyModifier.Ctrl) != 0)
                UI_CB_MOD_Ctrl.Checked = true;
            if ((settings.hotkeyModifiers & (short)KeyModifier.Super) != 0)
                UI_CB_MOD_Win.Checked = true;
            UI_TB_Hotkey.Text = ((Keys)settings.hotkeyKey).ToString();
            UI_CB_Active.Checked = settings.active;
            UI_CB_SlowType.Checked = settings.slowTyping;
            if (settings.slowTyping)
                UI_TRB_Delay.Enabled = true;
            else
                UI_TRB_Delay.Enabled = false;
        }


        /*************************
         * Method  : ToggleControls
         * Purpose : Enable / Disable controls while pasting. Uses Invoke for Thread Safety
         * Params  :
         *   enabled -> Enabled value for controls
         *************************/
        public void ToggleControls(bool enabled) {
            Invoke(new Action(() => {
                UI_CB_Active.Enabled = enabled;
                UI_CB_MOD_Alt.Enabled = enabled;
                UI_CB_MOD_Ctrl.Enabled = enabled;
                UI_CB_MOD_Shift.Enabled = enabled;
                UI_CB_MOD_Win.Enabled = enabled;
                UI_CB_RemoveCapslock.Enabled = enabled;
                UI_CB_RemoveReturn.Enabled = enabled;
                UI_CB_SendBackspaces.Enabled = enabled;
                UI_TB_Hotkey.Enabled = enabled;
                if (settings.slowTyping)
                    UI_TRB_Delay.Enabled = enabled;
                else 
                    UI_TRB_Delay.Enabled = false;
                UI_CB_SlowType.Enabled = enabled;

                UI_BTN_Stop.Enabled = !enabled;
            }));
        }


        /******************************
         * Method  : BindHotkey
         * Purpose : Given the passed settings, attempt to bind a system wide hotkey using Win32.h
         *****************************/
        internal void BindHotkey() {            
            // Register the hotkey
            if(!RegisterHotKey(Handle, PASTE_HOTKEY_ID, settings.hotkeyModifiers, (int)settings.hotkeyKey)) {
                MessageBox.Show("Failed to bind hotkey");
                return;
            }
        }


        /**********************************
         * Method  : WndProc
         * Purpose : Recieve windows events. Used to check if hotkey was pressed
         * Params  : 
         *   m -> message sent from windows
         **********************************/
        protected override void WndProc(ref Message m) {
            // Perform standard WinForms processing of events
            base.WndProc(ref m);

            // Check if the event is "hotkey" and the tool is enabled
            if (m.Msg == 0x0312 && settings.active) {

                // Obtain the ID of the event
                int id = m.WParam.ToInt32();

                switch (id) {
                    // If this was the hotkey for pasting, start typing using the VirtualTyper static method
                    case PASTE_HOTKEY_ID:
                        if (!VirtualTyper.Typing)
                            VirtualTyper.StartTyping(settings, Clipboard.GetText());
                        break;

                    // If this was the hotkey for cancelling, stop typing asap
                    case CANCEL_HOTKEY_ID:
                        if (VirtualTyper.Typing)
                            VirtualTyper.StopTyping();
                        break;
                }
            }
        }


    }
}
