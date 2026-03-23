namespace footballManager
{
    partial class TransfersForm
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
            label6 = new Label();
            label5 = new Label();
            lblFromClub = new Label();
            btnTransfer = new Button();
            cboToClub = new ComboBox();
            cboPlayer = new ComboBox();
            txtNote = new TextBox();
            dgvTransfers = new DataGridView();
            dtpTransferDate = new DateTimePicker();
            numFee = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFee).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.Location = new Point(100, 463);
            label6.Name = "label6";
            label6.Size = new Size(57, 25);
            label6.TabIndex = 40;
            label6.Text = "Клуб";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.Location = new Point(100, 435);
            label5.Name = "label5";
            label5.Size = new Size(65, 25);
            label5.TabIndex = 39;
            label5.Text = "Играч";
            // 
            // lblFromClub
            // 
            lblFromClub.AutoSize = true;
            lblFromClub.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblFromClub.Location = new Point(466, 509);
            lblFromClub.Name = "lblFromClub";
            lblFromClub.Size = new Size(50, 25);
            lblFromClub.TabIndex = 38;
            lblFromClub.Text = "Име";
            // 
            // btnTransfer
            // 
            btnTransfer.Font = new Font("Segoe UI", 14F);
            btnTransfer.Location = new Point(668, 419);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(142, 51);
            btnTransfer.TabIndex = 31;
            btnTransfer.Text = "Добави";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // cboToClub
            // 
            cboToClub.FormattingEnabled = true;
            cboToClub.Location = new Point(193, 466);
            cboToClub.Name = "cboToClub";
            cboToClub.Size = new Size(152, 23);
            cboToClub.TabIndex = 29;
            // 
            // cboPlayer
            // 
            cboPlayer.FormattingEnabled = true;
            cboPlayer.Location = new Point(193, 437);
            cboPlayer.Name = "cboPlayer";
            cboPlayer.Size = new Size(152, 23);
            cboPlayer.TabIndex = 28;
            cboPlayer.SelectedIndexChanged += cboPlayer_SelectedIndexChanged;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Location = new Point(193, 402);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(152, 23);
            txtNote.TabIndex = 26;
            // 
            // dgvTransfers
            // 
            dgvTransfers.AllowUserToAddRows = false;
            dgvTransfers.AllowUserToDeleteRows = false;
            dgvTransfers.AllowUserToResizeColumns = false;
            dgvTransfers.AllowUserToResizeRows = false;
            dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransfers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransfers.Location = new Point(78, 55);
            dgvTransfers.Name = "dgvTransfers";
            dgvTransfers.Size = new Size(746, 329);
            dgvTransfers.TabIndex = 23;
            // 
            // dtpTransferDate
            // 
            dtpTransferDate.Location = new Point(385, 402);
            dtpTransferDate.Name = "dtpTransferDate";
            dtpTransferDate.Size = new Size(200, 23);
            dtpTransferDate.TabIndex = 41;
            // 
            // numFee
            // 
            numFee.Location = new Point(433, 438);
            numFee.Name = "numFee";
            numFee.Size = new Size(120, 23);
            numFee.TabIndex = 42;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.Location = new Point(100, 402);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 43;
            label4.Text = "Бележка";
            // 
            // TransfersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 543);
            Controls.Add(label4);
            Controls.Add(numFee);
            Controls.Add(dtpTransferDate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lblFromClub);
            Controls.Add(btnTransfer);
            Controls.Add(cboToClub);
            Controls.Add(cboPlayer);
            Controls.Add(txtNote);
            Controls.Add(dgvTransfers);
            Name = "TransfersForm";
            Text = "TransfersForm";
            ((System.ComponentModel.ISupportInitialize)dgvTransfers).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearchName;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label lblFromClub;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnTransfer;
        private NumericUpDown numShirtNumber;
        private ComboBox cboToClub;
        private ComboBox cboPlayer;
        private DateTimePicker dtpBirthDate;
        private TextBox txtNote;
        private ComboBox cboPositionFilter;
        private ComboBox cboClubFilter;
        private DataGridView dgvTransfers;
        private DateTimePicker dtpTransferDate;
        private NumericUpDown numFee;
        private Label label4;
    }
}