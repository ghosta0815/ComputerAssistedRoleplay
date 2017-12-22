using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Model.Hitzone
{
    /// <summary>
    /// Class that defines a single Bodypart that can get hit with a range of Integers that define the hitchance
    /// </summary>
    public class SingleHitZone
    {
        /// <summary>
        /// Name of the Bodypart that gets hit
        /// </summary>
        public string ZoneName { set; get; }
        /// <summary>
        /// Start of the dice range that defines the hitchance of the bodypart
        /// </summary>
        public int ZoneIndexStart { set; get; }
        /// <summary>
        /// End of the dice range that defines the hitchance of the bodypart
        /// </summary>
        public int ZoneIndexEnd { set; get; }
        /// <summary>
        /// Range of the dice that define the hitchance
        /// </summary>
        public int DiceRange
        {
            get
            {
                return ZoneIndexEnd - ZoneIndexStart + 1;
            }
        }
        /// <summary>
        /// The last dicethrow the bodypart got checked against
        /// </summary>
        public int LastDiceThrow { set; get; }

        /// <summary>
        /// Constructor for a single Bodypart hitzone
        /// </summary>
        /// <param name="name">Name of the Bodypart</param>
        /// <param name="start">Start of the dicerange when it hits</param>
        /// <param name="end">End of the dicerange when it hits</param>
        public SingleHitZone(string name, int start, int end)
        {
            ZoneName = name;
            ZoneIndexStart = start;
            ZoneIndexEnd = end;
        }

        /// <summary>
        /// Returns if the bodypart got hit
        /// </summary>
        /// <param name="diceThrow">Dicethrow against which a hit is checked</param>
        /// <returns>Is the Bodypart hit?</returns>
        public bool isHit(int diceThrow)
        {
            LastDiceThrow = diceThrow;

            //1-15: 1 is hit 15 is hit
            if (diceThrow >= ZoneIndexStart && diceThrow <= ZoneIndexEnd)
            {
                return true;
            }
            else
            {
                return false;
            }              
        }
    }
}
