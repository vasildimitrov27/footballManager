namespace footballManager
{
    public partial class ClubsForm : Form
    {
        ClubRepository repo = new ClubRepository();
        int selectedClubId = 0;

        public ClubsForm()
        {
            InitializeComponent();
            SetupModernUI();
            LoadData();
        }

        private void LoadData()
        {
            dgvClubs.DataSource = repo.GetAllClubs();
            ClearFields();
        }

        private void SetupModernUI()
        {
            // 1. Настройки на самата форма
            this.BackColor = Color.FromArgb(245, 246, 250); // Много светло сиво, почти бяло
            this.Font = new Font("Segoe UI", 10); // Модерен шрифт
            this.Text = "Управление на футболни клубове";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Забранява оразмеряването
            this.MaximizeBox = false;

            // 2. Настройки на DataGridView (Таблицата)
            dgvClubs.BackgroundColor = Color.White;
            dgvClubs.BorderStyle = BorderStyle.None;
            dgvClubs.EnableHeadersVisualStyles = false; // Позволява ни да сменяме цвета на хедъра
            dgvClubs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185); // Тъмно синьо
            dgvClubs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClubs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvClubs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Колоните заемат цялото място
            dgvClubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Избира се целия ред
            dgvClubs.RowHeadersVisible = false; // Скрива грозната празна колона най-вляво
            dgvClubs.RowTemplate.Height = 35; // Прави редовете по-широки и удобни
            dgvClubs.AllowUserToAddRows = false; // Маха празния ред най-отдолу
            dgvClubs.ReadOnly = true;

            // 3. Настройки на Бутоните
            StyleButton(btnAdd, Color.FromArgb(46, 204, 113), "Добави"); // Зелено
            StyleButton(btnEdit, Color.FromArgb(52, 152, 219), "Редактирай"); // Синьо
            StyleButton(btnDelete, Color.FromArgb(231, 76, 60), "Изтрий"); // Червено
        }

        // Помощен метод за еднакъв стил на бутоните
        private void StyleButton(Button btn, Color bgColor, string text)
        {
            btn.Text = text;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0; // Премахва грозната рамка
            btn.BackColor = bgColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; // Мишката става на "ръчичка"
            btn.Height = 40;
        }

        private void ClearFields()
        {
            selectedClubId = 0;
            txtName.Clear();
            txtCity.Clear();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Името е задължително!"); return;
            }

            Club club = new Club { Name = txtName.Text, City = txtCity.Text };
            if (repo.Add(club))
            {
                MessageBox.Show("Успешно добавен!");
                LoadData();
            }
        }

        private void dgvClubs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedClubId = Convert.ToInt32(dgvClubs.Rows[e.RowIndex].Cells["ClubId"].Value);
                txtName.Text = dgvClubs.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtCity.Text = dgvClubs.Rows[e.RowIndex].Cells["City"].Value.ToString();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (selectedClubId == 0) return;

            Club club = new Club { ClubId = selectedClubId, Name = txtName.Text, City = txtCity.Text };
            if (repo.Update(club))
            {
                MessageBox.Show("Обновено!");
                LoadData();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedClubId == 0) return;

            var result = MessageBox.Show("Сигурни ли сте?", "Потвърждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (repo.Delete(selectedClubId)) LoadData();
            }
        }

        private void ClubsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenPlayers_Click(object sender, EventArgs e)
        {
            // Създаваме инстанция на формата
            PlayersForm playersForm = new PlayersForm();

            // Опция А: Отваря я като независим прозорец (можеш да кликаш и в двете форми)
            playersForm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();

            // Опция А: Отваря я като независим прозорец (можеш да кликаш и в двете форми)
            transfersForm.Show();
        }
    }
}
