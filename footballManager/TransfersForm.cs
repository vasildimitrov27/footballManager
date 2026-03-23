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
    public partial class TransfersForm : Form
    {
        TransfersRepository transRepo = new TransfersRepository();
        PlayersRepository playerRepo = new PlayersRepository(); // Използваме стария Repo за списъка

        int currentPlayerClubId = 0;

        public TransfersForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Зареждане на историята
            dgvTransfers.DataSource = transRepo.GetTransfersHistory();

            // Зареждане на играчи в ComboBox
            cboPlayer.DataSource = playerRepo.GetPlayers();
            cboPlayer.DisplayMember = "FullName";
            cboPlayer.ValueMember = "PlayerId";

            // Зареждане на целеви клубове
            cboToClub.DataSource = playerRepo.GetClubsForDropdown();
            cboToClub.DisplayMember = "Name";
            cboToClub.ValueMember = "ClubId";
        }

        // Когато изберем играч, трябва да видим от кой клуб ИДВА той
        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlayer.SelectedItem is DataRowView row)
            {
                lblFromClub.Text = row["ClubName"].ToString();
                currentPlayerClubId = Convert.ToInt32(row["ClubId"]);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            int targetClubId = Convert.ToInt32(cboToClub.SelectedValue);

            // ВАЛИДАЦИЯ 4.1: Не към същия клуб
            if (currentPlayerClubId == targetClubId)
            {
                MessageBox.Show("Играчът вече е в този клуб! Изберете различен целеви клуб.", "Валидация");
                return;
            }

            Transfer t = new Transfer
            {
                PlayerId = Convert.ToInt32(cboPlayer.SelectedValue),
                FromClubId = currentPlayerClubId,
                ToClubId = targetClubId,
                TransferDate = dtpTransferDate.Value,
                Fee = numFee.Value,
                Note = txtNote.Text
            };

            if (transRepo.ExecuteTransfer(t))
            {
                MessageBox.Show("Трансферът е извършен успешно!");
                LoadData(); // Обновяваме историята и списъците
            }
        }
    }
}
