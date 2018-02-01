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
            this.HitPointsDisplay = new System.Windows.Forms.NumericUpDown();
            this.characterDescriptionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.HitPointsDisplay)).BeginInit();
            this.SuspendLayout();
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
            // characterDescriptionTextBox
            // 
            this.characterDescriptionTextBox.Location = new System.Drawing.Point(13, 40);
            this.characterDescriptionTextBox.Multiline = true;
            this.characterDescriptionTextBox.Name = "characterDescriptionTextBox";
            this.characterDescriptionTextBox.ReadOnly = true;
            this.characterDescriptionTextBox.Size = new System.Drawing.Size(484, 597);
            this.characterDescriptionTextBox.TabIndex = 2;
            // 
            // CharacterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 649);
            this.Controls.Add(this.characterDescriptionTextBox);
            this.Controls.Add(this.HitPointsDisplay);
            this.Name = "CharacterView";
            this.Text = "CharacterView";
            ((System.ComponentModel.ISupportInitialize)(this.HitPointsDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown HitPointsDisplay;
        private System.Windows.Forms.TextBox characterDescriptionTextBox;
    }
}