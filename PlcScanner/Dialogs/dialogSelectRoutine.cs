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
    public partial class dialogSelectRoutine : Form
    {
        public string SelectedRoutine;
        public dialogSelectRoutine()
        {
            InitializeComponent();
        }
        public dialogSelectRoutine(string ProjectName)
        {
            InitializeComponent();
            string FilePath = Helper.GetPath(PathType.Routines, ProjectName);
            foreach(var file in Directory.GetFiles(FilePath))
            {
                lstRoutine.Items.Add(Path.GetFileName(file));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SelectedRoutine = lstRoutine.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
