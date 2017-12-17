namespace ComputerAssistedRoleplay.View
{
    partial class HitzoneView
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
            this.HitzonesTable = new System.Windows.Forms.DataGridView();
            this.Bodypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopHit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThrownEyes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaceHitzonesComboBox = new System.Windows.Forms.ComboBox();
            this.throwHitzoneCmd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HitzonesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // HitzonesTable
            // 
            this.HitzonesTable.AllowUserToAddRows = false;
            this.HitzonesTable.AllowUserToDeleteRows = false;
            this.HitzonesTable.AllowUserToResizeRows = false;
            this.HitzonesTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.HitzonesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HitzonesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bodypart,
            this.StartHit,
            this.StopHit,
            this.ThrownEyes});
            this.HitzonesTable.Location = new System.Drawing.Point(12, 9);
            this.HitzonesTable.Name = "HitzonesTable";
            this.HitzonesTable.ReadOnly = true;
            this.HitzonesTable.ShowEditingIcon = false;
            this.HitzonesTable.Size = new System.Drawing.Size(335, 469);
            this.HitzonesTable.TabIndex = 3;
            // 
            // Bodypart
            // 
            this.Bodypart.HeaderText = "Körperteil";
            this.Bodypart.Name = "Bodypart";
            this.Bodypart.ReadOnly = true;
            this.Bodypart.Width = 120;
            // 
            // StartHit
            // 
            this.StartHit.HeaderText = "Von";
            this.StartHit.Name = "StartHit";
            this.StartHit.ReadOnly = true;
            this.StartHit.Width = 50;
            // 
            // StopHit
            // 
            this.StopHit.HeaderText = "Bis";
            this.StopHit.Name = "StopHit";
            this.StopHit.ReadOnly = true;
            this.StopHit.Width = 50;
            // 
            // ThrownEyes
            // 
            this.ThrownEyes.HeaderText = "Treffer";
            this.ThrownEyes.Name = "ThrownEyes";
            this.ThrownEyes.ReadOnly = true;
            this.ThrownEyes.Width = 50;
            // 
            // RaceHitzonesComboBox
            // 
            this.RaceHitzonesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RaceHitzonesComboBox.FormattingEnabled = true;
            this.RaceHitzonesComboBox.Location = new System.Drawing.Point(360, 9);
            this.RaceHitzonesComboBox.Name = "RaceHitzonesComboBox";
            this.RaceHitzonesComboBox.Size = new System.Drawing.Size(121, 21);
            this.RaceHitzonesComboBox.TabIndex = 4;
            this.RaceHitzonesComboBox.SelectedIndexChanged += new System.EventHandler(this.RaceHitzonesComboBox_SelectedIndexChanged);
            // 
            // throwHitzoneCmd
            // 
            this.throwHitzoneCmd.Location = new System.Drawing.Point(361, 36);
            this.throwHitzoneCmd.Name = "throwHitzoneCmd";
            this.throwHitzoneCmd.Size = new System.Drawing.Size(120, 23);
            this.throwHitzoneCmd.TabIndex = 5;
            this.throwHitzoneCmd.Text = "Trefferzone würfeln";
            this.throwHitzoneCmd.UseVisualStyleBackColor = true;
            this.throwHitzoneCmd.Click += new System.EventHandler(this.throwHitzoneCmd_Click);
            // 
            // HitzoneView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 490);
            this.Controls.Add(this.throwHitzoneCmd);
            this.Controls.Add(this.RaceHitzonesComboBox);
            this.Controls.Add(this.HitzonesTable);
            this.Name = "HitzoneView";
            this.Text = "Trefferzonenrechner";
            ((System.ComponentModel.ISupportInitialize)(this.HitzonesTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView HitzonesTable;
        private System.Windows.Forms.ComboBox RaceHitzonesComboBox;
        private System.Windows.Forms.Button throwHitzoneCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bodypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopHit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThrownEyes;
    }
}

