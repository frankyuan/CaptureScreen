using System.Drawing.Drawing2D;

namespace CaptureScreen
{
    public enum EditMode
    {
        CleanArea,
        DrawLine,
        DrawRect,
        Unknown
    }

    public partial class frmAdjustImage : Form
    {
        private EditMode currentMode = EditMode.CleanArea;
        private static readonly Color FocusColor = SystemColors.Info;
        private Stack<Image> imageHistory = new Stack<Image>();

        #region These variables control the mouse position other than draw line
        private int selectX;
        private int selectY;
        private int selectWidth;
        private int selectHeight;
        private Pen selectPen;
        #endregion

        #region Variables which control status when drawing line
        private Point lastPoint = Point.Empty;
        #endregion
        private Image originalImage;
        private Image currentImage;

        bool start = false;

        public Image CurrentImage
        {
            get => currentImage;
            set 
            {
                currentImage = value;
                if (currentMode != EditMode.DrawLine)
                {
                    imageHistory.Push(currentImage);
                }
            }
        }

        public frmAdjustImage()
        {
            InitializeComponent();
        }

        private void frmAdjustImage_Load(object sender, EventArgs e)
        {
            originalImage = Clipboard.GetImage();
            CurrentImage = originalImage;
            picCapturedImage.Image = CurrentImage;

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

            if (currentMode == EditMode.DrawLine)
            {
                DrawLine_MouseDown(e);
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
                    var location = new PointF() { X = Math.Min(selectX, e.X), Y = Math.Min(selectY, e.Y) };
                    var size = new SizeF() { Width = Math.Abs(selectWidth), Height = Math.Abs(selectHeight) };
                    var rectFToFill = new RectangleF(location, size);
                    Bitmap _img = new(CurrentImage);
                    using Graphics g = Graphics.FromImage(_img);
                    SolidBrush shadowBrush = new(picBackGround.BackColor);
                    g.FillRectangles(shadowBrush, new RectangleF[] { rectFToFill });
                    CurrentImage = _img;
                    picCapturedImage.Image = CurrentImage;
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
                    selectPen = new Pen(picLineColor.BackColor, 1)
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
                    Bitmap _img = new(CurrentImage);
                    using Graphics g = Graphics.FromImage(_img);
                    g.DrawRectangle(
                        selectPen,
                        Math.Min(selectX, e.X),
                        Math.Min(selectY, e.Y),
                        Math.Abs(selectWidth),
                        Math.Abs(selectHeight));
                    CurrentImage = _img;
                    picCapturedImage.Image = CurrentImage;
                }
                start = false;
            }
        }

        private void DrawLine_MouseDown(MouseEventArgs e)
        {
            if (!start)
            {
                lastPoint = e.Location;
                start = true;
                selectPen = new Pen(picLineColor.BackColor, 5)
                {
                    DashStyle = DashStyle.Solid
                };
            }
            else
            {
                start = false;
                lastPoint = Point.Empty;
                var tmpCurrentMode = currentMode;
                currentMode = EditMode.Unknown;
                CurrentImage = picCapturedImage.Image;
                currentMode = tmpCurrentMode;
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

            if (currentMode == EditMode.DrawLine)
            {
                DrawLine_MouseMove(e);
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
                    Math.Min(selectX, e.X),
                    Math.Min(selectY, e.Y),
                    Math.Abs(selectWidth),
                    Math.Abs(selectHeight));
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
                    Math.Min(selectX, e.X),
                    Math.Min(selectY, e.Y),
                    Math.Abs(selectWidth),
                    Math.Abs(selectHeight));
            }
        }

        private void DrawLine_MouseMove(MouseEventArgs e)
        {
            if (!start || lastPoint == Point.Empty || CurrentImage == null)
            {
                return;
            }

            Bitmap _img = new(CurrentImage);
            using Graphics g = Graphics.FromImage(_img);
            g.DrawLine(selectPen, lastPoint, e.Location);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            picCapturedImage.Invalidate();
            lastPoint = e.Location;
            CurrentImage = _img;
            picCapturedImage.Image = CurrentImage;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (imageHistory.Count == 1)
            {
                return;
            }

            imageHistory.Pop();
            currentImage = imageHistory.Peek();
            picCapturedImage.Image = currentImage;
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
            Clipboard.SetImage(CurrentImage);
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

        private void btnLineColorPicker_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picLineColor.BackColor = colorDialog.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                picCapturedImage.Image.Save(saveFileDialog1.FileName);
                Application.Exit();
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
