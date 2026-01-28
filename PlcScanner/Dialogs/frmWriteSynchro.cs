using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlcScanner.Dialogs
{
    public partial class frmWriteSynchro : Form
    {
        string tag;
        string value;
        public frmWriteSynchro()
        {
            InitializeComponent();
        }
        public frmWriteSynchro(string tag, string val)
        {
            InitializeComponent();
            this.tag = tag;
            this.value = val;
            this.lblTag.Text = tag;
            this.txtValue.Text = val;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            this.value = this.txtValue.Text.ToString();
        }
        public string GetTag()
        {
            return this.tag;
        }
        public string GetValue()
        {
            return this.value;
        }

        private void frmWriteSynchro_Load(object sender, EventArgs e)
        {

        }
    }
}
