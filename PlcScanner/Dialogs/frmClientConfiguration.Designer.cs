namespace PlcScanner
{
    partial class frmClientConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientConfiguration));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.txtDiscoveryNodeId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numClientTimeout = new System.Windows.Forms.NumericUpDown();
            this.numTransportQuotas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLogLevel = new System.Windows.Forms.ComboBox();
            this.cbxMessageSecurityMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCertificationSubjectName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCertificationStoreType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCertStorePath = new System.Windows.Forms.Button();
            this.txtCertificationStorePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numClientTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransportQuotas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 26);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nome: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(148, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(305, 22);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "New Project";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 366);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Location = new System.Drawing.Point(148, 51);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(305, 22);
            this.txtEndpoint.TabIndex = 5;
            this.txtEndpoint.Text = "opc.tcp://localhost:4840";
            this.txtEndpoint.TextChanged += new System.EventHandler(this.txtEndpoint_TextChanged);
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(23, 54);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(83, 16);
            this.lblEndpoint.TabIndex = 4;
            this.lblEndpoint.Text = "EndpointUrl: ";
            // 
            // txtDiscoveryNodeId
            // 
            this.txtDiscoveryNodeId.Location = new System.Drawing.Point(148, 79);
            this.txtDiscoveryNodeId.Name = "txtDiscoveryNodeId";
            this.txtDiscoveryNodeId.Size = new System.Drawing.Size(305, 22);
            this.txtDiscoveryNodeId.TabIndex = 7;
            this.txtDiscoveryNodeId.Text = "ns=3; s=\"DataBlockGlobal\"";
            this.txtDiscoveryNodeId.TextChanged += new System.EventHandler(this.txtDiscoveryNodeId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "DiscoveryNodeId: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "ClientTimeout: ";
            // 
            // numClientTimeout
            // 
            this.numClientTimeout.Location = new System.Drawing.Point(148, 107);
            this.numClientTimeout.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numClientTimeout.Name = "numClientTimeout";
            this.numClientTimeout.Size = new System.Drawing.Size(305, 22);
            this.numClientTimeout.TabIndex = 9;
            this.numClientTimeout.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numClientTimeout.ValueChanged += new System.EventHandler(this.numClientTimeout_ValueChanged);
            // 
            // numTransportQuotas
            // 
            this.numTransportQuotas.Location = new System.Drawing.Point(148, 135);
            this.numTransportQuotas.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numTransportQuotas.Name = "numTransportQuotas";
            this.numTransportQuotas.Size = new System.Drawing.Size(305, 22);
            this.numTransportQuotas.TabIndex = 11;
            this.numTransportQuotas.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numTransportQuotas.ValueChanged += new System.EventHandler(this.numTransportQuotas_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "TransportQuotas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "LogLevel:";
            // 
            // cbxLogLevel
            // 
            this.cbxLogLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLogLevel.FormattingEnabled = true;
            this.cbxLogLevel.Items.AddRange(new object[] {
            "Debug",
            "Info",
            "Warning",
            "Error"});
            this.cbxLogLevel.Location = new System.Drawing.Point(148, 163);
            this.cbxLogLevel.Name = "cbxLogLevel";
            this.cbxLogLevel.Size = new System.Drawing.Size(305, 24);
            this.cbxLogLevel.TabIndex = 13;
            this.cbxLogLevel.SelectedIndexChanged += new System.EventHandler(this.cbxLogLevel_SelectedIndexChanged);
            // 
            // cbxMessageSecurityMode
            // 
            this.cbxMessageSecurityMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxMessageSecurityMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMessageSecurityMode.FormattingEnabled = true;
            this.cbxMessageSecurityMode.Items.AddRange(new object[] {
            "Invalid",
            "None",
            "Sign",
            "SignAndEncrypt"});
            this.cbxMessageSecurityMode.Location = new System.Drawing.Point(171, 39);
            this.cbxMessageSecurityMode.Name = "cbxMessageSecurityMode";
            this.cbxMessageSecurityMode.Size = new System.Drawing.Size(250, 24);
            this.cbxMessageSecurityMode.TabIndex = 15;
            this.cbxMessageSecurityMode.SelectedIndexChanged += new System.EventHandler(this.cbxMessageSecurityMode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "MessageSecurityMode:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCertificationSubjectName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCertificationStoreType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCertStorePath);
            this.groupBox1.Controls.Add(this.txtCertificationStorePath);
            this.groupBox1.Controls.Add(this.cbxMessageSecurityMode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 159);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // txtCertificationSubjectName
            // 
            this.txtCertificationSubjectName.Location = new System.Drawing.Point(172, 131);
            this.txtCertificationSubjectName.Name = "txtCertificationSubjectName";
            this.txtCertificationSubjectName.Size = new System.Drawing.Size(249, 22);
            this.txtCertificationSubjectName.TabIndex = 23;
            this.txtCertificationSubjectName.TextChanged += new System.EventHandler(this.txtCertificationSubjectName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Certificate Subject Name:";
            // 
            // txtCertificationStoreType
            // 
            this.txtCertificationStoreType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCertificationStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtCertificationStoreType.FormattingEnabled = true;
            this.txtCertificationStoreType.Items.AddRange(new object[] {
            "Folder",
            "X509Store"});
            this.txtCertificationStoreType.Location = new System.Drawing.Point(171, 97);
            this.txtCertificationStoreType.Name = "txtCertificationStoreType";
            this.txtCertificationStoreType.Size = new System.Drawing.Size(250, 24);
            this.txtCertificationStoreType.TabIndex = 21;
            this.txtCertificationStoreType.SelectedIndexChanged += new System.EventHandler(this.txtCertificationStoreType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Certification Store Type: ";
            // 
            // btnCertStorePath
            // 
            this.btnCertStorePath.Location = new System.Drawing.Point(387, 68);
            this.btnCertStorePath.Name = "btnCertStorePath";
            this.btnCertStorePath.Size = new System.Drawing.Size(33, 25);
            this.btnCertStorePath.TabIndex = 19;
            this.btnCertStorePath.Text = "...";
            this.btnCertStorePath.UseVisualStyleBackColor = true;
            this.btnCertStorePath.Click += new System.EventHandler(this.btnCertStorePath_Click);
            // 
            // txtCertificationStorePath
            // 
            this.txtCertificationStorePath.Location = new System.Drawing.Point(171, 69);
            this.txtCertificationStorePath.Name = "txtCertificationStorePath";
            this.txtCertificationStorePath.Size = new System.Drawing.Size(210, 22);
            this.txtCertificationStorePath.TabIndex = 18;
            this.txtCertificationStorePath.TextChanged += new System.EventHandler(this.txtCertificationStorePath_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Certification Store Path: ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmClientConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 403);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxLogLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTransportQuotas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numClientTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiscoveryNodeId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEndpoint);
            this.Controls.Add(this.lblEndpoint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Configuration";
            this.Load += new System.EventHandler(this.frmCreateConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numClientTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransportQuotas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.TextBox txtDiscoveryNodeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numClientTimeout;
        private System.Windows.Forms.NumericUpDown numTransportQuotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLogLevel;
        private System.Windows.Forms.ComboBox cbxMessageSecurityMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCertificationStorePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCertStorePath;
        private System.Windows.Forms.TextBox txtCertificationSubjectName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtCertificationStoreType;
        private System.Windows.Forms.Button btnCancel;
    }
}