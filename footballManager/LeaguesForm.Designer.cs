namespace footballManager
{
    partial class LeaguesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvLeagues = new DataGridView();
            dgvParticipants = new DataGridView();
            cboAvailableClubs = new ComboBox();
            txtLeagueName = new TextBox();
            txtSeason = new TextBox();
            btnAddClubToLeague = new Button();
            btnRemoveClub = new Button();
            btnAddLeague = new Button();
            Сезон = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).BeginInit();
            SuspendLayout();
            // 
            // dgvLeagues
            // 
            dgvLeagues.AllowUserToAddRows = false;
            dgvLeagues.AllowUserToDeleteRows = false;
            dgvLeagues.AllowUserToResizeColumns = false;
            dgvLeagues.AllowUserToResizeRows = false;
            dgvLeagues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeagues.Location = new Point(14, 30);
            dgvLeagues.Name = "dgvLeagues";
            dgvLeagues.ReadOnly = true;
            dgvLeagues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLeagues.Size = new Size(341, 246);
            dgvLeagues.TabIndex = 0;
            dgvLeagues.SelectionChanged += dgvLeagues_SelectionChanged;
            // 
            // dgvParticipants
            // 
            dgvParticipants.AllowUserToAddRows = false;
            dgvParticipants.AllowUserToDeleteRows = false;
            dgvParticipants.AllowUserToResizeColumns = false;
            dgvParticipants.AllowUserToResizeRows = false;
            dgvParticipants.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvParticipants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParticipants.Location = new Point(447, 30);
            dgvParticipants.MultiSelect = false;
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.ReadOnly = true;
            dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipants.Size = new Size(341, 246);
            dgvParticipants.TabIndex = 1;
            // 
            // cboAvailableClubs
            // 
            cboAvailableClubs.FormattingEnabled = true;
            cboAvailableClubs.Location = new Point(106, 311);
            cboAvailableClubs.Name = "cboAvailableClubs";
            cboAvailableClubs.Size = new Size(274, 23);
            cboAvailableClubs.TabIndex = 2;
            // 
            // txtLeagueName
            // 
            txtLeagueName.Location = new Point(106, 344);
            txtLeagueName.Name = "txtLeagueName";
            txtLeagueName.Size = new Size(125, 23);
            txtLeagueName.TabIndex = 3;
            // 
            // txtSeason
            // 
            txtSeason.Location = new Point(106, 380);
            txtSeason.Name = "txtSeason";
            txtSeason.Size = new Size(125, 23);
            txtSeason.TabIndex = 4;
            // 
            // btnAddClubToLeague
            // 
            btnAddClubToLeague.Location = new Point(511, 366);
            btnAddClubToLeague.Name = "btnAddClubToLeague";
            btnAddClubToLeague.Size = new Size(105, 48);
            btnAddClubToLeague.TabIndex = 5;
            btnAddClubToLeague.Text = "Добави клуб към лига";
            btnAddClubToLeague.UseVisualStyleBackColor = true;
            btnAddClubToLeague.Click += btnAddClubToLeague_Click;
            // 
            // btnRemoveClub
            // 
            btnRemoveClub.Location = new Point(631, 366);
            btnRemoveClub.Name = "btnRemoveClub";
            btnRemoveClub.Size = new Size(116, 48);
            btnRemoveClub.TabIndex = 6;
            btnRemoveClub.Text = "Премахни клуб";
            btnRemoveClub.UseVisualStyleBackColor = true;
            btnRemoveClub.Click += btnRemoveClub_Click;
            // 
            // btnAddLeague
            // 
            btnAddLeague.Location = new Point(570, 309);
            btnAddLeague.Name = "btnAddLeague";
            btnAddLeague.Size = new Size(105, 51);
            btnAddLeague.TabIndex = 7;
            btnAddLeague.Text = "Добави лига";
            btnAddLeague.UseVisualStyleBackColor = true;
            btnAddLeague.Click += btnAddLeague_Click;
            // 
            // Сезон
            // 
            Сезон.AutoSize = true;
            Сезон.Font = new Font("Segoe UI", 12F);
            Сезон.Location = new Point(14, 380);
            Сезон.Name = "Сезон";
            Сезон.Size = new Size(53, 21);
            Сезон.TabIndex = 8;
            Сезон.Text = "Сезон";
            Сезон.Click += Сезон_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(14, 348);
            label1.Name = "label1";
            label1.Size = new Size(86, 19);
            label1.TabIndex = 9;
            label1.Text = "Име на лига";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(14, 311);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 10;
            label2.Text = "Клубове";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(137, -1);
            label3.Name = "label3";
            label3.Size = new Size(61, 28);
            label3.TabIndex = 11;
            label3.Text = "Лиги";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.Location = new Point(539, -1);
            label4.Name = "label4";
            label4.Size = new Size(166, 28);
            label4.TabIndex = 12;
            label4.Text = "Клубове в лиги";
            // 
            // LeaguesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Сезон);
            Controls.Add(btnAddLeague);
            Controls.Add(btnRemoveClub);
            Controls.Add(btnAddClubToLeague);
            Controls.Add(txtSeason);
            Controls.Add(txtLeagueName);
            Controls.Add(cboAvailableClubs);
            Controls.Add(dgvParticipants);
            Controls.Add(dgvLeagues);
            Name = "LeaguesForm";
            Text = "LeaguesForm";
            ((System.ComponentModel.ISupportInitialize)dgvLeagues).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvParticipants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLeagues;
        private DataGridView dgvParticipants;
        private ComboBox cboAvailableClubs;
        private TextBox txtLeagueName;
        private TextBox txtSeason;
        private Button btnAddClubToLeague;
        private Button btnRemoveClub;
        private Button btnAddLeague;
        private Label Сезон;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}