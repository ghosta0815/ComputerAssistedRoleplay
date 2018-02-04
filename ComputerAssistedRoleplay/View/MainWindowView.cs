using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Controller;
using ComputerAssistedRoleplay.Model.Character;
using ComputerAssistedRoleplay.Model.Misc;

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
        /// Displays the Description of the Player
        /// </summary>
        /// <param name="description"></param>
        public void displayPlayerDescription(string description)
        {
            this.characterDescriptionTextBox.Text = description;
        }

        /// <summary>
        /// Displays the description of the Enemy
        /// </summary>
        /// <param name="description"></param>
        public void displayEnemyDescription(string description)
        {
            this.enemyDescriptionTextBox.Text = description;
        }

        /// <summary>
        /// Sets the text of the LogTextbox to text
        /// </summary>
        /// <param name="text"></param>
        public void SetLogText(string text)
        {
            this.LogTextBox.Text = text;
        }

        /// <summary>
        /// Appends the Text to the Logtextbox
        /// </summary>
        /// <param name="text"></param>
        public void AppendLogText(string text)
        {
            this.LogTextBox.AppendText(text);
        }

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

        /// <summary>
        /// The player attacks the Enemy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerAttacksBtn_Click(object sender, EventArgs e)
        {
            _controller.playerAttack();
        }

        /// <summary>
        /// The Enemy attacks the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enemyAttacksBtn_Click(object sender, EventArgs e)
        {
            _controller.enemyAttack();
        }

        /// <summary>
        /// Button to advane the Combat time is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvanceTimeButton_Click(object sender, EventArgs e)
        {
            _controller.AdvanceTime();
        }

        /// <summary>
        /// Button to reset the Combat time is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetTimeButton_Click(object sender, EventArgs e)
        {
            _controller.ResetTime();
        }

        /// <summary>
        /// Sets the Time Textbox to timeString
        /// </summary>
        /// <param name="timeString">The CombatTime as string</param>
        public void SetTime(string timeString)
        {
            this.CombatTimeTextbox.Text = timeString;
        }

        /// <summary>
        /// The Player selects a new weapon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerWeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.setPlayerWeapon(this.playerWeaponComboBox.Text);
        }

        /// <summary>
        /// The Enemy selects a new weapon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enemyWeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.setEnemyWeapon(this.enemyWeaponComboBox.Text);
        }

        /// <summary>
        /// Displays the weaponNames in the Weapon comboboxes of Player
        /// </summary>
        /// <param name="weaponNames"></param>
        public void displayPlayerWeapons(List<string> weaponNames, string selectedWeapon)
        {
            this.playerWeaponComboBox.Items.AddRange(weaponNames.ToArray());
            this.playerWeaponComboBox.Text = selectedWeapon;
        }

        /// <summary>
        /// Displays the weaponNames in the Weapon comboboxes of the Enemy
        /// </summary>
        /// <param name="weaponNames"></param>
        public void displayEnemyWeapons(List<string> weaponNames, string selectedWeapon)
        {
            this.enemyWeaponComboBox.Items.AddRange(weaponNames.ToArray());
            this.enemyWeaponComboBox.Text = selectedWeapon;
        }
    }
}
