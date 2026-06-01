namespace footballManager
{
    partial class ScheduleForm
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
            dgvMatches = new DataGridView();
            label1 = new Label();
            cboLeagues = new ComboBox();
            chkTwoRounds = new CheckBox();
            btnGenerateSchedule = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMatches).BeginInit();
            SuspendLayout();
            // 
            // dgvMatches
            // 
            dgvMatches.AllowUserToAddRows = false;
            dgvMatches.AllowUserToDeleteRows = false;
            dgvMatches.AllowUserToOrderColumns = true;
            dgvMatches.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatches.Location = new Point(32, 12);
            dgvMatches.Name = "dgvMatches";
            dgvMatches.ReadOnly = true;
            dgvMatches.Size = new Size(656, 247);
            dgvMatches.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 287);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 1;
            label1.Text = "Избери лига:";
            // 
            // cboLeagues
            // 
            cboLeagues.FormattingEnabled = true;
            cboLeagues.Location = new Point(142, 289);
            cboLeagues.Name = "cboLeagues";
            cboLeagues.Size = new Size(161, 23);
            cboLeagues.TabIndex = 2;
            // 
            // chkTwoRounds
            // 
            chkTwoRounds.AutoSize = true;
            chkTwoRounds.Location = new Point(418, 311);
            chkTwoRounds.Name = "chkTwoRounds";
            chkTwoRounds.Size = new Size(82, 19);
            chkTwoRounds.TabIndex = 3;
            chkTwoRounds.Text = "checkBox1";
            chkTwoRounds.UseVisualStyleBackColor = true;
            // 
            // btnGenerateSchedule
            // 
            btnGenerateSchedule.Location = new Point(342, 340);
            btnGenerateSchedule.Name = "btnGenerateSchedule";
            btnGenerateSchedule.Size = new Size(148, 57);
            btnGenerateSchedule.TabIndex = 4;
            btnGenerateSchedule.Text = "Генерирай програма";
            btnGenerateSchedule.UseVisualStyleBackColor = true;
            btnGenerateSchedule.Click += btnGenerateSchedule_Click;
            // 
            // ScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 450);
            Controls.Add(btnGenerateSchedule);
            Controls.Add(chkTwoRounds);
            Controls.Add(cboLeagues);
            Controls.Add(label1);
            Controls.Add(dgvMatches);
            Name = "ScheduleForm";
            Text = "ScheduleForm";
            ((System.ComponentModel.ISupportInitialize)dgvMatches).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMatches;
        private Label label1;
        private ComboBox cboLeagues;
        private CheckBox chkTwoRounds;
        private Button btnGenerateSchedule;
    }
}