using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerAssistedRoleplay.Controller;

namespace ComputerAssistedRoleplay.View
{
    public partial class MainWindowView : Form, IMainWindowView
    {
        #region Variables
        /// <summary>
        /// The controller that handles the view
        /// </summary>
        private MainWindowController _controller;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new Instance of the Main Window View
        /// </summary>
        public MainWindowView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the controller of the Current view
        /// </summary>
        /// <param name="controller">Controller that controls this view</param>
        public void SetController(MainWindowController controller)
        {
            _controller = controller;
        }
        #endregion

        #region ButtonEvents
        /// <summary>
        /// Opens the Hitzoneview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitZoneWindowCmd_Click(object sender, EventArgs e)
        {
            HitzoneView hitView = new HitzoneView();
            hitView.Visible = false;

            _controller.setHitZoneController(hitView);

            this.Enabled = true;
            hitView.Show(this);
        }
        #endregion
    }
}
