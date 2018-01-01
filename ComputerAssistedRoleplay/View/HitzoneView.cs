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
    public partial class HitzoneView : Form, IHitzoneView
    {
        /// <summary>
        /// The controller that handles the view
        /// </summary>
        private HitzoneViewController _controller;

        /// <summary>
        /// Name of the currently selected race
        /// </summary>
        public string selectedRace
        {
            get
            {
                return this.RaceHitzonesComboBox.Text;
            }

            set
            {
                this.RaceHitzonesComboBox.Text = value;
            }
        }

        #region Constructors
        /// <summary>
        /// Creates a new instance of the HitzoneView
        /// </summary>
        public HitzoneView()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Sets the controller of the current view
        /// </summary>
        /// <param name="controller">Instance that controls this view</param>
        public void SetController(HitzoneViewController controller)
        {
            _controller = controller;
        }

        #region Methods.Hitzones
        /// <summary>
        /// Clears the displayed Hitzones
        /// </summary>
        public void HitzonesClearGrid()
        {
            this.HitzonesTable.Rows.Clear();
        }

        /// <summary>
        /// Adds a new Bodypart to the Hitzonedisplay
        /// </summary>
        /// <param name="name">Name of the Bodypart</param>
        /// <param name="minHit">Minimum dice value to hit the Bodypart</param>
        /// <param name="maxHit">Maximum dice value to hit the Bodypart</param>
        public void HitzonesAddBodyParts(List<string> name, List<int> minHit, List<int> maxHit)
        {
            for(int i = 0; i < name.Count; i++)
            {
                this.HitzonesTable.Rows.Add(name[i], minHit[i], maxHit[i]);
            }
        }

        /// <summary>
        /// Sets the List of available races
        /// </summary>
        /// <param name="list">List of names of the available races</param>
        public void HitzonesSetAvailableRaces(List<string> list)
        {
            foreach (string race in list)
            {
                this.RaceHitzonesComboBox.Items.Add(race);
            }
        }

        /// <summary>
        /// Highlights the bodypart that got hit
        /// </summary>
        /// <param name="name">Name of the Bodypart</param>
        /// <param name="thrownEyes">Dicethrow that hit the Bodypart</param>
        public void HitzonesIndicateHit(string name, int thrownEyes)
        {
            foreach(DataGridViewRow row in this.HitzonesTable.Rows)
            {
                row.Cells[3].Value = "";
                row.Selected = false;
            }

            foreach (DataGridViewRow row in this.HitzonesTable.Rows)
            {
                if (row.Cells[0].Value.ToString() == name)
                {
                    row.Cells[3].Value = thrownEyes;
                    row.Selected = true;
                    this.HitzonesTable.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Event raised when a different race is chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RaceHitzonesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.RaceChanged(this.RaceHitzonesComboBox.Text);
        }

        /// <summary>
        /// Event raised when a new Hitzone dice throw is requested
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void throwHitzoneCmd_Click(object sender, EventArgs e)
        {
            _controller.RandomizeHitzone();
        }
        #endregion

    }
}
