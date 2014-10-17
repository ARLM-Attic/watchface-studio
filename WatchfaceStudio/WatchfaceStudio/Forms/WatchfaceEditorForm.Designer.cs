namespace WatchfaceStudio.Forms
{
    partial class WatchfaceEditorForm
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
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.pictureWatch = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlert = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // pictureWatch
            // 
            this.pictureWatch.Location = new System.Drawing.Point(12, 12);
            this.pictureWatch.Name = "pictureWatch";
            this.pictureWatch.Size = new System.Drawing.Size(320, 320);
            this.pictureWatch.TabIndex = 0;
            this.pictureWatch.TabStop = false;
            // 
            // pictureBoxAlert
            // 
            this.pictureBoxAlert.Image = global::WatchfaceStudio.Properties.Resources.IconAlert;
            this.pictureBoxAlert.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAlert.Name = "pictureBoxAlert";
            this.pictureBoxAlert.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxAlert.TabIndex = 1;
            this.pictureBoxAlert.TabStop = false;
            this.pictureBoxAlert.Visible = false;
            // 
            // WatchfaceEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(343, 343);
            this.Controls.Add(this.pictureBoxAlert);
            this.Controls.Add(this.pictureWatch);
            this.Name = "WatchfaceEditorForm";
            this.Text = "WatchfaceEditorForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlert)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureWatch;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.PictureBox pictureBoxAlert;
    }
}