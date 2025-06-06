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
            picCaptureScreen = new PictureBox();
            btnScreen1 = new Button();
            btnScreen2 = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)picCaptureScreen).BeginInit();
            SuspendLayout();
            // 
            // picCaptureScreen
            // 
            picCaptureScreen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picCaptureScreen.BackColor = SystemColors.Control;
            picCaptureScreen.Location = new Point(0, 6);
            picCaptureScreen.Margin = new Padding(6, 6, 6, 6);
            picCaptureScreen.Name = "picCaptureScreen";
            picCaptureScreen.Size = new Size(2944, 1839);
            picCaptureScreen.SizeMode = PictureBoxSizeMode.Zoom;
            picCaptureScreen.TabIndex = 0;
            picCaptureScreen.TabStop = false;
            picCaptureScreen.MouseDown += picCaptureScreen_MouseDown;
            picCaptureScreen.MouseMove += picCaptureScreen_MouseMove;
            picCaptureScreen.MouseUp += picCaptureScreen_MouseUp;
            picCaptureScreen.PreviewKeyDown += picCaptureScreen_PreviewKeyDown;
            // 
            // btnScreen1
            // 
            btnScreen1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScreen1.FlatAppearance.BorderSize = 0;
            btnScreen1.FlatStyle = FlatStyle.Flat;
            btnScreen1.Image = (Image)resources.GetObject("btnScreen1.Image");
            btnScreen1.Location = new Point(2550, 26);
            btnScreen1.Margin = new Padding(6, 6, 6, 6);
            btnScreen1.Name = "btnScreen1";
            btnScreen1.Size = new Size(89, 102);
            btnScreen1.TabIndex = 15;
            btnScreen1.TabStop = false;
            btnScreen1.UseVisualStyleBackColor = true;
            btnScreen1.Click += btnScreen1_Click;
            btnScreen1.MouseEnter += btnControlButton_MouseEnter;
            btnScreen1.MouseLeave += btnControlButton_MouseLeave;
            // 
            // btnScreen2
            // 
            btnScreen2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScreen2.FlatAppearance.BorderSize = 0;
            btnScreen2.FlatStyle = FlatStyle.Flat;
            btnScreen2.Image = (Image)resources.GetObject("btnScreen2.Image");
            btnScreen2.Location = new Point(2650, 26);
            btnScreen2.Margin = new Padding(6, 6, 6, 6);
            btnScreen2.Name = "btnScreen2";
            btnScreen2.Size = new Size(89, 102);
            btnScreen2.TabIndex = 14;
            btnScreen2.TabStop = false;
            btnScreen2.UseVisualStyleBackColor = true;
            btnScreen2.Click += btnScreen2_Click;
            btnScreen2.MouseEnter += btnControlButton_MouseEnter;
            btnScreen2.MouseLeave += btnControlButton_MouseLeave;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.Location = new Point(2834, 26);
            btnExit.Margin = new Padding(6, 6, 6, 6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(89, 102);
            btnExit.TabIndex = 102;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnControlButton_MouseEnter;
            btnExit.MouseLeave += btnControlButton_MouseLeave;
            // 
            // frmCaptureScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2945, 1845);
            Controls.Add(btnExit);
            Controls.Add(btnScreen1);
            Controls.Add(btnScreen2);
            Controls.Add(picCaptureScreen);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCaptureScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CaptureScreen";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += frmCaptureScreen_Load;
            KeyDown += frmCaptureScreen_KeyDown;
            MouseUp += frmCaptureScreen_MouseUp;
            ((System.ComponentModel.ISupportInitialize)picCaptureScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picCaptureScreen;
        private Button btnScreen1;
        private Button btnScreen2;
        private Button btnExit;
    }
}