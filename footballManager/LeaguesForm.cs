using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace footballManager
{
    public partial class LeaguesForm : Form
    {
        LeaguesRepository repo = new LeaguesRepository();
        int selectedLeagueId = 0;

        public LeaguesForm()
        {
            InitializeComponent();
            LoadLeagues();
        }

        private void LoadLeagues()
        {
            dgvLeagues.DataSource = repo.GetAllLeagues();

            if (dgvLeagues.Columns["LeagueID"] != null)
                dgvLeagues.Columns["LeagueID"].HeaderText = "ID на лига";
            if (dgvLeagues.Columns["Name"] != null)
                dgvLeagues.Columns["Name"].HeaderText = "Име";
            if (dgvLeagues.Columns["Season"] != null)
                dgvLeagues.Columns["Season"].HeaderText = "Сезон";



        }

        private void dgvLeagues_SelectionChanged(object sender, EventArgs e)
        {
            // Използваме CurrentRow вместо SelectedRows - много по-сигурно е!
            if (dgvLeagues.CurrentRow != null && dgvLeagues.CurrentRow.Index > -1)
            {
                selectedLeagueId = Convert.ToInt32(dgvLeagues.CurrentRow.Cells["LeagueId"].Value);
                RefreshParticipants();
            }
        }

        private void RefreshParticipants()
        {
            if (selectedLeagueId == 0) return;

            // 1. Списък с текущи участници
            dgvParticipants.DataSource = repo.GetParticipants(selectedLeagueId);
            if (dgvParticipants.Columns["ClubId"] != null)
                dgvParticipants.Columns["ClubId"].HeaderText = "ID на клуб";
            if (dgvParticipants.Columns["Name"] != null)
                dgvParticipants.Columns["Name"].HeaderText = "Име";
            if (dgvParticipants.Columns["City"] != null)
                dgvParticipants.Columns["City"].HeaderText = "Град";

            // 2. Списък с налични за добавяне клубове
            cboAvailableClubs.DataSource = repo.GetAvailableClubs(selectedLeagueId);
            cboAvailableClubs.DisplayMember = "Name";
            cboAvailableClubs.ValueMember = "ClubId";
        }

        private void btnAddLeague_Click(object sender, EventArgs e)
        {
            string name = txtLeagueName.Text.Trim();
            string season = txtSeason.Text.Trim();

            // Валидация за формат YYYY/YYYY
            if (!Regex.IsMatch(season, @"^\d{4}/\d{4}$"))
            {
                MessageBox.Show("Сезонът трябва да е във формат 2025/2026");
                return;
            }

            if (repo.AddLeague(name, season))
            {
                LoadLeagues();
            }
        }

        private void btnAddClubToLeague_Click(object sender, EventArgs e)
        {
            if (selectedLeagueId == 0 || cboAvailableClubs.SelectedValue == null) return;

            int clubId = Convert.ToInt32(cboAvailableClubs.SelectedValue);
            if (repo.AddClubToLeague(selectedLeagueId, clubId))
            {
                RefreshParticipants();
            }
        }

        private void btnRemoveClub_Click(object sender, EventArgs e)
        {
            if (selectedLeagueId == 0 || dgvParticipants.SelectedRows.Count == 0) return;

            int clubId = Convert.ToInt32(dgvParticipants.SelectedRows[0].Cells["ClubId"].Value);
            string clubName = dgvParticipants.SelectedRows[0].Cells["Name"].Value.ToString();

            var res = MessageBox.Show($"Премахване на {clubName} от лигата?", "Потвърждение", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                if (repo.RemoveClubFromLeague(selectedLeagueId, clubId))
                {
                    RefreshParticipants();
                }
                else
                {
                    MessageBox.Show("Не може да премахнете отбор, който вече има записани мачове!");
                }
            }
        }

        private void Сезон_Click(object sender, EventArgs e)
        {

        }
    }
}