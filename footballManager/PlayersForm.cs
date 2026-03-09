using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace footballManager
{
    public partial class PlayersForm : Form
    {
        PlayersRepository repo = new PlayersRepository();
        int selectedPlayerId = 0;
        private DataGridView dgvPlayers;
        private ComboBox cboClubFilter;
        private ComboBox cboPositionFilter;
        private ComboBox txtSearchName;
        private TextBox txtFullName;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboClub;
        private ComboBox cboPosition;
        private NumericUpDown numShirtNumber;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        bool isInitializing = true; // Флаг, за да не се задействат филтрите при първоначално зареждане

        public PlayersForm()
        {
            InitializeComponent();
            SetupModernUI();
            LoadDropdowns();
            LoadData();
            isInitializing = false;
        }

        private void SetupModernUI()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Управление на играчи";

            // Настройки на DataGridView
            dgvPlayers.BackgroundColor = Color.White;
            dgvPlayers.EnableHeadersVisualStyles = false;
            dgvPlayers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvPlayers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlayers.ReadOnly = true;
            dgvPlayers.AllowUserToAddRows = false;
            dgvPlayers.RowHeadersVisible = false;

            // Свързване на събития за филтрите
            cboClubFilter.SelectedIndexChanged += ApplyFilters;
            cboPositionFilter.SelectedIndexChanged += ApplyFilters;
            txtSearchName.TextChanged += ApplyFilters;
        }

        private void LoadDropdowns()
        {
            DataTable dtClubs = repo.GetClubsForDropdown();

            // Зареждане на клубовете във формата за добавяне/редакция
            cboClub.DataSource = dtClubs.Copy();
            cboClub.DisplayMember = "Name";
            cboClub.ValueMember = "ClubId";

            // Зареждане на клубовете във филтъра + опция "Всички"
            DataTable dtFilterClubs = dtClubs.Copy();
            DataRow row = dtFilterClubs.NewRow();
            row["ClubId"] = 0;
            row["Name"] = "-- Всички клубове --";
            dtFilterClubs.Rows.InsertAt(row, 0);

            cboClubFilter.DataSource = dtFilterClubs;
            cboClubFilter.DisplayMember = "Name";
            cboClubFilter.ValueMember = "ClubId";
            cboClubFilter.SelectedIndex = 0;

            // Позиции
            string[] positions = { "GK", "DF", "MF", "FW" };
            cboPosition.Items.AddRange(positions);

            cboPositionFilter.Items.Add("All");
            cboPositionFilter.Items.AddRange(positions);
            cboPositionFilter.SelectedIndex = 0;
        }

        private void LoadData()
        {
            int clubId = Convert.ToInt32(cboClubFilter.SelectedValue ?? 0);
            string position = cboPositionFilter.SelectedItem?.ToString() ?? "All";
            string search = txtSearchName.Text.Trim();

            dgvPlayers.DataSource = repo.GetPlayers(clubId, position, search);

            // Скриване на излишни колони
            if (dgvPlayers.Columns["ClubId"] != null) dgvPlayers.Columns["ClubId"].Visible = false;
        }

        private void ApplyFilters(object sender, EventArgs e)
        {
            if (!isInitializing) LoadData();
        }

        private void ClearFields()
        {
            selectedPlayerId = 0;
            txtFullName.Clear();
            dtpBirthDate.Value = DateTime.Now.AddYears(-20); // По подразбиране 20-годишен
            cboPosition.SelectedIndex = -1;
            numShirtNumber.Value = 1;
            dgvPlayers.ClearSelection();
        }

        private bool ValidateInput()
        {
            // 1. Име
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || txtFullName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Името трябва да съдържа поне 3 символа!", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Дата на раждане (между 10 и 60 години)
            int age = DateTime.Now.Year - dtpBirthDate.Value.Year;
            if (dtpBirthDate.Value.Date > DateTime.Now.AddYears(-age)) age--; // Корекция ако не е имал рожден ден тази година

            if (age < 10 || age > 60)
            {
                MessageBox.Show($"Невалидна възраст ({age} год.). Играчът трябва да е между 10 и 60 години.", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. Позиция и Клуб
            if (cboPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Моля, изберете позиция!", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboClub.SelectedValue == null)
            {
                MessageBox.Show("Моля, изберете клуб!", "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Player p = new Player
            {
                ClubId = Convert.ToInt32(cboClub.SelectedValue),
                FullName = txtFullName.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Position = cboPosition.SelectedItem.ToString(),
                ShirtNumber = (int)numShirtNumber.Value
            };

            if (repo.Add(p))
            {
                MessageBox.Show("Играчът е добавен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
        }

        private void dgvPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPlayers.Rows[e.RowIndex];
                selectedPlayerId = Convert.ToInt32(row.Cells["PlayerId"].Value);

                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                dtpBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
                cboPosition.SelectedItem = row.Cells["Position"].Value.ToString();
                numShirtNumber.Value = Convert.ToDecimal(row.Cells["ShirtNumber"].Value);
                cboClub.SelectedValue = Convert.ToInt32(row.Cells["ClubId"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPlayerId == 0)
            {
                MessageBox.Show("Моля, изберете играч за редакция от таблицата.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;

            Player p = new Player
            {
                PlayerId = selectedPlayerId,
                ClubId = Convert.ToInt32(cboClub.SelectedValue),
                FullName = txtFullName.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Position = cboPosition.SelectedItem.ToString(),
                ShirtNumber = (int)numShirtNumber.Value
            };

            if (repo.Update(p))
            {
                MessageBox.Show("Данните са обновени!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPlayerId == 0) return;

            var result = MessageBox.Show($"Сигурни ли сте, че искате да изтриете играч: {txtFullName.Text}?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (repo.Delete(selectedPlayerId))
                {
                    ClearFields();
                    LoadData();
                }
            }
        }

        private void InitializeComponent()
        {
            dgvPlayers = new DataGridView();
            cboClubFilter = new ComboBox();
            cboPositionFilter = new ComboBox();
            txtSearchName = new ComboBox();
            txtFullName = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboClub = new ComboBox();
            cboPosition = new ComboBox();
            numShirtNumber = new NumericUpDown();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShirtNumber).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(115, 91);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.Size = new Size(555, 329);
            dgvPlayers.TabIndex = 0;
            // 
            // cboClubFilter
            // 
            cboClubFilter.FormattingEnabled = true;
            cboClubFilter.Location = new Point(115, 49);
            cboClubFilter.Name = "cboClubFilter";
            cboClubFilter.Size = new Size(161, 23);
            cboClubFilter.TabIndex = 1;
            // 
            // cboPositionFilter
            // 
            cboPositionFilter.FormattingEnabled = true;
            cboPositionFilter.Location = new Point(322, 49);
            cboPositionFilter.Name = "cboPositionFilter";
            cboPositionFilter.Size = new Size(168, 23);
            cboPositionFilter.TabIndex = 2;
            // 
            // txtSearchName
            // 
            txtSearchName.FormattingEnabled = true;
            txtSearchName.Location = new Point(524, 49);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(146, 23);
            txtSearchName.TabIndex = 3;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(126, 453);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 23);
            txtFullName.TabIndex = 4;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(290, 453);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 23);
            dtpBirthDate.TabIndex = 6;
            // 
            // cboClub
            // 
            cboClub.FormattingEnabled = true;
            cboClub.Location = new Point(559, 449);
            cboClub.Name = "cboClub";
            cboClub.Size = new Size(121, 23);
            cboClub.TabIndex = 7;
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Location = new Point(136, 498);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(121, 23);
            cboPosition.TabIndex = 8;
            // 
            // numShirtNumber
            // 
            numShirtNumber.Location = new Point(538, 510);
            numShirtNumber.Name = "numShirtNumber";
            numShirtNumber.Size = new Size(120, 23);
            numShirtNumber.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(345, 547);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Добави";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(481, 549);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Актуализирай";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(633, 562);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Изтрий";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(141, 548);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 13;
            btnClear.Text = "Изчисти";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // PlayersForm
            // 
            ClientSize = new Size(753, 597);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(numShirtNumber);
            Controls.Add(cboPosition);
            Controls.Add(cboClub);
            Controls.Add(dtpBirthDate);
            Controls.Add(txtFullName);
            Controls.Add(txtSearchName);
            Controls.Add(cboPositionFilter);
            Controls.Add(cboClubFilter);
            Controls.Add(dgvPlayers);
            Name = "PlayersForm";
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numShirtNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

    }
}