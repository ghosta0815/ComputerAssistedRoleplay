namespace ComputerAssistedRoleplay.View
{
    partial class MainWindowView
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
            this.HitZoneWindowCmd = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ClearLogCmd = new System.Windows.Forms.Button();
            this.WeaponWindowCmd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HitZoneWindowCmd
            // 
            this.HitZoneWindowCmd.Location = new System.Drawing.Point(531, 13);
            this.HitZoneWindowCmd.Name = "HitZoneWindowCmd";
            this.HitZoneWindowCmd.Size = new System.Drawing.Size(75, 23);
            this.HitZoneWindowCmd.TabIndex = 0;
            this.HitZoneWindowCmd.Text = "Trefferzonen";
            this.HitZoneWindowCmd.UseVisualStyleBackColor = true;
            this.HitZoneWindowCmd.Click += new System.EventHandler(this.HitZoneWindowCmd_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LogTextBox.Location = new System.Drawing.Point(12, 12);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(410, 364);
            this.LogTextBox.TabIndex = 1;
            // 
            // ClearLogCmd
            // 
            this.ClearLogCmd.Location = new System.Drawing.Point(428, 353);
            this.ClearLogCmd.Name = "ClearLogCmd";
            this.ClearLogCmd.Size = new System.Drawing.Size(75, 23);
            this.ClearLogCmd.TabIndex = 2;
            this.ClearLogCmd.Text = "Log leeren";
            this.ClearLogCmd.UseVisualStyleBackColor = true;
            this.ClearLogCmd.Click += new System.EventHandler(this.ClearLogCmd_Click);
            // 
            // WeaponWindowCmd
            // 
            this.WeaponWindowCmd.Location = new System.Drawing.Point(531, 42);
            this.WeaponWindowCmd.Name = "WeaponWindowCmd";
            this.WeaponWindowCmd.Size = new System.Drawing.Size(75, 23);
            this.WeaponWindowCmd.TabIndex = 3;
            this.WeaponWindowCmd.Text = "Waffen";
            this.WeaponWindowCmd.UseVisualStyleBackColor = true;
            this.WeaponWindowCmd.Click += new System.EventHandler(this.WeaponWindowCmd_Click);
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 388);
            this.Controls.Add(this.WeaponWindowCmd);
            this.Controls.Add(this.ClearLogCmd);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.HitZoneWindowCmd);
            this.Name = "MainWindowView";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HitZoneWindowCmd;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button ClearLogCmd;
        private System.Windows.Forms.Button WeaponWindowCmd;
    }
}