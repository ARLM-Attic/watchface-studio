﻿using System;
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
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using WatchfaceStudio.Imaging;

namespace WatchfaceStudio
{
    public partial class StudioForm : Form
    {
        private FormWindowState _lastWindowState;
        public static string TempFolder;
        public static string CodePlexUrl = "https://watchfacestudio.codeplex.com/";

        public static int UntitledCounter = 1;
        
        //Clones
        private ToolStripMenuItem menuViewUnitsFahrenheitClone;
        private ToolStripMenuItem menuViewUnitsCelsiusClone;

        private ToolStripMenuItem menuViewWTMoto360Clone;
        private ToolStripMenuItem menuViewWTLGWClone;
        private ToolStripMenuItem menuViewWTLGWRClone;
        private ToolStripMenuItem menuViewWTSamsungGLClone;

        public void UpdateChanged()
        {
            EditorContext.SelectedWatchface.Changed = true;
            if (!EditorContext.SelectedWatchface.EditorForm.Text.StartsWith("*"))
                EditorContext.SelectedWatchface.EditorForm.Text = string.Concat("*", EditorContext.SelectedWatchface.EditorForm.Text);
        }

        private static ToolStripMenuItem CloneToolStripMenuItem(ToolStripMenuItem source, EventHandler onClick)
        {
            var target = new ToolStripMenuItem(source.Text, source.Image, onClick, source.ShortcutKeys);
            target.Checked = source.Checked;
            target.CheckState = source.CheckState;
            target.Tag = source.Tag;
            return target;
        }

        public StudioForm()
        {
            InitializeComponent();

            LoadSettings();

            //Toolbar cloning from menu

            menuViewUnitsFahrenheit.Tag = false;
            menuViewUnitsCelsius.Tag = true;

            menuViewUnitsFahrenheitClone = CloneToolStripMenuItem(menuViewUnitsFahrenheit, menuViewUnits_Click);
            menuViewUnitsCelsiusClone = CloneToolStripMenuItem(menuViewUnitsCelsius, menuViewUnits_Click);
            toolbarTemperatureUnits.DropDownItems.Add(menuViewUnitsFahrenheitClone);
            toolbarTemperatureUnits.DropDownItems.Add(menuViewUnitsCelsiusClone);

            menuViewWTMoto360.Tag = EWatchType.Moto_360;
            menuViewWTLGW.Tag = EWatchType.LG_G_Watch;
            menuViewWTLGWR.Tag = EWatchType.LG_G_Watch_R;
            menuViewWTSamsungGL.Tag = EWatchType.Samsung_Gear_Live;

            menuViewWTMoto360Clone = CloneToolStripMenuItem(menuViewWTMoto360, menuViewMode_Click);
            menuViewWTLGWClone = CloneToolStripMenuItem(menuViewWTLGW, menuViewMode_Click);
            menuViewWTLGWRClone = CloneToolStripMenuItem(menuViewWTLGWR, menuViewMode_Click);
            menuViewWTSamsungGLClone = CloneToolStripMenuItem(menuViewWTSamsungGL, menuViewMode_Click);
            toolbarWatchType.DropDownItems.Add(menuViewWTMoto360Clone);
            toolbarWatchType.DropDownItems.Add(menuViewWTLGWClone);
            toolbarWatchType.DropDownItems.Add(menuViewWTLGWRClone);
            toolbarWatchType.DropDownItems.Add(menuViewWTSamsungGLClone);

            toolbarLowPowerMode.Checked = menuViewLowPowerMode.Checked;

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
#if !DEBUG
            backgroundWorkerCheckForUpdates.RunWorkerAsync(false);
#endif
        }

        private void LoadSettings()
        {
            WindowState = Properties.Settings.Default.WindowStartupState;
            _lastWindowState = WindowState;

            menuViewLowPowerMode.Checked = Properties.Settings.Default.LowPowerMode;
            menuViewSmoothSecondHands.Checked = Properties.Settings.Default.SmoothSeconds;

            menuViewUnitsCelsius.Checked = Properties.Settings.Default.TempUnitsCelsius;
            menuViewUnitsFahrenheit.Checked = !menuViewUnitsCelsius.Checked;
            toolbarTemperatureUnits.Image =
                menuViewUnitsCelsius.Checked ? menuViewUnitsCelsius.Image :
                menuViewUnitsFahrenheit.Image;

            var watchtype = Properties.Settings.Default.Watchtype;
            menuViewWTMoto360.Checked = watchtype == (int)EWatchType.Moto_360;
            menuViewWTLGW.Checked = watchtype == (int)EWatchType.LG_G_Watch;
            menuViewWTLGWR.Checked = watchtype == (int)EWatchType.LG_G_Watch_R;
            menuViewWTSamsungGL.Checked = watchtype == (int)EWatchType.Samsung_Gear_Live;
            toolbarWatchType.Image =
                menuViewWTMoto360.Checked ? menuViewWTMoto360.Image :
                menuViewWTLGW.Checked ? menuViewWTLGW.Image :
                menuViewWTLGWR.Checked ? menuViewWTLGWR.Image :
                menuViewWTSamsungGL.Image;

            menuViewAppendixWindow.Checked = Properties.Settings.Default.AppendixVisible;
            panelLeft.Visible = menuViewAppendixWindow.Checked;
            splitterLeft.Visible = menuViewAppendixWindow.Checked;

            menuViewDateCustom.Checked = Properties.Settings.Default.ViewCustomDateTime;
            menuViewDateCustomDate.Text = Properties.Settings.Default.CustomDateTime.ToString("MM/dd/yyyy HH:mm");
            menuViewDateNow.Checked = !menuViewDateCustom.Checked;
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
            var isNew = path == null;
            var newForm = new WatchfaceEditorForm
            {
                Text = (isNew ? "*" : string.Empty) + Path.GetFileName(name),
                Watchface = new Entities.FacerWatchface(path),
                MdiParent = this,
                ZipFilePath = isNew ? null : name
            };
            newForm.Watchface.EditorForm = newForm;
            newForm.GotFocus += EditorFormFocus;
            newForm.FormClosing += EditorFormClosing;
            newForm.FormClosed += EditorFormClosed;
            newForm.DroppedFile += EditorFormDroppedFile;
            newForm.DraggedFile += EditorFormDraggedFile;
            newForm.Show();
        }

        void EditorFormDraggedFile(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                var ext = Path.GetExtension(fileNames[0]);
                var regex = new Regex("png|jpe?g|gif|bmp|ttf");
                e.Effect = regex.IsMatch(ext.Substring(1)) ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void EditorFormDroppedFile(object sender, DragEventArgs e)
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            var ext = Path.GetExtension(fileNames[0]);
            if (ext == ".ttf")
                AddNewFont(fileNames[0]);
            else
                AddNewImage(fileNames[0]);
        }

        private TreeNode AddFontToTree(TreeNode fontsNode, string key, FacerCustomFont fnt)
        {
            var newNode = fontsNode.Nodes.Add("font_" + key, key, 2, 2);
            newNode.Tag = fnt;
            return newNode;
        }

        private TreeNode AddImageToTree(TreeNode imagesNode, string key, Image img)
        {
            var newNode = imagesNode.Nodes.Add("image_" + key, key, 4, 4);
            newNode.Tag = img;
            return newNode;
        }

        private TreeNode AddLayerToTree(TreeNode layersNode, FacerLayer lyr)
        {
            TreeNode newNode = null;
            if (lyr.type == "image")
                newNode = layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                    "Image (" + lyr.hash + ")", 6, 6);
            else if (lyr.type == "text")
                newNode = layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                    "Text (" + lyr.text + ")", 7, 7);
            else if (lyr.type == "shape")
                newNode = layersNode.Nodes.Add("layer_" + Guid.NewGuid().ToString("N").ToLower(),
                    "Shape (" + ((FacerShapeType)lyr.shape_type).ToString() + ")", 8, 8);
            newNode.Tag = lyr;
            return newNode;
        }

        private void LoadWatchfaceSolution(FacerWatchface watchface)
        {
            EditorContext.SelectedWatchface = watchface;

            treeViewExplorer.Nodes.Clear();
            toolStripExplorer.Enabled = true;

            var root = treeViewExplorer.Nodes.Add("watchface", "Watchface (" + watchface.Description.title + ")", 0, 0);
            root.Tag = watchface.Description;

            var fontsNode = root.Nodes.Add("fonts", "Fonts", 1, 1);             
            foreach (var fnt in watchface.CustomFonts)
            {
                AddFontToTree(fontsNode, fnt.Key, fnt.Value);
            }

            var imagesNode = root.Nodes.Add("images", "Images", 3, 3); 
            foreach (var img in watchface.Images)
            {
                AddImageToTree(imagesNode, img.Key, img.Value);
            }
            
            var layersNode = root.Nodes.Add("layers", "Layers", 5, 5);
            foreach (var lyr in watchface.Layers)
            {
                AddLayerToTree(layersNode, lyr);
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

            if (e.ChangedItem.PropertyDescriptor.ComponentType == typeof(FacerLayer))
            {
                if (e.ChangedItem.Label == "Text")
                    ((TreeNode)propertyGrid.Tag).Text = "Text (" + e.ChangedItem.Value + ")";
                else if (e.ChangedItem.Label == "Image")
                    ((TreeNode)propertyGrid.Tag).Text = "Image (" + e.ChangedItem.Value + ")";
                else if (e.ChangedItem.Label == "Shape Type")
                    ((TreeNode)propertyGrid.Tag).Text = "Shape (" + (FacerShapeType)e.ChangedItem.Value + ")";
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
            propertyGrid.Tag = e.Node;
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

        private void OpenArchivedWatchface(string fileName)
        {
            string zipTempFolder = null;
            try
            {
                zipTempFolder = Path.Combine(TempFolder, fileName.GetHashCode().ToString().Replace('-', '_') + "_" + DateTime.Now.Ticks);
                if (Directory.Exists(zipTempFolder))
                    Directory.Delete(zipTempFolder, true);
                Directory.CreateDirectory(zipTempFolder);

                ZipFile.ExtractToDirectory(fileName, zipTempFolder);

                CreateEditorForm(fileName, zipTempFolder);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Facer files|*.face|Zip files|*.zip|All files|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            OpenArchivedWatchface(ofd.FileName);
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
            var watchType = (EWatchType)((ToolStripMenuItem)sender).Tag;

            menuViewWTMoto360Clone.Checked = menuViewWTMoto360.Checked = watchType == EWatchType.Moto_360;
            menuViewWTLGWClone.Checked = menuViewWTLGW.Checked = watchType == EWatchType.LG_G_Watch;
            menuViewWTLGWRClone.Checked = menuViewWTLGWR.Checked = watchType == EWatchType.LG_G_Watch_R;
            menuViewWTSamsungGLClone.Checked = menuViewWTSamsungGL.Checked = watchType == EWatchType.Samsung_Gear_Live;
            toolbarWatchType.Image = ((ToolStripMenuItem)sender).Image;

            WatchType.Current = watchType;
        }

        private void menuViewUnits_Click(object sender, EventArgs e)
        {
            var isTempUnitsCelsius = (bool)((ToolStripMenuItem)sender).Tag;

            menuViewUnitsCelsiusClone.Checked = menuViewUnitsCelsius.Checked = isTempUnitsCelsius;
            menuViewUnitsFahrenheitClone.Checked = menuViewUnitsFahrenheit.Checked = !isTempUnitsCelsius;
            toolbarTemperatureUnits.Image = ((ToolStripMenuItem)sender).Image;

            Properties.Settings.Default.TempUnitsCelsius = isTempUnitsCelsius;
            Properties.Settings.Default.Save();
        }

        private void menuViewLowPowerMode_Click(object sender, EventArgs e)
        {
            menuViewLowPowerMode.Checked = !menuViewLowPowerMode.Checked;
            toolbarLowPowerMode.Checked = menuViewLowPowerMode.Checked;

            Properties.Settings.Default.LowPowerMode = menuViewLowPowerMode.Checked;
            Properties.Settings.Default.Save();
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
        }

        private void menuViewSmoothSeconds_Click(object sender, EventArgs e)
        {
            menuViewSmoothSecondHands.Checked = !menuViewSmoothSecondHands.Checked;

            Properties.Settings.Default.SmoothSeconds = menuViewSmoothSecondHands.Checked;
            Properties.Settings.Default.Save();
        }

        private void AddNewFont(string fileName)
        {
            var key = EditorContext.SelectedWatchface.AddFontFile(fileName);
            AddFontToTree(treeViewExplorer.TopNode.Nodes["fonts"], key, EditorContext.SelectedWatchface.CustomFonts[key]);
            UpdateChanged();
        }

        private void buttonAddFont_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog {
                Title = "Select a font to add",
                Filter = "TrueType Font files|*.ttf" })
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                AddNewFont(ofd.FileName);
            }
        }

        private void AddNewImage(string fileName)
        {
            var key = EditorContext.SelectedWatchface.AddImageFile(fileName);
            var tn = AddImageToTree(treeViewExplorer.TopNode.Nodes["images"], key, EditorContext.SelectedWatchface.Images[key]);
            var img = (Image)tn.Tag;

            var containedSize = DrawingCalculations.GetContainedSize(img.Size, new Size(320, 320));

            //also add layer
            var newLayer = new FacerLayer
            {
                type = "image",
                x = "160",
                y = "160",
                r = "0",
                opacity = "100",
                low_power = true,

                alignment = (int)FacerImageAlignment.Center,

                width = containedSize.Width.ToString(),
                height = containedSize.Height.ToString(),

                hash = key,
                is_tinted = false,
                tint_color = null,
            };
            EditorContext.SelectedWatchface.Layers.Add(newLayer);
            treeViewExplorer.SelectedNode = AddLayerToTree(treeViewExplorer.TopNode.Nodes["layers"], newLayer);
            UpdateChanged();
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { 
                Title = "Select an image to add",
                Filter = "Image Files|*.png;*.jp?g;*.bmp;*.gif" })  //It will be saved as PNG anyway
            {
                if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                AddNewImage(ofd.FileName);
            }
        }

        private void buttonAddLayerText_Click(object sender, EventArgs e)
        {
            var newLayer = new FacerLayer
            {
                type = "text",
                x = "160",
                y = "160",
                r = "0",
                opacity = "100",
                low_power = true,
                
                alignment = (int)FacerTextAlignment.Center,
                
                color = "-1", //White
                bgcolor = "0",
                font_hash = "",
                low_power_color = "-1",
                font_family = (int)FacerFont.Roboto,
                size = "12",
                bold = false,
                italic = false,
                text = "Text",
                transform = (int)FacerTextTransform.None
            };
            EditorContext.SelectedWatchface.Layers.Add(newLayer);
            treeViewExplorer.SelectedNode = AddLayerToTree(treeViewExplorer.TopNode.Nodes["layers"], newLayer);
            UpdateChanged();
        }

        private void buttonAddLayerImage_Click(object sender, EventArgs e)
        {
            var newLayer = new FacerLayer
            {
                type = "image",
                x = "160",
                y = "160",
                r = "0",
                opacity = "100",
                low_power = true,
                
                alignment = (int)FacerImageAlignment.Center,
                
                width = "64",
                height = "64",

                hash = "",
                is_tinted = false,
                tint_color = null,
            };
            EditorContext.SelectedWatchface.Layers.Add(newLayer);
            treeViewExplorer.SelectedNode = AddLayerToTree(treeViewExplorer.TopNode.Nodes["layers"], newLayer);
            UpdateChanged();
        }

        private void buttonAddLayerShape_Click(object sender, EventArgs e)
        {
            var newLayer = new FacerLayer
            {
                type = "shape",
                x = "160",
                y = "160",
                r = "0",
                opacity = "100",
                low_power = true,

                color = "-1", //White
                radius = "16",
                shape_opt = ((int)FacerShapeOptions.Stroke).ToString(),
                shape_type = (int)FacerShapeType.Circle,
                sides = "6",
                stroke_size = "6"
            };
            EditorContext.SelectedWatchface.Layers.Add(newLayer);
            treeViewExplorer.SelectedNode = AddLayerToTree(treeViewExplorer.TopNode.Nodes["layers"], newLayer);
            UpdateChanged();
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (treeViewExplorer.SelectedNode == null) return;

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
            }
 
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowStartupState = FormWindowState.Normal;
                Properties.Settings.Default.Save();
            }
        }

        private void menuViewDateNow_Click(object sender, EventArgs e)
        {
            menuViewDateNow.Checked = true;
            menuViewDateCustom.Checked = false;

            Properties.Settings.Default.ViewCustomDateTime = false;
            Properties.Settings.Default.Save();
        }

        private void menuViewDateCustom_Click(object sender, EventArgs e)
        {
            var date = Properties.Settings.Default.CustomDateTime;
            if (DateTimePickerDialog.ShowDialog(ref date) != DialogResult.OK) return;

            menuViewDateNow.Checked = false;
            menuViewDateCustom.Checked = true;
            menuViewDateCustomDate.Text = date.ToString("MM/dd/yyyy HH:mm");

            Properties.Settings.Default.ViewCustomDateTime = true;
            Properties.Settings.Default.CustomDateTime = date;
            Properties.Settings.Default.Save();
        }

        private void menuHelpCheckForUpdate_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerCheckForUpdates.IsBusy)
                backgroundWorkerCheckForUpdates.RunWorkerAsync(true);
        }

        private void backgroundWorkerCheckForUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            var wc = new WebClient();
            var str = wc.DownloadString(CodePlexUrl);
            var regex = new Regex(@"Watchface Studio v([\d]+\.[\d]+)");
            var match = regex.Match(str);
            var manual = (bool)e.Argument;
            e.Result = string.Concat(manual ? 'M' : 'A',  match.Success ? match.Groups[1].ToString() : string.Empty);
        }

        private void backgroundWorkerCheckForUpdates_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var mode = e.Result.ToString()[0];
            var result = e.Result.ToString().Substring(1);
            if (result.Length == 0)
            {
                if (mode == 'M')
                    MessageBox.Show("Couldn't figure out the version.");
                return;
            }
            var currentVersion = Application.ProductVersion.Substring(0,
                Application.ProductVersion.IndexOf('.', Application.ProductVersion.IndexOf('.') + 1));
            if (currentVersion != result)
            {
                if (MessageBox.Show(string.Format(
@"There's a more updated version on the server.
Server version: {0}
Your version: {1}
Would you like to open the browser to download it?",
                    result, currentVersion),
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    Process.Start(CodePlexUrl);
                }
            }
            else
            {
                if (mode == 'M')
                    MessageBox.Show("You have the most updated version.", "Check for updates");
            }
        }

        private void StudioForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                var regex = new Regex("zip|face");
                e.Effect = fileNames.All(f => regex.IsMatch(Path.GetExtension(f).Substring(1))) ? 
                    DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void StudioForm_DragDrop(object sender, DragEventArgs e)
        {
            var fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach(var file in fileNames)
                OpenArchivedWatchface(file);
        }

    }
}
