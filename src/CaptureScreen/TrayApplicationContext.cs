namespace CaptureScreen
{
    internal sealed class TrayApplicationContext : ApplicationContext
    {
        internal const string MutexName = @"Local\CaptureScreen.SingleInstance";
        internal const string ShowEventName = @"Local\CaptureScreen.ShowCapture";

        private readonly NotifyIcon trayIcon;
        private readonly EventWaitHandle showEvent;
        private readonly Control syncControl = new();
        private frmCaptureScreen? captureForm;
        private bool exiting;

        public TrayApplicationContext(EventWaitHandle showEvent, List<Image> initialImages)
        {
            this.showEvent = showEvent;
            _ = syncControl.Handle;

            trayIcon = new NotifyIcon
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath) ?? SystemIcons.Application,
                Text = "CaptureScreen",
                Visible = true,
                ContextMenuStrip = CreateTrayMenu()
            };
            trayIcon.MouseClick += TrayIcon_MouseClick;

            var watcher = new Thread(WaitForShowRequests)
            {
                IsBackground = true,
                Name = "CaptureScreen.ShowWatcher"
            };
            watcher.Start();

            ShowCapture(initialImages);
        }

        private ContextMenuStrip CreateTrayMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("开始截屏", null, (_, _) => ShowCapture());
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("退出", null, (_, _) => ExitApplication());
            return menu;
        }

        private void TrayIcon_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowCapture();
            }
        }

        private void WaitForShowRequests()
        {
            while (!exiting)
            {
                showEvent.WaitOne();
                if (exiting)
                {
                    break;
                }

                try
                {
                    syncControl.BeginInvoke(ShowCaptureFromRunningInstance);
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (InvalidOperationException)
                {
                    break;
                }
            }
        }

        private void ShowCaptureFromRunningInstance()
        {
            // Capture before activating any existing window so an open context menu stays visible.
            ShowCapture(Utils.CaptureAllScreens());
        }

        public void ShowCapture(List<Image>? images = null)
        {
            images ??= Utils.CaptureAllScreens();
            CloseAdjustWindows();

            if (captureForm == null || captureForm.IsDisposed)
            {
                captureForm = new frmCaptureScreen();
                captureForm.FormClosing += CaptureForm_FormClosing;
            }

            captureForm.LoadScreens(images);
            if (!captureForm.Visible)
            {
                captureForm.Show();
            }

            captureForm.WindowState = FormWindowState.Maximized;
            captureForm.BringToFront();
            captureForm.Activate();
        }

        private void CaptureForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (exiting ||
                e.CloseReason == CloseReason.ApplicationExitCall ||
                e.CloseReason == CloseReason.WindowsShutDown ||
                e.CloseReason == CloseReason.TaskManagerClosing)
            {
                return;
            }

            e.Cancel = true;
            ReturnToTray();
        }

        public void ReturnToTray()
        {
            CloseAdjustWindows();
            if (captureForm != null && !captureForm.IsDisposed)
            {
                captureForm.Hide();
                captureForm.ReleaseScreens();
            }
        }

        private static void CloseAdjustWindows()
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (form is frmAdjustImage)
                {
                    form.Close();
                }
            }
        }

        public void ExitApplication()
        {
            exiting = true;
            showEvent.Set();
            trayIcon.Visible = false;
            trayIcon.Dispose();
            CloseAdjustWindows();
            if (captureForm != null && !captureForm.IsDisposed)
            {
                captureForm.FormClosing -= CaptureForm_FormClosing;
                captureForm.Close();
            }

            syncControl.Dispose();
            ExitThread();
        }
    }
}
