namespace CaptureScreen
{
    partial class frmAdjustImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdjustImage));
            picCapturedImage = new PictureBox();
            colorDialog = new ColorDialog();
            picBackGround = new PictureBox();
            picWhite = new PictureBox();
            picGreen = new PictureBox();
            btnClearArea = new Button();
            btnDrawLine = new Button();
            groupBox1 = new GroupBox();
            picGreen2 = new PictureBox();
            picSkyBlue = new PictureBox();
            picSepia = new PictureBox();
            picYellow = new PictureBox();
            picLime = new PictureBox();
            picLineColor = new PictureBox();
            picRed = new PictureBox();
            btnColorPicker = new Button();
            btnSaveToClip = new Button();
            btnDrawRect = new Button();
            btnUndo = new Button();
            btnSave = new Button();
            saveFileDialog1 = new SaveFileDialog();
            btnDrawArrow = new Button();
            btnExit = new Button();
            btnDrawStraightLine = new Button();
            btnHighLighter = new Button();
            btnCutArea = new Button();
            btnSelectArea = new Button();
            btnOpenPaint = new Button();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)picCapturedImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBackGround).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picWhite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picGreen).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picGreen2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSkyBlue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSepia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLineColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picRed).BeginInit();
            SuspendLayout();
            // 
            // picCapturedImage
            // 
            picCapturedImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picCapturedImage.BackColor = Color.White;
            picCapturedImage.BorderStyle = BorderStyle.FixedSingle;
            picCapturedImage.Location = new Point(-2, 151);
            picCapturedImage.Margin = new Padding(6);
            picCapturedImage.Name = "picCapturedImage";
            picCapturedImage.Size = new Size(2810, 1446);
            picCapturedImage.TabIndex = 0;
            picCapturedImage.TabStop = false;
            picCapturedImage.MouseDown += picCapturedImage_MouseDown;
            picCapturedImage.MouseEnter += picCapturedImage_MouseEnter;
            picCapturedImage.MouseLeave += picCapturedImage_MouseLeave;
            picCapturedImage.MouseMove += picCapturedImage_MouseMove;
            picCapturedImage.MouseUp += picCapturedImage_MouseUp;
            // 
            // picBackGround
            // 
            picBackGround.BackColor = Color.White;
            picBackGround.Location = new Point(45, 75);
            picBackGround.Margin = new Padding(6);
            picBackGround.Name = "picBackGround";
            picBackGround.Size = new Size(56, 64);
            picBackGround.TabIndex = 1;
            picBackGround.TabStop = false;
            picBackGround.Click += picBackGround_Click;
            // 
            // picWhite
            // 
            picWhite.BackColor = Color.White;
            picWhite.BorderStyle = BorderStyle.Fixed3D;
            picWhite.Location = new Point(228, 87);
            picWhite.Margin = new Padding(6);
            picWhite.Name = "picWhite";
            picWhite.Size = new Size(41, 47);
            picWhite.TabIndex = 3;
            picWhite.TabStop = false;
            picWhite.Click += picWhite_Click;
            // 
            // picGreen
            // 
            picGreen.BackColor = Color.FromArgb(219, 238, 221);
            picGreen.BorderStyle = BorderStyle.Fixed3D;
            picGreen.Location = new Point(271, 87);
            picGreen.Margin = new Padding(6);
            picGreen.Name = "picGreen";
            picGreen.Size = new Size(41, 47);
            picGreen.TabIndex = 4;
            picGreen.TabStop = false;
            picGreen.Click += picGreen_Click;
            // 
            // btnClearArea
            // 
            btnClearArea.FlatAppearance.BorderSize = 0;
            btnClearArea.FlatStyle = FlatStyle.Flat;
            btnClearArea.Image = (Image)resources.GetObject("btnClearArea.Image");
            btnClearArea.Location = new Point(524, 26);
            btnClearArea.Margin = new Padding(6);
            btnClearArea.Name = "btnClearArea";
            btnClearArea.Size = new Size(89, 102);
            btnClearArea.TabIndex = 4;
            btnClearArea.UseVisualStyleBackColor = false;
            btnClearArea.Click += btnClearArea_Click;
            // 
            // btnDrawLine
            // 
            btnDrawLine.FlatAppearance.BorderSize = 0;
            btnDrawLine.FlatStyle = FlatStyle.Flat;
            btnDrawLine.Image = (Image)resources.GetObject("btnDrawLine.Image");
            btnDrawLine.Location = new Point(323, 26);
            btnDrawLine.Margin = new Padding(6);
            btnDrawLine.Name = "btnDrawLine";
            btnDrawLine.Size = new Size(89, 102);
            btnDrawLine.TabIndex = 2;
            btnDrawLine.UseVisualStyleBackColor = true;
            btnDrawLine.Click += btnDrawLine_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picGreen2);
            groupBox1.Controls.Add(picSkyBlue);
            groupBox1.Controls.Add(picSepia);
            groupBox1.Controls.Add(picYellow);
            groupBox1.Controls.Add(picLime);
            groupBox1.Controls.Add(picLineColor);
            groupBox1.Controls.Add(picRed);
            groupBox1.Controls.Add(btnColorPicker);
            groupBox1.Controls.Add(picWhite);
            groupBox1.Controls.Add(picGreen);
            groupBox1.Controls.Add(picBackGround);
            groupBox1.Location = new Point(873, -9);
            groupBox1.Margin = new Padding(6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6);
            groupBox1.Size = new Size(438, 151);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // picGreen2
            // 
            picGreen2.BackColor = Color.FromArgb(247, 247, 248);
            picGreen2.BorderStyle = BorderStyle.Fixed3D;
            picGreen2.Location = new Point(362, 85);
            picGreen2.Margin = new Padding(6);
            picGreen2.Name = "picGreen2";
            picGreen2.Size = new Size(41, 47);
            picGreen2.TabIndex = 106;
            picGreen2.TabStop = false;
            picGreen2.Click += picGreen2_Click;
            // 
            // picSkyBlue
            // 
            picSkyBlue.BackColor = Color.SkyBlue;
            picSkyBlue.BorderStyle = BorderStyle.Fixed3D;
            picSkyBlue.Location = new Point(362, 36);
            picSkyBlue.Margin = new Padding(6);
            picSkyBlue.Name = "picSkyBlue";
            picSkyBlue.Size = new Size(41, 47);
            picSkyBlue.TabIndex = 105;
            picSkyBlue.TabStop = false;
            picSkyBlue.Click += picSkyBlue_Click;
            // 
            // picSepia
            // 
            picSepia.BackColor = Color.FromArgb(251, 240, 217);
            picSepia.BorderStyle = BorderStyle.Fixed3D;
            picSepia.Location = new Point(316, 87);
            picSepia.Margin = new Padding(6);
            picSepia.Name = "picSepia";
            picSepia.Size = new Size(41, 47);
            picSepia.TabIndex = 104;
            picSepia.TabStop = false;
            picSepia.Click += picSepia_Click;
            // 
            // picYellow
            // 
            picYellow.BackColor = Color.Yellow;
            picYellow.BorderStyle = BorderStyle.Fixed3D;
            picYellow.Location = new Point(316, 36);
            picYellow.Margin = new Padding(6);
            picYellow.Name = "picYellow";
            picYellow.Size = new Size(41, 47);
            picYellow.TabIndex = 103;
            picYellow.TabStop = false;
            picYellow.Click += picYellow_Click;
            // 
            // picLime
            // 
            picLime.BackColor = Color.Lime;
            picLime.BorderStyle = BorderStyle.Fixed3D;
            picLime.Location = new Point(271, 36);
            picLime.Margin = new Padding(6);
            picLime.Name = "picLime";
            picLime.Size = new Size(41, 47);
            picLime.TabIndex = 13;
            picLime.TabStop = false;
            picLime.Click += picLame_Click;
            // 
            // picLineColor
            // 
            picLineColor.BackColor = Color.Red;
            picLineColor.Location = new Point(11, 34);
            picLineColor.Margin = new Padding(6);
            picLineColor.Name = "picLineColor";
            picLineColor.Size = new Size(56, 64);
            picLineColor.TabIndex = 10;
            picLineColor.TabStop = false;
            picLineColor.Click += picLineColor_Click;
            // 
            // picRed
            // 
            picRed.BackColor = Color.Red;
            picRed.BorderStyle = BorderStyle.Fixed3D;
            picRed.Location = new Point(228, 36);
            picRed.Margin = new Padding(6);
            picRed.Name = "picRed";
            picRed.Size = new Size(41, 47);
            picRed.TabIndex = 12;
            picRed.TabStop = false;
            picRed.Click += picRed_Click;
            // 
            // btnColorPicker
            // 
            btnColorPicker.FlatAppearance.BorderSize = 0;
            btnColorPicker.FlatStyle = FlatStyle.Flat;
            btnColorPicker.Image = (Image)resources.GetObject("btnColorPicker.Image");
            btnColorPicker.Location = new Point(111, 34);
            btnColorPicker.Margin = new Padding(6);
            btnColorPicker.Name = "btnColorPicker";
            btnColorPicker.Size = new Size(89, 102);
            btnColorPicker.TabIndex = 5;
            btnColorPicker.UseVisualStyleBackColor = true;
            btnColorPicker.Click += btnColorPicker_Click;
            // 
            // btnSaveToClip
            // 
            btnSaveToClip.FlatAppearance.BorderSize = 0;
            btnSaveToClip.FlatStyle = FlatStyle.Flat;
            btnSaveToClip.Image = (Image)resources.GetObject("btnSaveToClip.Image");
            btnSaveToClip.Location = new Point(1454, 28);
            btnSaveToClip.Margin = new Padding(6);
            btnSaveToClip.Name = "btnSaveToClip";
            btnSaveToClip.Size = new Size(89, 102);
            btnSaveToClip.TabIndex = 0;
            btnSaveToClip.UseVisualStyleBackColor = true;
            btnSaveToClip.Click += btnSaveToClip_Click;
            // 
            // btnDrawRect
            // 
            btnDrawRect.FlatAppearance.BorderSize = 0;
            btnDrawRect.FlatStyle = FlatStyle.Flat;
            btnDrawRect.Image = (Image)resources.GetObject("btnDrawRect.Image");
            btnDrawRect.Location = new Point(22, 28);
            btnDrawRect.Margin = new Padding(6);
            btnDrawRect.Name = "btnDrawRect";
            btnDrawRect.Size = new Size(89, 102);
            btnDrawRect.TabIndex = 1;
            btnDrawRect.UseVisualStyleBackColor = true;
            btnDrawRect.Click += btnDrawRect_Click;
            // 
            // btnUndo
            // 
            btnUndo.FlatAppearance.BorderSize = 0;
            btnUndo.FlatStyle = FlatStyle.Flat;
            btnUndo.Image = (Image)resources.GetObject("btnUndo.Image");
            btnUndo.Location = new Point(1354, 28);
            btnUndo.Margin = new Padding(6);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(89, 102);
            btnUndo.TabIndex = 100;
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnSave
            // 
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(1554, 28);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 102);
            btnSave.TabIndex = 8;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDrawArrow
            // 
            btnDrawArrow.FlatAppearance.BorderSize = 0;
            btnDrawArrow.FlatStyle = FlatStyle.Flat;
            btnDrawArrow.Image = (Image)resources.GetObject("btnDrawArrow.Image");
            btnDrawArrow.Location = new Point(223, 28);
            btnDrawArrow.Margin = new Padding(6);
            btnDrawArrow.Name = "btnDrawArrow";
            btnDrawArrow.Size = new Size(89, 102);
            btnDrawArrow.TabIndex = 3;
            btnDrawArrow.UseVisualStyleBackColor = true;
            btnDrawArrow.Click += btnDrawArrow_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.Location = new Point(2695, 28);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(89, 102);
            btnExit.TabIndex = 101;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnDrawStraightLine
            // 
            btnDrawStraightLine.FlatAppearance.BorderSize = 0;
            btnDrawStraightLine.FlatStyle = FlatStyle.Flat;
            btnDrawStraightLine.Image = (Image)resources.GetObject("btnDrawStraightLine.Image");
            btnDrawStraightLine.Location = new Point(123, 26);
            btnDrawStraightLine.Margin = new Padding(6);
            btnDrawStraightLine.Name = "btnDrawStraightLine";
            btnDrawStraightLine.Size = new Size(89, 102);
            btnDrawStraightLine.TabIndex = 102;
            btnDrawStraightLine.UseVisualStyleBackColor = true;
            btnDrawStraightLine.Click += btnDrawStraightLine_Click;
            // 
            // btnHighLighter
            // 
            btnHighLighter.FlatAppearance.BorderSize = 0;
            btnHighLighter.FlatStyle = FlatStyle.Flat;
            btnHighLighter.Image = (Image)resources.GetObject("btnHighLighter.Image");
            btnHighLighter.Location = new Point(423, 26);
            btnHighLighter.Margin = new Padding(6);
            btnHighLighter.Name = "btnHighLighter";
            btnHighLighter.Size = new Size(89, 102);
            btnHighLighter.TabIndex = 103;
            btnHighLighter.UseVisualStyleBackColor = true;
            btnHighLighter.Click += btnHighLighter_Click;
            // 
            // btnCutArea
            // 
            btnCutArea.FlatAppearance.BorderSize = 0;
            btnCutArea.FlatStyle = FlatStyle.Flat;
            btnCutArea.Image = (Image)resources.GetObject("btnCutArea.Image");
            btnCutArea.Location = new Point(624, 26);
            btnCutArea.Margin = new Padding(6);
            btnCutArea.Name = "btnCutArea";
            btnCutArea.Size = new Size(89, 102);
            btnCutArea.TabIndex = 104;
            btnCutArea.UseVisualStyleBackColor = false;
            btnCutArea.Click += btnCutArea_Click;
            // 
            // btnSelectArea
            // 
            btnSelectArea.FlatAppearance.BorderSize = 0;
            btnSelectArea.FlatStyle = FlatStyle.Flat;
            btnSelectArea.Image = (Image)resources.GetObject("btnSelectArea.Image");
            btnSelectArea.Location = new Point(724, 26);
            btnSelectArea.Margin = new Padding(6);
            btnSelectArea.Name = "btnSelectArea";
            btnSelectArea.Size = new Size(89, 102);
            btnSelectArea.TabIndex = 105;
            btnSelectArea.UseVisualStyleBackColor = false;
            btnSelectArea.Click += btnSelectArea_Click;
            // 
            // btnOpenPaint
            // 
            btnOpenPaint.FlatAppearance.BorderSize = 0;
            btnOpenPaint.FlatStyle = FlatStyle.Flat;
            btnOpenPaint.Image = (Image)resources.GetObject("btnOpenPaint.Image");
            btnOpenPaint.Location = new Point(1655, 26);
            btnOpenPaint.Margin = new Padding(6);
            btnOpenPaint.Name = "btnOpenPaint";
            btnOpenPaint.Size = new Size(89, 102);
            btnOpenPaint.TabIndex = 106;
            btnOpenPaint.UseVisualStyleBackColor = true;
            btnOpenPaint.Click += btnOpenPaint_Click;
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Image = (Image)resources.GetObject("btnReturn.Image");
            btnReturn.Location = new Point(2594, 28);
            btnReturn.Margin = new Padding(6);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(89, 102);
            btnReturn.TabIndex = 107;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // frmAdjustImage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2806, 1591);
            Controls.Add(btnReturn);
            Controls.Add(btnOpenPaint);
            Controls.Add(btnSelectArea);
            Controls.Add(btnCutArea);
            Controls.Add(btnHighLighter);
            Controls.Add(btnDrawStraightLine);
            Controls.Add(btnExit);
            Controls.Add(btnDrawArrow);
            Controls.Add(btnSave);
            Controls.Add(btnUndo);
            Controls.Add(btnDrawRect);
            Controls.Add(btnSaveToClip);
            Controls.Add(groupBox1);
            Controls.Add(btnDrawLine);
            Controls.Add(btnClearArea);
            Controls.Add(picCapturedImage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(6);
            MinimizeBox = false;
            Name = "frmAdjustImage";
            Text = "Capture Screen";
            WindowState = FormWindowState.Maximized;
            Load += frmAdjustImage_Load;
            KeyDown += frmAdjustImage_KeyDown;
            PreviewKeyDown += frmAdjustImage_PreviewKeyDown;
            ((System.ComponentModel.ISupportInitialize)picCapturedImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBackGround).EndInit();
            ((System.ComponentModel.ISupportInitialize)picWhite).EndInit();
            ((System.ComponentModel.ISupportInitialize)picGreen).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picGreen2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSkyBlue).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSepia).EndInit();
            ((System.ComponentModel.ISupportInitialize)picYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLime).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLineColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)picRed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picCapturedImage;
        private ColorDialog colorDialog;
        private PictureBox picBackGround;
        private PictureBox picWhite;
        private PictureBox picGreen;
        private Button btnClearArea;
        private Button btnDrawLine;
        private GroupBox groupBox1;
        private Button btnSaveToClip;
        private Button btnDrawRect;
        private PictureBox picLineColor;
        private PictureBox picRed;
        private Button btnColorPicker;
        private Button btnUndo;
        private Button btnSave;
        private SaveFileDialog saveFileDialog1;
        private Button btnDrawArrow;
        private Button btnExit;
        private PictureBox picLime;
        private Button btnDrawStraightLine;
        private PictureBox picSepia;
        private PictureBox picYellow;
        private Button btnHighLighter;
        private PictureBox picGreen2;
        private PictureBox picSkyBlue;
        private Button btnCutArea;
        private Button btnSelectArea;
        private Button btnOpenPaint;
        private Button btnReturn;
    }
}