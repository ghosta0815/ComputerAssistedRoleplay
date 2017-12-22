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
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 388);
            this.Controls.Add(this.HitZoneWindowCmd);
            this.Name = "MainWindowView";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HitZoneWindowCmd;
    }
}