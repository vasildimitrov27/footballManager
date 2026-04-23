namespace footballManager
{
    partial class MainForm
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
            ClubsButton = new Button();
            label1 = new Label();
            TransferButton = new Button();
            LeaguesButton = new Button();
            PlayersButton = new Button();
            SuspendLayout();
            // 
            // ClubsButton
            // 
            ClubsButton.Font = new Font("Segoe UI", 12F);
            ClubsButton.Location = new Point(12, 99);
            ClubsButton.Name = "ClubsButton";
            ClubsButton.Size = new Size(155, 56);
            ClubsButton.TabIndex = 0;
            ClubsButton.Text = "Управление на клубове";
            ClubsButton.UseVisualStyleBackColor = true;
            ClubsButton.Click += ClubsButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(74, 35);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 4;
            label1.Text = "Football Manager";
            // 
            // TransferButton
            // 
            TransferButton.Font = new Font("Segoe UI", 12F);
            TransferButton.Location = new Point(184, 173);
            TransferButton.Name = "TransferButton";
            TransferButton.Size = new Size(147, 57);
            TransferButton.TabIndex = 7;
            TransferButton.Text = "Управление на трансфери";
            TransferButton.UseVisualStyleBackColor = true;
            TransferButton.Click += TransferButton_Click;
            // 
            // LeaguesButton
            // 
            LeaguesButton.Font = new Font("Segoe UI", 12F);
            LeaguesButton.Location = new Point(12, 173);
            LeaguesButton.Name = "LeaguesButton";
            LeaguesButton.Size = new Size(155, 57);
            LeaguesButton.TabIndex = 8;
            LeaguesButton.Text = "Управление на лиги";
            LeaguesButton.UseVisualStyleBackColor = true;
            LeaguesButton.Click += LeaguesButton_Click;
            // 
            // PlayersButton
            // 
            PlayersButton.Font = new Font("Segoe UI", 12F);
            PlayersButton.Location = new Point(184, 99);
            PlayersButton.Name = "PlayersButton";
            PlayersButton.Size = new Size(147, 56);
            PlayersButton.TabIndex = 9;
            PlayersButton.Text = "Управление на играчи";
            PlayersButton.UseVisualStyleBackColor = true;
            PlayersButton.Click += PlayersButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 297);
            Controls.Add(PlayersButton);
            Controls.Add(LeaguesButton);
            Controls.Add(TransferButton);
            Controls.Add(label1);
            Controls.Add(ClubsButton);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ClubsButton;
        private Label label1;
        private Button TransferButton;
        private Button LeaguesButton;
        private Button PlayersButton;
    }
}