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
            this.picCapturedImage = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.picBackGround = new System.Windows.Forms.PictureBox();
            this.picWhite = new System.Windows.Forms.PictureBox();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.btnClearArea = new System.Windows.Forms.Button();
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picSepia = new System.Windows.Forms.PictureBox();
            this.picYellow = new System.Windows.Forms.PictureBox();
            this.picLime = new System.Windows.Forms.PictureBox();
            this.picLineColor = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.btnSaveToClip = new System.Windows.Forms.Button();
            this.btnDrawRect = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnDrawArrow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDrawStraightLine = new System.Windows.Forms.Button();
            this.btnHighLighter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapturedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSepia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLineColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapturedImage
            // 
            this.picCapturedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCapturedImage.BackColor = System.Drawing.Color.White;
            this.picCapturedImage.Location = new System.Drawing.Point(-1, 71);
            this.picCapturedImage.Name = "picCapturedImage";
            this.picCapturedImage.Size = new System.Drawing.Size(1514, 679);
            this.picCapturedImage.TabIndex = 0;
            this.picCapturedImage.TabStop = false;
            this.picCapturedImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCapturedImage_MouseDown);
            this.picCapturedImage.MouseEnter += new System.EventHandler(this.picCapturedImage_MouseEnter);
            this.picCapturedImage.MouseLeave += new System.EventHandler(this.picCapturedImage_MouseLeave);
            this.picCapturedImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCapturedImage_MouseMove);
            this.picCapturedImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCapturedImage_MouseUp);
            // 
            // picBackGround
            // 
            this.picBackGround.BackColor = System.Drawing.Color.White;
            this.picBackGround.Location = new System.Drawing.Point(24, 35);
            this.picBackGround.Name = "picBackGround";
            this.picBackGround.Size = new System.Drawing.Size(30, 30);
            this.picBackGround.TabIndex = 1;
            this.picBackGround.TabStop = false;
            this.picBackGround.Click += new System.EventHandler(this.picBackGround_Click);
            // 
            // picWhite
            // 
            this.picWhite.BackColor = System.Drawing.Color.White;
            this.picWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picWhite.Location = new System.Drawing.Point(123, 41);
            this.picWhite.Name = "picWhite";
            this.picWhite.Size = new System.Drawing.Size(24, 24);
            this.picWhite.TabIndex = 3;
            this.picWhite.TabStop = false;
            this.picWhite.Click += new System.EventHandler(this.picWhite_Click);
            // 
            // picGreen
            // 
            this.picGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(238)))), ((int)(((byte)(221)))));
            this.picGreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGreen.Location = new System.Drawing.Point(146, 41);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(24, 24);
            this.picGreen.TabIndex = 4;
            this.picGreen.TabStop = false;
            this.picGreen.Click += new System.EventHandler(this.picGreen_Click);
            // 
            // btnClearArea
            // 
            this.btnClearArea.FlatAppearance.BorderSize = 0;
            this.btnClearArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearArea.Image = ((System.Drawing.Image)(resources.GetObject("btnClearArea.Image")));
            this.btnClearArea.Location = new System.Drawing.Point(282, 12);
            this.btnClearArea.Name = "btnClearArea";
            this.btnClearArea.Size = new System.Drawing.Size(48, 48);
            this.btnClearArea.TabIndex = 4;
            this.btnClearArea.UseVisualStyleBackColor = false;
            this.btnClearArea.Click += new System.EventHandler(this.btnClearArea_Click);
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.FlatAppearance.BorderSize = 0;
            this.btnDrawLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawLine.Image")));
            this.btnDrawLine.Location = new System.Drawing.Point(174, 12);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(48, 48);
            this.btnDrawLine.TabIndex = 2;
            this.btnDrawLine.UseVisualStyleBackColor = true;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picSepia);
            this.groupBox1.Controls.Add(this.picYellow);
            this.groupBox1.Controls.Add(this.picLime);
            this.groupBox1.Controls.Add(this.picLineColor);
            this.groupBox1.Controls.Add(this.picRed);
            this.groupBox1.Controls.Add(this.btnColorPicker);
            this.groupBox1.Controls.Add(this.picWhite);
            this.groupBox1.Controls.Add(this.picGreen);
            this.groupBox1.Controls.Add(this.picBackGround);
            this.groupBox1.Location = new System.Drawing.Point(358, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // picSepia
            // 
            this.picSepia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(240)))), ((int)(((byte)(217)))));
            this.picSepia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSepia.Location = new System.Drawing.Point(170, 41);
            this.picSepia.Name = "picSepia";
            this.picSepia.Size = new System.Drawing.Size(24, 24);
            this.picSepia.TabIndex = 104;
            this.picSepia.TabStop = false;
            this.picSepia.Click += new System.EventHandler(this.picSepia_Click);
            // 
            // picYellow
            // 
            this.picYellow.BackColor = System.Drawing.Color.Yellow;
            this.picYellow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picYellow.Location = new System.Drawing.Point(170, 17);
            this.picYellow.Name = "picYellow";
            this.picYellow.Size = new System.Drawing.Size(24, 24);
            this.picYellow.TabIndex = 103;
            this.picYellow.TabStop = false;
            this.picYellow.Click += new System.EventHandler(this.picYellow_Click);
            // 
            // picLime
            // 
            this.picLime.BackColor = System.Drawing.Color.Lime;
            this.picLime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picLime.Location = new System.Drawing.Point(146, 17);
            this.picLime.Name = "picLime";
            this.picLime.Size = new System.Drawing.Size(24, 24);
            this.picLime.TabIndex = 13;
            this.picLime.TabStop = false;
            this.picLime.Click += new System.EventHandler(this.picLame_Click);
            // 
            // picLineColor
            // 
            this.picLineColor.BackColor = System.Drawing.Color.Red;
            this.picLineColor.Location = new System.Drawing.Point(6, 16);
            this.picLineColor.Name = "picLineColor";
            this.picLineColor.Size = new System.Drawing.Size(30, 30);
            this.picLineColor.TabIndex = 10;
            this.picLineColor.TabStop = false;
            this.picLineColor.Click += new System.EventHandler(this.picLineColor_Click);
            // 
            // picRed
            // 
            this.picRed.BackColor = System.Drawing.Color.Red;
            this.picRed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picRed.Location = new System.Drawing.Point(123, 17);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(24, 24);
            this.picRed.TabIndex = 12;
            this.picRed.TabStop = false;
            this.picRed.Click += new System.EventHandler(this.picRed_Click);
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.FlatAppearance.BorderSize = 0;
            this.btnColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorPicker.Image = ((System.Drawing.Image)(resources.GetObject("btnColorPicker.Image")));
            this.btnColorPicker.Location = new System.Drawing.Point(60, 16);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(48, 48);
            this.btnColorPicker.TabIndex = 5;
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // btnSaveToClip
            // 
            this.btnSaveToClip.FlatAppearance.BorderSize = 0;
            this.btnSaveToClip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToClip.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveToClip.Image")));
            this.btnSaveToClip.Location = new System.Drawing.Point(641, 13);
            this.btnSaveToClip.Name = "btnSaveToClip";
            this.btnSaveToClip.Size = new System.Drawing.Size(48, 48);
            this.btnSaveToClip.TabIndex = 0;
            this.btnSaveToClip.UseVisualStyleBackColor = true;
            this.btnSaveToClip.Click += new System.EventHandler(this.btnSaveToClip_Click);
            // 
            // btnDrawRect
            // 
            this.btnDrawRect.FlatAppearance.BorderSize = 0;
            this.btnDrawRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawRect.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawRect.Image")));
            this.btnDrawRect.Location = new System.Drawing.Point(12, 13);
            this.btnDrawRect.Name = "btnDrawRect";
            this.btnDrawRect.Size = new System.Drawing.Size(48, 48);
            this.btnDrawRect.TabIndex = 1;
            this.btnDrawRect.UseVisualStyleBackColor = true;
            this.btnDrawRect.Click += new System.EventHandler(this.btnDrawRect_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.Location = new System.Drawing.Point(587, 13);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(48, 48);
            this.btnUndo.TabIndex = 100;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(695, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 48);
            this.btnSave.TabIndex = 8;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDrawArrow
            // 
            this.btnDrawArrow.FlatAppearance.BorderSize = 0;
            this.btnDrawArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawArrow.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawArrow.Image")));
            this.btnDrawArrow.Location = new System.Drawing.Point(120, 13);
            this.btnDrawArrow.Name = "btnDrawArrow";
            this.btnDrawArrow.Size = new System.Drawing.Size(48, 48);
            this.btnDrawArrow.TabIndex = 3;
            this.btnDrawArrow.UseVisualStyleBackColor = true;
            this.btnDrawArrow.Click += new System.EventHandler(this.btnDrawArrow_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1451, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 101;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDrawStraightLine
            // 
            this.btnDrawStraightLine.FlatAppearance.BorderSize = 0;
            this.btnDrawStraightLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrawStraightLine.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawStraightLine.Image")));
            this.btnDrawStraightLine.Location = new System.Drawing.Point(66, 12);
            this.btnDrawStraightLine.Name = "btnDrawStraightLine";
            this.btnDrawStraightLine.Size = new System.Drawing.Size(48, 48);
            this.btnDrawStraightLine.TabIndex = 102;
            this.btnDrawStraightLine.UseVisualStyleBackColor = true;
            this.btnDrawStraightLine.Click += new System.EventHandler(this.btnDrawStraightLine_Click);
            // 
            // btnHighLighter
            // 
            this.btnHighLighter.FlatAppearance.BorderSize = 0;
            this.btnHighLighter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHighLighter.Image = ((System.Drawing.Image)(resources.GetObject("btnHighLighter.Image")));
            this.btnHighLighter.Location = new System.Drawing.Point(228, 12);
            this.btnHighLighter.Name = "btnHighLighter";
            this.btnHighLighter.Size = new System.Drawing.Size(48, 48);
            this.btnHighLighter.TabIndex = 103;
            this.btnHighLighter.UseVisualStyleBackColor = true;
            this.btnHighLighter.Click += new System.EventHandler(this.btnHighLighter_Click);
            // 
            // frmAdjustImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 746);
            this.Controls.Add(this.btnHighLighter);
            this.Controls.Add(this.btnDrawStraightLine);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDrawArrow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnDrawRect);
            this.Controls.Add(this.btnSaveToClip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDrawLine);
            this.Controls.Add(this.btnClearArea);
            this.Controls.Add(this.picCapturedImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmAdjustImage";
            this.Text = "Capture Screen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdjustImage_FormClosed);
            this.Load += new System.EventHandler(this.frmAdjustImage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdjustImage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCapturedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSepia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLineColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            this.ResumeLayout(false);

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
    }
}