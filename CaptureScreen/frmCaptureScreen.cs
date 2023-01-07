using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CaptureScreen
{
    public partial class frmCaptureScreen : Form
    {
        //These variables control the mouse position
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;

        //This variable control when you start the right click
        bool start = false;

        public frmCaptureScreen()
        {
            InitializeComponent();
        }

        private void frmCaptureScreen_Load(object sender, EventArgs e)
        {
            this.Hide();
            Bitmap printscreen = new(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height);
            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            //Copy Image from the screen
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //Create a temporal memory stream for the image
            using (MemoryStream memoryStream = new())
            {
                printscreen.Save(memoryStream, ImageFormat.Bmp);
                picCaptureScreen.Size = new Size(this.Width, this.Height);
                picCaptureScreen.Image = Image.FromStream(memoryStream);
            }
            this.Show();
            Cursor = Cursors.Cross;
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
            if (selectWidth > 0)
            {

                Rectangle rect = new(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new(picCaptureScreen.Image, picCaptureScreen.Width, picCaptureScreen.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new(selectWidth, selectHeight);
                //create graphic variable
                Graphics g = Graphics.FromImage(_img);
                //set graphic attributes
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                //insert image stream into clipboard
                Clipboard.SetImage(_img);
            }
            //End application
            this.Hide();
            frmAdjustImage frmAdjustImage = new();
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
    }
}