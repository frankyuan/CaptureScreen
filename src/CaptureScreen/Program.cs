using System.Runtime.InteropServices;

namespace CaptureScreen
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDpiAwarenessContext(IntPtr dpiContext);

        private static readonly IntPtr DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = new(-4);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);

            using var mutex = new Mutex(true, TrayApplicationContext.MutexName, out bool createdNew);
            if (!createdNew)
            {
                // No window here. The running instance captures first, then shows UI.
                try
                {
                    using var runningEvent = EventWaitHandle.OpenExisting(TrayApplicationContext.ShowEventName);
                    runningEvent.Set();
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                }

                return;
            }

            using var showEvent = new EventWaitHandle(false, EventResetMode.AutoReset, TrayApplicationContext.ShowEventName);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Capture before any window exists so an open context menu stays in the shot.
            var screenImages = Utils.CaptureAllScreens();
            var context = new TrayApplicationContext(showEvent, screenImages);
            Utils.HideToTrayRequested += context.ReturnToTray;
            Application.Run(context);
        }
    }
}