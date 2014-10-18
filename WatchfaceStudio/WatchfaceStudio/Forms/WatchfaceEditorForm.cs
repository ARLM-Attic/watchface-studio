using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchfaceStudio.Entities;

namespace WatchfaceStudio.Forms
{
    public partial class WatchfaceEditorForm : Form
    {
        public FacerWatchface Watchface;
        public string ZipFilePath;
        public event DragEventHandler DraggedFile;
        public event DragEventHandler DroppedFile;
        public bool IsPlaying = true;

        public WatchfaceEditorForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.IconWatchface;

            Activated += WatchfaceEditorForm_Activated;
            Deactivate += WatchfaceEditorForm_Deactivated;
            
            timerClock_Tick(null, null);
        }

        public Image PreviewImage { get { return pictureWatch.Image; } }

        void WatchfaceEditorForm_Deactivated(object sender, EventArgs e)
        {
            timerClock.Enabled = false;
        }

        void WatchfaceEditorForm_Activated(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                timerClock_Tick(sender, e);
                timerClock.Enabled = true;
            }
        }
        
        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (this.ParentForm == null) //close
            {
                timerClock.Enabled = false;
                return;
            }

            if (timerClock.Interval == 1000 && Properties.Settings.Default.SmoothSeconds)
            {
                timerClock.Interval = 250;
            }
            else if (timerClock.Interval == 250 && !Properties.Settings.Default.SmoothSeconds)
            {
                timerClock.Interval = 1000;
            }

            bool errorsFound;
            var watchBmp = FacerWatcfaceRenderer.Render(Watchface, WatchType.Current, out errorsFound);
            pictureBoxAlert.Visible = errorsFound;
            pictureWatch.Image = watchBmp;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                timerClock.Enabled = false;
                IsPlaying = false;
                buttonPlayPause.Image = Properties.Resources.IconPlay16;
            }
            else
            {
                timerClock.Enabled = true;
                IsPlaying = true;
                buttonPlayPause.Image = Properties.Resources.IconPause16;
            }
        }

        private void WatchfaceEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            if (DraggedFile == null) return;
            DraggedFile(null, e);
        }

        private void WatchfaceEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            if (DroppedFile == null) return;
            DroppedFile(null, e);
        }
    }
}
