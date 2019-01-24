/*
 * EXERCISE............: Exercise 9.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms III. Text Editor 
 * DATE................: 24 Jan 2019
 */


namespace Exercise8
{
    partial class frmSplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplashScreen));
            this.cbarSplash = new CircularProgressBar.CircularProgressBar();
            this.tmrBar = new System.Windows.Forms.Timer(this.components);
            this.cbarSplash2 = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // cbarSplash
            // 
            this.cbarSplash.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cbarSplash.AnimationSpeed = 500;
            this.cbarSplash.BackColor = System.Drawing.Color.Transparent;
            this.cbarSplash.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cbarSplash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbarSplash.InnerColor = System.Drawing.Color.Transparent;
            this.cbarSplash.InnerMargin = 2;
            this.cbarSplash.InnerWidth = -1;
            this.cbarSplash.Location = new System.Drawing.Point(177, 246);
            this.cbarSplash.MarqueeAnimationSpeed = 1000;
            this.cbarSplash.Name = "cbarSplash";
            this.cbarSplash.OuterColor = System.Drawing.Color.DarkSlateGray;
            this.cbarSplash.OuterMargin = -10;
            this.cbarSplash.OuterWidth = 10;
            this.cbarSplash.ProgressColor = System.Drawing.Color.Aqua;
            this.cbarSplash.ProgressWidth = 10;
            this.cbarSplash.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cbarSplash.Size = new System.Drawing.Size(38, 37);
            this.cbarSplash.StartAngle = 270;
            this.cbarSplash.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cbarSplash.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cbarSplash.SubscriptText = ".23";
            this.cbarSplash.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cbarSplash.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cbarSplash.SuperscriptText = "°C";
            this.cbarSplash.TabIndex = 1;
            this.cbarSplash.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cbarSplash.Value = 68;
            // 
            // tmrBar
            // 
            this.tmrBar.Interval = 1;
            this.tmrBar.Tick += new System.EventHandler(this.tmrBar_Tick);
            // 
            // cbarSplash2
            // 
            this.cbarSplash2.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cbarSplash2.AnimationSpeed = 500;
            this.cbarSplash2.BackColor = System.Drawing.Color.Transparent;
            this.cbarSplash2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cbarSplash2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbarSplash2.InnerColor = System.Drawing.Color.Transparent;
            this.cbarSplash2.InnerMargin = 2;
            this.cbarSplash2.InnerWidth = -1;
            this.cbarSplash2.Location = new System.Drawing.Point(221, 209);
            this.cbarSplash2.MarqueeAnimationSpeed = 1000;
            this.cbarSplash2.Name = "cbarSplash2";
            this.cbarSplash2.OuterColor = System.Drawing.Color.Cyan;
            this.cbarSplash2.OuterMargin = -10;
            this.cbarSplash2.OuterWidth = 10;
            this.cbarSplash2.ProgressColor = System.Drawing.Color.DarkSlateGray;
            this.cbarSplash2.ProgressWidth = 10;
            this.cbarSplash2.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cbarSplash2.Size = new System.Drawing.Size(57, 56);
            this.cbarSplash2.StartAngle = 270;
            this.cbarSplash2.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cbarSplash2.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cbarSplash2.SubscriptText = ".23";
            this.cbarSplash2.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.cbarSplash2.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cbarSplash2.SuperscriptText = "°C";
            this.cbarSplash2.TabIndex = 2;
            this.cbarSplash2.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cbarSplash2.Value = 68;
            // 
            // frmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(434, 436);
            this.ControlBox = false;
            this.Controls.Add(this.cbarSplash);
            this.Controls.Add(this.cbarSplash2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSplashScreen";
            //this.Load += new System.EventHandler(this.frmSplashScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar cbarSplash;
        private System.Windows.Forms.Timer tmrBar;
        private CircularProgressBar.CircularProgressBar cbarSplash2;
    }
}