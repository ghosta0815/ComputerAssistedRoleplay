using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Model;
using ComputerAssistedRoleplay.View;
using ComputerAssistedRoleplay.Controller;

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
            HitzoneView view = new HitzoneView();
            view.Visible = false;

            CARCalculator calc = new CARCalculator();

            HitzoneViewControl MVControl = new HitzoneViewControl(view, calc);
            MVControl.LoadView();

            view.ShowDialog();

        }
    }
}
