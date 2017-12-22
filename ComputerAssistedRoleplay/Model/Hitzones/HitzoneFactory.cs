﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ComputerAssistedRoleplay.Model.JSON;
using ComputerAssistedRoleplay.Model.Logging;
using Newtonsoft.Json;


namespace ComputerAssistedRoleplay.Model.Hitzone
{
    public class HitzoneFactory
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

        private Random Rand { get; set; }
        private Log CombatLog { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the Hitzone Factory
        /// </summary>
        public HitzoneFactory(Random rand, Log log)
        {
            Rand = rand;
            CombatLog = log;
            RaceHitzones = new Dictionary<string, Hitzones>();
            HitzonesJS jsHitzones = loadHitzonesJSON();

            foreach(KeyValuePair<string, Dictionary<string, int>> hitzones in jsHitzones.HitZoneValuePairs)
            {
                RaceHitzones.Add(hitzones.Key, new Hitzones(hitzones.Key, hitzones.Value, Rand, CombatLog));
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
                return new Hitzones(race, Rand, CombatLog);
            }
        }

        /// <summary>
        /// Check if the Race is available
        /// </summary>
        /// <param name="race">Name of the Race</param>
        /// <returns>true if race is available</returns>
        public bool isZoneAvailable(string race)
        {
            return AvailableRaces.Contains(race);
        }

        /// <summary>
        /// Loads the available Hitzones from the JSON
        /// </summary>
        /// <returns>Hitzones</returns>
        private HitzonesJS loadHitzonesJSON()
        {
            HitzonesJS jsHitzones = new HitzonesJS();
            try
            {
                jsHitzones.HitZoneValuePairs = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,int>>>(File.ReadAllText(HitzonesJS.HitZoneJSPath));
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
        //Takes the RaceHitzones and converts it to HitzonesJS class, which is converted to HitzonesJS.json
    }
}