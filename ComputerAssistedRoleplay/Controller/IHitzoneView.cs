using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void SetController(HitzoneViewControl controller);

        #region Hitzones
        /// <summary>
        /// Clears the Hitzone Display
        /// </summary>
        void HitzonesClearGrid();

        /// <summary>
        /// Adds a bodypart to the hitzone display
        /// </summary>
        /// <param name="name">Name of the Bodypart</param>
        /// <param name="minHit">Minimum dice value to hit</param>
        /// <param name="maxHit">Maximum dice value to hit</param>
        void HitzonesAddBodyPart(string name, int minHit, int maxHit);

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
}
