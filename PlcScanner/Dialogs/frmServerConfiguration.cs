using Opc.Ua;
using PlcScanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlcScanner.Dialogs
{
    public partial class frmServerConfiguration : Form
    {
        public frmServerConfiguration(string Name)
        {
            InitializeComponent();
            this._config = new OpcServerConfiguration(Name);
            this.txtApplicationURI.Text = _config.ApplicationUri;
            this.lstBaseAddresses.Items.Clear();
            foreach (var item in _config.BaseAddresses)
                lstBaseAddresses.Items.Add(item);
            this.numTransportQuotas.Value = _config.TransportQuotas;
            this.cbxLogLevel.SelectedIndex = (int)_config.LogLevel;
            this.cbxMessageSecurityMode.SelectedIndex = (int)_config.MessageSecurityMode;
            this.cbxUserPolicy.SelectedIndex = (int)_config.UserPolicy;
            this.txtSubjectName.Text = _config.CertificateSubjectName;
            this.chkAddCertificateToTrustStore.Checked = _config.AddAppCertToTrustedStore;
            this.chkAutoAcceptUntrustedCertificate.Checked= _config.AutoAcceptUntrustedCertificates;
            tmrWatchFolders.Start();
        }
        OpcServerConfiguration _config;
        private void btnAddBaseAddress_Click(object sender, EventArgs e)
        {
            lstBaseAddresses.Items.Add(txtBaseAddress.Text);
            txtBaseAddress.Text = "";
        }
        private string GetFileByOFD()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Certificates|*.pem;*.crt;*.cer;*.der";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }
        private void DoCopy(TextBox txtb, string FolderName)
        {
            if (File.Exists(txtb.Text))
            {
                Helper.CopyFile(txtb.Text,
                Helper.GetServerCertificateSubfolder(_config.Name, FolderName),
                false);
            }
            else
            {
                MessageBox.Show($"File [{txtb.Text}] does not exists!", "PlcScanner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtb.Text = "";
        }
        private void DoDelete(string FileName, string FolderName) {
            string FullPath = Path.Combine(
                Helper.GetServerCertificateSubfolder(Name, FolderName),
                FileName);
            if (File.Exists(FullPath))
                File.Delete(FullPath);
        }
        private void UpdateList(ListBox list, string FolderName)
        {
            var listOfFile = Directory.GetFiles(FolderName);
            foreach(var file in listOfFile)
            {
                if (!list.Items.Contains(Path.GetFileName(file))){
                    list.Items.Add(Path.GetFileName(file));
                }
            }
            List<string> itemsToRemove = new List<string>();
            foreach(var item in list.Items)
            {
                if(!listOfFile.Any(f => Path.GetFileName(f) == item.ToString()))
                {
                    itemsToRemove.Add(item.ToString());
                }
            }
            foreach (var item in itemsToRemove)
                list.Items.Remove(item);
        }
        private void txtApplicaitonCertificates_Click(object sender, EventArgs e)
        {
            txtApplicaitonCertificates.Text = GetFileByOFD();
        }

        private void btnApplicationCertificates_Click(object sender, EventArgs e)
        {
            DoCopy(txtApplicaitonCertificates, "Own");
        }

        private void txtTrustedPeerCertificates_Click(object sender, EventArgs e)
        {
            txtTrustedPeerCertificates.Text = GetFileByOFD();
        }

        private void btnAddTrustedPeerCertificate_Click(object sender, EventArgs e)
        {
            DoCopy(txtTrustedPeerCertificates, "Peers");
        }

        private void txtTrustedIssuerCertificate_Click(object sender, EventArgs e)
        {
            txtTrustedIssuerCertificate.Text = GetFileByOFD();
        }

        private void btnAddTrustedIssuerCertificate_Click(object sender, EventArgs e)
        {
            DoCopy(txtTrustedIssuerCertificate, "Issuer");
        }

        private void txtRejectedCertificate_Click(object sender, EventArgs e)
        {
            txtRejectedCertificate.Text = GetFileByOFD();
        }

        private void btnAddRejectedCertificate_Click(object sender, EventArgs e)
        {
            DoCopy(txtRejectedCertificate, "Rejected");
        }

        private void tmrWatchFolders_Tick(object sender, EventArgs e)
        {
            UpdateList(lstApplicationCertificates, 
                Helper.GetServerCertificateSubfolder(_config.Name, "Own"));

            UpdateList(lstRejectedCertificates,
                Helper.GetServerCertificateSubfolder(_config.Name, "Rejected"));

            UpdateList(lstTrustedIssuerCertificates,
                Helper.GetServerCertificateSubfolder(_config.Name, "Issuer"));

            UpdateList(lstTrustedPeersCertificates,
                Helper.GetServerCertificateSubfolder(_config.Name, "Peers"));
        }

        private void lstBaseAddresses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstBaseAddresses.SelectedItems.Count > 0)
            {
                lstBaseAddresses.Items.Remove(lstBaseAddresses.SelectedItem);
            }
        }

        private void lstTrustedPeersCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstTrustedPeersCertificates.SelectedItems.Count > 0)
            {
                DoDelete(lstTrustedPeersCertificates.SelectedItem.ToString(), "Peers");
            }
        }

        private void lstApplicationCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstApplicationCertificates.SelectedItems.Count > 0)
            {
                DoDelete(lstApplicationCertificates.SelectedItem.ToString(), "Own");
            }
        }

        private void lstRejectedCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstRejectedCertificates.SelectedItems.Count > 0)
            {
                DoDelete(lstRejectedCertificates.SelectedItem.ToString(), "Rejected");
            }
        }
        private void lstTrustedIssuerCertificates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lstTrustedIssuerCertificates.SelectedItems.Count > 0)
            {
                DoDelete(lstTrustedIssuerCertificates.SelectedItem.ToString(), "Issuer");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _config.ApplicationUri = this.txtApplicationURI.Text;
            _config.BaseAddresses = new List<string>();
            foreach (var item in lstBaseAddresses.Items)
                _config.BaseAddresses.Add(item.ToString());
            _config.TransportQuotas = (int)this.numTransportQuotas.Value;
            _config.LogLevel = (LogLevel)this.cbxLogLevel.SelectedIndex;
            _config.MessageSecurityMode = (MessageSecurityMode)cbxMessageSecurityMode.SelectedIndex;
            _config.UserPolicy = (UserTokenType)this.cbxUserPolicy.SelectedIndex;
            _config.CertificateSubjectName = this.txtSubjectName.Text;
            _config.AddAppCertToTrustedStore = this.chkAddCertificateToTrustStore.Checked;
            _config.AutoAcceptUntrustedCertificates = this.chkAutoAcceptUntrustedCertificate.Checked;

            this.DialogResult = DialogResult.OK;
        }
        public OpcServerConfiguration GetConfiguration()
        {
            return _config; 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
