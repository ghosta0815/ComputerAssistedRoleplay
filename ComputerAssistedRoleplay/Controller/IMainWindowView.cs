using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAssistedRoleplay.Controller
{
    public interface IMainWindowView
    {
        /// <summary>
        /// Sets the controller of the View
        /// </summary>
        /// <param name="controller">Instance of the controller that is operating the view</param>
        void SetController(MainWindowController controller);
    }
}
