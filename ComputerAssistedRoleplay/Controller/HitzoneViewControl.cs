using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerAssistedRoleplay.Model;

namespace ComputerAssistedRoleplay.Controller
{
    public class HitzoneViewControl
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
        public HitzoneViewControl(IHitzoneView view, CARCalculator calculator)
        {
            _view = view;
            _hitFab = calculator.HitFab;
            view.SetController(this);
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
            foreach(SingleHitZone bodyPart in defaultHitZone.Bodyparts)
            {
                _view.HitzonesAddBodyPart(bodyPart.ZoneName, bodyPart.ZoneIndexStart, bodyPart.ZoneIndexEnd);
            }

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
            foreach (SingleHitZone bodyPart in newHitZone.Bodyparts)
            {
                _view.HitzonesAddBodyPart(bodyPart.ZoneName, bodyPart.ZoneIndexStart, bodyPart.ZoneIndexEnd);
            }
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
