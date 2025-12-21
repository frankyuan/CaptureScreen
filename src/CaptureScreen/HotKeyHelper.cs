using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CaptureScreen
{
    public static class HotKeyHelper
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 9000;

        // Modifiers: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
        // We will default to Ctrl + Alt + A (Ctrl=2 | Alt=1 = 3). 'A' is 65.
        
        public static void RegisterHotKey(IntPtr hWnd)
        {
            // Register Ctrl + Alt + A
            // Modifier: 0x0002 (Ctrl) | 0x0001 (Alt) = 0x0003
            // Key: A (0x41)
            RegisterHotKey(hWnd, HOTKEY_ID, 0x0003, 0x41);
        }

        public static void UnregisterHotKey(IntPtr hWnd)
        {
            UnregisterHotKey(hWnd, HOTKEY_ID);
        }

        public const int WM_HOTKEY = 0x0312;
        public const int ID = HOTKEY_ID;
    }
}
