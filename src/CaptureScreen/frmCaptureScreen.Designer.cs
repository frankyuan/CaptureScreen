namespace CaptureScreen
{
    partial class frmCaptureScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptureScreen));
            this.picCaptureScreen = new System.Windows.Forms.PictureBox();
            this.btnScreen1 = new System.Windows.Forms.Button();
            this.btnScreen2 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptureScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // picCaptureScreen
            // 
            this.picCaptureScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCaptureScreen.BackColor = System.Drawing.SystemColors.Control;
            this.picCaptureScreen.Location = new System.Drawing.Point(0, 3);
            this.picCaptureScreen.Name = "picCaptureScreen";
            this.picCaptureScreen.Size = new System.Drawing.Size(1585, 862);
            this.picCaptureScreen.TabIndex = 0;
            this.picCaptureScreen.TabStop = false;
            this.picCaptureScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCaptureScreen_MouseDown);
            this.picCaptureScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCaptureScreen_MouseMove);
            this.picCaptureScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCaptureScreen_MouseUp);
            this.picCaptureScreen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picCaptureScreen_PreviewKeyDown);
            // 
            // btnScreen1
            // 
            this.btnScreen1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreen1.FlatAppearance.BorderSize = 0;
            this.btnScreen1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreen1.Image = ((System.Drawing.Image)(resources.GetObject("btnScreen1.Image")));
            this.btnScreen1.Location = new System.Drawing.Point(1373, 12);
            this.btnScreen1.Name = "btnScreen1";
            this.btnScreen1.Size = new System.Drawing.Size(48, 48);
            this.btnScreen1.TabIndex = 15;
            this.btnScreen1.TabStop = false;
            this.btnScreen1.UseVisualStyleBackColor = true;
            this.btnScreen1.Click += new System.EventHandler(this.btnScreen1_Click);
            this.btnScreen1.MouseEnter += new System.EventHandler(this.btnControlButton_MouseEnter);
            this.btnScreen1.MouseLeave += new System.EventHandler(this.btnControlButton_MouseLeave);
            // 
            // btnScreen2
            // 
            this.btnScreen2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreen2.FlatAppearance.BorderSize = 0;
            this.btnScreen2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreen2.Image = ((System.Drawing.Image)(resources.GetObject("btnScreen2.Image")));
            this.btnScreen2.Location = new System.Drawing.Point(1427, 12);
            this.btnScreen2.Name = "btnScreen2";
            this.btnScreen2.Size = new System.Drawing.Size(48, 48);
            this.btnScreen2.TabIndex = 14;
            this.btnScreen2.TabStop = false;
            this.btnScreen2.UseVisualStyleBackColor = true;
            this.btnScreen2.Click += new System.EventHandler(this.btnScreen2_Click);
            this.btnScreen2.MouseEnter += new System.EventHandler(this.btnControlButton_MouseEnter);
            this.btnScreen2.MouseLeave += new System.EventHandler(this.btnControlButton_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1526, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 102;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnControlButton_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnControlButton_MouseLeave);
            // 
            // frmCaptureScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 865);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnScreen1);
            this.Controls.Add(this.btnScreen2);
            this.Controls.Add(this.picCaptureScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaptureScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaptureScreen";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCaptureScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaptureScreen_KeyDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmCaptureScreen_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptureScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picCaptureScreen;
        private Button btnScreen1;
        private Button btnScreen2;
        private Button btnExit;
    }
}