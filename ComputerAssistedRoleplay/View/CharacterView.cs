﻿using System;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Controller;
using ComputerAssistedRoleplay.Model.Character;

namespace ComputerAssistedRoleplay.View
{
    public partial class CharacterView : Form, ICharacterView, ICharacterObserver
    {
        CharacterViewController _controller;

        /// <summary>
        /// Constructor of the view initializes the components created by the designer
        /// </summary>
        public CharacterView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the controller of the view
        /// </summary>
        /// <param name="controller">The Character view controller</param>
        public void SetController(CharacterViewController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Occurs when the Hitpoints Display values are chagned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitPointsDisplay_ValueChanged(object sender, EventArgs e)
        {
            _controller.SetHitpoints(Convert.ToInt32(this.HitPointsDisplay.Value));
        }

        /// <summary>
        /// Displays the Hitpoints of the Character
        /// </summary>
        /// <param name="hitpoints"></param>
        public void DisplayStatus(int hitpoints)
        {
            this.HitPointsDisplay.Value = hitpoints;
        }

        /// <summary>
        /// Displays the Description of the Character
        /// </summary>
        /// <param name="characterDescription"></param>
        public void DisplayCharacterDescription(string characterDescription)
        {
            this.characterDescriptionTextBox.Text = characterDescription;
        }

        public void CharacterChangedEvent(ICharacterSender status, CharacterChangedEventArgs e)
        {
            this.characterDescriptionTextBox.Text = e.CharacterInfo;
        }
    }
}
