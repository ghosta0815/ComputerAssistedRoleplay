using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.JSON
{
    /// <summary>
    /// JSON format:
    /// [
    ///     {
    ///         "Kopf, Scheitel" : 15,
    ///         "Kopf, Seite/Hinten" : 25,
    ///         "Arm, Hand": 40,
    ///         ...
    ///     }
    /// ]
    /// </summary>
    public class HitzonesJS
    {
        public static string HitZoneJSPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JSON\HitzonesJS.json");
        public Dictionary<string, int> HitZoneValuePairs { get; set; }
    }
}
