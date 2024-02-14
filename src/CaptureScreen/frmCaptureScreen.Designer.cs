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
            picCaptureScreen.Location = new Point(0, 3);
            picCaptureScreen.Name = "picCaptureScreen";
            picCaptureScreen.Size = new Size(1585, 862);
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
            btnScreen1.Location = new Point(1373, 12);
            btnScreen1.Name = "btnScreen1";
            btnScreen1.Size = new Size(48, 48);
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
            btnScreen2.Location = new Point(1427, 12);
            btnScreen2.Name = "btnScreen2";
            btnScreen2.Size = new Size(48, 48);
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
            btnExit.Location = new Point(1526, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(48, 48);
            btnExit.TabIndex = 102;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnControlButton_MouseEnter;
            btnExit.MouseLeave += btnControlButton_MouseLeave;
            // 
            // frmCaptureScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1586, 865);
            Controls.Add(btnExit);
            Controls.Add(btnScreen1);
            Controls.Add(btnScreen2);
            Controls.Add(picCaptureScreen);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
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