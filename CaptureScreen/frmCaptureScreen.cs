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
            //Hide the Form
            this.Hide();
            //Create the Bitmap
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height);
            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            //Copy Image from the screen
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //Create a temporal memory stream for the image
            using (MemoryStream s = new MemoryStream())
            {
                //save graphic variable into memory
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new Size(this.Width, this.Height);
                //set the picture box with temporary stream
                pictureBox1.Image = Image.FromStream(s);
            }
            //Show Form
            this.Show();
            //Cross Cursor
            Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (pictureBox1.Image == null)
                return;
            //validate if right-click was trigger
            if (start)
            {
                //refresh picture box
                pictureBox1.Refresh();
                //set corner square to mouse coordinates
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                //draw dotted rectangle
                pictureBox1.CreateGraphics().DrawRectangle(selectPen,
                          selectX, selectY, selectWidth, selectHeight);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //validate when user right-click
            if (!start)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 1);
                    selectPen.DashStyle = DashStyle.Solid;
                }
                //refresh picture box
                pictureBox1.Refresh();
                //start control variable for draw rectangle
                start = true;
            }
            else
            {
                //validate if there is image
                if (pictureBox1.Image == null)
                    return;
                //same functionality when mouse is over
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pictureBox1.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    pictureBox1.CreateGraphics().DrawRectangle(selectPen, selectX,
                             selectY, selectWidth, selectHeight);

                }
                start = false;
                //function save image to clipboard
                SaveToClipboard();
            }
        }

        private void SaveToClipboard()
        {
            //validate if something selected
            if (selectWidth > 0)
            {

                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
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
    }
}