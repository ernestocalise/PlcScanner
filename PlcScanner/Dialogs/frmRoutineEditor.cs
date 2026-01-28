using PlcScanner.FormControls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlcScanner.Dialogs
{
    public partial class frmRoutineEditor : Form
    {
        public Dictionary<string, string> NameToPath  = new Dictionary<string, string>();
        List<ClientTag> Tags = new List<ClientTag>();
        private string _path;
        public frmRoutineEditor()
        {
            InitializeComponent();
        }
        public frmRoutineEditor(string ProjectName, List<ClientTag> lTag)
        {
            InitializeComponent();
            Tags = lTag;
            _path = Helper.GetPath(PathType.Routines, ProjectName);
            ReloadRoutines();
        }
        private void ReloadRoutines()
        {
            lstRoutines.Items.Clear();
            NameToPath.Clear();
            foreach (var file in Directory.GetFiles(_path))
            {
                lstRoutines.Items.Add(Path.GetFileNameWithoutExtension(file));
                NameToPath.Add(Path.GetFileNameWithoutExtension(file), file);
            }
        }
        private void frmRoutineEditor_Load(object sender, EventArgs e)
        {

        }

        private void SaveSelectedTab()
        {
            if (tcEditor.SelectedTab.Controls[0] is tabRecordedRoutineEditor)
            {
                var ctr = (tabRecordedRoutineEditor)tcEditor.SelectedTab.Controls[0];
                ctr.Save();
            } else if (tcEditor.SelectedTab.Controls[0] is tabProgrammedRoutine)
            {
                var ctr = (tabProgrammedRoutine)tcEditor.SelectedTab.Controls[0];
                ctr.Save();
            }
        }
        private void SaveAllTabs()
        {
            if (tcEditor.TabPages.Count > 0)
            {
                foreach (TabPage page in tcEditor.TabPages)
                {
                    if (page.Controls[0] is tabRecordedRoutineEditor)
                    {
                        var ctr = (tabRecordedRoutineEditor)tcEditor.SelectedTab.Controls[0];
                        if (ctr.Edited)
                            ctr.Save();
                    }
                }
            }
        }

        private void lstRoutines_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstRoutines.SelectedIndex < 0)
            {
                return;
            }

            if (tcEditor.TabPages.Count > 0)
            {
                foreach (TabPage page in tcEditor.TabPages)
                {
                    if (page.Text == lstRoutines.SelectedItem.ToString() || page.Text == $"*{lstRoutines.SelectedItem.ToString()}")
                    {
                        tcEditor.SelectTab(page);
                        return;
                    }
                }
            }
            NameToPath.TryGetValue(lstRoutines.SelectedItem.ToString(), out string FileName);
            switch (Path.GetExtension(FileName))
            {
                case ".json":
                    tcEditor.TabPages.Add(lstRoutines.SelectedItem.ToString());
                    TabPage tabRecorded = tcEditor.TabPages[tcEditor.TabPages.Count - 1];
                    tabRecorded.Controls.Add(new tabRecordedRoutineEditor(Tags, FileName));
                    tabRecorded.Controls[0].Size = tabRecorded.Size;
                    tcEditor.SelectTab(tabRecorded);
                    break;
                case ".pr":
                    tcEditor.TabPages.Add(lstRoutines.SelectedItem.ToString());
                    TabPage tabProgrammed = tcEditor.TabPages[tcEditor.TabPages.Count - 1];
                    tabProgrammed.Controls.Add(new tabProgrammedRoutine(Tags, FileName));
                    tabProgrammed.Controls[0].Size = tabProgrammed.Size;
                    tcEditor.SelectTab(tabProgrammed);
                    break;
            }
        }

        private void frmRoutineEditor_Resize(object sender, EventArgs e)
        {

        }

        private void tcEditor_Resize(object sender, EventArgs e)
        {
            if (tcEditor != null && tcEditor.TabCount > 0 && tcEditor.SelectedTab != null)
            {
                Size refSize = tcEditor.SelectedTab.Size;
                foreach (TabPage page in tcEditor.TabPages)
                {
                    page.Controls[0].Size = refSize;
                }
            }
        }

        private void tsButtonSave_Click(object sender, EventArgs e)
        {
            SaveSelectedTab();
        }

        private void frmRoutineEditor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tcEditor_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tab = tcEditor.TabPages[e.Index];
            Rectangle rect = tcEditor.GetTabRect(e.Index);

            // Background
            bool selected = (e.Index == tcEditor.SelectedIndex);
            Color backColor = selected ? Color.SteelBlue : Color.LightGray;
            Color foreColor = selected ? Color.White : Color.Black;

            using (Brush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, rect);

            // Text
            TextRenderer.DrawText(
                e.Graphics,
                tab.Text,
                tab.Font,
                rect,
                foreColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // Close button (small X)
            Rectangle closeRect = new Rectangle(rect.Right - 16, rect.Top + 4, 12, 12);
            e.Graphics.DrawRectangle(Pens.Black, closeRect);
            e.Graphics.DrawLine(Pens.Black, closeRect.Left, closeRect.Top, closeRect.Right, closeRect.Bottom);
            e.Graphics.DrawLine(Pens.Black, closeRect.Right, closeRect.Top, closeRect.Left, closeRect.Bottom);

            // Optional: store closeRect in TabPage.Tag if you want precise hit-testing
            tab.Tag = closeRect;
        }

        private void tcEditor_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tcEditor.TabCount; i++)
            {
                TabPage tab = tcEditor.TabPages[i];
                if (tab.Tag is Rectangle closeRect && closeRect.Contains(e.Location))
                {
                    // Remove the tab
                    tcEditor.TabPages.Remove(tab);
                    break;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveSelectedTab();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lstRoutines_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0)
                return;
            string text = lstRoutines.Items[e.Index].ToString();
            int padding = 4;

            Rectangle textRect = new Rectangle(
                e.Bounds.Left + padding,
                e.Bounds.Top,
                e.Bounds.Width - padding,
                e.Bounds.Height);

            TextRenderer.DrawText(e.Graphics,
                text,
                e.Font,
                textRect,
                e.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawFocusRectangle();

        }

        private bool CheckTabPagesModifyStatus()
        {
            if (tcEditor.TabPages.Count > 0)
            {
                foreach (TabPage page in tcEditor.TabPages)
                {
                    if (page.Controls[0] is tabRecordedRoutineEditor)
                    {
                        var ctr = (tabRecordedRoutineEditor)page.Controls[0];
                        if (ctr.Edited)
                            return true;
                    }
                    if (page.Controls[0] is tabProgrammedRoutine)
                    {
                        var ctr = (tabProgrammedRoutine)page.Controls[0];
                        if (ctr.Edited)
                            return true;
                    }
                }
            }
            return false;
        }

        private void frmRoutineEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckTabPagesModifyStatus())
            {
                if (MessageBox.Show("You have unsaved changes in Routines. Do you wanna proceed?",
                                    "PlcScanner",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information) != DialogResult.Yes)
                                e.Cancel = true;
            }
        }

        private void btnAddRoutine_Click(object sender, EventArgs e)
        {
            tcEditor.TabPages.Add("FileName");
            TabPage tab = tcEditor.TabPages[tcEditor.TabPages.Count - 1];
            tab.Controls.Add(new tabProgrammedRoutine(Tags, "FileName"));
            tab.Controls[0].Size = tab.Size;
            tcEditor.SelectTab(tab);
        }

        private void newProgrammedRoutineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pr = new List<ProgrammedRoutineStep>();
            string newPR = Newtonsoft.Json.JsonConvert.SerializeObject(pr);
            string filename = "Programmed_Routine";
            int peek = 1;
            string filePath = Path.Combine(_path, $"{filename}_{peek}.pr");
            while (File.Exists(filePath))
            {
                peek += 1;
                filePath = Path.Combine(_path, $"{filename}_{peek}.pr");
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            sw.Write(newPR);
            sw.Close();
            sw.Dispose();
            ReloadRoutines();
        }
    }
}
