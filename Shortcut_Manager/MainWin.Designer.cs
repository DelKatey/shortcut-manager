namespace Shortcut_Manager
{
    partial class mainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWin));
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.delButton = new System.Windows.Forms.Button();
            this.modButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.gapPanel1 = new System.Windows.Forms.Panel();
            this.modeGroupBox = new System.Windows.Forms.GroupBox();
            this.edButton = new System.Windows.Forms.Button();
            this.ddButton = new System.Windows.Forms.Button();
            this.ocButton = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendWhenLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDragDropPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultListOnStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autodeleteURLFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLCreationFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleChromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mozillaFirefoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testForInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dragdropParentPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.focusLabel = new System.Windows.Forms.Label();
            this.dragdropPanel = new System.Windows.Forms.Panel();
            this.dragdropGB = new System.Windows.Forms.GroupBox();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.listPanel = new System.Windows.Forms.Panel();
            this.listGroupBox = new System.Windows.Forms.GroupBox();
            this.shortcutLV = new System.Windows.Forms.ListView();
            this.columnHeaderSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shortcutIL = new System.Windows.Forms.ImageList(this.components);
            this.getTitleTimer = new System.Windows.Forms.Timer(this.components);
            this.controlsPanel.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            this.modeGroupBox.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.dragdropParentPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.dragdropPanel.SuspendLayout();
            this.dragdropGB.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.listGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.editGroupBox);
            this.controlsPanel.Controls.Add(this.gapPanel1);
            this.controlsPanel.Controls.Add(this.modeGroupBox);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsPanel.Location = new System.Drawing.Point(0, 203);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Padding = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.controlsPanel.Size = new System.Drawing.Size(587, 77);
            this.controlsPanel.TabIndex = 3;
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.delButton);
            this.editGroupBox.Controls.Add(this.modButton);
            this.editGroupBox.Controls.Add(this.addButton);
            this.editGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editGroupBox.Location = new System.Drawing.Point(298, 10);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Size = new System.Drawing.Size(282, 57);
            this.editGroupBox.TabIndex = 7;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Editing";
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(190, 19);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(86, 27);
            this.delButton.TabIndex = 4;
            this.delButton.Text = "Delete";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // modButton
            // 
            this.modButton.Location = new System.Drawing.Point(98, 19);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(86, 27);
            this.modButton.TabIndex = 3;
            this.modButton.Text = "Modify";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(86, 27);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // gapPanel1
            // 
            this.gapPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gapPanel1.Location = new System.Drawing.Point(290, 10);
            this.gapPanel1.Name = "gapPanel1";
            this.gapPanel1.Size = new System.Drawing.Size(8, 57);
            this.gapPanel1.TabIndex = 6;
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.edButton);
            this.modeGroupBox.Controls.Add(this.ddButton);
            this.modeGroupBox.Controls.Add(this.ocButton);
            this.modeGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.modeGroupBox.Location = new System.Drawing.Point(7, 10);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Size = new System.Drawing.Size(283, 57);
            this.modeGroupBox.TabIndex = 5;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Mode";
            // 
            // edButton
            // 
            this.edButton.Enabled = false;
            this.edButton.Location = new System.Drawing.Point(190, 19);
            this.edButton.Name = "edButton";
            this.edButton.Size = new System.Drawing.Size(86, 27);
            this.edButton.TabIndex = 2;
            this.edButton.Text = "Editing";
            this.edButton.UseVisualStyleBackColor = true;
            this.edButton.Click += new System.EventHandler(this.edButton_Click);
            // 
            // ddButton
            // 
            this.ddButton.Location = new System.Drawing.Point(6, 19);
            this.ddButton.Name = "ddButton";
            this.ddButton.Size = new System.Drawing.Size(86, 27);
            this.ddButton.TabIndex = 0;
            this.ddButton.Text = "Drag && Drop";
            this.ddButton.UseVisualStyleBackColor = true;
            this.ddButton.Click += new System.EventHandler(this.ddButton_Click);
            // 
            // ocButton
            // 
            this.ocButton.Location = new System.Drawing.Point(98, 19);
            this.ocButton.Name = "ocButton";
            this.ocButton.Size = new System.Drawing.Size(86, 27);
            this.ocButton.TabIndex = 1;
            this.ocButton.Text = "Open on click";
            this.ocButton.UseVisualStyleBackColor = true;
            this.ocButton.Click += new System.EventHandler(this.ocButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(587, 24);
            this.mainMenuStrip.TabIndex = 7;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.clearListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem.Text = "Load";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearListToolStripMenuItem.Text = "Clear List";
            this.clearListToolStripMenuItem.Click += new System.EventHandler(this.clearListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.testForInternetToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendWhenLoadingToolStripMenuItem,
            this.showDragDropPanelToolStripMenuItem,
            this.loadDefaultListOnStartToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.autodeleteURLFilesToolStripMenuItem,
            this.uRLCreationFormatToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // appendWhenLoadingToolStripMenuItem
            // 
            this.appendWhenLoadingToolStripMenuItem.Checked = true;
            this.appendWhenLoadingToolStripMenuItem.CheckOnClick = true;
            this.appendWhenLoadingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.appendWhenLoadingToolStripMenuItem.Name = "appendWhenLoadingToolStripMenuItem";
            this.appendWhenLoadingToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.appendWhenLoadingToolStripMenuItem.Text = "Append when loading";
            // 
            // showDragDropPanelToolStripMenuItem
            // 
            this.showDragDropPanelToolStripMenuItem.Checked = true;
            this.showDragDropPanelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showDragDropPanelToolStripMenuItem.Name = "showDragDropPanelToolStripMenuItem";
            this.showDragDropPanelToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.showDragDropPanelToolStripMenuItem.Text = "Show Drag-&&-Drop Panel";
            this.showDragDropPanelToolStripMenuItem.Click += new System.EventHandler(this.showDragDropPanelToolStripMenuItem_Click);
            // 
            // loadDefaultListOnStartToolStripMenuItem
            // 
            this.loadDefaultListOnStartToolStripMenuItem.Checked = true;
            this.loadDefaultListOnStartToolStripMenuItem.CheckOnClick = true;
            this.loadDefaultListOnStartToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadDefaultListOnStartToolStripMenuItem.Name = "loadDefaultListOnStartToolStripMenuItem";
            this.loadDefaultListOnStartToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.loadDefaultListOnStartToolStripMenuItem.Text = "Load Default List on Start";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // autodeleteURLFilesToolStripMenuItem
            // 
            this.autodeleteURLFilesToolStripMenuItem.CheckOnClick = true;
            this.autodeleteURLFilesToolStripMenuItem.Name = "autodeleteURLFilesToolStripMenuItem";
            this.autodeleteURLFilesToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.autodeleteURLFilesToolStripMenuItem.Text = "Auto-delete URL files";
            // 
            // uRLCreationFormatToolStripMenuItem
            // 
            this.uRLCreationFormatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleChromeToolStripMenuItem,
            this.mozillaFirefoxToolStripMenuItem});
            this.uRLCreationFormatToolStripMenuItem.Name = "uRLCreationFormatToolStripMenuItem";
            this.uRLCreationFormatToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.uRLCreationFormatToolStripMenuItem.Text = "URL Creation Format";
            // 
            // googleChromeToolStripMenuItem
            // 
            this.googleChromeToolStripMenuItem.Checked = true;
            this.googleChromeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.googleChromeToolStripMenuItem.Name = "googleChromeToolStripMenuItem";
            this.googleChromeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.googleChromeToolStripMenuItem.Text = "Google Chrome";
            this.googleChromeToolStripMenuItem.Click += new System.EventHandler(this.googleChromeToolStripMenuItem_Click);
            // 
            // mozillaFirefoxToolStripMenuItem
            // 
            this.mozillaFirefoxToolStripMenuItem.Name = "mozillaFirefoxToolStripMenuItem";
            this.mozillaFirefoxToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.mozillaFirefoxToolStripMenuItem.Text = "Mozilla Firefox";
            this.mozillaFirefoxToolStripMenuItem.Click += new System.EventHandler(this.mozillaFirefoxToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.chineseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // chineseToolStripMenuItem
            // 
            this.chineseToolStripMenuItem.Name = "chineseToolStripMenuItem";
            this.chineseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.chineseToolStripMenuItem.Text = "Simplified Chinese";
            this.chineseToolStripMenuItem.Click += new System.EventHandler(this.chineseToolStripMenuItem_Click);
            // 
            // testForInternetToolStripMenuItem
            // 
            this.testForInternetToolStripMenuItem.Name = "testForInternetToolStripMenuItem";
            this.testForInternetToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.testForInternetToolStripMenuItem.Text = "Test for Internet";
            this.testForInternetToolStripMenuItem.Click += new System.EventHandler(this.testForInternetToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dragdropParentPanel
            // 
            this.dragdropParentPanel.Controls.Add(this.panel2);
            this.dragdropParentPanel.Controls.Add(this.dragdropPanel);
            this.dragdropParentPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.dragdropParentPanel.Location = new System.Drawing.Point(0, 24);
            this.dragdropParentPanel.Name = "dragdropParentPanel";
            this.dragdropParentPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.dragdropParentPanel.Size = new System.Drawing.Size(203, 179);
            this.dragdropParentPanel.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.focusLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 26);
            this.panel2.TabIndex = 1;
            // 
            // focusLabel
            // 
            this.focusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.focusLabel.Location = new System.Drawing.Point(0, 0);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(203, 26);
            this.focusLabel.TabIndex = 0;
            // 
            // dragdropPanel
            // 
            this.dragdropPanel.Controls.Add(this.dragdropGB);
            this.dragdropPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dragdropPanel.Location = new System.Drawing.Point(0, 0);
            this.dragdropPanel.Name = "dragdropPanel";
            this.dragdropPanel.Padding = new System.Windows.Forms.Padding(7, 10, 7, 5);
            this.dragdropPanel.Size = new System.Drawing.Size(203, 146);
            this.dragdropPanel.TabIndex = 4;
            // 
            // dragdropGB
            // 
            this.dragdropGB.Controls.Add(this.UrlTextBox);
            this.dragdropGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dragdropGB.Location = new System.Drawing.Point(7, 10);
            this.dragdropGB.Name = "dragdropGB";
            this.dragdropGB.Size = new System.Drawing.Size(189, 131);
            this.dragdropGB.TabIndex = 3;
            this.dragdropGB.TabStop = false;
            this.dragdropGB.Text = "Drag && Drop Shortcuts Here";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.AllowDrop = true;
            this.UrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UrlTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.UrlTextBox.Location = new System.Drawing.Point(3, 16);
            this.UrlTextBox.Multiline = true;
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(183, 112);
            this.UrlTextBox.TabIndex = 0;
            this.UrlTextBox.Text = "\r\n\r\nDrag and drop shortcuts here, one-by-one!";
            this.UrlTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UrlTextBox.Click += new System.EventHandler(this.UrlTextBox_Click);
            this.UrlTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.UrlTextBox_DragDrop);
            this.UrlTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.UrlTextBox_DragEnter);
            this.UrlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UrlTextBox_KeyPress);
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.listGroupBox);
            this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPanel.Location = new System.Drawing.Point(203, 24);
            this.listPanel.Name = "listPanel";
            this.listPanel.Padding = new System.Windows.Forms.Padding(5, 10, 10, 5);
            this.listPanel.Size = new System.Drawing.Size(384, 179);
            this.listPanel.TabIndex = 10;
            // 
            // listGroupBox
            // 
            this.listGroupBox.Controls.Add(this.shortcutLV);
            this.listGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGroupBox.Location = new System.Drawing.Point(5, 10);
            this.listGroupBox.Name = "listGroupBox";
            this.listGroupBox.Size = new System.Drawing.Size(369, 164);
            this.listGroupBox.TabIndex = 0;
            this.listGroupBox.TabStop = false;
            this.listGroupBox.Text = "Shortcuts List";
            // 
            // shortcutLV
            // 
            this.shortcutLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSite,
            this.columnHeaderURL});
            this.shortcutLV.FullRowSelect = true;
            this.shortcutLV.Location = new System.Drawing.Point(3, 16);
            this.shortcutLV.Name = "shortcutLV";
            this.shortcutLV.Size = new System.Drawing.Size(363, 145);
            this.shortcutLV.TabIndex = 4;
            this.shortcutLV.UseCompatibleStateImageBehavior = false;
            this.shortcutLV.View = System.Windows.Forms.View.Details;
            this.shortcutLV.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.shortcutLV_ItemDrag);
            this.shortcutLV.DoubleClick += new System.EventHandler(this.shortcutLV_DoubleClick);
            // 
            // columnHeaderSite
            // 
            this.columnHeaderSite.Text = "Site";
            this.columnHeaderSite.Width = 120;
            // 
            // columnHeaderURL
            // 
            this.columnHeaderURL.Text = "URL";
            this.columnHeaderURL.Width = 500;
            // 
            // shortcutIL
            // 
            this.shortcutIL.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.shortcutIL.ImageSize = new System.Drawing.Size(16, 16);
            this.shortcutIL.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // getTitleTimer
            // 
            this.getTitleTimer.Tick += new System.EventHandler(this.getTitleTimer_Tick);
            // 
            // mainWin
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 280);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.dragdropParentPanel);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(603, 286);
            this.Name = "mainWin";
            this.Text = "Shortcut Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWin_FormClosing);
            this.Load += new System.EventHandler(this.mainWin_Load);
            this.controlsPanel.ResumeLayout(false);
            this.editGroupBox.ResumeLayout(false);
            this.modeGroupBox.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.dragdropParentPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.dragdropPanel.ResumeLayout(false);
            this.dragdropGB.ResumeLayout(false);
            this.dragdropGB.PerformLayout();
            this.listPanel.ResumeLayout(false);
            this.listGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Panel gapPanel1;
        private System.Windows.Forms.GroupBox modeGroupBox;
        private System.Windows.Forms.Button ddButton;
        private System.Windows.Forms.Button ocButton;
        private System.Windows.Forms.Panel dragdropParentPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.Button edButton;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.GroupBox listGroupBox;
        private System.Windows.Forms.ListView shortcutLV;
        private System.Windows.Forms.ColumnHeader columnHeaderSite;
        private System.Windows.Forms.ColumnHeader columnHeaderURL;
        private System.Windows.Forms.ImageList shortcutIL;
        private System.Windows.Forms.Timer getTitleTimer;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label focusLabel;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appendWhenLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDragDropPanelToolStripMenuItem;
        private System.Windows.Forms.Panel dragdropPanel;
        private System.Windows.Forms.GroupBox dragdropGB;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultListOnStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testForInternetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autodeleteURLFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLCreationFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleChromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mozillaFirefoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;

    }
}

