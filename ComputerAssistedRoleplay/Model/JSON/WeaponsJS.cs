using System;
using System.Collections.Generic;
using System.IO;

namespace ComputerAssistedRoleplay.Model.JSON
{
    class WeaponsJS
    {
        /// <summary>
        /// Path to the WeaponsJS.json file
        /// </summary>
        public static string WeaponsJSPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Model\JSON\WeaponsJS.json");
        public Dictionary<string, SingleWeaponJS> WeaponsIDValuePairs {get;set;} = new Dictionary<string,SingleWeaponJS>();
    }

    class SingleWeaponJS
    {
        public string Name { set; get; } = "";
        public int PierceDamage { set; get; } = 0;
        public int BashDamage { set; get; } = 0;
        public int CutDamage { set; get; } = 0;
        public List<string> StatusEffects { get; set; } = new List<string>();

    }
}
