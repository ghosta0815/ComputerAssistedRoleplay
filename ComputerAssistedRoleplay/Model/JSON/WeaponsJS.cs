using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

    public class SingleWeaponJS
    {
        [JsonProperty("Name")]
        public string Name { set; get; } = "";

        [JsonProperty("PierceDamage")]
        public string PierceDamageString { set; get; } = "";

        [JsonProperty("BashDamage")]
        public string BashDamageString { set; get; } = "";

        [JsonProperty("CutDamage")]
        public string CutDamageString { set; get; } = "";

        [JsonProperty("Weight")]
        public int Weight { set; get; } = 0;

        [JsonProperty("Length")]
        public int Length { set; get; } = 0;

        [JsonProperty("StatusEffects")]
        public List<string> StatusEffects { get; set; } = new List<string>();

    }
}
