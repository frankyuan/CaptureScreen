using CaptureScreen.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CaptureScreen
{
    public partial class frmCaptureScreen : Form
    {
        //These variables control the mouse position
        private int selectX;
        private int selectY;
        private int selectWidth;
        private int selectHeight;
        private Pen selectPen;
        private List<Image> screenImages = new List<Image>();

        bool start = false;

        public frmCaptureScreen()
        {
            InitializeComponent();
        }

        private void frmCaptureScreen_Load(object sender, EventArgs e)
        {
            btnScreen1.Visible = (Screen.AllScreens.Count() > 1);
            btnScreen2.Visible = (Screen.AllScreens.Count() > 1);
            ResetScreenButtonStyle();
            CaptureAllScreens();
        }

        private void CaptureAllScreens()
        {
            this.Hide();
            var defaultScreenIndex = -1;
            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                var screen = Screen.AllScreens[i];
                if (screen == Screen.PrimaryScreen)
                {
                    defaultScreenIndex = i;
                }

                Bitmap printscreen = new(screen.Bounds.Width, screen.Bounds.Height);
                //Create the Graphic Variable with screen Dimensions
                var graphics = Graphics.FromImage(printscreen);
                //Copy Image from the screen
                graphics.CopyFromScreen(
                    screen.Bounds.X,
                    screen.Bounds.Y,
                    0,
                    0,
                    screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                //Create a temporal memory stream for the image
                using MemoryStream memoryStream = new();
                printscreen.Save(memoryStream, ImageFormat.Bmp);
                var image = Image.FromStream(memoryStream);
                screenImages.Add(image);
            }

            var firstImage = screenImages[defaultScreenIndex];
            picCaptureScreen.Size = new Size(firstImage.Width, firstImage.Height);
            picCaptureScreen.Image = firstImage;
            this.Show();
            Cursor = Cursors.Cross;
            if (screenImages.Count >= 1 && firstImage == screenImages[0] && btnScreen1.Visible)
            {
                btnScreen1.FlatStyle = FlatStyle.Popup;
                btnScreen1.Image = Resources.screen1Select;
            }

            if (screenImages.Count >= 2 && firstImage == screenImages[1] && btnScreen2.Visible)
            {
                btnScreen2.FlatStyle = FlatStyle.Popup;
                btnScreen2.Image = Resources.screen2Select;
            }
        }

        private void picCaptureScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (picCaptureScreen.Image == null)
            {
                return;
            }

            if (start)
            {
                //refresh picture box
                picCaptureScreen.Refresh();
                //set corner square to mouse coordinates
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                //draw dotted rectangle
                picCaptureScreen.CreateGraphics().DrawRectangle(
                    selectPen,
                    Math.Min(selectX, e.X),
                    Math.Min(selectY, e.Y),
                    Math.Abs(selectWidth),
                    Math.Abs(selectHeight));
            }
        }

        private void picCaptureScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ExitApplication();
                return;
            }

            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 3)
                    {
                        DashStyle = DashStyle.Dot
                    };
                }
                picCaptureScreen.Refresh();
                start = true;
            }
            else
            {
                if (picCaptureScreen.Image == null)
                {
                    return;
                }

                if (e.Button == MouseButtons.Left)
                {
                    picCaptureScreen.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    picCaptureScreen.CreateGraphics().DrawRectangle(
                        selectPen,
                        Math.Min(selectX, e.X),
                        Math.Min(selectY, e.Y),
                        Math.Abs(selectWidth),
                        Math.Abs(selectHeight));
                }

                start = false;
                JumpToAdjustScreen(new Point(e.X, e.Y));
            }
        }

        private void JumpToAdjustScreen(Point currentPoint)
        {
            int capturedWidth = Math.Abs(selectWidth);
            int capturedHeight = Math.Abs(selectHeight);
            //validate if something selected
            if (capturedWidth == 0)
            {
                return;
            }

            Rectangle rect = new(
                Math.Min(selectX, currentPoint.X),
                Math.Min(selectY, currentPoint.Y),
                Math.Abs(capturedWidth),
                Math.Abs(capturedHeight));
            //create bitmap with original dimensions
            Bitmap OriginalImage = new(picCaptureScreen.Image, picCaptureScreen.Width, picCaptureScreen.Height);
            //create bitmap with selected dimensions
            Bitmap _img = new(capturedWidth, capturedHeight);
            //create graphic variable
            Graphics g = Graphics.FromImage(_img);
            //set graphic attributes
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
            //insert image stream into clipboard
            Clipboard.SetImage(_img);
            this.Hide();
            frmAdjustImage frmAdjustImage = new(_img);
            frmAdjustImage.Show();
        }

        private void frmCaptureScreen_KeyDown(object sender, KeyEventArgs e)
        {
            ExitApplicationWhenKeyDown(e.KeyCode);
        }

        private void picCaptureScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ExitApplicationWhenKeyDown(e.KeyCode);
        }

        private static void ExitApplicationWhenKeyDown(Keys key)
        {
            if (key == Keys.Escape)
            {
                ExitApplication();
            }
        }

        private static void ExitApplication()
        {
            Application.Exit();
        }

        private void btnScreen1_Click(object sender, EventArgs e)
        {
            ResetScreenButtonStyle();
            var image = screenImages[0];
            picCaptureScreen.Size = new Size(image.Width, image.Height);
            picCaptureScreen.Image = image;
            start = false;
            btnScreen1.FlatStyle = FlatStyle.Popup;
            btnScreen1.Image = Resources.screen1Select;
        }

        private void btnScreen2_Click(object sender, EventArgs e)
        {
            ResetScreenButtonStyle();
            var image = screenImages[1];
            picCaptureScreen.Size = new Size(image.Width, image.Height);
            picCaptureScreen.Image = image;
            start = false;
            btnScreen2.FlatStyle = FlatStyle.Popup;
            btnScreen2.Image = Resources.screen2Select;
        }

        private void btnControlButton_MouseEnter(object sender, EventArgs e)
        {
            SetMouseEnterCursorStyle();
        }

        private void btnControlButton_MouseLeave(object sender, EventArgs e)
        {
            SetMouseLeaveCursorStyle();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void frmCaptureScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ExitApplication();
            }
        }

        private void SetMouseEnterCursorStyle()
        {
            Cursor = Cursors.Arrow;
        }

        private void SetMouseLeaveCursorStyle()
        {
            Cursor = Cursors.Cross;
        }

        private void ResetScreenButtonStyle()
        {
            btnScreen1.FlatStyle = FlatStyle.Flat;
            btnScreen1.Image = Resources.screen1;
            btnScreen2.FlatStyle = FlatStyle.Flat;
            btnScreen2.Image = Resources.screen2;
        }
    }
}