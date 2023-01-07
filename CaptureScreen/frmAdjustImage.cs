using System.Drawing.Drawing2D;

namespace CaptureScreen
{
    public enum EditMode
    {
        CleanArea,
        DrawLine,
        DrawRect
    }

    public partial class frmAdjustImage : Form
    {
        private EditMode currentMode = EditMode.CleanArea;
        private static readonly Color FocusColor = SystemColors.Info;

        //These variables control the mouse position
        private int selectX;
        private int selectY;
        private int selectWidth;
        private int selectHeight;
        private Pen selectPen;
        private Image originalImage;
        private Image currentImage;

        bool start = false;

        public frmAdjustImage()
        {
            InitializeComponent();
        }

        private void frmAdjustImage_Load(object sender, EventArgs e)
        {
            originalImage = Clipboard.GetImage();
            currentImage = originalImage;
            picCapturedImage.Image = currentImage;

            var lastBackground = Properties.Settings.Default;
            picBackGround.BackColor = Color.FromArgb(
                int.Parse(lastBackground.BackgroundColorR),
                int.Parse(lastBackground.BackgroundColorG),
                int.Parse(lastBackground.BackgroundColorB));

            this.btnClearArea_Click(sender, e);
        }

        private void picCapturedImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMode == EditMode.CleanArea)
            {
                ClearArea_MouseDown(e);
            }

            if (currentMode == EditMode.DrawRect)
            {
                DrawRect_MouseDown(e);
            }
        }

        private void ClearArea_MouseDown(MouseEventArgs e)
        {
            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 1)
                    {
                        DashStyle = DashStyle.Solid
                    };
                }
                picCapturedImage.Refresh();
                start = true;
            }
            else
            {
                if (picCapturedImage.Image == null)
                {
                    return;
                }

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
                    currentImage = _img;
                    picCapturedImage.Image = currentImage;
                }
                start = false;
            }
        }

        private void DrawRect_MouseDown(MouseEventArgs e)
        {
            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.Red, 1)
                    {
                        DashStyle = DashStyle.Solid
                    };
                }
                picCapturedImage.Refresh();
                start = true;
            }
            else
            {
                if (picCapturedImage.Image == null)
                {
                    return;
                }

                if (e.Button == MouseButtons.Left)
                {
                    picCapturedImage.Refresh();
                    selectWidth = e.X - selectX;
                    selectHeight = e.Y - selectY;
                    Bitmap _img = new(currentImage);
                    using Graphics g = Graphics.FromImage(_img);
                    g.DrawRectangle(
                        selectPen,
                        selectX,
                        selectY,
                        selectWidth,
                        selectHeight);
                    currentImage = _img;
                    picCapturedImage.Image = currentImage;
                }
                start = false;
            }
        }

        private void picCapturedImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMode == EditMode.CleanArea)
            {
                ClearArea_MouseMove(e);
            }

            if (currentMode == EditMode.DrawRect)
            {
                DrawRect_MouseMove(e);
            }
        }

        private void ClearArea_MouseMove(MouseEventArgs e)
        {
            if (picCapturedImage.Image == null)
            {
                return;
            }

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

        private void DrawRect_MouseMove(MouseEventArgs e)
        {
            if (picCapturedImage.Image == null)
            {
                return;
            }

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

        private void btnUndo_Click(object sender, EventArgs e)
        {
            picCapturedImage.Image = originalImage;
        }

        private void picRed_Click(object sender, EventArgs e)
        {
            picLineColor.BackColor = picRed.BackColor;
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

        private void btnClearArea_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            this.currentMode = EditMode.CleanArea;
            this.btnClearArea.BackColor = FocusColor;
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            this.currentMode = EditMode.DrawLine;
            this.btnDrawLine.BackColor = FocusColor;
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            this.currentMode = EditMode.DrawRect;
            this.btnDrawRect.BackColor = FocusColor;
        }

        private void btnBackColorPicker_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picBackGround.BackColor = colorDialog.Color;
            }
        }

        private void ClearEditModeStyle()
        {
            this.btnClearArea.BackColor = this.BackColor;
            this.btnDrawLine.BackColor = this.BackColor;
            this.btnDrawRect.BackColor = this.BackColor;
        }
    }
}
