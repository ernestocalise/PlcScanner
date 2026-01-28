using Opc.Ua;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlcScanner
{
    public partial class frmClientConfiguration : Form
    {
        public PlcConfiguration plcConfig;
        public frmClientConfiguration()
        {
            InitializeComponent();
            plcConfig = new PlcConfiguration();
            cbxLogLevel.SelectedIndex = 0;
            cbxMessageSecurityMode.SelectedIndex = 1;
            plcConfig.ConfigurationName = this.txtName.Text;
            plcConfig.EndpointUrl = this.txtEndpoint.Text;
            plcConfig.DiscoveryNodeId = this.txtDiscoveryNodeId.Text;
            plcConfig.ClientTimeout = (int)this.numClientTimeout.Value;
            plcConfig.TransportQuotasTimeout = (int)this.numTransportQuotas.Value;
            plcConfig.LogLevel = this.cbxLogLevel.SelectedIndex;
            plcConfig.SecurityMode = (MessageSecurityMode)this.cbxMessageSecurityMode.SelectedIndex;
            plcConfig.CertificateStorePath = this.txtCertificationStorePath.Text;
            plcConfig.CertificateStoreType = this.txtCertificationStoreType.Text;
            plcConfig.CertificateSubjectName = this.txtCertificationSubjectName.Text;
        }
        public frmClientConfiguration(PlcConfiguration config)
        {
            InitializeComponent();
            plcConfig = config;
            config.OldConfigurationName = plcConfig.ConfigurationName;
            this.txtName.Text = plcConfig.ConfigurationName;
            this.txtEndpoint.Text = plcConfig.EndpointUrl;
            this.txtDiscoveryNodeId.Text = plcConfig.DiscoveryNodeId;
            this.numClientTimeout.Value = plcConfig.ClientTimeout;
            this.numTransportQuotas.Value = plcConfig.TransportQuotasTimeout;
            this.cbxLogLevel.SelectedIndex = plcConfig.LogLevel;
            this.cbxMessageSecurityMode.SelectedIndex = (int)plcConfig.SecurityMode;
            this.txtCertificationStorePath.Text = plcConfig.CertificateStorePath;
            this.txtCertificationStoreType.Text = plcConfig.CertificateStoreType;
            this.txtCertificationSubjectName.Text = plcConfig.CertificateSubjectName;
        }
        public void setConfigurationName(string NewConfigurationName)
        {
            this.plcConfig.ConfigurationName = NewConfigurationName;
            this.txtName.Text = NewConfigurationName;
        }
        private bool ValidateForm()
        {
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmCreateConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void cbxMessageSecurityMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            plcConfig.SecurityMode = (MessageSecurityMode)cbxMessageSecurityMode.SelectedIndex;
            if (cbxMessageSecurityMode.SelectedIndex <= 1)
            {
                txtCertificationStorePath.Enabled = false;
                txtCertificationStoreType.Enabled = false;
                txtCertificationSubjectName.Enabled = false;
                btnCertStorePath.Enabled = false;
            }
            else
            {
                txtCertificationStorePath.Enabled = true;
                txtCertificationStoreType.Enabled = true;
                txtCertificationSubjectName.Enabled = true;
                btnCertStorePath.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            plcConfig.ConfigurationName = txtName.Text;
        }

        private void txtEndpoint_TextChanged(object sender, EventArgs e)
        {
            plcConfig.EndpointUrl = txtEndpoint.Text;
        }

        private void txtDiscoveryNodeId_TextChanged(object sender, EventArgs e)
        {
            plcConfig.DiscoveryNodeId = txtDiscoveryNodeId.Text;
        }

        private void numClientTimeout_ValueChanged(object sender, EventArgs e)
        {
            plcConfig.ClientTimeout = (int)numClientTimeout.Value;
        }

        private void numTransportQuotas_ValueChanged(object sender, EventArgs e)
        {
            plcConfig.TransportQuotasTimeout = (int)numTransportQuotas.Value;
        }

        private void cbxLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            plcConfig.LogLevel = cbxLogLevel.SelectedIndex;
        }

        private void txtCertificationStorePath_TextChanged(object sender, EventArgs e)
        {
            plcConfig.CertificateStorePath = txtCertificationStorePath.Text;
        }

        private void txtCertificationStoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            plcConfig.CertificateStoreType = txtCertificationStoreType.Text;
        }

        private void txtCertificationSubjectName_TextChanged(object sender, EventArgs e)
        {
            plcConfig.CertificateSubjectName = txtCertificationSubjectName.Text;
        }

        private void btnCertStorePath_Click(object sender, EventArgs e)
        {
            var dialogCertStore = new FolderBrowserDialog();
            if (dialogCertStore.ShowDialog() == DialogResult.OK)
                txtCertificationStorePath.Text = dialogCertStore.SelectedPath;
        }
    }
}
