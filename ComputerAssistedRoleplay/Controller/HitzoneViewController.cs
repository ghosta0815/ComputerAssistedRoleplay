using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Controller
{
    public interface IHitzoneView
    {
        /// <summary>
        /// The currently selected Hitzone of the race that is displayed
        /// </summary>
        string selectedRace { get; set; }

        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the controller that is operating the view</param>
        void SetController(HitzoneViewController controller);

        #region Hitzones
        /// <summary>
        /// Clears the Hitzone Display
        /// </summary>
        void HitzonesClearGrid();

        /// <summary>
        /// Populates the view with all hitzones
        /// </summary>
        /// <param name="name">Name of the Bodypart</param>
        /// <param name="minHit">Minimum dice value to hit</param>
        /// <param name="maxHit">Maximum dice value to hit</param>
        void HitzonesAddBodyParts(List<string> name, List<int> minHit, List<int> maxHit);

        /// <summary>
        /// Sets the available races
        /// </summary>
        /// <param name="list">The available races</param>
        void HitzonesSetAvailableRaces(List<string> list);

        /// <summary>
        /// Highlight the hitzone that got hit
        /// </summary>
        /// <param name="name">Name of the Hitzone</param>
        /// <param name="thrownEyes">Thrown eyes of the dice</param>
        void HitzonesIndicateHit(string name, int thrownEyes);
        #endregion
    }

    public class HitzoneViewController
    {
        #region Variables
        /// <summary>
        /// Interface of the Hitzone Window
        /// </summary>
        IHitzoneView _view;
        /// <summary>
        /// Hitzonefactory of the Main Calculator
        /// </summary>
        HitzoneFactory _hitFab;
        #endregion

        #region Constructor
        /// <summary>
        /// Createas a new instance of the Hitzone view controller
        /// </summary>
        /// <param name="view">View interface it is linked to</param>
        /// <param name="calculator">Main Calculator class</param>
        public HitzoneViewController(IHitzoneView view, HitzoneFactory hitFab)
        {
            _view = view;
            _hitFab = hitFab;
            _view.SetController(this);

            this.LoadView();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initial setup of the View (fill with predefined values)
        /// </summary>
        private void LoadView()
        {
            string defaultRace = _hitFab.AvailableRaces[0];
            Hitzones defaultHitZone = _hitFab.getZonesFor(defaultRace);

            _view.HitzonesClearGrid();
            _view.HitzonesAddBodyParts(defaultHitZone.getHitzoneNames(), defaultHitZone.getHitzoneStartIndices(), defaultHitZone.getHitzoneEndIndices());

            _view.HitzonesSetAvailableRaces(_hitFab.AvailableRaces);
            _view.selectedRace = defaultRace;
        }

        /// <summary>
        /// Changes the Hitzones to the Hitzones of newRace
        /// </summary>
        /// <param name="newRace">Name of the Race</param>
        public void RaceChanged(string newRace)
        {
            _view.HitzonesClearGrid();
            Hitzones newHitZone = _hitFab.getZonesFor(newRace);

            _view.HitzonesAddBodyParts(newHitZone.getHitzoneNames(), newHitZone.getHitzoneStartIndices(), newHitZone.getHitzoneEndIndices());
        }

        /// <summary>
        /// Randomize a hit
        /// </summary>
        public void RandomizeHitzone()
        {
            SingleHitZone zone = _hitFab.getZonesFor(_view.selectedRace).randomizeHitzone();
            _view.HitzonesIndicateHit(zone.ZoneName, zone.LastDiceThrow);
        }
        #endregion
    }
}
