using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ComputerAssistedRoleplay.Model.JSON;
using System.IO;

namespace ComputerAssistedRoleplay.Model.Weapons
{
    /// <summary>
    /// A Factory Object for the creation of Weapons
    /// Uses WeaponsJS.json to create Weapons based on a configuration file
    /// </summary>
    class WeaponsFactory
    {
        #region Variables
        /// <summary>
        /// Contains key value pairs of all available weapons
        /// </summary>
        private Dictionary<string, Weapon> Weapons { get; set; }

        /// <summary>
        /// List of available weapons
        /// </summary>
        public List<string> AvailableWeapons
        {
            get
            {
                return Weapons.Keys.ToList<string>();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for the Weapons factory
        /// </summary>
        public WeaponsFactory()
        {
            WeaponsJS weaponsJS = loadWeaponsJS();
            Weapons = convertToWeapons(weaponsJS);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method to receive a weapon instance
        /// </summary>
        /// <param name="weaponName">Name (ID) of the Weapon</param>
        /// <returns>Weapon object</returns>
        /// 
        public Weapon getWeapon(string weaponName)
        {
            if (Weapons.ContainsKey(weaponName))
            {
                return Weapons[weaponName];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Weapon {0} not found", weaponName);
                return new Weapon();
            }
        }

        /// <summary>
        /// Checks if the weapon exists in the factory
        /// </summary>
        /// <param name="weaponName">Name (ID) of the Weapon</param>
        /// <returns></returns>
        public bool isWeaponAvailable(string weaponName)
        {
            return Weapons.ContainsKey(weaponName);
        }
        #endregion

        #region JSON reader
        /// <summary>
        /// Reads the WeaponsJS.json and converts it to a JSON Object
        /// </summary>
        /// <returns></returns>
        private WeaponsJS loadWeaponsJS()
        {
            WeaponsJS weaponsJS = new WeaponsJS();
            try
            {
                weaponsJS.WeaponsIDValuePairs = JsonConvert.DeserializeObject<Dictionary<string, SingleWeaponJS>>(File.ReadAllText(WeaponsJS.WeaponsJSPath));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while parsing: " + WeaponsJS.WeaponsJSPath);
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            return weaponsJS;
        }

        /// <summary>
        /// Converts a Weapons Json object to a Weapons Object that can be used ingame
        /// </summary>
        /// <param name="weaponsJS">JSON Object containing weapons data</param>
        /// <returns>Weapons object for further use</returns>
        private Dictionary<string, Weapon> convertToWeapons(WeaponsJS weaponsJS)
        {
            Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();
            foreach (KeyValuePair<string, SingleWeaponJS> weaponIdPair in weaponsJS.WeaponsIDValuePairs)
            {
                weapons.Add(weaponIdPair.Key, new Weapon(weaponIdPair.Value));
            }

            return weapons;
        }
        #endregion
    }
}
