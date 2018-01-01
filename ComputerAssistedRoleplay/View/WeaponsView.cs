using ComputerAssistedRoleplay.Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ComputerAssistedRoleplay.View
{
    public partial class WeaponsView : Form, IWeaponsView
    {
        /// <summary>
        /// The Controller this view is linked to
        /// </summary>
        private WeaponViewController _controller;

        /// <summary>
        /// The ID of the currently selected weapon
        /// </summary>
        public string selectedWeapon { get; set; }

        /// <summary>
        /// Constructor that initializes the view
        /// </summary>
        public WeaponsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clears the Datagrid that holds all weapons
        /// </summary>
        public void WeaponsClearGrid()
        {
            this.WeaponGrid.Rows.Clear();
        }

        /// <summary>
        /// Displays all weapons that are available in the Weaponsfactory
        /// </summary>
        /// <param name="name">List of IDs of the weapon</param>
        /// <param name="cutDamage"> List of Cutting damages of the weapons</param>
        /// <param name="pierceDamage">List of Piercing damages of the weapons</param>
        /// <param name="bashDamage">List of Bashing damages of the weapons</param>
        /// <param name="weight">List of weapon weights</param>
        /// <param name="length">List of weapon lengths</param>
        public void DisplayAllWeapons(List<string> name, List<int> cutDamage, List<int> pierceDamage, List<int> bashDamage, List<int> weight, List<int> length)
        {
            WeaponsClearGrid();

            for(int i = 0; i < name.Count; i++)
            {
                this.WeaponGrid.Rows.Add(name[i], cutDamage[i], bashDamage[i], pierceDamage[i], weight[i], length[i]);
            }

        }

        /// <summary>
        /// Sets the controller that controls the view
        /// </summary>
        /// <param name="controller">Instance of the controller that controls the view</param>
        public void SetController(WeaponViewController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Displays the detailed text of a selected weapon
        /// </summary>
        /// <param name="weaponDetailedText">Text to display</param>
        public void ShowDetailedView(string weaponDetailedText)
        {
            this.DetailedWeaponInfoTextbox.Text = weaponDetailedText;
        }

        #region events
        /// <summary>
        /// Fires when the selection in the Weaponsgrid is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeaponGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(WeaponGrid.SelectedRows.Count > 0) {
                _controller.WeaponSelectionChanged(this.WeaponGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        #endregion
    }
}
