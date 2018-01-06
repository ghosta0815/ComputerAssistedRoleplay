using System;
using System.Collections.Generic;
using ComputerAssistedRoleplay.Model.JSON;
using ComputerAssistedRoleplay.Model.Logging;
using ComputerAssistedRoleplay.Model.RandomGenerator;

namespace ComputerAssistedRoleplay.Model.Hitzone
{
    public class Hitzones
    {
        #region Variables
        /// <summary>
        /// List of Bodyparts of a race that can get hit with the respective hitchance
        /// </summary>
        public List<SingleHitZone> Bodyparts { set; get; }

        /// <summary>
        /// Name of the race where this hitzones apply.
        /// </summary>
        public string RaceName { set; get; }

        /// <summary>
        /// Returns the Sum of all individual hitzoneranges.
        /// </summary>
        public int TotalZonePoints
        {
            get
            {
                int zoneSum = 0;
                foreach (SingleHitZone zone in Bodyparts)
                {
                    zoneSum += zone.DiceRange;
                }
                return zoneSum;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates the Bodyparts that can get hit based on the JSON Inputfile
        /// </summary>
        /// <param name="hitzoneJS">Hitzone JSON that define the Bodyparts</param>
        public Hitzones(string name, Dictionary<string, int> hitzonesDict)
        {
            RaceName = name;
            Bodyparts = new List<SingleHitZone>();

            int toHitNumber = 0;
            foreach(KeyValuePair<string, int> jsHitzone in hitzonesDict)
            {
                Bodyparts.Add(new SingleHitZone(jsHitzone.Key, toHitNumber + 1, toHitNumber + jsHitzone.Value));
                toHitNumber = toHitNumber + jsHitzone.Value;
            }
        }

        /// <summary>
        /// Creates an empty Hitzone object
        /// </summary>
        public Hitzones(string name)
        {
            RaceName = name;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns the hitchance of a single Zone
        /// </summary>
        /// <param name="zone">Name of the Bodypart</param>
        /// <returns>Chance to hit</returns>
        public double GetHitChance(string targetZoneName)
        {
            if (Bodyparts.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (SingleHitZone zone in Bodyparts)
                {
                    if (zone.ZoneName == targetZoneName)
                    {
                        return zone.DiceRange / TotalZonePoints;
                    }
                }
            }

            return 0;
        }
        
        /// <summary>
        /// Throws a dice and returns a bodypart that got hit
        /// </summary>
        /// <returns>Bodypart that got hit</returns>
        public SingleHitZone randomizeHitzone()
        {
            int diceThrow = RNG.Instance.throwDiceWithSides(TotalZonePoints);

            foreach(SingleHitZone bodypart in Bodyparts)
            {
                if(bodypart.isHit(diceThrow))
                {
                    CombatLog.getInstance.Append("Du triffst " + RaceName + ": " + bodypart.ZoneName + " mit " + diceThrow + " auf " + bodypart.ZoneIndexStart + " - " + bodypart.ZoneIndexEnd);
                    return bodypart;
                }
            }

            System.Diagnostics.Debug.WriteLine("This should never appear: A Hitzone was randomly selected that does not exist");
            return new SingleHitZone("none", 0, 0);
        }

        /// <summary>
        /// Returns all Bodypart names in the Collection
        /// </summary>
        /// <returns>List of Bodypartnames</returns>
        public List<string> getHitzoneNames()
        {
            List<string> hitZoneNames = new List<string>();
            foreach(SingleHitZone bodyPart in Bodyparts)
            {
                hitZoneNames.Add(bodyPart.ZoneName);
            }

            return hitZoneNames;
        }

        /// <summary>
        /// Returns all Bodypart starting inidces
        /// </summary>
        /// <returns>List of Bodypart starting indices</returns>
        public List<int> getHitzoneStartIndices()
        {
            List<int> hitZoneStartIndices = new List<int>();
            foreach (SingleHitZone bodyPart in Bodyparts)
            {
                hitZoneStartIndices.Add(bodyPart.ZoneIndexStart);
            }

            return hitZoneStartIndices;
        }

        /// <summary>
        /// Returns all Bodypart ending indices
        /// </summary>
        /// <returns>List of bodypart ending indices</returns>
        public List<int> getHitzoneEndIndices()
        {
            List<int> hitZoneEndIndices = new List<int>();
            foreach (SingleHitZone bodyPart in Bodyparts)
            {
                hitZoneEndIndices.Add(bodyPart.ZoneIndexEnd);
            }

            return hitZoneEndIndices;
        }
        #endregion
    }
}
