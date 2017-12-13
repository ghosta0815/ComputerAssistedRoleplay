using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Model;

namespace ComputerAssistedRoleplay
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            HitzoneFactory hitZoneFab = new HitzoneFactory();
            Hitzones humanHitzones = hitZoneFab.getZonesFor("Mensch");

            System.Diagnostics.Debug.WriteLine("Race Name: " + humanHitzones.RaceName);
            System.Diagnostics.Debug.WriteLine("Total Zone Points: " + humanHitzones.TotalZonePoints);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);
            System.Diagnostics.Debug.WriteLine("Random Hitzone: " + humanHitzones.randomizeHitzone().ZoneName);

        }
    }
}
