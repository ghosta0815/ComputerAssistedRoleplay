using System;
using System.Collections.Generic;
using System.IO;

namespace ComputerAssistedRoleplay.Model.JSON
{
    /// <summary>
    /// JSON format:
    /// {
    ///  "Zwerg": {
    ///    "Kopf": 30,
    ///    "Bauch": 400,
    ///    ...
    ///  },
    ///  "Mensch": {
    ///    "Kopf": 30,
    ///    "Bauch": 400,
    ///    ...
    ///  },
    ///  ...
    /// }
    /// </summary>
    public class HitzonesJS
    {
        /// <summary>
        /// Path to the HitzonesJS.json file
        /// </summary>
        public static string HitZoneJSPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Model\JSON\HitzonesJS.json");

        /// <summary>
        /// Contains the Hitzonevaluepairs that can be converted to Hitzone objects
        /// </summary>
        public Dictionary<string, Dictionary<string, int>> HitZoneIDValuePairs { get; set; }
    }
}
