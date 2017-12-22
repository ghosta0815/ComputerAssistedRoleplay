using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
