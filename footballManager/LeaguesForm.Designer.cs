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
            dgvLeagues.Location = new Point(12, 21);
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
            dgvParticipants.Location = new Point(447, 21);
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
            cboAvailableClubs.Location = new Point(34, 305);
            cboAvailableClubs.Name = "cboAvailableClubs";
            cboAvailableClubs.Size = new Size(274, 23);
            cboAvailableClubs.TabIndex = 2;
            // 
            // txtLeagueName
            // 
            txtLeagueName.Location = new Point(474, 311);
            txtLeagueName.Name = "txtLeagueName";
            txtLeagueName.Size = new Size(100, 23);
            txtLeagueName.TabIndex = 3;
            // 
            // txtSeason
            // 
            txtSeason.Location = new Point(489, 360);
            txtSeason.Name = "txtSeason";
            txtSeason.Size = new Size(100, 23);
            txtSeason.TabIndex = 4;
            // 
            // btnAddClubToLeague
            // 
            btnAddClubToLeague.Location = new Point(165, 363);
            btnAddClubToLeague.Name = "btnAddClubToLeague";
            btnAddClubToLeague.Size = new Size(105, 48);
            btnAddClubToLeague.TabIndex = 5;
            btnAddClubToLeague.Text = "Добави клуб към лига";
            btnAddClubToLeague.UseVisualStyleBackColor = true;
            btnAddClubToLeague.Click += btnAddClubToLeague_Click;
            // 
            // btnRemoveClub
            // 
            btnRemoveClub.Location = new Point(343, 388);
            btnRemoveClub.Name = "btnRemoveClub";
            btnRemoveClub.Size = new Size(116, 41);
            btnRemoveClub.TabIndex = 6;
            btnRemoveClub.Text = "Премахни клуб";
            btnRemoveClub.UseVisualStyleBackColor = true;
            btnRemoveClub.Click += btnRemoveClub_Click;
            // 
            // btnAddLeague
            // 
            btnAddLeague.Location = new Point(360, 305);
            btnAddLeague.Name = "btnAddLeague";
            btnAddLeague.Size = new Size(84, 45);
            btnAddLeague.TabIndex = 7;
            btnAddLeague.Text = "Добави лига";
            btnAddLeague.UseVisualStyleBackColor = true;
            btnAddLeague.Click += btnAddLeague_Click;
            // 
            // LeaguesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}