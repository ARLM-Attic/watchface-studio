using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using WatchfaceStudio.Forms;
using WatchfaceStudio.Entities;
using WatchfaceStudio.Editor;

namespace WatchfaceStudio
{
    public partial class StudioForm : Form
    {
        private FormWindowState _lastWindowState;
        public static string TempFolder;

        public static int UntitledCounter = 1;

        public EWatchType Watchtype
        {
            get 
            { 
                var wt = Properties.Settings.Default.Watchtype;
                if (!Enum.IsDefined(typeof(EWatchType), wt))
                    wt = (int)default(EWatchType);
                return (EWatchType)wt;
            }
            set
            {
                Properties.Settings.Default.Watchtype = (int)value;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
        }

        public class PropertyLabelClass
        {
            private string _title;
            public string Title { get {return _title; } }
            public PropertyLabelClass(string title) { _title = title; }
        }

        public void UpdateChanged()
        {
            EditorContext.SelectedWatchface.Changed = true;
            if (!EditorContext.SelectedWatchface.EditorForm.Text.StartsWith("*"))
                EditorContext.SelectedWatchface.EditorForm.Text = string.Concat("*", EditorContext.SelectedWatchface.EditorForm.Text);
        }

        public StudioForm()
        {
            InitializeComponent();

            LoadSettings();

            Icon = Properties.Resources.IconApplication;

            imageListExplorer.Images.Add(Properties.Resources.IconWatchface16);
            imageListExplorer.Images.Add(Properties.Resources.IconFonts16);
            imageListExplorer.Images.Add(Properties.Resources.IconFont16);
            imageListExplorer.Images.Add(Properties.Resources.IconImages16);
            imageListExplorer.Images.Add(Properties.Resources.IconImage16);
            imageListExplorer.Images.Add(Properties.Resources.IconLayers16);
            imageListExplorer.Images.Add(Properties.Resources.IconLayerImage16);
            imageListExplorer.Images.Add(Properties.Resources.IconLayerText16);
            imageListExplorer.Images.Add(Properties.Resources.IconLayerShape16);

            TempFolder = Path.Combine(Path.GetTempPath(), "WatchfaceStudio/");
            try
            {
                if (Directory.Exists(TempFolder))
                    Directory.Delete(TempFolder, true);
                Directory.CreateDirectory(TempFolder);
            }
            catch { }

            foreach (var kvp in FacerTags.Tags)
            {
                listViewTagAppendix.Items.Add(kvp.Key).SubItems.Add(kvp.Value.Description);
            }
            foreach (ColumnHeader col in listViewTagAppendix.Columns)
                col.Width = -1;
        }

        private void LoadSettings()
        {
            WindowState = Properties.Settings.Default.WindowStartupState;
            _lastWindowState = WindowState;

            menuViewLowPowerMode.Checked = Properties.Settings.Default.LowPowerMode;
            menuViewSmoothSeconds.Checked = Properties.Settings.Default.SmoothSeconds;

            menuViewUnitsCelsius.Checked = Properties.Settings.Default.TempUnitsCelsius;
            menuViewUnitsFahrenheit.Checked = !menuViewUnitsCelsius.Checked;
            
            var watchtype = Properties.Settings.Default.Watchtype;
            menuViewWTMoto360.Checked = watchtype == (int)EWatchType.Moto_360;
            menuViewWTLGW.Checked = watchtype == (int)EWatchType.LG_G_Watch;
            menuViewWTLGWR.Checked = watchtype == (int)EWatchType.LG_G_Watch_R;
            menuViewWTSamsungGL.Checked = watchtype == (int)EWatchType.Samsung_Gear_Live;

            menuViewAppendixWindow.Checked = Properties.Settings.Default.AppendixVisible;
            panelLeft.Visible = menuViewAppendixWindow.Checked;
            splitterLeft.Visible = menuViewAppendixWindow.Checked;
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message
#if DEBUG
 + ex.StackTrace + (ex.InnerException != null ? ex.InnerException.Message + ex.InnerException.StackTrace : string.Empty)
#endif
, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void StudioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try 
            {
                if (Directory.Exists(TempFolder))
                    Directory.Delete(TempFolder, true);
            }
            catch { }
        }

        private void CreateEditorForm(string name, string path = null)
        {
            var newForm = new WatchfaceEditorForm
            {
                Text = (path == null ? "*" : string.Empty) + "Editor - " + Path.GetFileName(name),
                Watchface = new Entities.FacerWatchface(path),
                MdiParent = this,
                ZipFilePath = path == null ? null : name
            };
            newForm.Watchface.EditorForm = newForm;
            newForm.GotFocus += EditorFormFocus;
            newForm.FormClosing += EditorFormClosing;
            newForm.FormClosed += EditorFormClosed;
            newForm.Show();
        }

        private void LoadWatchfaceSolution(FacerWatchface watchface)
        {
            EditorContext.SelectedWatchface = watchface;

            treeViewExplorer.Nodes.Clear();
            toolStripExplorer.Enabled = true;

            var root = treeViewExplorer.Nodes.Add("watchface", "Watchface (" + watchface.Description.title + ")", 0, 0);
            root.Tag = watchface.Description;

            var fontsNode = root.Nodes.Add("fonts", "Fonts", 1, 1); 
            fontsNode.Tag = new PropertyLabelClass(fontsNode.Text);            
            foreach (var fnt in watchface.CustomFonts)
            {
                fontsNode.Nodes.Add("font_" + fnt.Key, "Font (" + fnt.Key + ")", 2, 2).Tag = fnt.Value;
            }

            var imagesNode = root.Nodes.Add("images", "Images", 3, 3); 
            imagesNode.Tag = new PropertyLabelClass(imagesNode.Text);
            foreach (var img in watchface.Images)
            {
                imagesNode.Nodes.Add("image_" +img.Key,img.Key, 4, 4).Tag = img.Value;
            }
            
            var layersNode = root.Nodes.Add("layers", "Layers", 5, 5);
            layersNode.Tag = new PropertyLabelClass(layersNode.Text);
            foreach (var lyr in watchface.Layers)
            {
                if (lyr.type == "image")
                    layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                        "Image (" + lyr.hash + ")", 6, 6).Tag = lyr;
                else if (lyr.type == "text")
                    layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                        "Text (" + lyr.text + ")", 7, 7).Tag = lyr;
                else if (lyr.type == "shape")
                    layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                        "Shape (" + ((FacerShapeType)lyr.shape_type).ToString() + ")", 8, 8).Tag = lyr;
            }

            root.Expand();
            layersNode.ExpandAll();
        }

        private void SaveWatch(string zipFile)
        {
            var wf = EditorContext.SelectedWatchface;
            var success = false;

            try
            {
                var folderPath = Path.Combine(TempFolder, zipFile.GetHashCode().ToString().Replace('-', '_') + "_" + DateTime.Now.Ticks);
                Directory.CreateDirectory(folderPath);

                success = wf.SaveTo(folderPath);

                if (success)
                {
                    ZipFile.CreateFromDirectory(folderPath, zipFile);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            if (success)
            {
                wf.Changed = false;
                if (wf.EditorForm.Text.StartsWith("*"))
                    wf.EditorForm.Text = wf.EditorForm.Text.Substring(1);
            }

            if (!success)
            {
                MessageBox.Show("There was somthing wrong while saving the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void EditorFormFocus(object sender, EventArgs e)
        {
            var form = (WatchfaceEditorForm)sender;

            if (EditorContext.SelectedWatchface == form.Watchface || !form.Visible) return;

            LoadWatchfaceSolution(form.Watchface);
        }

        void EditorFormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var form = (WatchfaceEditorForm)sender;

                if (form.Watchface.Changed)
                {
                    var saveChangesResult = MessageBox.Show(string.Format("Do you want to save changes for '{0}'?", form.Watchface.Description.title), this.Text, 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (saveChangesResult)
                    {
                        case System.Windows.Forms.DialogResult.Yes:
                            menuFileSave_Click(sender, e);
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                        //case System.Windows.Forms.DialogResult.No:
                    }
                }
            }
            catch { }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.PropertyDescriptor.ComponentType == typeof(FacerWatchfaceDescription))
            {
                treeViewExplorer.TopNode.Text = "Watchface (" + e.ChangedItem.Value + ")";
            }

            UpdateChanged();
        }

        void EditorFormClosed(object sender, FormClosedEventArgs e)
        {
            EditorContext.SelectedWatchface = null;
            treeViewExplorer.Nodes.Clear();
            toolStripExplorer.Enabled = false;
            propertyGrid.SelectedObject = null;
        }

        private void treeViewExplorer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGrid.SelectedObject = e.Node.Tag;
            if (e.Node.Tag is FacerLayer)
            {
                EditorContext.SelectedWatchface.SelectedLayer = (FacerLayer)e.Node.Tag;
            }
            else
            {
                EditorContext.SelectedWatchface.SelectedLayer = null;
            }

        }

        #region Menu

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            CreateEditorForm("Untitled" + UntitledCounter++);
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Facer files|*.face|Zip files|*.zip|All files|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string zipTempFolder = null;
            try
            {
                zipTempFolder = Path.Combine(TempFolder, ofd.FileName.GetHashCode().ToString().Replace('-', '_') + "_" + DateTime.Now.Ticks);
                if (Directory.Exists(zipTempFolder))
                    Directory.Delete(zipTempFolder, true);
                Directory.CreateDirectory(zipTempFolder);

                ZipFile.ExtractToDirectory(ofd.FileName, zipTempFolder);

                CreateEditorForm(ofd.FileName, zipTempFolder);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void menuFileClose_Click(object sender, EventArgs e)
        {
            if (EditorContext.SelectedWatchface != null)
                EditorContext.SelectedWatchface.EditorForm.Close();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (EditorContext.SelectedWatchface != null)
            {
                var wf = EditorContext.SelectedWatchface;

                if (wf.EditorForm.ZipFilePath == null)
                {
                    menuFileSaveAs_Click(sender, e);
                    return;
                }

                SaveWatch(wf.EditorForm.ZipFilePath);
            }
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (EditorContext.SelectedWatchface != null)
            {
                var wf = EditorContext.SelectedWatchface;

                using (var sfd = new SaveFileDialog { Title = "Save Watchface", Filter = "Face Files|*.face|Zip files|*.zip" })
                {
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveWatch(sfd.FileName);
                    }
                }
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuViewMode_Click(object sender, EventArgs e)
        {
            menuViewWTMoto360.Checked = sender == menuViewWTMoto360;
            menuViewWTLGW.Checked = sender == menuViewWTLGW;
            menuViewWTLGWR.Checked = sender == menuViewWTLGWR;
            menuViewWTSamsungGL.Checked = sender == menuViewWTSamsungGL;

            Watchtype = menuViewWTMoto360.Checked ? EWatchType.Moto_360 :
                (menuViewWTLGW.Checked ? EWatchType.LG_G_Watch : 
                (menuViewWTLGWR.Checked ? EWatchType.LG_G_Watch_R :
                EWatchType.Samsung_Gear_Live));
        }

        private void menuViewUnits_Click(object sender, EventArgs e)
        {
            menuViewUnitsCelsius.Checked = sender == menuViewUnitsCelsius;
            menuViewUnitsFahrenheit.Checked = sender == menuViewUnitsFahrenheit;

            Properties.Settings.Default.TempUnitsCelsius = menuViewUnitsCelsius.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        private void menuViewLowPowerMode_Click(object sender, EventArgs e)
        {
            menuViewLowPowerMode.Checked = !menuViewLowPowerMode.Checked;

            Properties.Settings.Default.LowPowerMode = menuViewLowPowerMode.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        #endregion

        private void menuViewAppendixWindow_Click(object sender, EventArgs e)
        {
            menuViewAppendixWindow.Checked = !menuViewAppendixWindow.Checked;

            panelLeft.Visible = menuViewAppendixWindow.Checked;
            splitterLeft.Visible = menuViewAppendixWindow.Checked;

            Properties.Settings.Default.AppendixVisible = menuViewAppendixWindow.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        private void menuViewSmoothSeconds_Click(object sender, EventArgs e)
        {
            menuViewSmoothSeconds.Checked = !menuViewSmoothSeconds.Checked;

            Properties.Settings.Default.SmoothSeconds = menuViewSmoothSeconds.Checked;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
        }

        private void buttonAddFont_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog {
                Title = "Select a font to add",
                Filter = "TrueType Font files|*.ttf" })
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                EditorContext.SelectedWatchface.AddFontFile(ofd.FileName);
                UpdateChanged();
            }
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { 
                Title = "Select an image to add",
                Filter = "Image Files|*.png;*.jp?g;*.bmp;*.gif" })  //It will be saved as PNG anyway
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                EditorContext.SelectedWatchface.AddImageFile(ofd.FileName);
                UpdateChanged();
            }
        }

        private void buttonAddLayerText_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddLayerImage_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddLayerShape_Click(object sender, EventArgs e)
        {

        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (treeViewExplorer.SelectedNode != null) return;

            if (treeViewExplorer.SelectedNode.Tag is FacerLayer)
            {
                EditorContext.SelectedWatchface.Layers.Remove((FacerLayer)treeViewExplorer.SelectedNode.Tag);
                treeViewExplorer.SelectedNode.Remove();
            }
            else if (treeViewExplorer.SelectedNode.Tag is Image)
            {
                EditorContext.SelectedWatchface.Images.Remove(treeViewExplorer.SelectedNode.Text);
                treeViewExplorer.SelectedNode.Remove();
            }
            else if (treeViewExplorer.SelectedNode.Tag is Image)
            {
                EditorContext.SelectedWatchface.CustomFonts.Remove(treeViewExplorer.SelectedNode.Text);
                treeViewExplorer.SelectedNode.Remove();
            }
        }

        private void StudioForm_Resize(object sender, EventArgs e)
        {
            if (_lastWindowState == this.WindowState) return;

            if (this.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.WindowStartupState = FormWindowState.Maximized;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
 
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowStartupState = FormWindowState.Normal;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
        }

    }
}
