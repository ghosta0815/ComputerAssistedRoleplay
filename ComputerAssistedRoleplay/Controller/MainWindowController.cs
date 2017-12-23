using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerAssistedRoleplay.Model;

namespace ComputerAssistedRoleplay.Controller
{
    public class MainWindowController
    {
        #region Variables
        /// <summary>
        /// Interface of the Hitzone Window
        /// </summary>
        IMainWindowView _view;
        /// <summary>
        /// Hitzonefactory of the Main Calculator
        /// </summary>
        CARCalculator _carCalc;
        #endregion

        #region Constructor
        /// <summary>
        /// Createas a new instance of the Hitzone view controller
        /// </summary>
        /// <param name="view">View interface it is linked to</param>
        /// <param name="calculator">Main Calculator class</param>
        public MainWindowController(IMainWindowView view, CARCalculator calculator)
        {
            _view = view;
            _carCalc = calculator;
            view.SetController(this);
            calculator.CombatLog.Subscribe(view);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initial setup of the View (fill with predefined values)
        /// </summary>
        public void LoadView()
        {
            //DO nothing (for now)
        }

        /// <summary>
        /// Sets the Controller of the View
        /// </summary>
        /// <param name="hzView">View of the Hitzone</param>
        public void setHitZoneController(IHitzoneView hzView)
        {
            HitzoneViewController HZControl = new HitzoneViewController(hzView, _carCalc.HitFab);
        }

        /// <summary>
        /// Empties the CombatLog
        /// </summary>
        public void clearLog()
        {
            _carCalc.CombatLog.Clear();
        }
        #endregion
    }
}
