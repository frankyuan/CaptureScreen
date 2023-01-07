using System.Drawing.Drawing2D;

namespace CaptureScreen
{
    public partial class frmAdjustImage : Form
    {
        //These variables control the mouse position
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;
        public Image currentImage;

        //This variable control when you start the right click
        bool start = false;

        public frmAdjustImage()
        {
            InitializeComponent();
        }

        private void frmAdjustImage_Load(object sender, EventArgs e)
        {
            currentImage = Clipboard.GetImage();
            picCapturedImage.Image = currentImage;
            var lastBackground = Properties.Settings.Default;
            picBackGround.BackColor = Color.FromArgb(
                int.Parse(lastBackground.BackgroundColorR),
                int.Parse(lastBackground.BackgroundColorG),
                int.Parse(lastBackground.BackgroundColorB));
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picBackGround.BackColor = colorDialog.Color;
            }
        }

        private void picCapturedImage_MouseDown(object sender, MouseEventArgs e)
        {
            //validate when user right-click
            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //starts coordinates for rectangle
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 1)
                    {
                        DashStyle = DashStyle.Solid
                    };
                }
                picCapturedImage.Refresh();
                //start control variable for draw rectangle
                start = true;
            }
            else
            {
                //validate if there is image
                if (picCapturedImage.Image == null)
                    return;
                //same functionality when mouse is over
                if (e.Button == MouseButtons.Left)
                {
                    picCapturedImage.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    var location = new PointF() { X = selectX, Y = selectY };
                    var size = new SizeF() { Width = selectWidth, Height = selectHeight };
                    var rectFToFill = new RectangleF(location, size);
                    Bitmap _img = new(currentImage);
                    using Graphics g = Graphics.FromImage(_img);
                    SolidBrush shadowBrush = new(picBackGround.BackColor);
                    g.FillRectangles(shadowBrush, new RectangleF[] { rectFToFill });
                    Clipboard.SetImage(_img);
                    Application.Exit();
                }
                start = false;
            }
        }

        private void picCapturedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (picCapturedImage.Image == null)
                return;

            if (start)
            {
                picCapturedImage.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                picCapturedImage.CreateGraphics().DrawRectangle(
                    selectPen,
                    selectX,
                    selectY,
                    selectWidth,
                    selectHeight);
            }
        }

        private void picGreen_Click(object sender, EventArgs e)
        {
            picBackGround.BackColor = picGreen.BackColor;
            SaveBackColor();
        }

        private void picWhite_Click(object sender, EventArgs e)
        {
            picBackGround.BackColor = picWhite.BackColor;
            SaveBackColor();
        }

        private void SaveBackColor()
        {
            var lastBackground = Properties.Settings.Default;
            lastBackground.BackgroundColorR = picBackGround.BackColor.R.ToString();
            lastBackground.BackgroundColorG = picBackGround.BackColor.G.ToString();
            lastBackground.BackgroundColorB = picBackGround.BackColor.B.ToString();
            Properties.Settings.Default.Save();
        }

        private void btnSaveToClip_Click(object sender, EventArgs e)
        {
            SaveOriginImageAndExit();
        }

        private void frmAdjustImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SaveOriginImageAndExit();
            }
        }

        private void SaveOriginImageAndExit()
        {
            Clipboard.SetImage(currentImage);
            Application.Exit();
        }

        private void frmAdjustImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
