using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace footballManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ClubsButton_Click(object sender, EventArgs e)
        {
            ClubsForm clubsform = new ClubsForm();
            clubsform.ShowDialog();
        }

        private void PlayersButton_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.ShowDialog();
        }

        private void LeaguesButton_Click(object sender, EventArgs e)
        {
            LeaguesForm leaguesForm = new LeaguesForm();
            leaguesForm.ShowDialog();
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();
            transfersForm.ShowDialog();
        }
    }
}
