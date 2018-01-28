namespace ComputerAssistedRoleplay.View
{
    partial class CharacterView
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
            this.attackBtn = new System.Windows.Forms.Button();
            this.HitPointsDisplay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.HitPointsDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // attackBtn
            // 
            this.attackBtn.Location = new System.Drawing.Point(197, 13);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(75, 23);
            this.attackBtn.TabIndex = 0;
            this.attackBtn.Text = "Angriff";
            this.attackBtn.UseVisualStyleBackColor = true;
            this.attackBtn.Click += new System.EventHandler(this.attackBtn_Click);
            // 
            // HitPointsDisplay
            // 
            this.HitPointsDisplay.Location = new System.Drawing.Point(13, 13);
            this.HitPointsDisplay.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.HitPointsDisplay.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.HitPointsDisplay.Name = "HitPointsDisplay";
            this.HitPointsDisplay.Size = new System.Drawing.Size(120, 20);
            this.HitPointsDisplay.TabIndex = 1;
            this.HitPointsDisplay.ValueChanged += new System.EventHandler(this.HitPointsDisplay_ValueChanged);
            // 
            // CharacterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.HitPointsDisplay);
            this.Controls.Add(this.attackBtn);
            this.Name = "CharacterView";
            this.Text = "CharacterView";
            ((System.ComponentModel.ISupportInitialize)(this.HitPointsDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button attackBtn;
        private System.Windows.Forms.NumericUpDown HitPointsDisplay;
    }
}