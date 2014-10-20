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
            this.menuViewSmoothSecondHands = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuHelpCheckForUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSeperator0 = new System.Windows.Forms.ToolStripSeparator();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelExplorer = new System.Windows.Forms.TableLayoutPanel();
            this.labelWatchfaceExplorer = new System.Windows.Forms.Label();
            this.panelExplorer = new System.Windows.Forms.Panel();
            this.treeViewExplorer = new System.Windows.Forms.TreeView();
            this.imageListExplorer = new System.Windows.Forms.ImageList(this.components);
            this.toolStripExplorer = new System.Windows.Forms.ToolStrip();
            this.buttonAddFont = new System.Windows.Forms.ToolStripButton();
            this.buttonAddImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripExplorerSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAddLayerText = new System.Windows.Forms.ToolStripButton();
            this.buttonAddLayerImage = new System.Windows.Forms.ToolStripButton();
            this.buttonAddLayerShape = new System.Windows.Forms.ToolStripButton();
            this.toolStripExplorerSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonRemoveItem = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanelProperties = new System.Windows.Forms.TableLayoutPanel();
            this.labelProperties = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitterRight = new System.Windows.Forms.Splitter();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.tableLayoutPanelAppendix = new System.Windows.Forms.TableLayoutPanel();
            this.labelAppendix = new System.Windows.Forms.Label();
            this.listViewTagAppendix = new System.Windows.Forms.ListView();
            this.columnHeaderTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitterLeft = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbarNewWatchface = new System.Windows.Forms.ToolStripButton();
            this.toolbarOpenWatchface = new System.Windows.Forms.ToolStripButton();
            this.toolbarSave = new System.Windows.Forms.ToolStripButton();
            this.toolbarSeperator0 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarLowPowerMode = new System.Windows.Forms.ToolStripButton();
            this.toolbarSmoothSecondHands = new System.Windows.Forms.ToolStripButton();
            this.toolbarTemperatureUnits = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolbarWatchType = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolbarSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbarAppendixWindow = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorkerCheckForUpdates = new System.ComponentModel.BackgroundWorker();
            this.panelErrors = new System.Windows.Forms.Panel();
            this.tableLayoutPanelErrors = new System.Windows.Forms.TableLayoutPanel();
            this.labelErrors = new System.Windows.Forms.Label();
            this.listViewErrors = new System.Windows.Forms.ListView();
            this.columnHeaderComponent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderErrorDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListErrors = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.tableLayoutPanelExplorer.SuspendLayout();
            this.panelExplorer.SuspendLayout();
            this.toolStripExplorer.SuspendLayout();
            this.tableLayoutPanelProperties.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.tableLayoutPanelAppendix.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelErrors.SuspendLayout();
            this.tableLayoutPanelErrors.SuspendLayout();
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
            this.menuViewSmoothSecondHands,
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
            this.menuViewLowPowerMode.Image = global::WatchfaceStudio.Properties.Resources.IconLowPower16;
            this.menuViewLowPowerMode.Name = "menuViewLowPowerMode";
            this.menuViewLowPowerMode.Size = new System.Drawing.Size(195, 22);
            this.menuViewLowPowerMode.Text = "&Low Power Mode";
            this.menuViewLowPowerMode.Click += new System.EventHandler(this.menuViewLowPowerMode_Click);
            // 
            // menuViewSmoothSecondHands
            // 
            this.menuViewSmoothSecondHands.Image = global::WatchfaceStudio.Properties.Resources.IconSpeed16;
            this.menuViewSmoothSecondHands.Name = "menuViewSmoothSecondHands";
            this.menuViewSmoothSecondHands.Size = new System.Drawing.Size(195, 22);
            this.menuViewSmoothSecondHands.Text = "&Smooth Second Hands";
            this.menuViewSmoothSecondHands.Click += new System.EventHandler(this.menuViewSmoothSeconds_Click);
            // 
            // menuViewUnits
            // 
            this.menuViewUnits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewUnitsFahrenheit,
            this.menuViewUnitsCelsius});
            this.menuViewUnits.Name = "menuViewUnits";
            this.menuViewUnits.Size = new System.Drawing.Size(195, 22);
            this.menuViewUnits.Text = "&Temperature Units";
            // 
            // menuViewUnitsFahrenheit
            // 
            this.menuViewUnitsFahrenheit.Checked = true;
            this.menuViewUnitsFahrenheit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewUnitsFahrenheit.Image = global::WatchfaceStudio.Properties.Resources.IconFahrenheit16;
            this.menuViewUnitsFahrenheit.Name = "menuViewUnitsFahrenheit";
            this.menuViewUnitsFahrenheit.Size = new System.Drawing.Size(130, 22);
            this.menuViewUnitsFahrenheit.Tag = "";
            this.menuViewUnitsFahrenheit.Text = "&Fahrenheit";
            this.menuViewUnitsFahrenheit.Click += new System.EventHandler(this.menuViewUnits_Click);
            // 
            // menuViewUnitsCelsius
            // 
            this.menuViewUnitsCelsius.Image = global::WatchfaceStudio.Properties.Resources.IconCelsius16;
            this.menuViewUnitsCelsius.Name = "menuViewUnitsCelsius";
            this.menuViewUnitsCelsius.Size = new System.Drawing.Size(130, 22);
            this.menuViewUnitsCelsius.Text = "&Celsius";
            this.menuViewUnitsCelsius.Click += new System.EventHandler(this.menuViewUnits_Click);
            // 
            // menuViewWatchType
            // 
            this.menuViewWatchType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewWTMoto360,
            this.menuViewWTLGW,
            this.menuViewWTLGWR,
            this.menuViewWTSamsungGL});
            this.menuViewWatchType.Name = "menuViewWatchType";
            this.menuViewWatchType.Size = new System.Drawing.Size(195, 22);
            this.menuViewWatchType.Text = "&Watch Type";
            // 
            // menuViewWTMoto360
            // 
            this.menuViewWTMoto360.Checked = true;
            this.menuViewWTMoto360.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewWTMoto360.Image = global::WatchfaceStudio.Properties.Resources.IconMediumCircleCut16;
            this.menuViewWTMoto360.Name = "menuViewWTMoto360";
            this.menuViewWTMoto360.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTMoto360.Text = "Moto 360";
            this.menuViewWTMoto360.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTLGW
            // 
            this.menuViewWTLGW.Image = global::WatchfaceStudio.Properties.Resources.IconSmallSquare16;
            this.menuViewWTLGW.Name = "menuViewWTLGW";
            this.menuViewWTLGW.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTLGW.Text = "LG G-Watch";
            this.menuViewWTLGW.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTLGWR
            // 
            this.menuViewWTLGWR.Image = global::WatchfaceStudio.Properties.Resources.IconMediumCircle16;
            this.menuViewWTLGWR.Name = "menuViewWTLGWR";
            this.menuViewWTLGWR.Size = new System.Drawing.Size(174, 22);
            this.menuViewWTLGWR.Text = "LG G-Watch R";
            this.menuViewWTLGWR.Click += new System.EventHandler(this.menuViewMode_Click);
            // 
            // menuViewWTSamsungGL
            // 
            this.menuViewWTSamsungGL.Image = global::WatchfaceStudio.Properties.Resources.IconMediumSquare16;
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
            this.menuViewDate.Size = new System.Drawing.Size(195, 22);
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
            this.menuViewSeparator0.Size = new System.Drawing.Size(192, 6);
            // 
            // menuViewAppendixWindow
            // 
            this.menuViewAppendixWindow.Checked = true;
            this.menuViewAppendixWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewAppendixWindow.Image = global::WatchfaceStudio.Properties.Resources.IconHash16;
            this.menuViewAppendixWindow.Name = "menuViewAppendixWindow";
            this.menuViewAppendixWindow.Size = new System.Drawing.Size(195, 22);
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
            this.menuHelpCheckForUpdate,
            this.menuHelpSeperator0,
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpCheckForUpdate
            // 
            this.menuHelpCheckForUpdate.Name = "menuHelpCheckForUpdate";
            this.menuHelpCheckForUpdate.Size = new System.Drawing.Size(174, 22);
            this.menuHelpCheckForUpdate.Text = "&Check for update...";
            this.menuHelpCheckForUpdate.Click += new System.EventHandler(this.menuHelpCheckForUpdate_Click);
            // 
            // menuHelpSeperator0
            // 
            this.menuHelpSeperator0.Name = "menuHelpSeperator0";
            this.menuHelpSeperator0.Size = new System.Drawing.Size(171, 6);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(174, 22);
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainerRight.Location = new System.Drawing.Point(843, 49);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.tableLayoutPanelExplorer);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitContainerRight.Panel2.Controls.Add(this.tableLayoutPanelProperties);
            this.splitContainerRight.Size = new System.Drawing.Size(300, 555);
            this.splitContainerRight.SplitterDistance = 267;
            this.splitContainerRight.TabIndex = 2;
            // 
            // tableLayoutPanelExplorer
            // 
            this.tableLayoutPanelExplorer.ColumnCount = 1;
            this.tableLayoutPanelExplorer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExplorer.Controls.Add(this.labelWatchfaceExplorer, 0, 0);
            this.tableLayoutPanelExplorer.Controls.Add(this.panelExplorer, 0, 1);
            this.tableLayoutPanelExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelExplorer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelExplorer.Name = "tableLayoutPanelExplorer";
            this.tableLayoutPanelExplorer.RowCount = 2;
            this.tableLayoutPanelExplorer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExplorer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelExplorer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelExplorer.Size = new System.Drawing.Size(300, 267);
            this.tableLayoutPanelExplorer.TabIndex = 0;
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
            this.panelExplorer.Size = new System.Drawing.Size(294, 241);
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
            this.treeViewExplorer.Size = new System.Drawing.Size(294, 216);
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
            this.toolStripExplorerSeparator0,
            this.buttonAddLayerText,
            this.buttonAddLayerImage,
            this.buttonAddLayerShape,
            this.toolStripExplorerSeparator1,
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
            // toolStripExplorerSeparator0
            // 
            this.toolStripExplorerSeparator0.Name = "toolStripExplorerSeparator0";
            this.toolStripExplorerSeparator0.Size = new System.Drawing.Size(6, 25);
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
            // toolStripExplorerSeparator1
            // 
            this.toolStripExplorerSeparator1.Name = "toolStripExplorerSeparator1";
            this.toolStripExplorerSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // tableLayoutPanelProperties
            // 
            this.tableLayoutPanelProperties.ColumnCount = 1;
            this.tableLayoutPanelProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProperties.Controls.Add(this.labelProperties, 0, 0);
            this.tableLayoutPanelProperties.Controls.Add(this.propertyGrid, 0, 1);
            this.tableLayoutPanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProperties.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProperties.Name = "tableLayoutPanelProperties";
            this.tableLayoutPanelProperties.RowCount = 2;
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProperties.Size = new System.Drawing.Size(300, 284);
            this.tableLayoutPanelProperties.TabIndex = 1;
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
            this.propertyGrid.Size = new System.Drawing.Size(294, 258);
            this.propertyGrid.TabIndex = 2;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // splitterRight
            // 
            this.splitterRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterRight.Location = new System.Drawing.Point(840, 49);
            this.splitterRight.Name = "splitterRight";
            this.splitterRight.Size = new System.Drawing.Size(3, 555);
            this.splitterRight.TabIndex = 4;
            this.splitterRight.TabStop = false;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.tableLayoutPanelAppendix);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 49);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(231, 555);
            this.panelLeft.TabIndex = 5;
            // 
            // tableLayoutPanelAppendix
            // 
            this.tableLayoutPanelAppendix.ColumnCount = 1;
            this.tableLayoutPanelAppendix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAppendix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelAppendix.Controls.Add(this.labelAppendix, 0, 0);
            this.tableLayoutPanelAppendix.Controls.Add(this.listViewTagAppendix, 0, 1);
            this.tableLayoutPanelAppendix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelAppendix.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelAppendix.Name = "tableLayoutPanelAppendix";
            this.tableLayoutPanelAppendix.RowCount = 2;
            this.tableLayoutPanelAppendix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelAppendix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAppendix.Size = new System.Drawing.Size(231, 555);
            this.tableLayoutPanelAppendix.TabIndex = 1;
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
            this.listViewTagAppendix.Size = new System.Drawing.Size(225, 525);
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
            this.splitterLeft.Location = new System.Drawing.Point(231, 49);
            this.splitterLeft.Name = "splitterLeft";
            this.splitterLeft.Size = new System.Drawing.Size(3, 555);
            this.splitterLeft.TabIndex = 6;
            this.splitterLeft.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarNewWatchface,
            this.toolbarOpenWatchface,
            this.toolbarSave,
            this.toolbarSeperator0,
            this.toolbarLowPowerMode,
            this.toolbarSmoothSecondHands,
            this.toolbarTemperatureUnits,
            this.toolbarWatchType,
            this.toolbarSeperator1,
            this.toolbarAppendixWindow});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1143, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolbarNewWatchface
            // 
            this.toolbarNewWatchface.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarNewWatchface.Image = global::WatchfaceStudio.Properties.Resources.IconNewWatchface16;
            this.toolbarNewWatchface.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarNewWatchface.Name = "toolbarNewWatchface";
            this.toolbarNewWatchface.Size = new System.Drawing.Size(23, 22);
            this.toolbarNewWatchface.Text = "New Watchface";
            this.toolbarNewWatchface.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // toolbarOpenWatchface
            // 
            this.toolbarOpenWatchface.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarOpenWatchface.Image = global::WatchfaceStudio.Properties.Resources.IconOpen16;
            this.toolbarOpenWatchface.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarOpenWatchface.Name = "toolbarOpenWatchface";
            this.toolbarOpenWatchface.Size = new System.Drawing.Size(23, 22);
            this.toolbarOpenWatchface.Text = "Open Watchface";
            this.toolbarOpenWatchface.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // toolbarSave
            // 
            this.toolbarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarSave.Image = global::WatchfaceStudio.Properties.Resources.IconSave16;
            this.toolbarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarSave.Name = "toolbarSave";
            this.toolbarSave.Size = new System.Drawing.Size(23, 22);
            this.toolbarSave.Text = "Save";
            this.toolbarSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // toolbarSeperator0
            // 
            this.toolbarSeperator0.Name = "toolbarSeperator0";
            this.toolbarSeperator0.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbarLowPowerMode
            // 
            this.toolbarLowPowerMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarLowPowerMode.Image = global::WatchfaceStudio.Properties.Resources.IconLowPower16;
            this.toolbarLowPowerMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarLowPowerMode.Name = "toolbarLowPowerMode";
            this.toolbarLowPowerMode.Size = new System.Drawing.Size(23, 22);
            this.toolbarLowPowerMode.Text = "Low Power Mode";
            this.toolbarLowPowerMode.Click += new System.EventHandler(this.menuViewLowPowerMode_Click);
            // 
            // toolbarSmoothSecondHands
            // 
            this.toolbarSmoothSecondHands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarSmoothSecondHands.Image = global::WatchfaceStudio.Properties.Resources.IconSpeed16;
            this.toolbarSmoothSecondHands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarSmoothSecondHands.Name = "toolbarSmoothSecondHands";
            this.toolbarSmoothSecondHands.Size = new System.Drawing.Size(23, 22);
            this.toolbarSmoothSecondHands.Text = "Smooth Second Hands";
            this.toolbarSmoothSecondHands.Click += new System.EventHandler(this.menuViewSmoothSeconds_Click);
            // 
            // toolbarTemperatureUnits
            // 
            this.toolbarTemperatureUnits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarTemperatureUnits.Image = global::WatchfaceStudio.Properties.Resources.IconFahrenheit16;
            this.toolbarTemperatureUnits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarTemperatureUnits.Name = "toolbarTemperatureUnits";
            this.toolbarTemperatureUnits.Size = new System.Drawing.Size(29, 22);
            this.toolbarTemperatureUnits.Text = "Temperature Units";
            // 
            // toolbarWatchType
            // 
            this.toolbarWatchType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarWatchType.Image = global::WatchfaceStudio.Properties.Resources.IconMediumCircleCut16;
            this.toolbarWatchType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarWatchType.Name = "toolbarWatchType";
            this.toolbarWatchType.Size = new System.Drawing.Size(29, 22);
            this.toolbarWatchType.Text = "Watch Type";
            // 
            // toolbarSeperator1
            // 
            this.toolbarSeperator1.Name = "toolbarSeperator1";
            this.toolbarSeperator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbarAppendixWindow
            // 
            this.toolbarAppendixWindow.Checked = true;
            this.toolbarAppendixWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolbarAppendixWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarAppendixWindow.Image = global::WatchfaceStudio.Properties.Resources.IconHash16;
            this.toolbarAppendixWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarAppendixWindow.Name = "toolbarAppendixWindow";
            this.toolbarAppendixWindow.Size = new System.Drawing.Size(23, 22);
            this.toolbarAppendixWindow.Text = "Appendix Window";
            this.toolbarAppendixWindow.Click += new System.EventHandler(this.menuViewAppendixWindow_Click);
            // 
            // backgroundWorkerCheckForUpdates
            // 
            this.backgroundWorkerCheckForUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCheckForUpdates_DoWork);
            this.backgroundWorkerCheckForUpdates.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCheckForUpdates_RunWorkerCompleted);
            // 
            // panelErrors
            // 
            this.panelErrors.Controls.Add(this.tableLayoutPanelErrors);
            this.panelErrors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelErrors.Location = new System.Drawing.Point(234, 462);
            this.panelErrors.Name = "panelErrors";
            this.panelErrors.Size = new System.Drawing.Size(606, 142);
            this.panelErrors.TabIndex = 8;
            // 
            // tableLayoutPanelErrors
            // 
            this.tableLayoutPanelErrors.ColumnCount = 1;
            this.tableLayoutPanelErrors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelErrors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelErrors.Controls.Add(this.labelErrors, 0, 0);
            this.tableLayoutPanelErrors.Controls.Add(this.listViewErrors, 0, 1);
            this.tableLayoutPanelErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelErrors.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelErrors.Name = "tableLayoutPanelErrors";
            this.tableLayoutPanelErrors.RowCount = 2;
            this.tableLayoutPanelErrors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelErrors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelErrors.Size = new System.Drawing.Size(606, 142);
            this.tableLayoutPanelErrors.TabIndex = 1;
            // 
            // labelErrors
            // 
            this.labelErrors.AutoSize = true;
            this.labelErrors.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.labelErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrors.Location = new System.Drawing.Point(3, 0);
            this.labelErrors.Name = "labelErrors";
            this.labelErrors.Size = new System.Drawing.Size(600, 24);
            this.labelErrors.TabIndex = 2;
            this.labelErrors.Text = "Errors";
            this.labelErrors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listViewErrors
            // 
            this.listViewErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderComponent,
            this.columnHeaderErrorDescription});
            this.listViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewErrors.FullRowSelect = true;
            this.listViewErrors.GridLines = true;
            this.listViewErrors.Location = new System.Drawing.Point(3, 27);
            this.listViewErrors.Name = "listViewErrors";
            this.listViewErrors.Size = new System.Drawing.Size(600, 112);
            this.listViewErrors.SmallImageList = this.imageListErrors;
            this.listViewErrors.TabIndex = 0;
            this.listViewErrors.UseCompatibleStateImageBehavior = false;
            this.listViewErrors.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderComponent
            // 
            this.columnHeaderComponent.Text = "Component";
            this.columnHeaderComponent.Width = 100;
            // 
            // columnHeaderErrorDescription
            // 
            this.columnHeaderErrorDescription.Text = "Description";
            this.columnHeaderErrorDescription.Width = 478;
            // 
            // imageListErrors
            // 
            this.imageListErrors.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListErrors.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListErrors.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StudioForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 604);
            this.Controls.Add(this.panelErrors);
            this.Controls.Add(this.splitterLeft);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.splitContainerRight);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "StudioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Watchface Studio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudioForm_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.StudioForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.StudioForm_DragEnter);
            this.Resize += new System.EventHandler(this.StudioForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.tableLayoutPanelExplorer.ResumeLayout(false);
            this.tableLayoutPanelExplorer.PerformLayout();
            this.panelExplorer.ResumeLayout(false);
            this.panelExplorer.PerformLayout();
            this.toolStripExplorer.ResumeLayout(false);
            this.toolStripExplorer.PerformLayout();
            this.tableLayoutPanelProperties.ResumeLayout(false);
            this.tableLayoutPanelProperties.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.tableLayoutPanelAppendix.ResumeLayout(false);
            this.tableLayoutPanelAppendix.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelErrors.ResumeLayout(false);
            this.tableLayoutPanelErrors.ResumeLayout(false);
            this.tableLayoutPanelErrors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExplorer;
        private System.Windows.Forms.Label labelWatchfaceExplorer;
        private System.Windows.Forms.Panel panelExplorer;
        private System.Windows.Forms.TreeView treeViewExplorer;
        private System.Windows.Forms.ToolStrip toolStripExplorer;
        private System.Windows.Forms.ToolStripButton buttonAddFont;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProperties;
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
        private System.Windows.Forms.ToolStripSeparator toolStripExplorerSeparator0;
        private System.Windows.Forms.ToolStripButton buttonRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuWindow;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripSeparator toolStripExplorerSeparator1;
        private System.Windows.Forms.ToolStripButton buttonAddLayerImage;
        private System.Windows.Forms.ToolStripButton buttonAddLayerShape;
        private System.Windows.Forms.Splitter splitterRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAppendix;
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
        private System.Windows.Forms.ToolStripMenuItem menuViewSmoothSecondHands;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnits;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnitsFahrenheit;
        private System.Windows.Forms.ToolStripMenuItem menuViewUnitsCelsius;
        private System.Windows.Forms.ToolStripMenuItem menuViewDate;
        private System.Windows.Forms.ToolStripMenuItem menuViewDateNow;
        private System.Windows.Forms.ToolStripMenuItem menuViewDateCustom;
        private System.Windows.Forms.ToolStripTextBox menuViewDateCustomDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbarNewWatchface;
        private System.Windows.Forms.ToolStripButton toolbarOpenWatchface;
        private System.Windows.Forms.ToolStripButton toolbarSave;
        private System.Windows.Forms.ToolStripSeparator toolbarSeperator0;
        private System.Windows.Forms.ToolStripButton toolbarLowPowerMode;
        private System.Windows.Forms.ToolStripButton toolbarSmoothSecondHands;
        private System.Windows.Forms.ToolStripSeparator toolbarSeperator1;
        private System.Windows.Forms.ToolStripButton toolbarAppendixWindow;
        private System.Windows.Forms.ToolStripDropDownButton toolbarTemperatureUnits;
        private System.Windows.Forms.ToolStripDropDownButton toolbarWatchType;
        private System.Windows.Forms.ToolStripMenuItem menuHelpCheckForUpdate;
        private System.Windows.Forms.ToolStripSeparator menuHelpSeperator0;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckForUpdates;
        private System.Windows.Forms.Panel panelErrors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelErrors;
        private System.Windows.Forms.Label labelErrors;
        private System.Windows.Forms.ListView listViewErrors;
        private System.Windows.Forms.ColumnHeader columnHeaderComponent;
        private System.Windows.Forms.ColumnHeader columnHeaderErrorDescription;
        private System.Windows.Forms.ImageList imageListErrors;
    }
}

