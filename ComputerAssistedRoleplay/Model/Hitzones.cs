using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerAssistedRoleplay.JSON;

namespace ComputerAssistedRoleplay.Model
{
    class Hitzones
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
        public Hitzones(HitzonesJS jsHitzones)
        {
            int toHitNumber = 0;
            foreach(KeyValuePair<string, int> jsHitzone in jsHitzones.HitZoneValuePairs)
            {
                Bodyparts.Add(new SingleHitZone(jsHitzone.Key, toHitNumber + 1, toHitNumber + jsHitzone.Value));
                toHitNumber = toHitNumber + jsHitzone.Value;
            }
        }

        #endregion

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
        public SingleHitZone determineHitzone()
        {
            Random rand = new Random();
            int diceThrow = rand.Next(1, TotalZonePoints);

            foreach(SingleHitZone bodypart in Bodyparts)
            {
                if(bodypart.isHit(diceThrow))
                {
                    return bodypart;
                }
            }

            System.Diagnostics.Debug.WriteLine("This should never appear: A Hitzone was randomly selected that does not exist");
            return new SingleHitZone("none", 0, 0);
        }
    }
}
