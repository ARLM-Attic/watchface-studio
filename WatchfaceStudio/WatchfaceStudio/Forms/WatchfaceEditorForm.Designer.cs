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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
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
            this.pictureWatch.Location = new System.Drawing.Point(12, 26);
            this.pictureWatch.Name = "pictureWatch";
            this.pictureWatch.Size = new System.Drawing.Size(320, 320);
            this.pictureWatch.TabIndex = 0;
            this.pictureWatch.TabStop = false;
            // 
            // pictureBoxAlert
            // 
            this.pictureBoxAlert.Image = global::WatchfaceStudio.Properties.Resources.IconAlert;
            this.pictureBoxAlert.Location = new System.Drawing.Point(24, 4);
            this.pictureBoxAlert.Name = "pictureBoxAlert";
            this.pictureBoxAlert.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxAlert.TabIndex = 1;
            this.pictureBoxAlert.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxAlert, "Errors found during rendering");
            this.pictureBoxAlert.Visible = false;
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPlayPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.Image = global::WatchfaceStudio.Properties.Resources.IconPause16;
            this.buttonPlayPause.Location = new System.Drawing.Point(2, 2);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(20, 20);
            this.buttonPlayPause.TabIndex = 3;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.White;
            this.labelError.Location = new System.Drawing.Point(46, 6);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(28, 13);
            this.labelError.TabIndex = 4;
            this.labelError.Text = "error";
            this.labelError.Visible = false;
            // 
            // WatchfaceEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(344, 358);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.pictureBoxAlert);
            this.Controls.Add(this.pictureWatch);
            this.Name = "WatchfaceEditorForm";
            this.Text = "WatchfaceEditorForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WatchfaceEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WatchfaceEditorForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureWatch;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.PictureBox pictureBoxAlert;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Label labelError;
    }
}