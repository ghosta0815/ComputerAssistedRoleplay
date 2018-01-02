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
using ComputerAssistedRoleplay.Model.Logging;

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

        /// <summary>
        /// ILogObserver function when a Log is Changing the Text
        /// </summary>
        /// <param name="log"></param>
        /// <param name="e"></param>
        public void logTextChanged(ILog log, LogEventArgs e)
        {
            if (e.LogCleared)
            {
                this.LogTextBox.Text = "";
            }
            else
            {
                this.LogTextBox.AppendText(e.NewLogEntry + "\r\n");
            }
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

        /// <summary>
        /// Opens the WeaponsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeaponWindowCmd_Click(object sender, EventArgs e)
        {
            WeaponsView weapView = new WeaponsView();
            weapView.Visible = false;

            _controller.setWeaponController(weapView);

            this.Enabled = true;
            weapView.Show(this);
        }

        /// <summary>
        /// Clears the Log from any entries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLogCmd_Click(object sender, EventArgs e)
        {
            _controller.clearLog();
        }

        #endregion

        private void MainWindowView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _controller.Close();
        }
    }
}
