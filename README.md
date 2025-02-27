# ![image](https://github.com/EricCaverly/virt_paste/blob/main/Img/VirtPaste.png) Virt_Paste

![image](https://github.com/user-attachments/assets/63791dfe-e9a0-46be-9444-3cab4e99d99e)

The purpose of Virtual Paste is to send virtual key presses of the contents from the Windows clipboard. This enables pasting into applications that either do not respect the clipboard or support it.

Common use cases include Web VNC, Web-based SSH, or ScreenConnect sessions.

## How to use
1. Download the EXE from the releases section
2. Run the EXE, by default the hotkey is bound to CTRL+SHIFT+V

**You can cancel a paste job at any time by holding ESC or clicking the "Stop" button on the UI**

## Hotkey
1. Enable the modifier keys you wish to use, note that at least one is required
2. Type the character for the key you wish to use, note that this must be one character

## Advanced compatibility
#### Slow Typing
Ocassionaly some characters will be lost when pasting through connections with poor bandwidth. If this occurs, enable slow typing and increase the delay until characters are no longer being missed. 30ms is generally the minimum delay before some characters will be missed on the local computer, so remote hosts may need 50+ms.

#### Remove \\r
When copying from a CRLF source, both \\n and \\r will be present in the clipboard. When VirtPaste goes to send virtual key presses, it converts both into enter key presses, meaning the enter key is pressed twice. As this is often not desired when pasting multi-line texts, this option will trim out \r from the clipboard when creating the queue of key presses, ensuring enter is pressed the proper number of times.

#### Override Capslock
Will detect if Capslock is currently on, if yes disable it before typing and re-enable it once done. Generally this works fine however if pasting in a remote session it may be neccesary to disable it.

#### Send Backspaces
Some applications / remote sessions will but "invisible" characters in when any modifier key is pressed (CTRL, ALT, etc) which will polute the input before the clipboard contents are typed out. Enabling this option will send 7 backspace key presses to remove these characters. Note that 7 is likely more than the minimum required, this option should only be enabled when pasting into fields with no text before the current cursor position (passwords, etc).

## System Tray
- The application can be hidden by clicking on the "Hide" button. To get the settings window back, find the icon in the system tray and either double click or right click -> show settings.
- You can also quit the application from the system tray menu

## Development
> This program is written in .NET Framework 4.7.2
1. Clone the repo
2. Open VirtPaste/VirtPaste.sln within Visual Studio
