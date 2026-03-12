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
        private TextBox txtFullName;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboClub;
        private ComboBox cboPosition;
        private NumericUpDown numShirtNumber;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtSearchName;
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
            txtFullName = new TextBox();
            dtpBirthDate = new DateTimePicker();
            cboClub = new ComboBox();
            cboPosition = new ComboBox();
            numShirtNumber = new NumericUpDown();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtSearchName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPlayers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShirtNumber).BeginInit();
            SuspendLayout();
            // 
            // dgvPlayers
            // 
            dgvPlayers.AllowUserToAddRows = false;
            dgvPlayers.AllowUserToDeleteRows = false;
            dgvPlayers.AllowUserToResizeColumns = false;
            dgvPlayers.AllowUserToResizeRows = false;
            dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPlayers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlayers.Location = new Point(4, 91);
            dgvPlayers.Name = "dgvPlayers";
            dgvPlayers.Size = new Size(746, 329);
            dgvPlayers.TabIndex = 0;
            dgvPlayers.CellClick += dgvPlayers_CellClick;
            // 
            // cboClubFilter
            // 
            cboClubFilter.FormattingEnabled = true;
            cboClubFilter.Location = new Point(50, 49);
            cboClubFilter.Name = "cboClubFilter";
            cboClubFilter.Size = new Size(195, 23);
            cboClubFilter.TabIndex = 1;
            // 
            // cboPositionFilter
            // 
            cboPositionFilter.FormattingEnabled = true;
            cboPositionFilter.Location = new Point(294, 49);
            cboPositionFilter.Name = "cboPositionFilter";
            cboPositionFilter.Size = new Size(180, 23);
            cboPositionFilter.TabIndex = 2;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Location = new Point(105, 449);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(152, 23);
            txtFullName.TabIndex = 4;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(271, 451);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(219, 23);
            dtpBirthDate.TabIndex = 6;
            // 
            // cboClub
            // 
            cboClub.FormattingEnabled = true;
            cboClub.Location = new Point(105, 477);
            cboClub.Name = "cboClub";
            cboClub.Size = new Size(152, 23);
            cboClub.TabIndex = 7;
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Location = new Point(105, 506);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(152, 23);
            cboPosition.TabIndex = 8;
            // 
            // numShirtNumber
            // 
            numShirtNumber.Location = new Point(105, 536);
            numShirtNumber.Name = "numShirtNumber";
            numShirtNumber.Size = new Size(152, 23);
            numShirtNumber.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.Location = new Point(496, 446);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(142, 51);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Добави";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 14F);
            btnUpdate.Location = new Point(496, 506);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(142, 56);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Актуализирай";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 14F);
            btnDelete.Location = new Point(645, 506);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 56);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Изтрий";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 14F);
            btnClear.Location = new Point(645, 446);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(105, 51);
            btnClear.TabIndex = 13;
            btnClear.Text = "Изчисти";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(568, 16);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 14;
            label1.Text = "Търсачка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(105, 16);
            label2.Name = "label2";
            label2.Size = new Size(62, 30);
            label2.TabIndex = 15;
            label2.Text = "Клуб";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(328, 16);
            label3.Name = "label3";
            label3.Size = new Size(102, 30);
            label3.TabIndex = 16;
            label3.Text = "Позиция";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.Location = new Point(12, 449);
            label4.Name = "label4";
            label4.Size = new Size(50, 25);
            label4.TabIndex = 17;
            label4.Text = "Име";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.Location = new Point(12, 475);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 18;
            label5.Text = "Клуб";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.Location = new Point(12, 503);
            label6.Name = "label6";
            label6.Size = new Size(90, 25);
            label6.TabIndex = 19;
            label6.Text = "Позиция";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label7.Location = new Point(12, 536);
            label7.Name = "label7";
            label7.Size = new Size(72, 25);
            label7.TabIndex = 20;
            label7.Text = "Номер";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label8.Location = new Point(319, 423);
            label8.Name = "label8";
            label8.Size = new Size(145, 25);
            label8.TabIndex = 21;
            label8.Text = "Рожденна дата";
            // 
            // txtSearchName
            // 
            txtSearchName.BorderStyle = BorderStyle.FixedSingle;
            txtSearchName.Location = new Point(530, 49);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(194, 23);
            txtSearchName.TabIndex = 22;
            // 
            // PlayersForm
            // 
            ClientSize = new Size(753, 597);
            Controls.Add(txtSearchName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(numShirtNumber);
            Controls.Add(cboPosition);
            Controls.Add(cboClub);
            Controls.Add(dtpBirthDate);
            Controls.Add(txtFullName);
            Controls.Add(cboPositionFilter);
            Controls.Add(cboClubFilter);
            Controls.Add(dgvPlayers);
            Name = "PlayersForm";
            StartPosition = FormStartPosition.CenterScreen;
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