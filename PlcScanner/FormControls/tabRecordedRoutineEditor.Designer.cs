namespace PlcScanner.FormControls
{
    partial class tabRecordedRoutineEditor
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsbMoveDown = new System.Windows.Forms.ToolStripButton();
            this.dgRecordedRoutine = new System.Windows.Forms.DataGridView();
            this.tgrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagSelected = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecordedRoutine)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.tsbMoveUp,
            this.tsbMoveDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tsbAdd.Image = global::PlcScanner.Properties.Resources.IconAdd;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(29, 28);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::PlcScanner.Properties.Resources.IconDelete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(29, 28);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbMoveUp
            // 
            this.tsbMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveUp.Image = global::PlcScanner.Properties.Resources.IconArrowUp;
            this.tsbMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveUp.Name = "tsbMoveUp";
            this.tsbMoveUp.Size = new System.Drawing.Size(29, 28);
            this.tsbMoveUp.Text = "Move up";
            this.tsbMoveUp.Click += new System.EventHandler(this.tsbMoveUp_Click);
            // 
            // tsbMoveDown
            // 
            this.tsbMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMoveDown.Image = global::PlcScanner.Properties.Resources.IconArrowDown;
            this.tsbMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoveDown.Name = "tsbMoveDown";
            this.tsbMoveDown.Size = new System.Drawing.Size(29, 28);
            this.tsbMoveDown.Text = "Move down";
            this.tsbMoveDown.Click += new System.EventHandler(this.tsbMoveDown_Click);
            // 
            // dgRecordedRoutine
            // 
            this.dgRecordedRoutine.AllowUserToAddRows = false;
            this.dgRecordedRoutine.AllowUserToDeleteRows = false;
            this.dgRecordedRoutine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRecordedRoutine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecordedRoutine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tgrName,
            this.TagSelected,
            this.OldValue,
            this.NewValue,
            this.TimeSpan});
            this.dgRecordedRoutine.Location = new System.Drawing.Point(3, 30);
            this.dgRecordedRoutine.Name = "dgRecordedRoutine";
            this.dgRecordedRoutine.RowHeadersWidth = 51;
            this.dgRecordedRoutine.RowTemplate.Height = 24;
            this.dgRecordedRoutine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRecordedRoutine.Size = new System.Drawing.Size(742, 432);
            this.dgRecordedRoutine.TabIndex = 2;
            this.dgRecordedRoutine.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRecordedRoutine_CellValueChanged);
            // 
            // tgrName
            // 
            this.tgrName.HeaderText = "Name";
            this.tgrName.MinimumWidth = 6;
            this.tgrName.Name = "tgrName";
            this.tgrName.Width = 125;
            // 
            // TagSelected
            // 
            this.TagSelected.HeaderText = "TagSelected";
            this.TagSelected.MinimumWidth = 6;
            this.TagSelected.Name = "TagSelected";
            this.TagSelected.Width = 125;
            // 
            // OldValue
            // 
            this.OldValue.HeaderText = "OldValue";
            this.OldValue.MinimumWidth = 6;
            this.OldValue.Name = "OldValue";
            this.OldValue.Width = 125;
            // 
            // NewValue
            // 
            this.NewValue.HeaderText = "New Value";
            this.NewValue.MinimumWidth = 6;
            this.NewValue.Name = "NewValue";
            this.NewValue.Width = 125;
            // 
            // TimeSpan
            // 
            this.TimeSpan.HeaderText = "TimeSpan";
            this.TimeSpan.MinimumWidth = 6;
            this.TimeSpan.Name = "TimeSpan";
            this.TimeSpan.Width = 125;
            // 
            // tabRecordedRoutineEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgRecordedRoutine);
            this.Controls.Add(this.toolStrip1);
            this.Name = "tabRecordedRoutineEditor";
            this.Size = new System.Drawing.Size(745, 465);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecordedRoutine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbMoveUp;
        private System.Windows.Forms.ToolStripButton tsbMoveDown;
        private System.Windows.Forms.DataGridView dgRecordedRoutine;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgrName;
        private System.Windows.Forms.DataGridViewComboBoxColumn TagSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSpan;
    }
}
