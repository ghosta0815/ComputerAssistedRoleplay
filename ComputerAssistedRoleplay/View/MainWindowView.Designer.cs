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
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 388);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.HitZoneWindowCmd);
            this.Name = "MainWindowView";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HitZoneWindowCmd;
        private System.Windows.Forms.TextBox LogTextBox;
    }
}