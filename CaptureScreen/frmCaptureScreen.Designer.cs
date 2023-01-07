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
            this.picCaptureScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptureScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // picCaptureScreen
            // 
            this.picCaptureScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCaptureScreen.Location = new System.Drawing.Point(0, 3);
            this.picCaptureScreen.Name = "picCaptureScreen";
            this.picCaptureScreen.Size = new System.Drawing.Size(1585, 862);
            this.picCaptureScreen.TabIndex = 0;
            this.picCaptureScreen.TabStop = false;
            this.picCaptureScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCaptureScreen_MouseDown);
            this.picCaptureScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCaptureScreen_MouseMove);
            this.picCaptureScreen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picCaptureScreen_PreviewKeyDown);
            // 
            // frmCaptureScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 865);
            this.Controls.Add(this.picCaptureScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCaptureScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaptureScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCaptureScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCaptureScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptureScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picCaptureScreen;
    }
}