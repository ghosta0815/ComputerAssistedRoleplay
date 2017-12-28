using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ComputerAssistedRoleplay.Model.JSON;
using System.IO;

namespace ComputerAssistedRoleplay.Model.Weapons
{
    class WeaponsFactory
    {
        #region Variables
        private Dictionary<string, Weapon> Weapons { get; set; }
        public List<string> AvailableWeapons
        {
            get
            {
                return Weapons.Keys.ToList<string>();
            }
        }
        #endregion

        #region Constructors
        public WeaponsFactory()
        {
            Weapons = new Dictionary<string, Weapon>();
            WeaponsJS weaponsJS = loadWeaponsJS();
            foreach (KeyValuePair<string, SingleWeaponJS> weaponIdPair in weaponsJS.WeaponsIDValuePairs)
            {
                Weapons.Add(weaponIdPair.Key, new Weapon(weaponIdPair.Value));
            }
        }
        #endregion

        #region Methods
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
        public bool isWeaponAvailable(string weaponName)
        {
            return Weapons.ContainsKey(weaponName);
        }
        #endregion

        #region JSON reader
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
        #endregion
    }
}
