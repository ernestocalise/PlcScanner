using PlcScanner.Models;
using PlcScanner.Routine;
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
    public partial class tabProgrammedRoutine : UserControl
    {
        string _routinePath;
        string _routineName;
        List<ClientTag> _tags;
        List<ProgrammedRoutineStep> _steps;
        public readonly int DGSTEPCONDITION_NODEID = 0;
        public readonly int DGSTEPACTION_NODEID = 0;
        public bool Edited { get; private set; } = false;
        public tabProgrammedRoutine(List<ClientTag> lTag, string RoutinePath)
        {
            InitializeComponent();
            _routinePath = RoutinePath;
            _tags = lTag;
            foreach (var tag in _tags)
            {
                cbxConditionNodeId.Items.Add(tag.NodeId);
                cbxConditionTarget.Items.Add(tag.NodeId);
                cbxActionNodeId.Items.Add(tag.NodeId);
                cbxActionValue.Items.Add(tag.NodeId);
            }
            StreamReader sr = new StreamReader(RoutinePath);
            _steps = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProgrammedRoutineStep>>(sr.ReadToEnd());
            sr.Close();
            sr.Dispose();
            this._routineName = Path.GetFileNameWithoutExtension(RoutinePath);
            foreach(var step in _steps)
            {
                lstRoutineSteps.Items.Add($"Step {_steps.IndexOf(step)+1}");
            }
            setEdited(false);
        }
        public string GetName()
        {
            if (this.Edited)
                return $"*{this._routineName}";
            return this._routineName;
        }
        private void setEdited(bool change)
        {
            this.Edited = change;
            if (this.Parent != null)
                this.Parent.Text = GetName();
        }
        public void OpenProgrammedRoutine()
        {
            var sr = new StreamReader(_routinePath);
            var stringResult = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            _steps = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProgrammedRoutineStep>>(stringResult);
        }
        private void tabProgrammedRoutine_Load(object sender, EventArgs e)
        {

        }
        private void ConditionTypeChanged(TagConditionType newCondition)
        {
            cbxConditionNodeId.Enabled = true;
            cbxConditionTarget.Enabled = true;
            maskedConditionTarget.Enabled = false;
            switch (newCondition)
            {
                case TagConditionType.Equals:
                case TagConditionType.NotEquals:
                    lblConditionDescription.Text = "The Equals condition allow you to compare the Node Value to an arbitrary value or another node value.";
                    break;
                case TagConditionType.Contains:
                case TagConditionType.DoesNotContains:
                    lblConditionDescription.Text = "The Contains condition allow you to compare the Node Value to check that an arbitrary value or another node value is present into a given node value.";
                    break;
                case TagConditionType.CountEquals:
                case TagConditionType.CountLowerThan:
                case TagConditionType.CountBiggerThan:
                    lblConditionDescription.Text = "The Count condition allow you to check that the Array dimension of the Given Node is satified.";
                    break;
                case TagConditionType.BiggerThan:
                case TagConditionType.LowerThan:
                    lblConditionDescription.Text = "The Bigger/Lower condition allow you to check that the Value of the Given Node is Bigger/Lower than the target.";
                    break;
                case TagConditionType.BeforeTime:
                case TagConditionType.AfterTime:
                    lblConditionDescription.Text = "The Time condition allow you to execute the routine only when the current time is in the frame selected.";
                    cbxConditionNodeId.Enabled = false;
                    cbxConditionTarget.Enabled = false;
                    maskedConditionTarget.Enabled = true;
                    _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument = maskedConditionTarget.Text;
                    break;
                case TagConditionType.StartsWith:
                case TagConditionType.EndsWith:
                    lblConditionDescription.Text = "The StartsWith/EndsWith condition allow you to check that the Value of the Given Node Starts/Ends with the target.";
                    break;

            }
        }
        private void cbxConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConditionTypeChanged((TagConditionType)cbxConditionType.SelectedIndex);
        }

        private void tsAddStep_Click(object sender, EventArgs e)
        {
            var step = new ProgrammedRoutineStep();
            step.Name = $"Step {_steps.Count + 1}";
            _steps.Add(step);
            lstRoutineSteps.Items.Add(step.Name);
            setEdited(true);
        }

        private void cbxConditionNodeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblAddCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var condition = new TagCondition();
            condition.Type = TagConditionType.Equals;
            _steps[lstRoutineSteps.SelectedIndex].Conditions.Add(condition);
            lstConditions.Items.Add($"Condition {lstConditions.Items.Count + 1}");
            setEdited(true);
        }

        private void lstConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConditions.SelectedIndex != -1)
            {
                groupBox1.Visible = true;
                cbxConditionNodeId.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].NodeId;
                cbxConditionType.SelectedIndex = (int)_steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type;
                if (_steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type == TagConditionType.BeforeTime ||
                    _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type == TagConditionType.AfterTime)
                {
                    maskedConditionTarget.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument;
                }
                else
                {
                    cbxConditionTarget.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument;
                }
            }
            else
            {
                groupBox1.Visible = false;
            }
            ConditionTypeChanged(_steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type);
        }

        private void lstRoutineSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoutineSteps.SelectedIndex != -1)
            {
                tcConditionActions.Visible = true;
                lstActions.Items.Clear();
                lstConditions.Items.Clear();
                foreach (var action in _steps[lstRoutineSteps.SelectedIndex].Actions)
                    lstActions.Items.Add($"Action {_steps[lstRoutineSteps.SelectedIndex].Actions.IndexOf(action) + 1}");
                foreach (var condition in _steps[lstRoutineSteps.SelectedIndex].Conditions)
                    lstConditions.Items.Add($"Condition {_steps[lstRoutineSteps.SelectedIndex].Conditions.IndexOf(condition) + 1}");
            }
            else
                tcConditionActions.Visible = false;
        }

        private void maskedConditionTarget_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbxConditionTarget_TextChanged(object sender, EventArgs e)
        {
        }

        public void Save()
        {
            string RoutineString = Newtonsoft.Json.JsonConvert.SerializeObject(_steps);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(_routinePath);
            writer.Write(RoutineString);
            writer.Close();
            writer.Dispose();
            setEdited(false);
        }

        private void btnConditionApply_Click(object sender, EventArgs e)
        {
            _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].NodeId = cbxConditionNodeId.Text;
            _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type = (TagConditionType)cbxConditionType.SelectedIndex;
            if ((TagConditionType)cbxConditionType.SelectedIndex == TagConditionType.BeforeTime || (TagConditionType)cbxConditionType.SelectedIndex == TagConditionType.AfterTime)
                _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument = maskedConditionTarget.Text;
            else
                _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument = cbxConditionTarget.Text;
            setEdited(true);
        }

        private void btnConditionRestore_Click(object sender, EventArgs e)
        {
            cbxConditionNodeId.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].NodeId;
            cbxConditionType.SelectedIndex = (int)_steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type;
            ConditionTypeChanged(_steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Type);
            if ((TagConditionType)cbxConditionType.SelectedIndex == TagConditionType.BeforeTime || (TagConditionType)cbxConditionType.SelectedIndex == TagConditionType.AfterTime)
                maskedConditionTarget.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument;
            else
                cbxConditionTarget.Text = _steps[lstRoutineSteps.SelectedIndex].Conditions[lstConditions.SelectedIndex].Argument;
        }

        private void lvlAddAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var action = new TagAction();
            action.Type = TagActionType.Write;
            _steps[lstRoutineSteps.SelectedIndex].Actions.Add(action);
            lstActions.Items.Add($"Action {lstActions.Items.Count + 1}");
            setEdited(true);
        }

        private void btnActionApply_Click(object sender, EventArgs e)
        {
            _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].NodeId = cbxActionNodeId.Text;
            _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Type = (TagActionType)cbxActionType.SelectedIndex;
            _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Value = cbxActionValue.Text;
            setEdited(true);
        }

        private void btnActionRestore_Click(object sender, EventArgs e)
        {
            cbxActionNodeId.Text = _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].NodeId;
            cbxActionType.SelectedIndex = (int)_steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Type;
            cbxActionValue.Text = _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Value;
        }

        private void lstActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstActions.SelectedIndex != -1)
            {
                groupBox2.Visible = true;
                cbxActionNodeId.Text = _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].NodeId;
                cbxActionType.SelectedIndex = (int)_steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Type;
                cbxActionValue.Text = _steps[lstRoutineSteps.SelectedIndex].Actions[lstActions.SelectedIndex].Value;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }
    }
}
