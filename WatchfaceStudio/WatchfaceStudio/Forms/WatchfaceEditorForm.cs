using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WatchfaceStudio.Editor;
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

        private bool _isLayerDragging;
        private Point _beforePoint;
        private Point _pointerStart;

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
        
        private void RefreshWatch()
        {
            var watchBmp = FacerWatcfaceRenderer.Render(Watchface, EditorContext.WatchType, EditorContext.Overlay, false, null);
            pictureWatch.Image = watchBmp;
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (this.ParentForm == null) //close
            {
                timerClock.Enabled = false;
                return;
            }

            if (timerClock.Interval != 50 && _isLayerDragging)
            {
                timerClock.Interval = 50;
            }
            else if (timerClock.Interval != 250 && Properties.Settings.Default.SmoothSeconds)
            {
                timerClock.Interval = 250;
            }
            else if (timerClock.Interval != 1000 && !Properties.Settings.Default.SmoothSeconds)
            {
                timerClock.Interval = 1000;
            }

            RefreshWatch();
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (IsPlaying)
            {
                timerClock.Enabled = false;
                IsPlaying = false;
                buttonPlayPause.Image = Properties.Resources.IconPlay16;
                toolTip.SetToolTip(buttonPlayPause, "Play");
            }
            else
            {
                timerClock.Enabled = true;
                IsPlaying = true;
                buttonPlayPause.Image = Properties.Resources.IconPause16;
                toolTip.SetToolTip(buttonPlayPause, "Pause");
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

        private void pictureWatch_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkBoxUnlock.Checked) return;

            int x, y;
            if (!int.TryParse(EditorContext.SelectedWatchface.SelectedLayer.x, out x) ||
                !int.TryParse(EditorContext.SelectedWatchface.SelectedLayer.y, out y))
                return;
            _beforePoint = new Point(x, y);
            _pointerStart = e.Location;
            _isLayerDragging = true;
            timerClock.Interval = 50;
        }

        private void pictureWatch_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isLayerDragging) return;

            if (e.Button.HasFlag(MouseButtons.Right)) //cancel
            {
                _isLayerDragging = false;

                EditorContext.SelectedWatchface.SelectedLayer.x = _beforePoint.X.ToString();
                EditorContext.SelectedWatchface.SelectedLayer.y = _beforePoint.Y.ToString();

                RefreshWatch();
            }

            var offset = new Point(e.Location.X - _pointerStart.X, e.Location.Y - _pointerStart.Y);
            var newPoint = _beforePoint;
            newPoint.Offset(offset);

            EditorContext.SelectedWatchface.SelectedLayer.x = newPoint.X.ToString();
            EditorContext.SelectedWatchface.SelectedLayer.y = newPoint.Y.ToString();
        }

        private void pictureWatch_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isLayerDragging) return;

            _isLayerDragging = false;
            ((StudioForm)MdiParent).RefreshPropertyGrid();
        }
    }
}
