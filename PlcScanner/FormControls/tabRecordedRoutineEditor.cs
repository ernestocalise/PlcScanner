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

namespace PlcScanner.FormControls
{
    public partial class tabRecordedRoutineEditor : UserControl
    {
        List<ClientTag> _tags = new List<ClientTag>();
        string _routinePath;
        string _routineName;
        DataTable _tbChanges = new DataTable();
        public bool Edited { get; private set; } = false;
        public tabRecordedRoutineEditor()
        {
            InitializeComponent();
        }
        private void setEdited(bool change)
        {
            this.Edited = change;
            if(this.Parent != null)
            this.Parent.Text = GetName();
        }
        public tabRecordedRoutineEditor(List<ClientTag> lTag, string routinePath)
        {
            InitializeComponent();
            _routinePath = routinePath;
            _tags = lTag;
            var col = (DataGridViewComboBoxColumn)dgRecordedRoutine.Columns["TagSelected"];
            foreach (var tag in _tags)
            {
                col.Items.Add(tag.NodeId.ToString());
            }
            var sr = new StreamReader(routinePath);
            string json = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            var tagChanges = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TagChange>>(json);
            foreach (var tagChange in tagChanges)
            {
                var dgRow = new DataGridViewRow();
                dgRow.CreateCells(dgRecordedRoutine);
                dgRow.Cells[0].Value = tagChange.Name;
                dgRow.Cells[1].Value = tagChange.NodeId;
                dgRow.Cells[2].Value = tagChange.OldValue;
                dgRow.Cells[3].Value = tagChange.Value;
                dgRow.Cells[4].Value = tagChange.Time;
                dgRecordedRoutine.Rows.Add(dgRow);
            }

            setEdited(false);
            this._routineName = Path.GetFileNameWithoutExtension(routinePath);
            // Gli devo passare lista delle tag e..?
            // Path della routine per scaricare tutta i passaggi da mettere in lista..
            // poi? credo basta
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            if (dgRecordedRoutine.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgRecordedRoutine.SelectedRows[0];
            int index = row.Index;

            if (index == 0)
                return; // already at top
            var prevTime = dgRecordedRoutine.Rows[index - 1].Cells[4].Value.ToString();
            dgRecordedRoutine.Rows[index - 1].Cells[4].Value = dgRecordedRoutine.Rows[index].Cells[4].Value;
            dgRecordedRoutine.Rows.RemoveAt(index);
            row.Cells[4].Value = prevTime;
            dgRecordedRoutine.Rows.Insert(index - 1, row);

            dgRecordedRoutine.ClearSelection();
            row.Selected = true;
            setEdited(true);
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            if (dgRecordedRoutine.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgRecordedRoutine.SelectedRows[0];
            int index = row.Index;

            if (index >= dgRecordedRoutine.Rows.Count - 1)
                return; // already at bottom

            var nextTime = dgRecordedRoutine.Rows[index + 1].Cells[4].Value.ToString();
            dgRecordedRoutine.Rows[index + 1].Cells[4].Value = dgRecordedRoutine.Rows[index].Cells[4].Value;
            dgRecordedRoutine.Rows.RemoveAt(index);
            row.Cells[4].Value = nextTime;
            dgRecordedRoutine.Rows.Insert(index + 1, row);

            dgRecordedRoutine.ClearSelection();
            row.Selected = true;
            setEdited(true);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgRecordedRoutine.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgRecordedRoutine.SelectedRows[0];
            int index = row.Index;
            dgRecordedRoutine.Rows.RemoveAt(index);
            setEdited(true);
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var dgRow = new DataGridViewRow();
            dgRow.CreateCells(dgRecordedRoutine);
            dgRecordedRoutine.Rows.Add(dgRow);
            setEdited(true);
        }
        public void Save()
        {
            try
            {
                var collTagChange = new List<TagChange>();
                foreach (DataGridViewRow row in dgRecordedRoutine.Rows)
                {
                    var tagChange = new TagChange();
                    tagChange.Name = row.Cells[0].Value.ToString();
                    tagChange.NodeId = row.Cells[1].Value.ToString();
                    tagChange.OldValue = row.Cells[2].Value.ToString();
                    tagChange.Value = row.Cells[3].Value.ToString();
                    tagChange.Time = System.TimeSpan.Parse(row.Cells[4].Value.ToString());
                    collTagChange.Add(tagChange);
                }
                string fileModified = Newtonsoft.Json.JsonConvert.SerializeObject(collTagChange);
                System.IO.StreamWriter sw = new StreamWriter(_routinePath);
                sw.Write(fileModified);
                sw.Close();
                sw.Dispose();

                MessageBox.Show($"Saved! {_routinePath}");
                setEdited(false);
            }
            catch
            {
                MessageBox.Show($"Unable to save!");
            }

        }
        public string GetName()
        {
            if (this.Edited)
                return $"*{this._routineName}";
            return this._routineName;
        }
        private void dgRecordedRoutine_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            setEdited(true);
        }
    }
}
