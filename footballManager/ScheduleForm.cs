using System;
using System.Data;
using System.Windows.Forms;

namespace footballManager
{
    public partial class ScheduleForm : Form
    {
        private ScheduleService service = new ScheduleService();

        public ScheduleForm()
        {
            InitializeComponent();
            LoadLeaguesCombo();
            LoadSchedule(1);
        }

        // 1. Метод за зареждане на мачовете в DataGridView
        private void LoadSchedule(int leagueId)
        {
            try
            {
                // Викаме бизнес слоя (BLL) да ни върне таблицата с мачовете
                DataTable dtMatches = service.GetScheduleTable(leagueId);

                // Закачаме я за DataGridView-то
                dgvMatches.DataSource = dtMatches;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на програмата: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLeaguesCombo()
        {
            cboLeagues.DataSource = service.GetLeagues();
            cboLeagues.DisplayMember = "LeagueInfo";
            cboLeagues.ValueMember = "LeagueId";

            if (cboLeagues.Items.Count > 0)
                cboLeagues.SelectedIndex = 0;
        }

        // При смяна на лигата от падащото меню, веднага показваме мачовете ѝ (ако има)
        private void cboLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLeagues.SelectedValue != null && int.TryParse(cboLeagues.SelectedValue.ToString(), out int leagueId))
            {
                dgvMatches.DataSource = service.GetScheduleTable(leagueId);
            }
        }

        // Клик на бутона за генериране
        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            if (cboLeagues.SelectedValue == null) return;
            int leagueId = Convert.ToInt32(cboLeagues.SelectedValue);

            // Защита: Ако вече има мачове, питаме потребителя
            if (service.LeagueHasMatches(leagueId))
            {
                var result = MessageBox.Show("За тази лига вече има генерирана програма! Сигурни ли сте, че искате да я изтриете и генерирате наново?",
                    "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No) return;
            }

            try
            {
                bool twoRounds = chkTwoRounds.Checked;

                // Извикваме бизнес слоя
                service.GenerateTournamentSchedule(leagueId, twoRounds);

                MessageBox.Show("Програмата беше генерирана успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Обновяваме таблицата на екрана
                dgvMatches.DataSource = service.GetScheduleTable(leagueId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Възникна грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {

        }
    }
}