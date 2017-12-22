using System;
using ComputerAssistedRoleplay.Model.Hitzone;

namespace ComputerAssistedRoleplay.Controller
{
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
            view.SetController(this);

            this.LoadView();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initial setup of the View (fill with predefined values)
        /// </summary>
        public void LoadView()
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
