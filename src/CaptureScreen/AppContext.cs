using System;
using System.Drawing;
using System.Windows.Forms;
using CaptureScreen.Properties;

namespace CaptureScreen
{
    public class AppContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Form messageForm; // Invisible form to handle messages

        public AppContext()
        {
            // Create a hidden window to receive HotKey messages
            messageForm = new MessageForm(this);
            
            // Initialize Tray Icon
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Exit", null, OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "CaptureScreen (Ctrl + Alt + A)";
            
            // Try to load an icon. If Resources doesn't have one, use system default or error.
            // Using a generic icon for now if specific one fails, but let's try to assume Resources exists as seen in file listing.
            // If Resources.Icon is not available, we can use SystemIcons.
            try {
               // Assuming the project has an icon based on frmCaptureScreen.Designer.cs usage
               // But usually Resources returns Bitmap. We need Icon.
               // Let's use SystemIcons.Application as safe fallback or try to extract.
               trayIcon.Icon = SystemIcons.Application; 
            } catch { }

            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;

            HotKeyHelper.RegisterHotKey(messageForm.Handle);
        }

        public void TakeScreenshot()
        {
             // Capture logic
             // We instantiate the form, capture, then show.
             frmCaptureScreen frm = new frmCaptureScreen();
             // We will need to modify frmCaptureScreen to allow manual triggering of capture
             // For now, let's assume we will refactor frmCaptureScreen to have a public Capture method
             // and NOT capture on Load.
             
             frm.InitCapture(); // We will add this method
             frm.Show();
             frm.Activate(); // Bring to front
        }

        private void OnExit(object sender, EventArgs e)
        {
            HotKeyHelper.UnregisterHotKey(messageForm.Handle);
            trayIcon.Visible = false;
            // Ensure we kill the message form
            messageForm.Close(); 
            Application.Exit();
        }

        // Invisible form to handle Windows Messages for HotKey
        private class MessageForm : Form
        {
            private AppContext context;
            public MessageForm(AppContext context)
            {
                this.context = context;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ShowInTaskbar = false;
                this.Load += (s, e) => {
                     this.Size = new Size(0, 0); 
                     this.Visible = false; 
                };
                // We need the handle to exist, so we might need to CreateHandle or just effectively be invisible
                // Calling CreateControl forces handle creation
                this.CreateControl();
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == HotKeyHelper.WM_HOTKEY)
                {
                    if (m.WParam.ToInt32() == HotKeyHelper.ID)
                    {
                        context.TakeScreenshot();
                    }
                }
                base.WndProc(ref m);
            }
        }
    }
}
