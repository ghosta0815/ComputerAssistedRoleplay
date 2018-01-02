using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerAssistedRoleplay.Model;
using ComputerAssistedRoleplay.Model.Logging;

namespace ComputerAssistedRoleplay.Controller
{
    public interface IMainWindowView : ILogObserver
    {
        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the controller that is operating the view</param>
        void SetController(MainWindowController controller);
    }

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
            _view.SetController(this);
            _carCalc.Log.Subscribe(_view);
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
        /// Sets the Controller of the Hitzone View
        /// </summary>
        /// <param name="hzView">View of the Hitzone</param>
        public void setHitZoneController(IHitzoneView hzView)
        {
            HitzoneViewController HZControl = new HitzoneViewController(hzView, _carCalc.HitFab);
        }

        /// <summary>
        /// Sets the Controller of the Weapons View
        /// </summary>
        /// <param name="wpView">View of the Weapons</param>
        public void setWeaponController(IWeaponsView wpView)
        {
            WeaponViewController WPView = new WeaponViewController(wpView, _carCalc.WeapFab);
        }

        /// <summary>
        /// Empties the CombatLog
        /// </summary>
        public void clearLog()
        {
            _carCalc.Log.Clear();
        }

        /// <summary>
        /// Close action of the MainWindow (Cleanup time)
        /// </summary>
        internal void Close()
        {
            _carCalc.Log.UnSubscribe(_view);
        }
        #endregion
    }
}
