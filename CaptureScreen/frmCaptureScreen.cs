using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

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
            ClearScreenButtonScreen();
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
            if (firstImage == screenImages[0])
            {
                btnScreen1.BackColor = Const.FocusColor;
            }
            if (firstImage == screenImages[1])
            {
                btnScreen2.BackColor = Const.FocusColor;
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
                    picCaptureScreen.CreateGraphics().DrawRectangle(selectPen, selectX,
                             selectY, selectWidth, selectHeight);
                }

                start = false;
                SaveToClipboard();
            }
        }

        private void SaveToClipboard()
        {
            //validate if something selected
            if (selectWidth <= 0)
            {
                return;
            }

            Rectangle rect = new(selectX, selectY, selectWidth, selectHeight);
            //create bitmap with original dimensions
            Bitmap OriginalImage = new(picCaptureScreen.Image, picCaptureScreen.Width, picCaptureScreen.Height);
            //create bitmap with selected dimensions
            Bitmap _img = new(selectWidth, selectHeight);
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
            ExitApplication(e.KeyCode);
        }

        private void picCaptureScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ExitApplication(e.KeyCode);
        }

        private static void ExitApplication(Keys key)
        {
            if (key == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btnScreen1_Click(object sender, EventArgs e)
        {
            ClearScreenButtonScreen();
            var image = screenImages[0];
            picCaptureScreen.Size = new Size(image.Width, image.Height);
            picCaptureScreen.Image = image;
            start = false;
            btnScreen1.BackColor = Const.FocusColor;
        }

        private void btnScreen2_Click(object sender, EventArgs e)
        {
            ClearScreenButtonScreen();
            var image = screenImages[1];
            picCaptureScreen.Size = new Size(image.Width, image.Height);
            picCaptureScreen.Image = image;
            start = false;
            btnScreen2.BackColor = Const.FocusColor;
        }

        private void btnScreen1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void btnScreen1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void btnScreen2_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void btnScreen2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void ClearScreenButtonScreen()
        {
            btnScreen1.BackColor = this.BackColor;
            btnScreen2.BackColor = this.BackColor;
        }
    }
}