﻿using System;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Controller;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Logging;

namespace ComputerAssistedRoleplay.View
{
    public partial class MainWindowView : Form, IMainWindowView
    {
        /// <summary>
        /// The controller that handles the view
        /// </summary>
        private MainWindowController _controller;

        /// <summary>
        /// Creates a new Instance of the Main Window View
        /// </summary>
        public MainWindowView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the controller of the Current view
        /// </summary>
        /// <param name="controller">Controller that controls this view</param>
        public void SetController(MainWindowController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// ILogObserver function when a Log is Changing the Text
        /// </summary>
        /// <param name="log"></param>
        /// <param name="e"></param>
        public void logTextChanged(ILog log, LogEventArgs e)
        {
            if (e.LogCleared)
            {
                this.LogTextBox.Text = "";
            }
            else
            {
                this.LogTextBox.AppendText(e.NewLogEntry + "\r\n");
            }
        }

        #region ButtonEvents
        /// <summary>
        /// Opens the Hitzoneview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitZoneWindowCmd_Click(object sender, EventArgs e)
        {
            HitzoneView hitView = new HitzoneView();
            hitView.Visible = false;

            _controller.setHitZoneController(hitView);

            this.Enabled = true;
            hitView.Show(this);
        }

        /// <summary>
        /// Opens the WeaponsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeaponWindowCmd_Click(object sender, EventArgs e)
        {
            WeaponsView weapView = new WeaponsView();
            weapView.Visible = false;

            _controller.setWeaponController(weapView);

            this.Enabled = true;
            weapView.Show(this);
        }

        /// <summary>
        /// Clears the Log from any entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLogCmd_Click(object sender, EventArgs e)
        {
            _controller.clearLog();
        }

        /// <summary>
        /// Closes the form and calls the procedure for controlled shutdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindowView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Close();
        }

        /// <summary>
        /// Throws one six sided die
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throw1w6Cmd_Click(object sender, EventArgs e)
        {
            _controller.throwDice(1, 6);
        }

        /// <summary>
        /// Throws three six sided dies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throw3w6Cmd_Click(object sender, EventArgs e)
        {
            _controller.throwDice(3, 6);
        }

        /// <summary>
        /// Throws one twenty sided die
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throw1w20Cmd_Click(object sender, EventArgs e)
        {
            _controller.throwDice(1, 20);
        }

        /// <summary>
        /// Throws three twenty sided die.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throw3w20Cmd_Click(object sender, EventArgs e)
        {
            _controller.throwDice(3, 20);
        }

        /// <summary>
        /// Interpretes a dice String and throws that many dice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throwDiceStringCmd_Click(object sender, EventArgs e)
        {
            _controller.throwDiceString(diceStringTextBox.Text);
        }

        /// <summary>
        /// Opens the Player character window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerSheetBtn_Click(object sender, EventArgs e)
        {
            CharacterView playerView = new CharacterView();
            playerView.Text = "Spieler";
            playerView.Visible = false;

            _controller.setPlayerController(playerView);

            this.Enabled = true;
            playerView.Show(this);
        }

        /// <summary>
        /// Opens the enemy character window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemySheetBtn_Click(object sender, EventArgs e)
        {
            CharacterView enemyView = new CharacterView();
            enemyView.Text = "Gegner";
            enemyView.Visible = false;

            _controller.setEnemyController(enemyView);

            this.Enabled = true;
            enemyView.Show(this);
        }

        public void displayPlayerDescription(string description)
        {
            this.characterDescriptionTextBox.Text = description;
        }

        public void displayEnemyDescription(string description)
        {
            this.enemyDescriptionTextBox.Text = description;
        }
        #endregion

        private void playerAttacksBtn_Click(object sender, EventArgs e)
        {
            _controller.playerAttack();
        }

        private void enemyAttacksBtn_Click(object sender, EventArgs e)
        {
            _controller.enemyAttack();
        }
    }
}
