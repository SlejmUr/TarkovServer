using System.Runtime.InteropServices;

namespace ServerApp
{
    internal class ExtConsoleManagement
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static IntPtr handle = IntPtr.Zero;
        public static bool _IsConsoleOpen = true;
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static ExtConsoleManagement()
        {
            handle = GetConsoleWindow();
            Hide();
        }

        public static void ChangeConsole()
        {
            if (_IsConsoleOpen)
            {
                ShowWindow(handle, SW_HIDE);
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
            _IsConsoleOpen = !_IsConsoleOpen;
        }

        public static void Hide()
        {
            ShowWindow(handle, SW_HIDE);
            _IsConsoleOpen = false;
        }
    }
}
