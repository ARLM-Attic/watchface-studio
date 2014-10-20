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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonPlayPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatch)).BeginInit();
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
            // WatchfaceEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(344, 358);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.pictureWatch);
            this.Name = "WatchfaceEditorForm";
            this.Text = "WatchfaceEditorForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.WatchfaceEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.WatchfaceEditorForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureWatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureWatch;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonPlayPause;
    }
}