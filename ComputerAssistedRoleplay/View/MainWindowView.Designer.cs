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
            this.throw1w6Cmd = new System.Windows.Forms.Button();
            this.throw3w20Cmd = new System.Windows.Forms.Button();
            this.throw3w6Cmd = new System.Windows.Forms.Button();
            this.throw1w20Cmd = new System.Windows.Forms.Button();
            this.diceStringTextBox = new System.Windows.Forms.TextBox();
            this.throwDiceStringCmd = new System.Windows.Forms.Button();
            this.PlayerSheetBtn = new System.Windows.Forms.Button();
            this.EnemySheetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HitZoneWindowCmd
            // 
            this.HitZoneWindowCmd.Location = new System.Drawing.Point(539, 13);
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
            this.WeaponWindowCmd.Location = new System.Drawing.Point(539, 42);
            this.WeaponWindowCmd.Name = "WeaponWindowCmd";
            this.WeaponWindowCmd.Size = new System.Drawing.Size(75, 23);
            this.WeaponWindowCmd.TabIndex = 3;
            this.WeaponWindowCmd.Text = "Waffen";
            this.WeaponWindowCmd.UseVisualStyleBackColor = true;
            this.WeaponWindowCmd.Click += new System.EventHandler(this.WeaponWindowCmd_Click);
            // 
            // throw1w6Cmd
            // 
            this.throw1w6Cmd.Location = new System.Drawing.Point(428, 307);
            this.throw1w6Cmd.Name = "throw1w6Cmd";
            this.throw1w6Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw1w6Cmd.TabIndex = 4;
            this.throw1w6Cmd.Text = "1w6";
            this.throw1w6Cmd.UseVisualStyleBackColor = true;
            this.throw1w6Cmd.Click += new System.EventHandler(this.throw1w6Cmd_Click);
            // 
            // throw3w20Cmd
            // 
            this.throw3w20Cmd.Location = new System.Drawing.Point(572, 307);
            this.throw3w20Cmd.Name = "throw3w20Cmd";
            this.throw3w20Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw3w20Cmd.TabIndex = 4;
            this.throw3w20Cmd.Text = "3w20";
            this.throw3w20Cmd.UseVisualStyleBackColor = true;
            this.throw3w20Cmd.Click += new System.EventHandler(this.throw3w20Cmd_Click);
            // 
            // throw3w6Cmd
            // 
            this.throw3w6Cmd.Location = new System.Drawing.Point(476, 307);
            this.throw3w6Cmd.Name = "throw3w6Cmd";
            this.throw3w6Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw3w6Cmd.TabIndex = 4;
            this.throw3w6Cmd.Text = "3w6";
            this.throw3w6Cmd.UseVisualStyleBackColor = true;
            this.throw3w6Cmd.Click += new System.EventHandler(this.throw3w6Cmd_Click);
            // 
            // throw1w20Cmd
            // 
            this.throw1w20Cmd.Location = new System.Drawing.Point(524, 307);
            this.throw1w20Cmd.Name = "throw1w20Cmd";
            this.throw1w20Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw1w20Cmd.TabIndex = 4;
            this.throw1w20Cmd.Text = "1w20";
            this.throw1w20Cmd.UseVisualStyleBackColor = true;
            this.throw1w20Cmd.Click += new System.EventHandler(this.throw1w20Cmd_Click);
            // 
            // diceStringTextBox
            // 
            this.diceStringTextBox.Location = new System.Drawing.Point(429, 281);
            this.diceStringTextBox.Name = "diceStringTextBox";
            this.diceStringTextBox.Size = new System.Drawing.Size(115, 20);
            this.diceStringTextBox.TabIndex = 5;
            this.diceStringTextBox.Text = "1w6+3";
            // 
            // throwDiceStringCmd
            // 
            this.throwDiceStringCmd.Location = new System.Drawing.Point(550, 281);
            this.throwDiceStringCmd.Name = "throwDiceStringCmd";
            this.throwDiceStringCmd.Size = new System.Drawing.Size(64, 20);
            this.throwDiceStringCmd.TabIndex = 6;
            this.throwDiceStringCmd.Text = "Würfeln";
            this.throwDiceStringCmd.UseVisualStyleBackColor = true;
            this.throwDiceStringCmd.Click += new System.EventHandler(this.throwDiceStringCmd_Click);
            // 
            // PlayerSheetBtn
            // 
            this.PlayerSheetBtn.Location = new System.Drawing.Point(428, 13);
            this.PlayerSheetBtn.Name = "PlayerSheetBtn";
            this.PlayerSheetBtn.Size = new System.Drawing.Size(75, 23);
            this.PlayerSheetBtn.TabIndex = 0;
            this.PlayerSheetBtn.Text = "Spieler";
            this.PlayerSheetBtn.UseVisualStyleBackColor = true;
            this.PlayerSheetBtn.Click += new System.EventHandler(this.PlayerSheetBtn_Click);
            // 
            // EnemySheetBtn
            // 
            this.EnemySheetBtn.Location = new System.Drawing.Point(428, 42);
            this.EnemySheetBtn.Name = "EnemySheetBtn";
            this.EnemySheetBtn.Size = new System.Drawing.Size(75, 23);
            this.EnemySheetBtn.TabIndex = 0;
            this.EnemySheetBtn.Text = "Gegner";
            this.EnemySheetBtn.UseVisualStyleBackColor = true;
            this.EnemySheetBtn.Click += new System.EventHandler(this.EnemySheetBtn_Click);
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 388);
            this.Controls.Add(this.throwDiceStringCmd);
            this.Controls.Add(this.diceStringTextBox);
            this.Controls.Add(this.throw1w20Cmd);
            this.Controls.Add(this.throw3w6Cmd);
            this.Controls.Add(this.throw3w20Cmd);
            this.Controls.Add(this.throw1w6Cmd);
            this.Controls.Add(this.WeaponWindowCmd);
            this.Controls.Add(this.ClearLogCmd);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.EnemySheetBtn);
            this.Controls.Add(this.PlayerSheetBtn);
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
        private System.Windows.Forms.Button throw1w6Cmd;
        private System.Windows.Forms.Button throw3w20Cmd;
        private System.Windows.Forms.Button throw3w6Cmd;
        private System.Windows.Forms.Button throw1w20Cmd;
        private System.Windows.Forms.TextBox diceStringTextBox;
        private System.Windows.Forms.Button throwDiceStringCmd;
        private System.Windows.Forms.Button PlayerSheetBtn;
        private System.Windows.Forms.Button EnemySheetBtn;
    }
}