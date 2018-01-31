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
            this.characterDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.enemyDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.playerAttacksBtn = new System.Windows.Forms.Button();
            this.enemyAttacksBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HitZoneWindowCmd
            // 
            this.HitZoneWindowCmd.Location = new System.Drawing.Point(20, 321);
            this.HitZoneWindowCmd.Name = "HitZoneWindowCmd";
            this.HitZoneWindowCmd.Size = new System.Drawing.Size(75, 23);
            this.HitZoneWindowCmd.TabIndex = 0;
            this.HitZoneWindowCmd.Text = "Trefferzonen";
            this.HitZoneWindowCmd.UseVisualStyleBackColor = true;
            this.HitZoneWindowCmd.Click += new System.EventHandler(this.HitZoneWindowCmd_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogTextBox.Location = new System.Drawing.Point(0, 517);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(963, 174);
            this.LogTextBox.TabIndex = 1;
            // 
            // ClearLogCmd
            // 
            this.ClearLogCmd.Location = new System.Drawing.Point(20, 379);
            this.ClearLogCmd.Name = "ClearLogCmd";
            this.ClearLogCmd.Size = new System.Drawing.Size(75, 23);
            this.ClearLogCmd.TabIndex = 2;
            this.ClearLogCmd.Text = "Log leeren";
            this.ClearLogCmd.UseVisualStyleBackColor = true;
            this.ClearLogCmd.Click += new System.EventHandler(this.ClearLogCmd_Click);
            // 
            // WeaponWindowCmd
            // 
            this.WeaponWindowCmd.Location = new System.Drawing.Point(20, 350);
            this.WeaponWindowCmd.Name = "WeaponWindowCmd";
            this.WeaponWindowCmd.Size = new System.Drawing.Size(75, 23);
            this.WeaponWindowCmd.TabIndex = 3;
            this.WeaponWindowCmd.Text = "Waffen";
            this.WeaponWindowCmd.UseVisualStyleBackColor = true;
            this.WeaponWindowCmd.Click += new System.EventHandler(this.WeaponWindowCmd_Click);
            // 
            // throw1w6Cmd
            // 
            this.throw1w6Cmd.Location = new System.Drawing.Point(19, 238);
            this.throw1w6Cmd.Name = "throw1w6Cmd";
            this.throw1w6Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw1w6Cmd.TabIndex = 4;
            this.throw1w6Cmd.Text = "1w6";
            this.throw1w6Cmd.UseVisualStyleBackColor = true;
            this.throw1w6Cmd.Click += new System.EventHandler(this.throw1w6Cmd_Click);
            // 
            // throw3w20Cmd
            // 
            this.throw3w20Cmd.Location = new System.Drawing.Point(163, 238);
            this.throw3w20Cmd.Name = "throw3w20Cmd";
            this.throw3w20Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw3w20Cmd.TabIndex = 4;
            this.throw3w20Cmd.Text = "3w20";
            this.throw3w20Cmd.UseVisualStyleBackColor = true;
            this.throw3w20Cmd.Click += new System.EventHandler(this.throw3w20Cmd_Click);
            // 
            // throw3w6Cmd
            // 
            this.throw3w6Cmd.Location = new System.Drawing.Point(67, 238);
            this.throw3w6Cmd.Name = "throw3w6Cmd";
            this.throw3w6Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw3w6Cmd.TabIndex = 4;
            this.throw3w6Cmd.Text = "3w6";
            this.throw3w6Cmd.UseVisualStyleBackColor = true;
            this.throw3w6Cmd.Click += new System.EventHandler(this.throw3w6Cmd_Click);
            // 
            // throw1w20Cmd
            // 
            this.throw1w20Cmd.Location = new System.Drawing.Point(115, 238);
            this.throw1w20Cmd.Name = "throw1w20Cmd";
            this.throw1w20Cmd.Size = new System.Drawing.Size(42, 40);
            this.throw1w20Cmd.TabIndex = 4;
            this.throw1w20Cmd.Text = "1w20";
            this.throw1w20Cmd.UseVisualStyleBackColor = true;
            this.throw1w20Cmd.Click += new System.EventHandler(this.throw1w20Cmd_Click);
            // 
            // diceStringTextBox
            // 
            this.diceStringTextBox.Location = new System.Drawing.Point(20, 212);
            this.diceStringTextBox.Name = "diceStringTextBox";
            this.diceStringTextBox.Size = new System.Drawing.Size(115, 20);
            this.diceStringTextBox.TabIndex = 5;
            this.diceStringTextBox.Text = "1w6+3";
            // 
            // throwDiceStringCmd
            // 
            this.throwDiceStringCmd.Location = new System.Drawing.Point(141, 212);
            this.throwDiceStringCmd.Name = "throwDiceStringCmd";
            this.throwDiceStringCmd.Size = new System.Drawing.Size(64, 20);
            this.throwDiceStringCmd.TabIndex = 6;
            this.throwDiceStringCmd.Text = "Würfeln";
            this.throwDiceStringCmd.UseVisualStyleBackColor = true;
            this.throwDiceStringCmd.Click += new System.EventHandler(this.throwDiceStringCmd_Click);
            // 
            // PlayerSheetBtn
            // 
            this.PlayerSheetBtn.Location = new System.Drawing.Point(3, 6);
            this.PlayerSheetBtn.Name = "PlayerSheetBtn";
            this.PlayerSheetBtn.Size = new System.Drawing.Size(75, 23);
            this.PlayerSheetBtn.TabIndex = 0;
            this.PlayerSheetBtn.Text = "Spieler";
            this.PlayerSheetBtn.UseVisualStyleBackColor = true;
            this.PlayerSheetBtn.Click += new System.EventHandler(this.PlayerSheetBtn_Click);
            // 
            // EnemySheetBtn
            // 
            this.EnemySheetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnemySheetBtn.Location = new System.Drawing.Point(204, 6);
            this.EnemySheetBtn.Name = "EnemySheetBtn";
            this.EnemySheetBtn.Size = new System.Drawing.Size(75, 23);
            this.EnemySheetBtn.TabIndex = 0;
            this.EnemySheetBtn.Text = "Gegner";
            this.EnemySheetBtn.UseVisualStyleBackColor = true;
            this.EnemySheetBtn.Click += new System.EventHandler(this.EnemySheetBtn_Click);
            // 
            // characterDescriptionTextBox
            // 
            this.characterDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.characterDescriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this.characterDescriptionTextBox.Multiline = true;
            this.characterDescriptionTextBox.Name = "characterDescriptionTextBox";
            this.characterDescriptionTextBox.ReadOnly = true;
            this.characterDescriptionTextBox.Size = new System.Drawing.Size(333, 517);
            this.characterDescriptionTextBox.TabIndex = 7;
            // 
            // enemyDescriptionTextBox
            // 
            this.enemyDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyDescriptionTextBox.Location = new System.Drawing.Point(630, 0);
            this.enemyDescriptionTextBox.Multiline = true;
            this.enemyDescriptionTextBox.Name = "enemyDescriptionTextBox";
            this.enemyDescriptionTextBox.ReadOnly = true;
            this.enemyDescriptionTextBox.Size = new System.Drawing.Size(330, 511);
            this.enemyDescriptionTextBox.TabIndex = 8;
            // 
            // playerAttacksBtn
            // 
            this.playerAttacksBtn.Location = new System.Drawing.Point(3, 35);
            this.playerAttacksBtn.Name = "playerAttacksBtn";
            this.playerAttacksBtn.Size = new System.Drawing.Size(75, 23);
            this.playerAttacksBtn.TabIndex = 9;
            this.playerAttacksBtn.Text = "Angriff -->";
            this.playerAttacksBtn.UseVisualStyleBackColor = true;
            this.playerAttacksBtn.Click += new System.EventHandler(this.playerAttacksBtn_Click);
            // 
            // enemyAttacksBtn
            // 
            this.enemyAttacksBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enemyAttacksBtn.Location = new System.Drawing.Point(204, 35);
            this.enemyAttacksBtn.Name = "enemyAttacksBtn";
            this.enemyAttacksBtn.Size = new System.Drawing.Size(75, 23);
            this.enemyAttacksBtn.TabIndex = 10;
            this.enemyAttacksBtn.Text = "<-- Angriff";
            this.enemyAttacksBtn.UseVisualStyleBackColor = true;
            this.enemyAttacksBtn.Click += new System.EventHandler(this.enemyAttacksBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(335, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(293, 517);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.EnemySheetBtn);
            this.tabPage1.Controls.Add(this.playerAttacksBtn);
            this.tabPage1.Controls.Add(this.enemyAttacksBtn);
            this.tabPage1.Controls.Add(this.HitZoneWindowCmd);
            this.tabPage1.Controls.Add(this.ClearLogCmd);
            this.tabPage1.Controls.Add(this.throwDiceStringCmd);
            this.tabPage1.Controls.Add(this.PlayerSheetBtn);
            this.tabPage1.Controls.Add(this.WeaponWindowCmd);
            this.tabPage1.Controls.Add(this.diceStringTextBox);
            this.tabPage1.Controls.Add(this.throw1w20Cmd);
            this.tabPage1.Controls.Add(this.throw1w6Cmd);
            this.tabPage1.Controls.Add(this.throw3w6Cmd);
            this.tabPage1.Controls.Add(this.throw3w20Cmd);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(285, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(285, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 691);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.enemyDescriptionTextBox);
            this.Controls.Add(this.characterDescriptionTextBox);
            this.Controls.Add(this.LogTextBox);
            this.Name = "MainWindowView";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowView_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
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
        private System.Windows.Forms.TextBox characterDescriptionTextBox;
        private System.Windows.Forms.TextBox enemyDescriptionTextBox;
        private System.Windows.Forms.Button playerAttacksBtn;
        private System.Windows.Forms.Button enemyAttacksBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}