namespace ComputerAssistedRoleplay.View
{
    partial class WeaponsView
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
            this.WeaponGrid = new System.Windows.Forms.DataGridView();
            this.WeaponNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CutDamageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BashDamageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PierceDamageCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LengthCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailedWeaponInfoTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.WeaponGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WeaponGrid
            // 
            this.WeaponGrid.AllowUserToAddRows = false;
            this.WeaponGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.WeaponGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeaponGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeaponNameCol,
            this.CutDamageCol,
            this.BashDamageCol,
            this.PierceDamageCol,
            this.WeightCol,
            this.LengthCol});
            this.WeaponGrid.Location = new System.Drawing.Point(13, 13);
            this.WeaponGrid.Name = "WeaponGrid";
            this.WeaponGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WeaponGrid.Size = new System.Drawing.Size(444, 350);
            this.WeaponGrid.TabIndex = 0;
            this.WeaponGrid.SelectionChanged += new System.EventHandler(this.WeaponGrid_SelectionChanged);
            // 
            // WeaponNameCol
            // 
            this.WeaponNameCol.HeaderText = "Name";
            this.WeaponNameCol.Name = "WeaponNameCol";
            // 
            // CutDamageCol
            // 
            this.CutDamageCol.HeaderText = "Schnitt";
            this.CutDamageCol.Name = "CutDamageCol";
            this.CutDamageCol.Width = 50;
            // 
            // BashDamageCol
            // 
            this.BashDamageCol.HeaderText = "Wucht";
            this.BashDamageCol.Name = "BashDamageCol";
            this.BashDamageCol.Width = 50;
            // 
            // PierceDamageCol
            // 
            this.PierceDamageCol.HeaderText = "Stich";
            this.PierceDamageCol.Name = "PierceDamageCol";
            this.PierceDamageCol.Width = 50;
            // 
            // WeightCol
            // 
            this.WeightCol.HeaderText = "Gewicht";
            this.WeightCol.Name = "WeightCol";
            this.WeightCol.Width = 75;
            // 
            // LengthCol
            // 
            this.LengthCol.HeaderText = "Länge";
            this.LengthCol.Name = "LengthCol";
            this.LengthCol.Width = 75;
            // 
            // DetailedWeaponInfoTextbox
            // 
            this.DetailedWeaponInfoTextbox.Location = new System.Drawing.Point(463, 14);
            this.DetailedWeaponInfoTextbox.Multiline = true;
            this.DetailedWeaponInfoTextbox.Name = "DetailedWeaponInfoTextbox";
            this.DetailedWeaponInfoTextbox.ReadOnly = true;
            this.DetailedWeaponInfoTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DetailedWeaponInfoTextbox.Size = new System.Drawing.Size(245, 206);
            this.DetailedWeaponInfoTextbox.TabIndex = 1;
            // 
            // WeaponsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 375);
            this.Controls.Add(this.DetailedWeaponInfoTextbox);
            this.Controls.Add(this.WeaponGrid);
            this.Name = "WeaponsView";
            this.Text = "WeaponsView";
            ((System.ComponentModel.ISupportInitialize)(this.WeaponGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView WeaponGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeaponNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CutDamageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BashDamageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PierceDamageCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn LengthCol;
        private System.Windows.Forms.TextBox DetailedWeaponInfoTextbox;
    }
}