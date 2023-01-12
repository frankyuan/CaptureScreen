using System.Drawing.Drawing2D;

namespace CaptureScreen
{
    public enum ColorPickerMode
    {
        LineColor,
        BackgroundColor
    }

    public enum ActionMode
    {
        CleanArea,
        DrawLine,
        DrawRect,
        DrawArrow,
        DrawStraightLine,
        Unknown
    }

    public partial class frmAdjustImage : Form
    {
        private static int LineWidth = 3;
        private static int ArrowLong = 4;
        private static int ArrowShort = 1;
        private ActionMode currentActionMode = ActionMode.CleanArea;
        private ColorPickerMode currentColorPickerMode = ColorPickerMode.BackgroundColor;
        private Stack<Image> imageHistory = new();
        private List<Button> actionButtons = new();

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
                if (currentActionMode != ActionMode.DrawLine)
                {
                    imageHistory.Push(currentImage);
                    RefreshUndoStatus();
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
            InitActionButtons();
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
            btnClearArea_Click(sender, e);
            InitColorPickerStyle();
        }

        private void InitActionButtons()
        {
            actionButtons.Add(btnClearArea);
            actionButtons.Add(btnDrawLine);
            actionButtons.Add(btnDrawRect);
            actionButtons.Add(btnDrawArrow);
            actionButtons.Add(btnDrawStraightLine);
        }

        private void picCapturedImage_MouseDown(object sender, MouseEventArgs e)
        {
            switch (currentActionMode)
            {
                case ActionMode.CleanArea:
                    ClearArea_MouseDown(e);
                    break;
                case ActionMode.DrawLine:
                    DrawLine_MouseDown(e);
                    break;
                case ActionMode.DrawRect:
                    DrawRect_MouseDown(e);
                    break;
                case ActionMode.DrawArrow:
                    DrowArrow_MouseDown(e);
                    break;
                case ActionMode.DrawStraightLine:
                    DrowStraightLine_MouseDown(e);
                    break;
                case ActionMode.Unknown:
                    break;
                default:
                    break;
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
                var tmpCurrentMode = currentActionMode;
                currentActionMode = ActionMode.Unknown;
                CurrentImage = picCapturedImage.Image;
                currentActionMode = tmpCurrentMode;
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
                    using GraphicsPath capPath = new();
                    // TODO: A triangle, need refactor
                    capPath.AddLine(-1 * ArrowShort, ArrowLong * -1, ArrowShort, ArrowLong * -1);
                    capPath.AddLine(-1 * ArrowShort, ArrowLong * -1, 0, 0);
                    capPath.AddLine(0, 0, ArrowShort, ArrowLong * -1);
                    selectPen.CustomStartCap = new CustomLineCap(null, capPath);
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
                    g.DrawLine(selectPen, e.X, e.Y, selectX, selectY);
                    CurrentImage = _img;
                    picCapturedImage.Image = CurrentImage;
                }

                start = false;
            }
        }

        private void DrowStraightLine_MouseDown(MouseEventArgs e)
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
                    g.DrawLine(selectPen, e.X, e.Y, selectX, selectY);
                    CurrentImage = _img;
                    picCapturedImage.Image = CurrentImage;
                }

                start = false;
            }
        }

        private void picCapturedImage_MouseMove(object sender, MouseEventArgs e)
        {
            switch (currentActionMode)
            {
                case ActionMode.CleanArea:
                ClearArea_MouseMove(e);
                    break;
                case ActionMode.DrawLine:
                DrawLine_MouseMove(e);
                    break;
                case ActionMode.DrawRect:
                DrawRect_MouseMove(e);
                    break;
                case ActionMode.DrawArrow:
                DrawArrow_MouseMove(e);
                    break;
                case ActionMode.DrawStraightLine:
                DrawStraightLine_MouseMove(e);
                    break;
                case ActionMode.Unknown:
                    break;
                default:
                    break;
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

        private void DrawStraightLine_MouseMove(MouseEventArgs e)
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
            RefreshUndoStatus();
        }

        private void picRed_Click(object sender, EventArgs e)
        {
            SaveSpecificColor(picRed.BackColor);
        }

        private void picGreen_Click(object sender, EventArgs e)
        {
            SaveSpecificColor(picGreen.BackColor);
        }

        private void picWhite_Click(object sender, EventArgs e)
        {
            SaveSpecificColor(picWhite.BackColor);
        }

        private void picLame_Click(object sender, EventArgs e)
        {
            SaveSpecificColor(picLime.BackColor);
        }

        private void SaveSpecificColor(Color color)
        {
            if (currentColorPickerMode == ColorPickerMode.BackgroundColor)
            {
                picBackGround.BackColor = color;
                SaveBackColor();
            }

            if (currentColorPickerMode == ColorPickerMode.LineColor)
            {
                picLineColor.BackColor = color;
                SaveLineColor();
            }
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
            ResetEditModeStyle();
            currentActionMode = ActionMode.CleanArea;
            btnClearArea.FlatStyle = FlatStyle.Popup;
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            ResetEditModeStyle();
            currentActionMode = ActionMode.DrawLine;
            btnDrawLine.FlatStyle = FlatStyle.Popup;
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            ResetEditModeStyle();
            currentActionMode = ActionMode.DrawRect;
            btnDrawRect.FlatStyle = FlatStyle.Popup;
        }

        private void btnDrawArrow_Click(object sender, EventArgs e)
        {
            ResetEditModeStyle();
            currentActionMode = ActionMode.DrawArrow;
            btnDrawArrow.FlatStyle = FlatStyle.Popup;
        }

        private void btnDrawStraightLine_Click(object sender, EventArgs e)
        {
            ResetEditModeStyle();
            currentActionMode = ActionMode.DrawStraightLine;
            btnDrawStraightLine.FlatStyle = FlatStyle.Popup;
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            SetBackgroundColor();
        }

        private void SetBackgroundColor()
        {
            var result = colorDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (currentColorPickerMode == ColorPickerMode.BackgroundColor)
                {
                    picBackGround.BackColor = colorDialog.Color;
                    SaveBackColor();
                }

                if (currentColorPickerMode == ColorPickerMode.LineColor)
                {
                    picLineColor.BackColor = colorDialog.Color;
                    SaveLineColor();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = $"Untitled-{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}";
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                picCapturedImage.Image.Save(saveFileDialog1.FileName);
                Application.Exit();
            }
        }

        private void picLineColor_Click(object sender, EventArgs e)
        {
            ResetColorPickerModeStyle();
            currentColorPickerMode = ColorPickerMode.LineColor;
            SetColorPickerModeStyle();
        }

        private void picBackGround_Click(object sender, EventArgs e)
        {
            ResetColorPickerModeStyle();
            currentColorPickerMode = ColorPickerMode.BackgroundColor;
            SetColorPickerModeStyle();
        }

        private void ResetEditModeStyle()
        {
            foreach (var btn in actionButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
            }
        }

        private void InitColorPickerStyle()
        {
            ResetColorPickerModeStyle();
            SetColorPickerModeStyle();
        }

        private void ResetColorPickerModeStyle()
        {
            picBackGround.BorderStyle = BorderStyle.None;
            picLineColor.BorderStyle = BorderStyle.None;
        }

        private void SetColorPickerModeStyle()
        {
            if (currentColorPickerMode == ColorPickerMode.BackgroundColor)
            {
                picBackGround.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                picLineColor.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void RefreshUndoStatus()
        {
            btnUndo.Enabled = imageHistory.Count > 1;
        }

        private Pen CreatePen =>
            new(picLineColor.BackColor, LineWidth)
            {
                DashStyle = DashStyle.Solid
            };

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
