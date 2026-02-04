namespace PlcScanner
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaNuovaConfigurazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaConfigurazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esportaConfigurazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstConfigurations = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsConfigurationBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsConfigurationBtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsConfigurationBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsConfigurationBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsConfigurationBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tcClientServer = new System.Windows.Forms.TabControl();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.twClientNodes = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            this.gwClientNodeId = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn();
            this.ctxMenuClientTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.readSyncronouslyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeSyncronouslyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gwClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwClientValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwClientTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwClientStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwClientSubscribed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSubscibeTags = new System.Windows.Forms.Button();
            this.btnExploreRoutines = new System.Windows.Forms.Button();
            this.lblRoutineLenght = new System.Windows.Forms.Label();
            this.btnRegisterRoutine = new System.Windows.Forms.Button();
            this.btnRunClientDiscovery = new System.Windows.Forms.Button();
            this.btnEditClientConfiguration = new System.Windows.Forms.Button();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.btnEditServerConfiguration = new System.Windows.Forms.Button();
            this.btnAddRoutine = new System.Windows.Forms.Button();
            this.dgRoutines = new System.Windows.Forms.DataGridView();
            this.lblRoutines = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartSimulationServer = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gwHistorian = new System.Windows.Forms.DataGridView();
            this.gwHistorianType = new System.Windows.Forms.DataGridViewImageColumn();
            this.gwHistorianProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwHistorianProjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwHistorianMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwHistorianTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxListConfigutations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realoadConfigurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrRoutine = new System.Windows.Forms.Timer(this.components);
            this.ctxRoutineTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tcClientServer.SuspendLayout();
            this.tabClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twClientNodes)).BeginInit();
            this.ctxMenuClientTable.SuspendLayout();
            this.tabServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoutines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gwHistorian)).BeginInit();
            this.ctxListConfigutations.SuspendLayout();
            this.ctxRoutineTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(935, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaNuovaConfigurazioneToolStripMenuItem,
            this.importaConfigurazioneToolStripMenuItem,
            this.esportaConfigurazioneToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // creaNuovaConfigurazioneToolStripMenuItem
            // 
            this.creaNuovaConfigurazioneToolStripMenuItem.Name = "creaNuovaConfigurazioneToolStripMenuItem";
            this.creaNuovaConfigurazioneToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.creaNuovaConfigurazioneToolStripMenuItem.Text = "Create new configuration";
            this.creaNuovaConfigurazioneToolStripMenuItem.Click += new System.EventHandler(this.creaNuovaConfigurazioneToolStripMenuItem_Click);
            // 
            // importaConfigurazioneToolStripMenuItem
            // 
            this.importaConfigurazioneToolStripMenuItem.Name = "importaConfigurazioneToolStripMenuItem";
            this.importaConfigurazioneToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.importaConfigurazioneToolStripMenuItem.Text = "Import Configuration";
            this.importaConfigurazioneToolStripMenuItem.Click += new System.EventHandler(this.importaConfigurazioneToolStripMenuItem_Click);
            // 
            // esportaConfigurazioneToolStripMenuItem
            // 
            this.esportaConfigurazioneToolStripMenuItem.Name = "esportaConfigurazioneToolStripMenuItem";
            this.esportaConfigurazioneToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.esportaConfigurazioneToolStripMenuItem.Text = "Export Configuration";
            this.esportaConfigurazioneToolStripMenuItem.Click += new System.EventHandler(this.esportaConfigurazioneToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.esciToolStripMenuItem.Text = "Exit";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(935, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 20);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstConfigurations);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.tcClientServer);
            this.splitContainer1.Size = new System.Drawing.Size(935, 272);
            this.splitContainer1.SplitterDistance = 310;
            this.splitContainer1.TabIndex = 3;
            // 
            // lstConfigurations
            // 
            this.lstConfigurations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstConfigurations.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstConfigurations.FormattingEnabled = true;
            this.lstConfigurations.ItemHeight = 32;
            this.lstConfigurations.Location = new System.Drawing.Point(0, 27);
            this.lstConfigurations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstConfigurations.Name = "lstConfigurations";
            this.lstConfigurations.Size = new System.Drawing.Size(310, 245);
            this.lstConfigurations.TabIndex = 1;
            this.lstConfigurations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstConfigurations_DrawItem);
            this.lstConfigurations.SelectedIndexChanged += new System.EventHandler(this.lstConfigurations_SelectedIndexChanged);
            this.lstConfigurations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstConfigurations_MouseDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConfigurationBtnAdd,
            this.tsConfigurationBtnEdit,
            this.tsConfigurationBtnCopy,
            this.tsConfigurationBtnDelete,
            this.toolStripSeparator1,
            this.tsConfigurationBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(310, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsConfigurationBtnAdd
            // 
            this.tsConfigurationBtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfigurationBtnAdd.Image = global::PlcScanner.Properties.Resources.IconAdd;
            this.tsConfigurationBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfigurationBtnAdd.Name = "tsConfigurationBtnAdd";
            this.tsConfigurationBtnAdd.Size = new System.Drawing.Size(29, 24);
            this.tsConfigurationBtnAdd.Click += new System.EventHandler(this.tsConfigurationBtnAdd_Click);
            // 
            // tsConfigurationBtnEdit
            // 
            this.tsConfigurationBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfigurationBtnEdit.Enabled = false;
            this.tsConfigurationBtnEdit.Image = global::PlcScanner.Properties.Resources.IconEdit;
            this.tsConfigurationBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfigurationBtnEdit.Name = "tsConfigurationBtnEdit";
            this.tsConfigurationBtnEdit.Size = new System.Drawing.Size(29, 24);
            this.tsConfigurationBtnEdit.Click += new System.EventHandler(this.tsConfigurationBtnEdit_Click);
            // 
            // tsConfigurationBtnCopy
            // 
            this.tsConfigurationBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfigurationBtnCopy.Enabled = false;
            this.tsConfigurationBtnCopy.Image = global::PlcScanner.Properties.Resources.IconCopy;
            this.tsConfigurationBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfigurationBtnCopy.Name = "tsConfigurationBtnCopy";
            this.tsConfigurationBtnCopy.Size = new System.Drawing.Size(29, 24);
            this.tsConfigurationBtnCopy.Click += new System.EventHandler(this.tsConfigurationBtnCopy_Click);
            // 
            // tsConfigurationBtnDelete
            // 
            this.tsConfigurationBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfigurationBtnDelete.Enabled = false;
            this.tsConfigurationBtnDelete.Image = global::PlcScanner.Properties.Resources.IconDelete;
            this.tsConfigurationBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfigurationBtnDelete.Name = "tsConfigurationBtnDelete";
            this.tsConfigurationBtnDelete.Size = new System.Drawing.Size(29, 24);
            this.tsConfigurationBtnDelete.Click += new System.EventHandler(this.tsConfigurationBtnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsConfigurationBtnRefresh
            // 
            this.tsConfigurationBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsConfigurationBtnRefresh.Image = global::PlcScanner.Properties.Resources.IconRefresh;
            this.tsConfigurationBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConfigurationBtnRefresh.Name = "tsConfigurationBtnRefresh";
            this.tsConfigurationBtnRefresh.Size = new System.Drawing.Size(29, 24);
            this.tsConfigurationBtnRefresh.Click += new System.EventHandler(this.tsConfigurationBtnRefresh_Click);
            // 
            // tcClientServer
            // 
            this.tcClientServer.Controls.Add(this.tabClient);
            this.tcClientServer.Controls.Add(this.tabServer);
            this.tcClientServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcClientServer.Location = new System.Drawing.Point(0, 0);
            this.tcClientServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcClientServer.Name = "tcClientServer";
            this.tcClientServer.SelectedIndex = 0;
            this.tcClientServer.Size = new System.Drawing.Size(621, 272);
            this.tcClientServer.TabIndex = 0;
            // 
            // tabClient
            // 
            this.tabClient.Controls.Add(this.twClientNodes);
            this.tabClient.Controls.Add(this.btnSubscibeTags);
            this.tabClient.Controls.Add(this.btnExploreRoutines);
            this.tabClient.Controls.Add(this.lblRoutineLenght);
            this.tabClient.Controls.Add(this.btnRegisterRoutine);
            this.tabClient.Controls.Add(this.btnRunClientDiscovery);
            this.tabClient.Controls.Add(this.btnEditClientConfiguration);
            this.tabClient.Controls.Add(this.btnClientConnect);
            this.tabClient.Controls.Add(this.lblClientStatus);
            this.tabClient.Controls.Add(this.label1);
            this.tabClient.Location = new System.Drawing.Point(4, 25);
            this.tabClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabClient.Size = new System.Drawing.Size(613, 243);
            this.tabClient.TabIndex = 0;
            this.tabClient.Text = "Client";
            this.tabClient.UseVisualStyleBackColor = true;
            // 
            // twClientNodes
            // 
            this.twClientNodes.AllowUserToAddRows = false;
            this.twClientNodes.AllowUserToDeleteRows = false;
            this.twClientNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.twClientNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.twClientNodes.ColumnHeadersHeight = 36;
            this.twClientNodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gwClientNodeId,
            this.gwClientName,
            this.gwClientValue,
            this.gwClientTimestamp,
            this.gwClientStatus,
            this.gwClientSubscribed});
            this.twClientNodes.DataSource = null;
            this.twClientNodes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.twClientNodes.ImageList = null;
            this.twClientNodes.Location = new System.Drawing.Point(23, 43);
            this.twClientNodes.Name = "twClientNodes";
            this.twClientNodes.RowHeadersWidth = 51;
            this.twClientNodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.twClientNodes.Size = new System.Drawing.Size(591, 155);
            this.twClientNodes.TabIndex = 10;
            // 
            // gwClientNodeId
            // 
            this.gwClientNodeId.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientNodeId.DefaultNodeImage = null;
            this.gwClientNodeId.HeaderText = "Name";
            this.gwClientNodeId.MinimumWidth = 6;
            this.gwClientNodeId.Name = "gwClientNodeId";
            this.gwClientNodeId.ReadOnly = true;
            this.gwClientNodeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gwClientNodeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gwClientNodeId.Width = 125;
            // 
            // ctxMenuClientTable
            // 
            this.ctxMenuClientTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxMenuClientTable.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenuClientTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readSyncronouslyToolStripMenuItem,
            this.writeSyncronouslyToolStripMenuItem});
            this.ctxMenuClientTable.Name = "ctxMenuClientTable";
            this.ctxMenuClientTable.Size = new System.Drawing.Size(205, 52);
            // 
            // readSyncronouslyToolStripMenuItem
            // 
            this.readSyncronouslyToolStripMenuItem.Name = "readSyncronouslyToolStripMenuItem";
            this.readSyncronouslyToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.readSyncronouslyToolStripMenuItem.Text = "Read Syncronously";
            this.readSyncronouslyToolStripMenuItem.Click += new System.EventHandler(this.readSyncronouslyToolStripMenuItem_Click);
            // 
            // writeSyncronouslyToolStripMenuItem
            // 
            this.writeSyncronouslyToolStripMenuItem.Name = "writeSyncronouslyToolStripMenuItem";
            this.writeSyncronouslyToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.writeSyncronouslyToolStripMenuItem.Text = "Write Syncronously";
            this.writeSyncronouslyToolStripMenuItem.Click += new System.EventHandler(this.writeSyncronouslyToolStripMenuItem_Click);
            // 
            // gwClientName
            // 
            this.gwClientName.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientName.HeaderText = "NodeId";
            this.gwClientName.MinimumWidth = 6;
            this.gwClientName.Name = "gwClientName";
            this.gwClientName.ReadOnly = true;
            this.gwClientName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gwClientName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gwClientName.Width = 125;
            // 
            // gwClientValue
            // 
            this.gwClientValue.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientValue.HeaderText = "Value";
            this.gwClientValue.MinimumWidth = 6;
            this.gwClientValue.Name = "gwClientValue";
            this.gwClientValue.ReadOnly = true;
            this.gwClientValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gwClientValue.Width = 125;
            // 
            // gwClientTimestamp
            // 
            this.gwClientTimestamp.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientTimestamp.HeaderText = "TimeStamp";
            this.gwClientTimestamp.MinimumWidth = 6;
            this.gwClientTimestamp.Name = "gwClientTimestamp";
            this.gwClientTimestamp.ReadOnly = true;
            this.gwClientTimestamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gwClientTimestamp.Width = 125;
            // 
            // gwClientStatus
            // 
            this.gwClientStatus.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientStatus.HeaderText = "Status";
            this.gwClientStatus.MinimumWidth = 6;
            this.gwClientStatus.Name = "gwClientStatus";
            this.gwClientStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gwClientStatus.Width = 125;
            // 
            // gwClientSubscribed
            // 
            this.gwClientSubscribed.ContextMenuStrip = this.ctxMenuClientTable;
            this.gwClientSubscribed.HeaderText = "Subscribed";
            this.gwClientSubscribed.MinimumWidth = 6;
            this.gwClientSubscribed.Name = "gwClientSubscribed";
            this.gwClientSubscribed.ReadOnly = true;
            this.gwClientSubscribed.Width = 125;
            // 
            // btnSubscibeTags
            // 
            this.btnSubscibeTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubscibeTags.Location = new System.Drawing.Point(128, 203);
            this.btnSubscibeTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSubscibeTags.Name = "btnSubscibeTags";
            this.btnSubscibeTags.Size = new System.Drawing.Size(133, 31);
            this.btnSubscibeTags.TabIndex = 9;
            this.btnSubscibeTags.Text = "Subscribe Tags";
            this.btnSubscibeTags.UseVisualStyleBackColor = true;
            this.btnSubscibeTags.Click += new System.EventHandler(this.btnSubscibeTags_Click);
            // 
            // btnExploreRoutines
            // 
            this.btnExploreRoutines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExploreRoutines.Location = new System.Drawing.Point(6, 203);
            this.btnExploreRoutines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExploreRoutines.Name = "btnExploreRoutines";
            this.btnExploreRoutines.Size = new System.Drawing.Size(116, 31);
            this.btnExploreRoutines.TabIndex = 8;
            this.btnExploreRoutines.Text = "View Routines";
            this.btnExploreRoutines.UseVisualStyleBackColor = true;
            this.btnExploreRoutines.Click += new System.EventHandler(this.btnExploreRoutines_Click);
            // 
            // lblRoutineLenght
            // 
            this.lblRoutineLenght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoutineLenght.AutoSize = true;
            this.lblRoutineLenght.Location = new System.Drawing.Point(404, 210);
            this.lblRoutineLenght.Name = "lblRoutineLenght";
            this.lblRoutineLenght.Size = new System.Drawing.Size(55, 16);
            this.lblRoutineLenght.TabIndex = 7;
            this.lblRoutineLenght.Text = "00:00:00";
            // 
            // btnRegisterRoutine
            // 
            this.btnRegisterRoutine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterRoutine.Location = new System.Drawing.Point(474, 203);
            this.btnRegisterRoutine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegisterRoutine.Name = "btnRegisterRoutine";
            this.btnRegisterRoutine.Size = new System.Drawing.Size(131, 31);
            this.btnRegisterRoutine.TabIndex = 6;
            this.btnRegisterRoutine.Text = "Register Routine";
            this.btnRegisterRoutine.UseVisualStyleBackColor = true;
            this.btnRegisterRoutine.Click += new System.EventHandler(this.btnRegisterRoutine_Click);
            // 
            // btnRunClientDiscovery
            // 
            this.btnRunClientDiscovery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunClientDiscovery.Location = new System.Drawing.Point(349, 7);
            this.btnRunClientDiscovery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunClientDiscovery.Name = "btnRunClientDiscovery";
            this.btnRunClientDiscovery.Size = new System.Drawing.Size(119, 31);
            this.btnRunClientDiscovery.TabIndex = 5;
            this.btnRunClientDiscovery.Text = "Run Discovery";
            this.btnRunClientDiscovery.UseVisualStyleBackColor = true;
            this.btnRunClientDiscovery.Click += new System.EventHandler(this.btnRunClientDiscovery_Click);
            // 
            // btnEditClientConfiguration
            // 
            this.btnEditClientConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditClientConfiguration.Location = new System.Drawing.Point(474, 7);
            this.btnEditClientConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditClientConfiguration.Name = "btnEditClientConfiguration";
            this.btnEditClientConfiguration.Size = new System.Drawing.Size(131, 31);
            this.btnEditClientConfiguration.TabIndex = 3;
            this.btnEditClientConfiguration.Text = "Edit Configuration";
            this.btnEditClientConfiguration.UseVisualStyleBackColor = true;
            this.btnEditClientConfiguration.Click += new System.EventHandler(this.btnEditClientConfiguration_Click);
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientConnect.Location = new System.Drawing.Point(227, 7);
            this.btnClientConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(116, 31);
            this.btnClientConnect.TabIndex = 2;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.AutoSize = true;
            this.lblClientStatus.Location = new System.Drawing.Point(80, 14);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(90, 16);
            this.lblClientStatus.TabIndex = 1;
            this.lblClientStatus.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status: ";
            // 
            // tabServer
            // 
            this.tabServer.Controls.Add(this.btnEditServerConfiguration);
            this.tabServer.Controls.Add(this.btnAddRoutine);
            this.tabServer.Controls.Add(this.dgRoutines);
            this.tabServer.Controls.Add(this.lblRoutines);
            this.tabServer.Controls.Add(this.lblServerStatus);
            this.tabServer.Controls.Add(this.label2);
            this.tabServer.Controls.Add(this.btnStartSimulationServer);
            this.tabServer.Location = new System.Drawing.Point(4, 25);
            this.tabServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabServer.Name = "tabServer";
            this.tabServer.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabServer.Size = new System.Drawing.Size(613, 245);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "Server";
            this.tabServer.UseVisualStyleBackColor = true;
            // 
            // btnEditServerConfiguration
            // 
            this.btnEditServerConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditServerConfiguration.Location = new System.Drawing.Point(474, 5);
            this.btnEditServerConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditServerConfiguration.Name = "btnEditServerConfiguration";
            this.btnEditServerConfiguration.Size = new System.Drawing.Size(131, 31);
            this.btnEditServerConfiguration.TabIndex = 6;
            this.btnEditServerConfiguration.Text = "Edit Configuration";
            this.btnEditServerConfiguration.UseVisualStyleBackColor = true;
            this.btnEditServerConfiguration.Click += new System.EventHandler(this.btnEditServerConfiguration_Click);
            // 
            // btnAddRoutine
            // 
            this.btnAddRoutine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRoutine.Location = new System.Drawing.Point(501, 211);
            this.btnAddRoutine.Name = "btnAddRoutine";
            this.btnAddRoutine.Size = new System.Drawing.Size(104, 31);
            this.btnAddRoutine.TabIndex = 5;
            this.btnAddRoutine.Text = "Add Routine";
            this.btnAddRoutine.UseVisualStyleBackColor = true;
            this.btnAddRoutine.Click += new System.EventHandler(this.btnAddRoutine_Click);
            // 
            // dgRoutines
            // 
            this.dgRoutines.AllowUserToAddRows = false;
            this.dgRoutines.AllowUserToDeleteRows = false;
            this.dgRoutines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRoutines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRoutines.Location = new System.Drawing.Point(9, 60);
            this.dgRoutines.Name = "dgRoutines";
            this.dgRoutines.ReadOnly = true;
            this.dgRoutines.RowHeadersWidth = 51;
            this.dgRoutines.RowTemplate.Height = 24;
            this.dgRoutines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRoutines.Size = new System.Drawing.Size(596, 149);
            this.dgRoutines.TabIndex = 4;
            this.dgRoutines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgRoutines_DataBindingComplete);
            // 
            // lblRoutines
            // 
            this.lblRoutines.AutoSize = true;
            this.lblRoutines.Location = new System.Drawing.Point(6, 40);
            this.lblRoutines.Name = "lblRoutines";
            this.lblRoutines.Size = new System.Drawing.Size(132, 16);
            this.lblRoutines.TabIndex = 3;
            this.lblRoutines.Text = "Routine in execution: ";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(62, 12);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(90, 16);
            this.lblServerStatus.TabIndex = 2;
            this.lblServerStatus.Text = "Disconnected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status: ";
            // 
            // btnStartSimulationServer
            // 
            this.btnStartSimulationServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartSimulationServer.Location = new System.Drawing.Point(364, 5);
            this.btnStartSimulationServer.Name = "btnStartSimulationServer";
            this.btnStartSimulationServer.Size = new System.Drawing.Size(104, 31);
            this.btnStartSimulationServer.TabIndex = 0;
            this.btnStartSimulationServer.Text = "Start Server";
            this.btnStartSimulationServer.UseVisualStyleBackColor = true;
            this.btnStartSimulationServer.Click += new System.EventHandler(this.btnStartSimulationServer_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 30);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gwHistorian);
            this.splitContainer2.Size = new System.Drawing.Size(935, 401);
            this.splitContainer2.SplitterDistance = 272;
            this.splitContainer2.TabIndex = 5;
            // 
            // gwHistorian
            // 
            this.gwHistorian.AllowUserToAddRows = false;
            this.gwHistorian.AllowUserToDeleteRows = false;
            this.gwHistorian.AllowUserToOrderColumns = true;
            this.gwHistorian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gwHistorian.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gwHistorianType,
            this.gwHistorianProjectName,
            this.gwHistorianProjectType,
            this.gwHistorianMessage,
            this.gwHistorianTimestamp});
            this.gwHistorian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gwHistorian.Location = new System.Drawing.Point(0, 0);
            this.gwHistorian.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gwHistorian.Name = "gwHistorian";
            this.gwHistorian.ReadOnly = true;
            this.gwHistorian.RowHeadersVisible = false;
            this.gwHistorian.RowHeadersWidth = 51;
            this.gwHistorian.RowTemplate.Height = 24;
            this.gwHistorian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gwHistorian.Size = new System.Drawing.Size(935, 125);
            this.gwHistorian.TabIndex = 0;
            this.gwHistorian.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gwHistorian_DataBindingComplete);
            // 
            // gwHistorianType
            // 
            this.gwHistorianType.HeaderText = "Type";
            this.gwHistorianType.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.gwHistorianType.MinimumWidth = 6;
            this.gwHistorianType.Name = "gwHistorianType";
            this.gwHistorianType.ReadOnly = true;
            this.gwHistorianType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gwHistorianType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gwHistorianType.Width = 125;
            // 
            // gwHistorianProjectName
            // 
            this.gwHistorianProjectName.HeaderText = "Project";
            this.gwHistorianProjectName.MinimumWidth = 6;
            this.gwHistorianProjectName.Name = "gwHistorianProjectName";
            this.gwHistorianProjectName.ReadOnly = true;
            this.gwHistorianProjectName.Width = 125;
            // 
            // gwHistorianProjectType
            // 
            this.gwHistorianProjectType.HeaderText = "Location";
            this.gwHistorianProjectType.MinimumWidth = 6;
            this.gwHistorianProjectType.Name = "gwHistorianProjectType";
            this.gwHistorianProjectType.ReadOnly = true;
            this.gwHistorianProjectType.Width = 125;
            // 
            // gwHistorianMessage
            // 
            this.gwHistorianMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gwHistorianMessage.HeaderText = "Message";
            this.gwHistorianMessage.MinimumWidth = 6;
            this.gwHistorianMessage.Name = "gwHistorianMessage";
            this.gwHistorianMessage.ReadOnly = true;
            // 
            // gwHistorianTimestamp
            // 
            this.gwHistorianTimestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gwHistorianTimestamp.HeaderText = "Timestamp";
            this.gwHistorianTimestamp.MinimumWidth = 6;
            this.gwHistorianTimestamp.Name = "gwHistorianTimestamp";
            this.gwHistorianTimestamp.ReadOnly = true;
            this.gwHistorianTimestamp.Width = 104;
            // 
            // ctxListConfigutations
            // 
            this.ctxListConfigutations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxListConfigutations.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxListConfigutations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createConfigurationToolStripMenuItem,
            this.realoadConfigurationsToolStripMenuItem,
            this.copyConfigurationToolStripMenuItem,
            this.editConfigurationToolStripMenuItem,
            this.deleteConfigurationToolStripMenuItem});
            this.ctxListConfigutations.Name = "ctxListConfigutations";
            this.ctxListConfigutations.Size = new System.Drawing.Size(227, 124);
            // 
            // createConfigurationToolStripMenuItem
            // 
            this.createConfigurationToolStripMenuItem.Name = "createConfigurationToolStripMenuItem";
            this.createConfigurationToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.createConfigurationToolStripMenuItem.Text = "Create Configuration";
            this.createConfigurationToolStripMenuItem.Click += new System.EventHandler(this.createConfigurationToolStripMenuItem_Click);
            // 
            // realoadConfigurationsToolStripMenuItem
            // 
            this.realoadConfigurationsToolStripMenuItem.Name = "realoadConfigurationsToolStripMenuItem";
            this.realoadConfigurationsToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.realoadConfigurationsToolStripMenuItem.Text = "Reload Configurations";
            this.realoadConfigurationsToolStripMenuItem.Click += new System.EventHandler(this.realoadConfigurationsToolStripMenuItem_Click);
            // 
            // copyConfigurationToolStripMenuItem
            // 
            this.copyConfigurationToolStripMenuItem.Name = "copyConfigurationToolStripMenuItem";
            this.copyConfigurationToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.copyConfigurationToolStripMenuItem.Text = "Copy Configuration";
            this.copyConfigurationToolStripMenuItem.Click += new System.EventHandler(this.copyConfigurationToolStripMenuItem_Click);
            // 
            // editConfigurationToolStripMenuItem
            // 
            this.editConfigurationToolStripMenuItem.Name = "editConfigurationToolStripMenuItem";
            this.editConfigurationToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.editConfigurationToolStripMenuItem.Text = "Edit Configuration";
            this.editConfigurationToolStripMenuItem.Click += new System.EventHandler(this.editConfigurationToolStripMenuItem_Click);
            // 
            // deleteConfigurationToolStripMenuItem
            // 
            this.deleteConfigurationToolStripMenuItem.Name = "deleteConfigurationToolStripMenuItem";
            this.deleteConfigurationToolStripMenuItem.Size = new System.Drawing.Size(226, 24);
            this.deleteConfigurationToolStripMenuItem.Text = "Delete Configuration";
            this.deleteConfigurationToolStripMenuItem.Click += new System.EventHandler(this.deleteConfigurationToolStripMenuItem_Click);
            // 
            // tmrRoutine
            // 
            this.tmrRoutine.Enabled = true;
            this.tmrRoutine.Tick += new System.EventHandler(this.tmrRoutine_Tick);
            // 
            // ctxRoutineTables
            // 
            this.ctxRoutineTables.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxRoutineTables.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxRoutineTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.ctxRoutineTables.Name = "ctxRoutineTables";
            this.ctxRoutineTables.Size = new System.Drawing.Size(229, 76);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.startToolStripMenuItem.Text = "Start Routine";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.pauseToolStripMenuItem.Text = "Pause/Resume Routine";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(228, 24);
            this.stopToolStripMenuItem.Text = "Stop Routine";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 457);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "PlcScanner";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tcClientServer.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twClientNodes)).EndInit();
            this.ctxMenuClientTable.ResumeLayout(false);
            this.tabServer.ResumeLayout(false);
            this.tabServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRoutines)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gwHistorian)).EndInit();
            this.ctxListConfigutations.ResumeLayout(false);
            this.ctxRoutineTables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaNuovaConfigurazioneToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstConfigurations;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tcClientServer;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.TabPage tabServer;
        private System.Windows.Forms.Button btnEditClientConfiguration;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunClientDiscovery;
        private System.Windows.Forms.Label lblRoutineLenght;
        private System.Windows.Forms.Button btnRegisterRoutine;
        private System.Windows.Forms.Button btnExploreRoutines;
        private System.Windows.Forms.ContextMenuStrip ctxMenuClientTable;
        private System.Windows.Forms.ToolStripMenuItem readSyncronouslyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeSyncronouslyToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView gwHistorian;
        private System.Windows.Forms.ContextMenuStrip ctxListConfigutations;
        private System.Windows.Forms.ToolStripMenuItem createConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realoadConfigurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsConfigurationBtnAdd;
        private System.Windows.Forms.ToolStripButton tsConfigurationBtnCopy;
        private System.Windows.Forms.ToolStripButton tsConfigurationBtnEdit;
        private System.Windows.Forms.ToolStripButton tsConfigurationBtnRefresh;
        private System.Windows.Forms.ToolStripButton tsConfigurationBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnStartSimulationServer;
        private System.Windows.Forms.Timer tmrRoutine;
        private System.Windows.Forms.Button btnSubscibeTags;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRoutines;
        private System.Windows.Forms.Button btnAddRoutine;
        private System.Windows.Forms.DataGridView dgRoutines;
        private System.Windows.Forms.ContextMenuStrip ctxRoutineTables;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Button btnEditServerConfiguration;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView twClientNodes;
        private System.Windows.Forms.ToolStripMenuItem importaConfigurazioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esportaConfigurazioneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.DataGridViewImageColumn gwHistorianType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwHistorianProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwHistorianProjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwHistorianMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwHistorianTimestamp;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn gwClientNodeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwClientValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwClientTimestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwClientStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gwClientSubscribed;
    }
}

