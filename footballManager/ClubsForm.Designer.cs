namespace footballManager
{
    partial class ClubsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvClubs = new DataGridView();
            txtName = new TextBox();
            txtCity = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            label1 = new Label();
            label2 = new Label();
            btnOpenPlayers = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClubs).BeginInit();
            SuspendLayout();
            // 
            // dgvClubs
            // 
            dgvClubs.AllowUserToAddRows = false;
            dgvClubs.AllowUserToDeleteRows = false;
            dgvClubs.AllowUserToResizeColumns = false;
            dgvClubs.AllowUserToResizeRows = false;
            dgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClubs.Location = new Point(51, 24);
            dgvClubs.Name = "dgvClubs";
            dgvClubs.Size = new Size(803, 364);
            dgvClubs.TabIndex = 0;
            dgvClubs.CellClick += dgvClubs_CellClick;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.Window;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 14F);
            txtName.Location = new Point(194, 430);
            txtName.Name = "txtName";
            txtName.Size = new Size(198, 32);
            txtName.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Font = new Font("Segoe UI", 14F);
            txtCity.Location = new Point(194, 485);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(198, 32);
            txtCity.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 14F);
            btnAdd.Location = new Point(613, 401);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(182, 57);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добави";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 14F);
            btnEdit.Location = new Point(618, 542);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(177, 55);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редактирай";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 14F);
            btnDelete.Location = new Point(618, 472);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 57);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Изтрий";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(42, 430);
            label1.Name = "label1";
            label1.Size = new Size(126, 28);
            label1.TabIndex = 6;
            label1.Text = "Име на клуб";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(68, 485);
            label2.Name = "label2";
            label2.Size = new Size(54, 28);
            label2.TabIndex = 7;
            label2.Text = "Град";
            // 
            // btnOpenPlayers
            // 
            btnOpenPlayers.Font = new Font("Segoe UI", 14F);
            btnOpenPlayers.Location = new Point(823, 472);
            btnOpenPlayers.Name = "btnOpenPlayers";
            btnOpenPlayers.Size = new Size(88, 57);
            btnOpenPlayers.TabIndex = 8;
            btnOpenPlayers.Text = "Играчи";
            btnOpenPlayers.UseVisualStyleBackColor = true;
            btnOpenPlayers.Click += btnOpenPlayers_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(231, 542);
            button1.Name = "button1";
            button1.Size = new Size(148, 57);
            button1.TabIndex = 9;
            button1.Text = "Трансфери";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 641);
            Controls.Add(button1);
            Controls.Add(btnOpenPlayers);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtCity);
            Controls.Add(txtName);
            Controls.Add(dgvClubs);
            Name = "ClubsForm";
            Text = "Form1";
            Load += ClubsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClubs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClubs;
        private TextBox txtName;
        private TextBox txtCity;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Label label1;
        private Label label2;
        private Button btnOpenPlayers;
        private Button button1;
    }
}
