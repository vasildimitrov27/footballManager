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
            ((System.ComponentModel.ISupportInitialize)dgvClubs).BeginInit();
            SuspendLayout();
            // 
            // dgvClubs
            // 
            dgvClubs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClubs.Location = new Point(51, 24);
            dgvClubs.Name = "dgvClubs";
            dgvClubs.Size = new Size(803, 364);
            dgvClubs.TabIndex = 0;
            dgvClubs.CellContentClick += dgvClubs_CellContentClick;
            // 
            // txtName
            // 
            txtName.Location = new Point(165, 427);
            txtName.Name = "txtName";
            txtName.Size = new Size(198, 23);
            txtName.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(634, 427);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(100, 23);
            txtCity.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(217, 481);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(217, 526);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(102, 23);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(217, 580);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(102, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 430);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 6;
            label1.Text = "Име на клуб";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(542, 430);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "Град";
            // 
            // btnOpenPlayers
            // 
            btnOpenPlayers.Location = new Point(532, 489);
            btnOpenPlayers.Name = "btnOpenPlayers";
            btnOpenPlayers.Size = new Size(75, 23);
            btnOpenPlayers.TabIndex = 8;
            btnOpenPlayers.Text = "Играчи";
            btnOpenPlayers.UseVisualStyleBackColor = true;
            btnOpenPlayers.Click += btnOpenPlayers_Click;
            // 
            // ClubsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 641);
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
    }
}
