namespace PlcScanner.Dialogs
{
    partial class frmServerConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerConfiguration));
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxMessageSecurityMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxLogLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numTransportQuotas = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApplicationURI = new System.Windows.Forms.TextBox();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddBaseAddress = new System.Windows.Forms.Button();
            this.txtBaseAddress = new System.Windows.Forms.TextBox();
            this.lstBaseAddresses = new System.Windows.Forms.ListBox();
            this.cbxUserPolicy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnApplicationCertificates = new System.Windows.Forms.Button();
            this.txtApplicaitonCertificates = new System.Windows.Forms.TextBox();
            this.lstApplicationCertificates = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddTrustedPeerCertificate = new System.Windows.Forms.Button();
            this.txtTrustedPeerCertificates = new System.Windows.Forms.TextBox();
            this.lstTrustedPeersCertificates = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddTrustedIssuerCertificate = new System.Windows.Forms.Button();
            this.txtTrustedIssuerCertificate = new System.Windows.Forms.TextBox();
            this.lstTrustedIssuerCertificates = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddRejectedCertificate = new System.Windows.Forms.Button();
            this.txtRejectedCertificate = new System.Windows.Forms.TextBox();
            this.lstRejectedCertificates = new System.Windows.Forms.ListBox();
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoAcceptUntrustedCertificate = new System.Windows.Forms.CheckBox();
            this.chkAddCertificateToTrustStore = new System.Windows.Forms.CheckBox();
            this.tmrWatchFolders = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numTransportQuotas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(793, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 32);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.cbxMessageSecurityMode.Location = new System.Drawing.Point(180, 220);
            this.cbxMessageSecurityMode.Name = "cbxMessageSecurityMode";
            this.cbxMessageSecurityMode.Size = new System.Drawing.Size(243, 24);
            this.cbxMessageSecurityMode.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "MessageSecurityMode:";
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
            this.cbxLogLevel.Location = new System.Drawing.Point(180, 188);
            this.cbxLogLevel.Name = "cbxLogLevel";
            this.cbxLogLevel.Size = new System.Drawing.Size(243, 24);
            this.cbxLogLevel.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "LogLevel:";
            // 
            // numTransportQuotas
            // 
            this.numTransportQuotas.Location = new System.Drawing.Point(180, 158);
            this.numTransportQuotas.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numTransportQuotas.Name = "numTransportQuotas";
            this.numTransportQuotas.Size = new System.Drawing.Size(243, 22);
            this.numTransportQuotas.TabIndex = 28;
            this.numTransportQuotas.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "TransportQuotas:";
            // 
            // txtApplicationURI
            // 
            this.txtApplicationURI.Location = new System.Drawing.Point(180, 12);
            this.txtApplicationURI.Name = "txtApplicationURI";
            this.txtApplicationURI.Size = new System.Drawing.Size(243, 22);
            this.txtApplicationURI.TabIndex = 22;
            this.txtApplicationURI.Text = "opc.tcp://localhost:4840";
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(21, 15);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(100, 16);
            this.lblEndpoint.TabIndex = 21;
            this.lblEndpoint.Text = "ApplicationURI:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(706, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddBaseAddress);
            this.groupBox2.Controls.Add(this.txtBaseAddress);
            this.groupBox2.Controls.Add(this.lstBaseAddresses);
            this.groupBox2.Location = new System.Drawing.Point(15, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 116);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BaseAddresses";
            // 
            // btnAddBaseAddress
            // 
            this.btnAddBaseAddress.Location = new System.Drawing.Point(354, 80);
            this.btnAddBaseAddress.Name = "btnAddBaseAddress";
            this.btnAddBaseAddress.Size = new System.Drawing.Size(54, 27);
            this.btnAddBaseAddress.TabIndex = 25;
            this.btnAddBaseAddress.Text = "Add";
            this.btnAddBaseAddress.UseVisualStyleBackColor = true;
            this.btnAddBaseAddress.Click += new System.EventHandler(this.btnAddBaseAddress_Click);
            // 
            // txtBaseAddress
            // 
            this.txtBaseAddress.Location = new System.Drawing.Point(9, 80);
            this.txtBaseAddress.Name = "txtBaseAddress";
            this.txtBaseAddress.Size = new System.Drawing.Size(339, 22);
            this.txtBaseAddress.TabIndex = 24;
            // 
            // lstBaseAddresses
            // 
            this.lstBaseAddresses.FormattingEnabled = true;
            this.lstBaseAddresses.ItemHeight = 16;
            this.lstBaseAddresses.Location = new System.Drawing.Point(9, 22);
            this.lstBaseAddresses.Name = "lstBaseAddresses";
            this.lstBaseAddresses.Size = new System.Drawing.Size(399, 52);
            this.lstBaseAddresses.TabIndex = 0;
            this.lstBaseAddresses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstBaseAddresses_KeyDown);
            // 
            // cbxUserPolicy
            // 
            this.cbxUserPolicy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxUserPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUserPolicy.FormattingEnabled = true;
            this.cbxUserPolicy.Items.AddRange(new object[] {
            "Anonymous",
            "UserName",
            "Certificate",
            "IssuedToken"});
            this.cbxUserPolicy.Location = new System.Drawing.Point(180, 251);
            this.cbxUserPolicy.Name = "cbxUserPolicy";
            this.cbxUserPolicy.Size = new System.Drawing.Size(243, 24);
            this.cbxUserPolicy.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "User Policy: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnApplicationCertificates);
            this.groupBox1.Controls.Add(this.txtApplicaitonCertificates);
            this.groupBox1.Controls.Add(this.lstApplicationCertificates);
            this.groupBox1.Location = new System.Drawing.Point(15, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 116);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ApplicationCertificates";
            // 
            // btnApplicationCertificates
            // 
            this.btnApplicationCertificates.Location = new System.Drawing.Point(354, 80);
            this.btnApplicationCertificates.Name = "btnApplicationCertificates";
            this.btnApplicationCertificates.Size = new System.Drawing.Size(54, 27);
            this.btnApplicationCertificates.TabIndex = 25;
            this.btnApplicationCertificates.Text = "Add";
            this.btnApplicationCertificates.UseVisualStyleBackColor = true;
            this.btnApplicationCertificates.Click += new System.EventHandler(this.btnApplicationCertificates_Click);
            // 
            // txtApplicaitonCertificates
            // 
            this.txtApplicaitonCertificates.Location = new System.Drawing.Point(9, 80);
            this.txtApplicaitonCertificates.Name = "txtApplicaitonCertificates";
            this.txtApplicaitonCertificates.ReadOnly = true;
            this.txtApplicaitonCertificates.Size = new System.Drawing.Size(339, 22);
            this.txtApplicaitonCertificates.TabIndex = 24;
            this.txtApplicaitonCertificates.Click += new System.EventHandler(this.txtApplicaitonCertificates_Click);
            // 
            // lstApplicationCertificates
            // 
            this.lstApplicationCertificates.FormattingEnabled = true;
            this.lstApplicationCertificates.ItemHeight = 16;
            this.lstApplicationCertificates.Location = new System.Drawing.Point(9, 22);
            this.lstApplicationCertificates.Name = "lstApplicationCertificates";
            this.lstApplicationCertificates.Size = new System.Drawing.Size(399, 52);
            this.lstApplicationCertificates.TabIndex = 0;
            this.lstApplicationCertificates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstApplicationCertificates_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddTrustedPeerCertificate);
            this.groupBox3.Controls.Add(this.txtTrustedPeerCertificates);
            this.groupBox3.Controls.Add(this.lstTrustedPeersCertificates);
            this.groupBox3.Location = new System.Drawing.Point(455, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 116);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trusted Peer Certificates";
            // 
            // btnAddTrustedPeerCertificate
            // 
            this.btnAddTrustedPeerCertificate.Location = new System.Drawing.Point(354, 80);
            this.btnAddTrustedPeerCertificate.Name = "btnAddTrustedPeerCertificate";
            this.btnAddTrustedPeerCertificate.Size = new System.Drawing.Size(54, 27);
            this.btnAddTrustedPeerCertificate.TabIndex = 25;
            this.btnAddTrustedPeerCertificate.Text = "Add";
            this.btnAddTrustedPeerCertificate.UseVisualStyleBackColor = true;
            this.btnAddTrustedPeerCertificate.Click += new System.EventHandler(this.btnAddTrustedPeerCertificate_Click);
            // 
            // txtTrustedPeerCertificates
            // 
            this.txtTrustedPeerCertificates.Location = new System.Drawing.Point(9, 80);
            this.txtTrustedPeerCertificates.Name = "txtTrustedPeerCertificates";
            this.txtTrustedPeerCertificates.Size = new System.Drawing.Size(339, 22);
            this.txtTrustedPeerCertificates.TabIndex = 24;
            this.txtTrustedPeerCertificates.Click += new System.EventHandler(this.txtTrustedPeerCertificates_Click);
            // 
            // lstTrustedPeersCertificates
            // 
            this.lstTrustedPeersCertificates.FormattingEnabled = true;
            this.lstTrustedPeersCertificates.ItemHeight = 16;
            this.lstTrustedPeersCertificates.Location = new System.Drawing.Point(9, 22);
            this.lstTrustedPeersCertificates.Name = "lstTrustedPeersCertificates";
            this.lstTrustedPeersCertificates.Size = new System.Drawing.Size(399, 52);
            this.lstTrustedPeersCertificates.TabIndex = 0;
            this.lstTrustedPeersCertificates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTrustedPeersCertificates_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddTrustedIssuerCertificate);
            this.groupBox4.Controls.Add(this.txtTrustedIssuerCertificate);
            this.groupBox4.Controls.Add(this.lstTrustedIssuerCertificates);
            this.groupBox4.Location = new System.Drawing.Point(458, 170);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(420, 116);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trusted Issuer Certificates";
            // 
            // btnAddTrustedIssuerCertificate
            // 
            this.btnAddTrustedIssuerCertificate.Location = new System.Drawing.Point(354, 80);
            this.btnAddTrustedIssuerCertificate.Name = "btnAddTrustedIssuerCertificate";
            this.btnAddTrustedIssuerCertificate.Size = new System.Drawing.Size(54, 27);
            this.btnAddTrustedIssuerCertificate.TabIndex = 25;
            this.btnAddTrustedIssuerCertificate.Text = "Add";
            this.btnAddTrustedIssuerCertificate.UseVisualStyleBackColor = true;
            this.btnAddTrustedIssuerCertificate.Click += new System.EventHandler(this.btnAddTrustedIssuerCertificate_Click);
            // 
            // txtTrustedIssuerCertificate
            // 
            this.txtTrustedIssuerCertificate.Location = new System.Drawing.Point(9, 80);
            this.txtTrustedIssuerCertificate.Name = "txtTrustedIssuerCertificate";
            this.txtTrustedIssuerCertificate.Size = new System.Drawing.Size(339, 22);
            this.txtTrustedIssuerCertificate.TabIndex = 24;
            this.txtTrustedIssuerCertificate.Click += new System.EventHandler(this.txtTrustedIssuerCertificate_Click);
            // 
            // lstTrustedIssuerCertificates
            // 
            this.lstTrustedIssuerCertificates.FormattingEnabled = true;
            this.lstTrustedIssuerCertificates.ItemHeight = 16;
            this.lstTrustedIssuerCertificates.Location = new System.Drawing.Point(9, 22);
            this.lstTrustedIssuerCertificates.Name = "lstTrustedIssuerCertificates";
            this.lstTrustedIssuerCertificates.Size = new System.Drawing.Size(399, 52);
            this.lstTrustedIssuerCertificates.TabIndex = 0;
            this.lstTrustedIssuerCertificates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstTrustedIssuerCertificates_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddRejectedCertificate);
            this.groupBox5.Controls.Add(this.txtRejectedCertificate);
            this.groupBox5.Controls.Add(this.lstRejectedCertificates);
            this.groupBox5.Location = new System.Drawing.Point(455, 292);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(420, 116);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rejected Certificates";
            // 
            // btnAddRejectedCertificate
            // 
            this.btnAddRejectedCertificate.Location = new System.Drawing.Point(354, 80);
            this.btnAddRejectedCertificate.Name = "btnAddRejectedCertificate";
            this.btnAddRejectedCertificate.Size = new System.Drawing.Size(54, 27);
            this.btnAddRejectedCertificate.TabIndex = 25;
            this.btnAddRejectedCertificate.Text = "Add";
            this.btnAddRejectedCertificate.UseVisualStyleBackColor = true;
            this.btnAddRejectedCertificate.Click += new System.EventHandler(this.btnAddRejectedCertificate_Click);
            // 
            // txtRejectedCertificate
            // 
            this.txtRejectedCertificate.Location = new System.Drawing.Point(9, 80);
            this.txtRejectedCertificate.Name = "txtRejectedCertificate";
            this.txtRejectedCertificate.Size = new System.Drawing.Size(339, 22);
            this.txtRejectedCertificate.TabIndex = 24;
            this.txtRejectedCertificate.Click += new System.EventHandler(this.txtRejectedCertificate_Click);
            // 
            // lstRejectedCertificates
            // 
            this.lstRejectedCertificates.FormattingEnabled = true;
            this.lstRejectedCertificates.ItemHeight = 16;
            this.lstRejectedCertificates.Location = new System.Drawing.Point(9, 22);
            this.lstRejectedCertificates.Name = "lstRejectedCertificates";
            this.lstRejectedCertificates.Size = new System.Drawing.Size(399, 52);
            this.lstRejectedCertificates.TabIndex = 0;
            this.lstRejectedCertificates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstRejectedCertificates_KeyDown);
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.Location = new System.Drawing.Point(567, 12);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(287, 22);
            this.txtSubjectName.TabIndex = 41;
            this.txtSubjectName.Text = "opc.tcp://localhost:4840";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Subject Name: ";
            // 
            // chkAutoAcceptUntrustedCertificate
            // 
            this.chkAutoAcceptUntrustedCertificate.AutoSize = true;
            this.chkAutoAcceptUntrustedCertificate.Location = new System.Drawing.Point(24, 421);
            this.chkAutoAcceptUntrustedCertificate.Name = "chkAutoAcceptUntrustedCertificate";
            this.chkAutoAcceptUntrustedCertificate.Size = new System.Drawing.Size(200, 20);
            this.chkAutoAcceptUntrustedCertificate.TabIndex = 42;
            this.chkAutoAcceptUntrustedCertificate.Text = "Accept Untrusted Certificates";
            this.chkAutoAcceptUntrustedCertificate.UseVisualStyleBackColor = true;
            // 
            // chkAddCertificateToTrustStore
            // 
            this.chkAddCertificateToTrustStore.AutoSize = true;
            this.chkAddCertificateToTrustStore.Location = new System.Drawing.Point(230, 421);
            this.chkAddCertificateToTrustStore.Name = "chkAddCertificateToTrustStore";
            this.chkAddCertificateToTrustStore.Size = new System.Drawing.Size(242, 20);
            this.chkAddCertificateToTrustStore.TabIndex = 43;
            this.chkAddCertificateToTrustStore.Text = "Add App Certificate to Trusted Store";
            this.chkAddCertificateToTrustStore.UseVisualStyleBackColor = true;
            // 
            // tmrWatchFolders
            // 
            this.tmrWatchFolders.Interval = 3000;
            this.tmrWatchFolders.Tick += new System.EventHandler(this.tmrWatchFolders_Tick);
            // 
            // frmServerConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.chkAddCertificateToTrustStore);
            this.Controls.Add(this.chkAutoAcceptUntrustedCertificate);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxUserPolicy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbxLogLevel);
            this.Controls.Add(this.numTransportQuotas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtApplicationURI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEndpoint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxMessageSecurityMode);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServerConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurazione Server";
            ((System.ComponentModel.ISupportInitialize)(this.numTransportQuotas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbxMessageSecurityMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxLogLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numTransportQuotas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApplicationURI;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddBaseAddress;
        private System.Windows.Forms.TextBox txtBaseAddress;
        private System.Windows.Forms.ListBox lstBaseAddresses;
        private System.Windows.Forms.ComboBox cbxUserPolicy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApplicationCertificates;
        private System.Windows.Forms.TextBox txtApplicaitonCertificates;
        private System.Windows.Forms.ListBox lstApplicationCertificates;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddTrustedPeerCertificate;
        private System.Windows.Forms.TextBox txtTrustedPeerCertificates;
        private System.Windows.Forms.ListBox lstTrustedPeersCertificates;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddTrustedIssuerCertificate;
        private System.Windows.Forms.TextBox txtTrustedIssuerCertificate;
        private System.Windows.Forms.ListBox lstTrustedIssuerCertificates;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddRejectedCertificate;
        private System.Windows.Forms.TextBox txtRejectedCertificate;
        private System.Windows.Forms.ListBox lstRejectedCertificates;
        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoAcceptUntrustedCertificate;
        private System.Windows.Forms.CheckBox chkAddCertificateToTrustStore;
        private System.Windows.Forms.Timer tmrWatchFolders;
    }
}