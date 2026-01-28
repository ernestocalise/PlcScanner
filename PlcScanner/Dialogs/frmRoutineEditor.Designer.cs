namespace PlcScanner.Dialogs
{
    partial class frmRoutineEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoutineEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstRoutines = new System.Windows.Forms.ListBox();
            this.tcEditor = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnAddRoutine = new System.Windows.Forms.ToolStripDropDownButton();
            this.newProgrammedRoutineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecordedRoutineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstRoutines);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcEditor);
            this.splitContainer1.Size = new System.Drawing.Size(792, 368);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstRoutines
            // 
            this.lstRoutines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoutines.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstRoutines.FormattingEnabled = true;
            this.lstRoutines.ItemHeight = 32;
            this.lstRoutines.Location = new System.Drawing.Point(0, 0);
            this.lstRoutines.Name = "lstRoutines";
            this.lstRoutines.Size = new System.Drawing.Size(196, 368);
            this.lstRoutines.TabIndex = 0;
            this.lstRoutines.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstRoutines_DrawItem);
            this.lstRoutines.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstRoutines_MouseDoubleClick);
            // 
            // tcEditor
            // 
            this.tcEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEditor.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tcEditor.Location = new System.Drawing.Point(0, 0);
            this.tcEditor.Name = "tcEditor";
            this.tcEditor.Padding = new System.Drawing.Point(18, 4);
            this.tcEditor.SelectedIndex = 0;
            this.tcEditor.Size = new System.Drawing.Size(592, 368);
            this.tcEditor.TabIndex = 0;
            this.tcEditor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcEditor_DrawItem);
            this.tcEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tcEditor_MouseDown);
            this.tcEditor.Resize += new System.EventHandler(this.tcEditor_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRoutine,
            this.tsButtonSave,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButtonSave
            // 
            this.tsButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonSave.Image = global::PlcScanner.Properties.Resources.IconSave;
            this.tsButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonSave.Name = "tsButtonSave";
            this.tsButtonSave.Size = new System.Drawing.Size(29, 28);
            this.tsButtonSave.Text = "Save Routine";
            this.tsButtonSave.Click += new System.EventHandler(this.tsButtonSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PlcScanner.Properties.Resources.SaveMultiple;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // btnAddRoutine
            // 
            this.btnAddRoutine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRoutine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProgrammedRoutineToolStripMenuItem,
            this.newRecordedRoutineToolStripMenuItem});
            this.btnAddRoutine.Image = global::PlcScanner.Properties.Resources.IconAdd;
            this.btnAddRoutine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRoutine.Name = "btnAddRoutine";
            this.btnAddRoutine.Size = new System.Drawing.Size(34, 28);
            this.btnAddRoutine.Text = "toolStripDropDownButton1";
            // 
            // newProgrammedRoutineToolStripMenuItem
            // 
            this.newProgrammedRoutineToolStripMenuItem.Name = "newProgrammedRoutineToolStripMenuItem";
            this.newProgrammedRoutineToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.newProgrammedRoutineToolStripMenuItem.Text = "New Programmed Routine";
            this.newProgrammedRoutineToolStripMenuItem.Click += new System.EventHandler(this.newProgrammedRoutineToolStripMenuItem_Click);
            // 
            // newRecordedRoutineToolStripMenuItem
            // 
            this.newRecordedRoutineToolStripMenuItem.Name = "newRecordedRoutineToolStripMenuItem";
            this.newRecordedRoutineToolStripMenuItem.Size = new System.Drawing.Size(268, 26);
            this.newRecordedRoutineToolStripMenuItem.Text = "New Recorded Routine";
            // 
            // frmRoutineEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 398);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRoutineEditor";
            this.Text = "Routine Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRoutineEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmRoutineEditor_Load);
            this.SizeChanged += new System.EventHandler(this.tcEditor_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRoutineEditor_KeyDown);
            this.Resize += new System.EventHandler(this.frmRoutineEditor_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstRoutines;
        private System.Windows.Forms.TabControl tcEditor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripDropDownButton btnAddRoutine;
        private System.Windows.Forms.ToolStripMenuItem newProgrammedRoutineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRecordedRoutineToolStripMenuItem;
    }
}