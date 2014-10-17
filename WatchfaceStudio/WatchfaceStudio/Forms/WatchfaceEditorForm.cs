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
        public static WatchfaceEditorForm FocusedEditor;

        public FacerWatchface Watchface;
        public string ZipFilePath;

        public WatchfaceEditorForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.IconWatchface;

            GotFocus += WatchfaceEditorForm_GotFocus;
            LostFocus += WatchfaceEditorForm_LostFocus;
        }

        public Image PreviewImage { get { return pictureWatch.Image; } }

        void WatchfaceEditorForm_LostFocus(object sender, EventArgs e)
        {
            //timerClock.Enabled = false;
        }

        void WatchfaceEditorForm_GotFocus(object sender, EventArgs e)
        {
            FocusedEditor = this;

            timerClock_Tick(sender, e);
            timerClock.Enabled = true;
        }
        
        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (this != FocusedEditor) return;
            if (this.ParentForm == null)
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

            var watchtype = ((StudioForm)this.ParentForm).Watchtype;
            bool errorsFound;
            var watchBmp = FacerWatcfaceRenderer.Render(Watchface, watchtype, out errorsFound);
            pictureBoxAlert.Visible = errorsFound;
            pictureWatch.Image = watchBmp;
        }
    }
}
