using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.Weapons;

namespace ComputerAssistedRoleplay.Controller
{
    public interface IWeaponsView
    {
        /// <summary>
        /// The currently selected Weapon (show a detailed view)
        /// </summary>
        string selectedWeapon { get; set; }

        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the Weapons controller that is operating the view</param>
        void SetController(WeaponViewController controller);

        #region Methods for WeaponsDisplay
        /// <summary>
        /// Clears the Weapons Display
        /// </summary>
        void WeaponsClearGrid();

        /// <summary>
        /// Populates the view with all Weapons that should be displayed
        /// </summary>
        /// <param name="name">Name of the Weapon</param>
        /// <param name="pierceDamage">Piwrce Damage of the Weapon</param>
        /// <param name="bashDamage">Bashing Damage of the Weapon</param>
        /// <param name="cutDamage">Cutting Damage of the Weapon</param>
        void DisplayAllWeapons(List<string> name, List<string> cutDamage, List<string> pierceDamage, List<string> bashDamage, List<int> weight, List<int> length);

        /// <summary>
        /// Shows a detailed view of the selected Weapon
        /// </summary>
        /// <param name="weaponName">Name of the Weapon to be displayed</param>
        void ShowDetailedView(string weaponName);
        #endregion
    }

    public class WeaponViewController
    {
        #region Variables
        /// <summary>
        /// The View the controller is linked to;
        /// </summary>
        private IWeaponsView _view;

        /// <summary>
        /// The Weapons factory the controller is linked to
        /// </summary>
        private WeaponsFactory _weapFab;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an instance of the View Controller
        /// </summary>
        /// <param name="view">The View the Controller is relating to</param>
        /// <param name="weapFab">The Weapons Factory the Controller is relating to</param>
        public WeaponViewController(IWeaponsView view, WeaponsFactory weapFab)
        {
            _view = view;
            _weapFab = weapFab;

            _view.SetController(this);
            this.loadView();

        }

        /// <summary>
        /// Loads the View and populates it with its initial values
        /// </summary>
        private void loadView()
        {
            DeliverWeaponsToView();
        }

        /// <summary>
        /// Transforms all avaialble Weapons in individual Lists for display
        /// </summary>
        private void DeliverWeaponsToView()
        {
            List<string> weapNames = new List<string>();
            List<string> weapBashDamages = new List<string>();
            List<string> weapCutDamages = new List<string>();
            List<string> weapPierceDamages = new List<string>();
            List<int> weapWeights = new List<int>();
            List<int> weapLengths = new List<int>();

            foreach (string weapID in _weapFab.AvailableWeapons)
            {
                weapNames.Add(weapID);
                weapBashDamages.Add(_weapFab.getWeapon(weapID).BashDamage.ToString());
                weapCutDamages.Add(_weapFab.getWeapon(weapID).CutDamage.ToString());
                weapPierceDamages.Add(_weapFab.getWeapon(weapID).PierceDamage.ToString());
                weapWeights.Add(_weapFab.getWeapon(weapID).Weight);
                weapLengths.Add(_weapFab.getWeapon(weapID).Length);
            }

            _view.DisplayAllWeapons(weapNames, weapCutDamages, weapPierceDamages, weapBashDamages, weapWeights, weapLengths);
        }

        /// <summary>
        /// Occurs when a different weapon is selected and displays a detailed view of the weapon
        /// </summary>
        /// <param name="weaponID">ID of the Weapon</param>
        internal void WeaponSelectionChanged(string weaponID)
        {
            Weapon weaponToDisplay = _weapFab.getWeapon(weaponID);
            _view.selectedWeapon = weaponToDisplay.Name;

            _view.ShowDetailedView(weaponToDisplay.ToString());
        }
        #endregion
    }
}