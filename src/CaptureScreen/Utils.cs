namespace CaptureScreen
{
    public static class Utils
    {
        public static event Action? HideToTrayRequested;

        public static void ExitApplication()
        {
            Application.Exit();
        }

        public static void ReturnToTray()
        {
            if (HideToTrayRequested == null)
            {
                Application.Exit();
                return;
            }

            HideToTrayRequested.Invoke();
        }

        /// <summary>
        /// Capture every monitor before any window is created or activated.
        /// Creating or focusing a form dismisses open context menus.
        /// </summary>
        public static List<Image> CaptureAllScreens()
        {
            var screenImages = new List<Image>();
            foreach (Screen screen in Screen.AllScreens)
            {
                var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(
                        screen.Bounds.X,
                        screen.Bounds.Y,
                        0,
                        0,
                        screen.Bounds.Size,
                        CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
                }

                screenImages.Add(bitmap);
            }

            return screenImages;
        }
    }
}
