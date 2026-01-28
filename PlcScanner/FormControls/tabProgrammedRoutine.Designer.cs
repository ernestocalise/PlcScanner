namespace PlcScanner.FormControls
{
    partial class tabProgrammedRoutine
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsAddStep = new System.Windows.Forms.ToolStripButton();
            this.tsDeleteStep = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlCurrentStep = new System.Windows.Forms.Panel();
            this.tcConditionActions = new System.Windows.Forms.TabControl();
            this.tbConditions = new System.Windows.Forms.TabPage();
            this.lblAddCondition = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedConditionTarget = new System.Windows.Forms.MaskedTextBox();
            this.cbxConditionTarget = new System.Windows.Forms.ComboBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxConditionNodeId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxConditionType = new System.Windows.Forms.ComboBox();
            this.lblConditionDescription = new System.Windows.Forms.Label();
            this.lstConditions = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbActions = new System.Windows.Forms.TabPage();
            this.lstRoutineSteps = new System.Windows.Forms.ListBox();
            this.lblTargetTime = new System.Windows.Forms.Label();
            this.btnConditionApply = new System.Windows.Forms.Button();
            this.btnConditionRestore = new System.Windows.Forms.Button();
            this.lvlAddAction = new System.Windows.Forms.LinkLabel();
            this.lstActions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActionRestore = new System.Windows.Forms.Button();
            this.btnActionApply = new System.Windows.Forms.Button();
            this.cbxActionValue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxActionNodeId = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxActionType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlCurrentStep.SuspendLayout();
            this.tcConditionActions.SuspendLayout();
            this.tbConditions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbActions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddStep,
            this.tsDeleteStep});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsAddStep
            // 
            this.tsAddStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAddStep.Image = global::PlcScanner.Properties.Resources.IconAdd;
            this.tsAddStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddStep.Name = "tsAddStep";
            this.tsAddStep.Size = new System.Drawing.Size(29, 24);
            this.tsAddStep.Text = "Add Step";
            this.tsAddStep.Click += new System.EventHandler(this.tsAddStep_Click);
            // 
            // tsDeleteStep
            // 
            this.tsDeleteStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDeleteStep.Image = global::PlcScanner.Properties.Resources.IconDelete;
            this.tsDeleteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDeleteStep.Name = "tsDeleteStep";
            this.tsDeleteStep.Size = new System.Drawing.Size(29, 24);
            this.tsDeleteStep.Text = "Remove Step";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlCurrentStep);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstRoutineSteps);
            this.splitContainer1.Size = new System.Drawing.Size(794, 471);
            this.splitContainer1.SplitterDistance = 611;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnlCurrentStep
            // 
            this.pnlCurrentStep.Controls.Add(this.tcConditionActions);
            this.pnlCurrentStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCurrentStep.Location = new System.Drawing.Point(0, 0);
            this.pnlCurrentStep.Name = "pnlCurrentStep";
            this.pnlCurrentStep.Size = new System.Drawing.Size(611, 471);
            this.pnlCurrentStep.TabIndex = 0;
            // 
            // tcConditionActions
            // 
            this.tcConditionActions.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcConditionActions.Controls.Add(this.tbConditions);
            this.tcConditionActions.Controls.Add(this.tbActions);
            this.tcConditionActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConditionActions.Location = new System.Drawing.Point(0, 0);
            this.tcConditionActions.Multiline = true;
            this.tcConditionActions.Name = "tcConditionActions";
            this.tcConditionActions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tcConditionActions.SelectedIndex = 0;
            this.tcConditionActions.Size = new System.Drawing.Size(611, 471);
            this.tcConditionActions.TabIndex = 0;
            this.tcConditionActions.Visible = false;
            // 
            // tbConditions
            // 
            this.tbConditions.Controls.Add(this.lblAddCondition);
            this.tbConditions.Controls.Add(this.groupBox1);
            this.tbConditions.Controls.Add(this.lstConditions);
            this.tbConditions.Controls.Add(this.label1);
            this.tbConditions.Location = new System.Drawing.Point(4, 4);
            this.tbConditions.Name = "tbConditions";
            this.tbConditions.Padding = new System.Windows.Forms.Padding(3);
            this.tbConditions.Size = new System.Drawing.Size(603, 442);
            this.tbConditions.TabIndex = 0;
            this.tbConditions.Text = "Conditions";
            this.tbConditions.UseVisualStyleBackColor = true;
            // 
            // lblAddCondition
            // 
            this.lblAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddCondition.AutoSize = true;
            this.lblAddCondition.Location = new System.Drawing.Point(488, 8);
            this.lblAddCondition.Name = "lblAddCondition";
            this.lblAddCondition.Size = new System.Drawing.Size(91, 16);
            this.lblAddCondition.TabIndex = 3;
            this.lblAddCondition.TabStop = true;
            this.lblAddCondition.Text = "Add Condition";
            this.lblAddCondition.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddCondition_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnConditionRestore);
            this.groupBox1.Controls.Add(this.btnConditionApply);
            this.groupBox1.Controls.Add(this.lblTargetTime);
            this.groupBox1.Controls.Add(this.maskedConditionTarget);
            this.groupBox1.Controls.Add(this.cbxConditionTarget);
            this.groupBox1.Controls.Add(this.lblTarget);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbxConditionNodeId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxConditionType);
            this.groupBox1.Controls.Add(this.lblConditionDescription);
            this.groupBox1.Location = new System.Drawing.Point(19, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 289);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition Editor";
            this.groupBox1.Visible = false;
            // 
            // maskedConditionTarget
            // 
            this.maskedConditionTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedConditionTarget.Enabled = false;
            this.maskedConditionTarget.Location = new System.Drawing.Point(114, 222);
            this.maskedConditionTarget.Mask = "00:00";
            this.maskedConditionTarget.Name = "maskedConditionTarget";
            this.maskedConditionTarget.Size = new System.Drawing.Size(397, 22);
            this.maskedConditionTarget.TabIndex = 7;
            this.maskedConditionTarget.ValidatingType = typeof(System.DateTime);
            this.maskedConditionTarget.TextChanged += new System.EventHandler(this.maskedConditionTarget_TextChanged);
            // 
            // cbxConditionTarget
            // 
            this.cbxConditionTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConditionTarget.FormattingEnabled = true;
            this.cbxConditionTarget.Location = new System.Drawing.Point(114, 181);
            this.cbxConditionTarget.Name = "cbxConditionTarget";
            this.cbxConditionTarget.Size = new System.Drawing.Size(397, 24);
            this.cbxConditionTarget.TabIndex = 6;
            this.cbxConditionTarget.TextChanged += new System.EventHandler(this.cbxConditionTarget_TextChanged);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(21, 184);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(47, 16);
            this.lblTarget.TabIndex = 5;
            this.lblTarget.Text = "Target";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Condition";
            // 
            // cbxConditionNodeId
            // 
            this.cbxConditionNodeId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConditionNodeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConditionNodeId.FormattingEnabled = true;
            this.cbxConditionNodeId.Location = new System.Drawing.Point(114, 94);
            this.cbxConditionNodeId.Name = "cbxConditionNodeId";
            this.cbxConditionNodeId.Size = new System.Drawing.Size(397, 24);
            this.cbxConditionNodeId.TabIndex = 3;
            this.cbxConditionNodeId.SelectedIndexChanged += new System.EventHandler(this.cbxConditionNodeId_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "NodeId: ";
            // 
            // cbxConditionType
            // 
            this.cbxConditionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxConditionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxConditionType.FormattingEnabled = true;
            this.cbxConditionType.Items.AddRange(new object[] {
            "Equals",
            "Not Equals",
            "Bigger Than",
            "Lower Than",
            "Count Equals",
            "Count Lower Than",
            "Count Bigger Than",
            "Starts With",
            "Ends With",
            "Contains",
            "Does Not Contains",
            "Before Time",
            "After Time"});
            this.cbxConditionType.Location = new System.Drawing.Point(114, 140);
            this.cbxConditionType.Name = "cbxConditionType";
            this.cbxConditionType.Size = new System.Drawing.Size(397, 24);
            this.cbxConditionType.TabIndex = 1;
            this.cbxConditionType.SelectedIndexChanged += new System.EventHandler(this.cbxConditionType_SelectedIndexChanged);
            // 
            // lblConditionDescription
            // 
            this.lblConditionDescription.AutoSize = true;
            this.lblConditionDescription.Location = new System.Drawing.Point(21, 30);
            this.lblConditionDescription.Name = "lblConditionDescription";
            this.lblConditionDescription.Size = new System.Drawing.Size(150, 16);
            this.lblConditionDescription.TabIndex = 0;
            this.lblConditionDescription.Text = "Select a Condition type: ";
            // 
            // lstConditions
            // 
            this.lstConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstConditions.FormattingEnabled = true;
            this.lstConditions.ItemHeight = 16;
            this.lstConditions.Location = new System.Drawing.Point(19, 27);
            this.lstConditions.Name = "lstConditions";
            this.lstConditions.Size = new System.Drawing.Size(560, 84);
            this.lstConditions.TabIndex = 1;
            this.lstConditions.SelectedIndexChanged += new System.EventHandler(this.lstConditions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conditions:";
            // 
            // tbActions
            // 
            this.tbActions.Controls.Add(this.groupBox2);
            this.tbActions.Controls.Add(this.lvlAddAction);
            this.tbActions.Controls.Add(this.lstActions);
            this.tbActions.Controls.Add(this.label4);
            this.tbActions.Location = new System.Drawing.Point(4, 4);
            this.tbActions.Name = "tbActions";
            this.tbActions.Padding = new System.Windows.Forms.Padding(3);
            this.tbActions.Size = new System.Drawing.Size(603, 442);
            this.tbActions.TabIndex = 1;
            this.tbActions.Text = "Actions";
            this.tbActions.UseVisualStyleBackColor = true;
            // 
            // lstRoutineSteps
            // 
            this.lstRoutineSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoutineSteps.FormattingEnabled = true;
            this.lstRoutineSteps.ItemHeight = 16;
            this.lstRoutineSteps.Location = new System.Drawing.Point(0, 0);
            this.lstRoutineSteps.Name = "lstRoutineSteps";
            this.lstRoutineSteps.Size = new System.Drawing.Size(179, 471);
            this.lstRoutineSteps.TabIndex = 0;
            this.lstRoutineSteps.SelectedIndexChanged += new System.EventHandler(this.lstRoutineSteps_SelectedIndexChanged);
            // 
            // lblTargetTime
            // 
            this.lblTargetTime.AutoSize = true;
            this.lblTargetTime.Enabled = false;
            this.lblTargetTime.Location = new System.Drawing.Point(21, 225);
            this.lblTargetTime.Name = "lblTargetTime";
            this.lblTargetTime.Size = new System.Drawing.Size(87, 16);
            this.lblTargetTime.TabIndex = 8;
            this.lblTargetTime.Text = "Target Time: ";
            // 
            // btnConditionApply
            // 
            this.btnConditionApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConditionApply.Location = new System.Drawing.Point(357, 248);
            this.btnConditionApply.Name = "btnConditionApply";
            this.btnConditionApply.Size = new System.Drawing.Size(93, 35);
            this.btnConditionApply.TabIndex = 9;
            this.btnConditionApply.Text = "Apply";
            this.btnConditionApply.UseVisualStyleBackColor = true;
            this.btnConditionApply.Click += new System.EventHandler(this.btnConditionApply_Click);
            // 
            // btnConditionRestore
            // 
            this.btnConditionRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConditionRestore.Location = new System.Drawing.Point(456, 248);
            this.btnConditionRestore.Name = "btnConditionRestore";
            this.btnConditionRestore.Size = new System.Drawing.Size(93, 35);
            this.btnConditionRestore.TabIndex = 10;
            this.btnConditionRestore.Text = "Restore";
            this.btnConditionRestore.UseVisualStyleBackColor = true;
            this.btnConditionRestore.Click += new System.EventHandler(this.btnConditionRestore_Click);
            // 
            // lvlAddAction
            // 
            this.lvlAddAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvlAddAction.AutoSize = true;
            this.lvlAddAction.Location = new System.Drawing.Point(497, 4);
            this.lvlAddAction.Name = "lvlAddAction";
            this.lvlAddAction.Size = new System.Drawing.Size(78, 16);
            this.lvlAddAction.TabIndex = 6;
            this.lvlAddAction.TabStop = true;
            this.lvlAddAction.Text = "Add Action: ";
            this.lvlAddAction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lvlAddAction_LinkClicked);
            // 
            // lstActions
            // 
            this.lstActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstActions.FormattingEnabled = true;
            this.lstActions.ItemHeight = 16;
            this.lstActions.Location = new System.Drawing.Point(28, 23);
            this.lstActions.Name = "lstActions";
            this.lstActions.Size = new System.Drawing.Size(560, 84);
            this.lstActions.TabIndex = 5;
            this.lstActions.SelectedIndexChanged += new System.EventHandler(this.lstActions_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Actions: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnActionRestore);
            this.groupBox2.Controls.Add(this.btnActionApply);
            this.groupBox2.Controls.Add(this.cbxActionValue);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxActionNodeId);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbxActionType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(28, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 289);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions Editor";
            this.groupBox2.Visible = false;
            // 
            // btnActionRestore
            // 
            this.btnActionRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActionRestore.Location = new System.Drawing.Point(450, 248);
            this.btnActionRestore.Name = "btnActionRestore";
            this.btnActionRestore.Size = new System.Drawing.Size(93, 35);
            this.btnActionRestore.TabIndex = 10;
            this.btnActionRestore.Text = "Restore";
            this.btnActionRestore.UseVisualStyleBackColor = true;
            this.btnActionRestore.Click += new System.EventHandler(this.btnActionRestore_Click);
            // 
            // btnActionApply
            // 
            this.btnActionApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActionApply.Location = new System.Drawing.Point(351, 248);
            this.btnActionApply.Name = "btnActionApply";
            this.btnActionApply.Size = new System.Drawing.Size(93, 35);
            this.btnActionApply.TabIndex = 9;
            this.btnActionApply.Text = "Apply";
            this.btnActionApply.UseVisualStyleBackColor = true;
            this.btnActionApply.Click += new System.EventHandler(this.btnActionApply_Click);
            // 
            // cbxActionValue
            // 
            this.cbxActionValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxActionValue.FormattingEnabled = true;
            this.cbxActionValue.Location = new System.Drawing.Point(114, 181);
            this.cbxActionValue.Name = "cbxActionValue";
            this.cbxActionValue.Size = new System.Drawing.Size(397, 24);
            this.cbxActionValue.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Action: ";
            // 
            // cbxActionNodeId
            // 
            this.cbxActionNodeId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxActionNodeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActionNodeId.FormattingEnabled = true;
            this.cbxActionNodeId.Location = new System.Drawing.Point(114, 94);
            this.cbxActionNodeId.Name = "cbxActionNodeId";
            this.cbxActionNodeId.Size = new System.Drawing.Size(397, 24);
            this.cbxActionNodeId.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "NodeId: ";
            // 
            // cbxActionType
            // 
            this.cbxActionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActionType.FormattingEnabled = true;
            this.cbxActionType.Items.AddRange(new object[] {
            "Write",
            "Increment",
            "Decrement",
            "Sleep",
            "EmptyArray"});
            this.cbxActionType.Location = new System.Drawing.Point(114, 140);
            this.cbxActionType.Name = "cbxActionType";
            this.cbxActionType.Size = new System.Drawing.Size(397, 24);
            this.cbxActionType.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Select an Action Type";
            // 
            // tabProgrammedRoutine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "tabProgrammedRoutine";
            this.Size = new System.Drawing.Size(794, 498);
            this.Load += new System.EventHandler(this.tabProgrammedRoutine_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlCurrentStep.ResumeLayout(false);
            this.tcConditionActions.ResumeLayout(false);
            this.tbConditions.ResumeLayout(false);
            this.tbConditions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbActions.ResumeLayout(false);
            this.tbActions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstRoutineSteps;
        private System.Windows.Forms.Panel pnlCurrentStep;
        private System.Windows.Forms.ToolStripButton tsAddStep;
        private System.Windows.Forms.ToolStripButton tsDeleteStep;
        private System.Windows.Forms.TabControl tcConditionActions;
        private System.Windows.Forms.TabPage tbConditions;
        private System.Windows.Forms.TabPage tbActions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxConditionType;
        private System.Windows.Forms.Label lblConditionDescription;
        private System.Windows.Forms.ListBox lstConditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxConditionNodeId;
        private System.Windows.Forms.ComboBox cbxConditionTarget;
        private System.Windows.Forms.MaskedTextBox maskedConditionTarget;
        private System.Windows.Forms.LinkLabel lblAddCondition;
        private System.Windows.Forms.Label lblTargetTime;
        private System.Windows.Forms.Button btnConditionRestore;
        private System.Windows.Forms.Button btnConditionApply;
        private System.Windows.Forms.LinkLabel lvlAddAction;
        private System.Windows.Forms.ListBox lstActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnActionRestore;
        private System.Windows.Forms.Button btnActionApply;
        private System.Windows.Forms.ComboBox cbxActionValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxActionNodeId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxActionType;
        private System.Windows.Forms.Label label9;
    }
}
