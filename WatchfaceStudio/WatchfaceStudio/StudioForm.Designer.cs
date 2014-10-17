namespace WatchfaceStudio
{
    partial class StudioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudioForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeperator0 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewLowPowerMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewSmoothSeconds = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewUnitsFahrenheit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewUnitsCelsius = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewWatchType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewWTMoto360 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewWTLGW = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewWTLGWR = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewWTSamsungGL = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDateNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDateCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewDateCustomDate = new System.Windows.Forms.ToolStripTextBox();
            this.menuViewSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewAppendixWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelWatchfaceExplorer = new System.Windows.Forms.Label();
            this.panelExplorer = new System.Windows.Forms.Panel();
            this.treeViewExplorer = new System.Windows.Forms.TreeView();
            this.imageListExplorer = new System.Windows.Forms.ImageList(this.components);
            this.toolStripExplorer = new System.Windows.Forms.ToolStrip();
            this.buttonAddFont = new System.Windows.Forms.ToolStripButton();
            this.buttonAddImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAddLayerText = new System.Windows.Forms.ToolStripButton();
            this.buttonAddLayerImage = new System.Windows.Forms.ToolStripButton();
            this.buttonAddLayerShape = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveItem = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelProperties = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitterRight = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAppendix = new System.Windows.Forms.Label();
            this.listViewTagAppendix = new System.Windows.Forms.ListView();
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelExplorer.SuspendLayout();
            this.toolStripExplorer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuView,
            this.menuWindow,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.menuWindow;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "Menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSeperator0,
            this.menuFileClose,
            this.menuFileSeperator1,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileSeperator2,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Image = ((System.Drawing.Image)(resources.GetObject("menuFileNew.Image")));
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuFileNew.Size = new System.Drawing.Size(205, 22);
            this.menuFileNew.Text = "&New Watchface";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Image = global::WatchfaceStudio.Properties.Resources.IconOpen16;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(205, 22);
            this.menuFileOpen.Text = "&Open Watchface";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSeperator0
            // 
            this.menuFileSeperator0.Name = "menuFileSeperator0";
            this.menuFileSeperator0.Size = new System.Drawing.Size(202, 6);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.Size = new System.Drawing.Size(205, 22);
            this.menuFileClose.Text = "&Close Watchface";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuFileSeperator1
            // 
            this.menuFileSeperator1.Name = "menuFileSeperator1";
            this.menuFileSeperator1.Size = new System.Drawing.Size(202, 6);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::WatchfaceStudio.Properties.Resources.IconSave16;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(205, 22);
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(205, 22);
            this.menuFileSaveAs.Text = "Save &As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuFileSeperator2
            // 
            this.menuFileSeperator2.Name = "menuFileSeperator2";
            this.menuFileSeperator2.Size = new System.Drawing.Size(202, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Image = global::WatchfaceStudio.Properties.Resources.IconClose16;
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuFileExit.Size = new System.Drawing.Size(205, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewLowPowerMode,
            this.menuViewSmoothSeconds,
            this.menuViewUnits,
            this.menuViewWatchType,
            this.menuViewDate,
            this.menuViewSeparator0,
            this.menuViewAppendixWindow});
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuViewLowPowerMode
            // 
            this.menuViewLowPowerMode.Name = "menuViewLowPowerMode";
            this.menuViewLowPowerMode.Size = new System.Drawing.Size(172, 22);
            this.menuViewLowPowerMode.Text = "&Low Power Mode";
            this.menuViewLowPowerMode.Click += new System.EventHandler(this.menuViewLowPowerMode_Click);
            // 
            // menuViewSmoothSeconds
            // 
            this.menuViewSmoothSeconds.Name = "menuViewSmoothSeconds";
            this.menuViewSmoothSeconds.Size = new System.Drawing.Size(172, 22);
            this.menuViewSmoothSeconds.Text = "&Smooth Seconds";
            this.menuViewSmoothSeconds.Click += new System.EventHandler(this.menuViewSmoothSeconds_Click);
            // 
            // menuViewUnits
            // 
            this.menuViewUnits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewUnitsFahrenheit,
            this.menuViewUnitsCelsius});
            this.menuViewUnits.Name = "menuViewUnits";
            this.menuViewUnits.Size = new System.Drawing.Size(172, 22);
            this.menuViewUnits.Text = "&Temperature Units";
            // 
            // menuViewUnitsFahrenheit
            // 
            this.menuViewUnitsFahrenheit.Checked = true;
            this.menuViewUnitsFahrenheit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewUnitsFahrenheit.Name = "menuViewUnitsFahrenheit";
            this.menuViewUnitsFahrenheit.Size = new System.Drawing.Size(130, 22);
            this.menuViewUnitsFahrenheit.Text = "&Fahrenheit";
            this.menuViewUnitsFahrenheit.Click += new System.EventHandler(this.menuViewUnits_Click);
            // 
            // menuViewUnitsCelsius
            // 
            this.menuViewUnitsCelsius.Name = "menuViewUnitsCelsius";
            this.menuViewUnitsCelsius.Size = new System.Drawing.Size(130, 22);
            this.menuViewUnitsCelsius.Text = "&Celsius";
            // 
            // menuViewWatchType
            // 
            this.menuViewWatchType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewWTMoto360,
            this.menuViewWTLGW,
            this.menuViewWTLGWR,
            this.menuViewWTSamsungGL});
            this.menuViewWatchType.Name = "menuViewWatchType";
            this.menuViewWatchType.Size = new System.Drawing.Size(172, 22);
            this.menuViewWatchType.Text = "&Watch Type";
            // 
            // menuViewWTMoto360
            // 
            this.menuViewWTMoto360.Checked = true;
            this.menuViewWTMoto360.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewWTMoto360.Name = "menuViewWTMoto360";
            this.menuViewWTMoto360.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTMoto360.Text = "Moto 360";
            this.menuViewWTMoto360.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTLGW
            // 
            this.menuViewWTLGW.Name = "menuViewWTLGW";
            this.menuViewWTLGW.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTLGW.Text = "LG G-Watch";
            this.menuViewWTLGW.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTLGWR
            // 
            this.menuViewWTLGWR.Name = "menuViewWTLGWR";
            this.menuViewWTLGWR.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTLGWR.Text = "LG G-Watch R";
            this.menuViewWTLGWR.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTSamsungGL
            // 
            this.menuViewWTSamsungGL.Name = "menuViewWTSamsungGL";
            this.menuViewWTSamsungGL.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTSamsungGL.Text = "Samsung Gear Live";
            this.menuViewWTSamsungGL.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewDate
            // 
            this.menuViewDate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewDateNow,
            this.menuViewDateCustom,
            this.menuViewDateCustomDate});
            this.menuViewDate.Name = "menuViewDate";
            this.menuViewDate.Size = new System.Drawing.Size(172, 22);
            this.menuViewDate.Text = "&Date";
            // 
            // menuViewDateNow
            // 
            this.menuViewDateNow.Checked = true;
            this.menuViewDateNow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewDateNow.Name = "menuViewDateNow";
            this.menuViewDateNow.Size = new System.Drawing.Size(160, 22);
            this.menuViewDateNow.Text = "&Now";
            this.menuViewDateNow.Click += new System.EventHandler(this.menuViewDateNow_Click);
            // 
            // menuViewDateCustom
            // 
            this.menuViewDateCustom.Name = "menuViewDateCustom";
            this.menuViewDateCustom.Size = new System.Drawing.Size(160, 22);
            this.menuViewDateCustom.Text = "&Custom...";
            this.menuViewDateCustom.Click += new System.EventHandler(this.menuViewDateCustom_Click);
            // 
            // menuViewDateCustomDate
            // 
            this.menuViewDateCustomDate.Enabled = false;
            this.menuViewDateCustomDate.Name = "menuViewDateCustomDate";
            this.menuViewDateCustomDate.Size = new System.Drawing.Size(100, 23);
            // 
            // menuViewSeparator0
            // 
            this.menuViewSeparator0.Name = "menuViewSeparator0";
            this.menuViewSeparator0.Size = new System.Drawing.Size(169, 6);
            // 
            // menuViewAppendixWindow
            // 
            this.menuViewAppendixWindow.Checked = true;
            this.menuViewAppendixWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewAppendixWindow.Name = "menuViewAppendixWindow";
            this.menuViewAppendixWindow.Size = new System.Drawing.Size(172, 22);
            this.menuViewAppendixWindow.Text = "&Appendix Window";
            this.menuViewAppendixWindow.Click += new System.EventHandler(this.menuViewAppendixWindow_Click);
            // 
            // menuWindow
            // 
            this.menuWindow.Name = "menuWindow";
            this.menuWindow.Size = new System.Drawing.Size(63, 20);
            this.menuWindow.Text = "&Window";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainerRight.Location = new System.Drawing.Point(843, 24);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainerRight.Size = new System.Drawing.Size(300, 515);
            this.splitContainerRight.SplitterDistance = 249;
            this.splitContainerRight.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelWatchfaceExplorer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelExplorer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 249);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelWatchfaceExplorer
            // 
            this.labelWatchfaceExplorer.AutoSize = true;
            this.labelWatchfaceExplorer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelWatchfaceExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWatchfaceExplorer.Location = new System.Drawing.Point(3, 0);
            this.labelWatchfaceExplorer.Name = "labelWatchfaceExplorer";
            this.labelWatchfaceExplorer.Size = new System.Drawing.Size(294, 20);
            this.labelWatchfaceExplorer.TabIndex = 0;
            this.labelWatchfaceExplorer.Text = "Watchface Explorer";
            this.labelWatchfaceExplorer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelExplorer
            // 
            this.panelExplorer.Controls.Add(this.treeViewExplorer);
            this.panelExplorer.Controls.Add(this.toolStripExplorer);
            this.panelExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExplorer.Location = new System.Drawing.Point(3, 23);
            this.panelExplorer.Name = "panelExplorer";
            this.panelExplorer.Size = new System.Drawing.Size(294, 223);
            this.panelExplorer.TabIndex = 1;
            // 
            // treeViewExplorer
            // 
            this.treeViewExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExplorer.ImageIndex = 0;
            this.treeViewExplorer.ImageList = this.imageListExplorer;
            this.treeViewExplorer.Location = new System.Drawing.Point(0, 25);
            this.treeViewExplorer.Name = "treeViewExplorer";
            this.treeViewExplorer.SelectedImageIndex = 0;
            this.treeViewExplorer.Size = new System.Drawing.Size(294, 198);
            this.treeViewExplorer.TabIndex = 1;
            this.treeViewExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExplorer_AfterSelect);
            // 
            // imageListExplorer
            // 
            this.imageListExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListExplorer.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListExplorer.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStripExplorer
            // 
            this.toolStripExplorer.Enabled = false;
            this.toolStripExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAddFont,
            this.buttonAddImage,
            this.toolStripSeparator1,
            this.buttonAddLayerText,
            this.buttonAddLayerImage,
            this.buttonAddLayerShape,
            this.toolStripSeparator2,
            this.buttonRemoveItem});
            this.toolStripExplorer.Location = new System.Drawing.Point(0, 0);
            this.toolStripExplorer.Name = "toolStripExplorer";
            this.toolStripExplorer.Size = new System.Drawing.Size(294, 25);
            this.toolStripExplorer.TabIndex = 0;
            this.toolStripExplorer.Text = "toolStrip1";
            // 
            // buttonAddFont
            // 
            this.buttonAddFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddFont.Image = global::WatchfaceStudio.Properties.Resources.IconAddFont16;
            this.buttonAddFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddFont.Name = "buttonAddFont";
            this.buttonAddFont.Size = new System.Drawing.Size(23, 22);
            this.buttonAddFont.Text = "Add Font";
            this.buttonAddFont.Click += new System.EventHandler(this.buttonAddFont_Click);
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddImage.Image = global::WatchfaceStudio.Properties.Resources.IconAddImage16;
            this.buttonAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(23, 22);
            this.buttonAddImage.Text = "Add Image";
            this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonAddLayerText
            // 
            this.buttonAddLayerText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddLayerText.Image = global::WatchfaceStudio.Properties.Resources.IconAddLayerText16;
            this.buttonAddLayerText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddLayerText.Name = "buttonAddLayerText";
            this.buttonAddLayerText.Size = new System.Drawing.Size(23, 22);
            this.buttonAddLayerText.Text = "Add Text Layer";
            this.buttonAddLayerText.Click += new System.EventHandler(this.buttonAddLayerText_Click);
            // 
            // buttonAddLayerImage
            // 
            this.buttonAddLayerImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddLayerImage.Image = global::WatchfaceStudio.Properties.Resources.IconAddLayerImage16;
            this.buttonAddLayerImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddLayerImage.Name = "buttonAddLayerImage";
            this.buttonAddLayerImage.Size = new System.Drawing.Size(23, 22);
            this.buttonAddLayerImage.Text = "Add Image Layer";
            this.buttonAddLayerImage.Click += new System.EventHandler(this.buttonAddLayerImage_Click);
            // 
            // buttonAddLayerShape
            // 
            this.buttonAddLayerShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAddLayerShape.Image = global::WatchfaceStudio.Properties.Resources.IconAddLayerShape16;
            this.buttonAddLayerShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAddLayerShape.Name = "buttonAddLayerShape";
            this.buttonAddLayerShape.Size = new System.Drawing.Size(23, 22);
            this.buttonAddLayerShape.Text = "Add Shape Layer";
            this.buttonAddLayerShape.Click += new System.EventHandler(this.buttonAddLayerShape_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRemoveItem.Image = global::WatchfaceStudio.Properties.Resources.IconRemove16;
            this.buttonRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(23, 22);
            this.buttonRemoveItem.Text = "Remove Item";
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelProperties, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.propertyGrid, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 262);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelProperties
            // 
            this.labelProperties.AutoSize = true;
            this.labelProperties.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProperties.Location = new System.Drawing.Point(3, 0);
            this.labelProperties.Name = "labelProperties";
            this.labelProperties.Size = new System.Drawing.Size(294, 20);
            this.labelProperties.TabIndex = 1;
            this.labelProperties.Text = "Properties";
            this.labelProperties.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(3, 23);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(294, 236);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // splitterRight
            // 
            this.splitterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterRight.Location = new System.Drawing.Point(840, 24);
            this.splitterRight.Name = "splitterRight";
            this.splitterRight.Size = new System.Drawing.Size(3, 515);
            this.splitterRight.TabIndex = 4;
            this.splitterRight.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.tableLayoutPanel3);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 24);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(231, 515);
            this.panelLeft.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.labelAppendix, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listViewTagAppendix, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(231, 515);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // labelAppendix
            // 
            this.labelAppendix.AutoSize = true;
            this.labelAppendix.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelAppendix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAppendix.Location = new System.Drawing.Point(3, 0);
            this.labelAppendix.Name = "labelAppendix";
            this.labelAppendix.Size = new System.Drawing.Size(225, 24);
            this.labelAppendix.TabIndex = 2;
            this.labelAppendix.Text = "Appendix";
            this.labelAppendix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewTagAppendix
            // 
            this.listViewTagAppendix.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTag,
            this.columnHeaderDescription});
            this.listViewTagAppendix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTagAppendix.FullRowSelect = true;
            this.listViewTagAppendix.GridLines = true;
            this.listViewTagAppendix.Location = new System.Drawing.Point(3, 27);
            this.listViewTagAppendix.Name = "listViewTagAppendix";
            this.listViewTagAppendix.Size = new System.Drawing.Size(225, 485);
            this.listViewTagAppendix.TabIndex = 0;
            this.listViewTagAppendix.UseCompatibleStateImageBehavior = false;
            this.listViewTagAppendix.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderTag
            // 
            this.columnHeaderTag.Text = "Tag";
            // 
            // columnHeaderDescription
            // 
            this.columnHeaderDescription.Text = "Description";
            this.columnHeaderDescription.Width = 103;
            // 
            // splitterLeft
            // 
            this.splitterLeft.Location = new System.Drawing.Point(231, 24);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(3, 515);
            this.splitterLeft.TabIndex = 6;
            this.splitterLeft.TabStop = false;
            // 
            // StudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 539);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.splitContainerRight);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "StudioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watchface Studio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudioForm_FormClosed);
            this.Resize += new System.EventHandler(this.StudioForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelExplorer.ResumeLayout(false);
            this.panelExplorer.PerformLayout();
            this.toolStripExplorer.ResumeLayout(false);
            this.toolStripExplorer.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelWatchfaceExplorer;
        private System.Windows.Forms.Panel panelExplorer;
        private System.Windows.Forms.TreeView treeViewExplorer;
        private System.Windows.Forms.ToolStrip toolStripExplorer;
        private System.Windows.Forms.ToolStripButton buttonAddFont;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelProperties;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripSeparator menuFileSeperator0;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.ToolStripSeparator menuFileSeperator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator menuFileSeperator2;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripButton buttonAddImage;
        private System.Windows.Forms.ToolStripButton buttonAddLayerText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonAddLayerImage;
        private System.Windows.Forms.ToolStripButton buttonAddLayerShape;
        private System.Windows.Forms.Splitter splitterRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelAppendix;
        private System.Windows.Forms.ListView listViewTagAppendix;
        private System.Windows.Forms.ColumnHeader columnHeaderTag;
        private System.Windows.Forms.ColumnHeader columnHeaderDescription;
        private System.Windows.Forms.Splitter splitterLeft;
        private System.Windows.Forms.ImageList imageListExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuViewLowPowerMode;
        private System.Windows.Forms.ToolStripMenuItem menuViewWatchType;
        private System.Windows.Forms.ToolStripMenuItem menuViewWTMoto360;
        private System.Windows.Forms.ToolStripMenuItem menuViewWTLGW;
        private System.Windows.Forms.ToolStripMenuItem menuViewWTLGWR;
        private System.Windows.Forms.ToolStripMenuItem menuViewWTSamsungGL;
        private System.Windows.Forms.ToolStripSeparator menuViewSeparator0;
        private System.Windows.Forms.ToolStripMenuItem menuViewAppendixWindow;
        private System.Windows.Forms.ToolStripMenuItem menuViewSmoothSeconds;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnits;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnitsFahrenheit;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnitsCelsius;
        private System.Windows.Forms.ToolStripMenuItem menuViewDate;
        private System.Windows.Forms.ToolStripMenuItem menuViewDateNow;
        private System.Windows.Forms.ToolStripMenuItem menuViewDateCustom;
        private System.Windows.Forms.ToolStripTextBox menuViewDateCustomDate;
    }
}

