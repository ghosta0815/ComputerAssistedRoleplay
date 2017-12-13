using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ComputerAssistedRoleplay.JSON;
using Newtonsoft.Json;


namespace ComputerAssistedRoleplay.Model
{
    class HitzoneFactory
    {
        #region Variables
        /// <summary>
        /// Available Hitzones for the races
        /// </summary>
        private Dictionary<string, Hitzones> RaceHitzones { get; set; }

        /// <summary>
        /// The list of available races
        /// </summary>
        public List<string> AvailableRaces
        {
            get { return RaceHitzones.Keys.ToList(); }

        }
        #endregion

        #region Constructors
        public HitzoneFactory()
        {
            RaceHitzones = new Dictionary<string, Hitzones>();
            Dictionary<string, HitzonesJS> jsHitzones = loadHitzonesJSON();

            foreach(KeyValuePair<string, HitzonesJS> jsHitzone in jsHitzones)
            {
                RaceHitzones.Add(jsHitzone.Key, new Hitzones(jsHitzone.Key, jsHitzone.Value));
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Hitzone based on the Race
        /// </summary>
        /// <param name="race">Race you want to get the hitzone for</param>
        /// <returns>Hitzones for the specified object</returns>
        public Hitzones getZonesFor(string race)
        {
            if(RaceHitzones.ContainsKey(race))
            {
                return RaceHitzones[race];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Hitzones for Race {0} not found", race);
                return new Hitzones(race);
            }
        }

        /// <summary>
        /// Loads the available Hitzones from the JSON
        /// </summary>
        /// <returns>Hitzones</returns>
        private Dictionary<string, HitzonesJS> loadHitzonesJSON()
        {
            Dictionary<string, HitzonesJS> jsHitzones = null;
            try
            {
                jsHitzones = JsonConvert.DeserializeObject<Dictionary<string, HitzonesJS>>(File.ReadAllText(HitzonesJS.HitZoneJSPath));
                foreach(string key in jsHitzones.Keys)
                {
                    System.Diagnostics.Debug.WriteLine("Here is the Name: " + key);
                    foreach(string hzJS in jsHitzones[key].HitZoneValuePairs.Keys)
                    {
                        System.Diagnostics.Debug.WriteLine("Here are the Bodyparts: " + hzJS);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while parsing: " + HitzonesJS.HitZoneJSPath);
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            return jsHitzones;
        }
        #endregion

        //JSON Writer:
        //do not know yet...
    }
}
