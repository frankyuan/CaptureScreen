﻿using System.Drawing.Drawing2D;

namespace CaptureScreen
{
    public enum EditMode
    {
        CleanArea,
        DrawLine,
        DrawRect,
        DrawArrow,
        Unknown
    }

    public partial class frmAdjustImage : Form
    {
        private static int LineWidth = 3;
        private static int ArrowLong = 4;
        private static int ArrowShort = 1;
        private EditMode currentMode = EditMode.CleanArea;
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

        public frmAdjustImage(Image img)
        {
            InitializeComponent();
            originalImage = img;
        }

        private void frmAdjustImage_Load(object sender, EventArgs e)
        {
            CurrentImage = originalImage;
            picCapturedImage.Image = CurrentImage;

            saveFileDialog1.Filter = "Images (*.png,*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.AddExtension = true;
            var lastSetting = Properties.Settings.Default;
            picBackGround.BackColor = Color.FromArgb(
                int.Parse(lastSetting.BackgroundColorR),
                int.Parse(lastSetting.BackgroundColorG),
                int.Parse(lastSetting.BackgroundColorB));

            picLineColor.BackColor = Color.FromArgb(
                int.Parse(lastSetting.LineColorR),
                int.Parse(lastSetting.LineColorG),
                int.Parse(lastSetting.LineColorB));
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

            if (currentMode == EditMode.DrawArrow)
            {
                DrowArrow_MouseDown(e);
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
                    selectPen = new Pen(Color.Red, 2)
                    {
                        DashStyle = DashStyle.Dot
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
                    selectPen = CreatePen;
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
                selectPen = CreatePen;
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

        private void DrowArrow_MouseDown(MouseEventArgs e)
        {
            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = CreatePen;
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
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using var pen = CreatePen;
                    using (GraphicsPath capPath = new())
                    {
                        // A triangle
                        capPath.AddLine(-1 * ArrowShort, 0, ArrowShort, 0);
                        capPath.AddLine(-1 * ArrowShort, 0, 0, ArrowLong);
                        capPath.AddLine(0, ArrowLong, ArrowShort, 0);
                        pen.CustomEndCap = new CustomLineCap(null, capPath);
                        g.DrawLine(pen, selectX, selectY, e.X, e.Y);
                    }

                    CurrentImage = _img;
                    picCapturedImage.Image = CurrentImage;
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

            if (currentMode == EditMode.DrawLine)
            {
                DrawLine_MouseMove(e);
            }

            if (currentMode == EditMode.DrawArrow)
            {
                DrawArrow_MouseMove(e);
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
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(selectPen, lastPoint, e.Location);
            picCapturedImage.Invalidate();
            lastPoint = e.Location;
            CurrentImage = _img;
            picCapturedImage.Image = CurrentImage;
        }

        private void DrawArrow_MouseMove(MouseEventArgs e)
        {
            if (picCapturedImage.Image == null)
            {
                return;
            }

            if (start)
            {
                picCapturedImage.Refresh();
                using Graphics g = picCapturedImage.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawLine(
                    selectPen,
                    new Point(e.X, e.Y),
                    new Point(selectX, selectY));
            }
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
            SaveLineColor();
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
            var lastSetting = Properties.Settings.Default;
            lastSetting.BackgroundColorR = picBackGround.BackColor.R.ToString();
            lastSetting.BackgroundColorG = picBackGround.BackColor.G.ToString();
            lastSetting.BackgroundColorB = picBackGround.BackColor.B.ToString();
            Properties.Settings.Default.Save();
        }

        private void SaveLineColor()
        {
            var lastSetting = Properties.Settings.Default;
            lastSetting.LineColorR = picLineColor.BackColor.R.ToString();
            lastSetting.LineColorG = picLineColor.BackColor.G.ToString();
            lastSetting.LineColorB = picLineColor.BackColor.B.ToString();
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
            this.btnClearArea.BackColor = Const.FocusColor;
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            this.currentMode = EditMode.DrawLine;
            this.btnDrawLine.BackColor = Const.FocusColor;
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            this.currentMode = EditMode.DrawRect;
            this.btnDrawRect.BackColor = Const.FocusColor;
        }

        private void btnDrawArrow_Click(object sender, EventArgs e)
        {
            ClearEditModeStyle();
            currentMode = EditMode.DrawArrow;
            btnDrawArrow.BackColor = Const.FocusColor;
        }

        private void btnBackColorPicker_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picBackGround.BackColor = colorDialog.Color;
                SaveBackColor();
            }
        }

        private void btnLineColorPicker_Click(object sender, EventArgs e)
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                picLineColor.BackColor = colorDialog.Color;
                SaveLineColor();
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
            btnClearArea.BackColor = BackColor;
            btnDrawLine.BackColor = BackColor;
            btnDrawRect.BackColor = BackColor;
            btnDrawArrow.BackColor = BackColor;
        }

        private Pen CreatePen =>
            new(picLineColor.BackColor, LineWidth)
            {
                DashStyle = DashStyle.Solid
            };
    }
}
