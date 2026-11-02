namespace Quizmester_App
{
    partial class MainMenu
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
            cmbCategories = new ComboBox();
            label1 = new Label();
            btnStartQuiz = new Button();
            btnGeneralQuiz = new Button();
            btnAdminPanel = new Button();
            btnTimeTrial = new Button();
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.BackColor = Color.Black;
            cmbCategories.FlatStyle = FlatStyle.Flat;
            cmbCategories.ForeColor = Color.Red;
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(332, 190);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(151, 28);
            cmbCategories.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(300, 132);
            label1.Name = "label1";
            label1.Size = new Size(214, 31);
            label1.TabIndex = 1;
            label1.Text = "Kies een categorie:";
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.BackColor = Color.Black;
            btnStartQuiz.FlatAppearance.BorderSize = 0;
            btnStartQuiz.FlatStyle = FlatStyle.Flat;
            btnStartQuiz.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStartQuiz.ForeColor = Color.Red;
            btnStartQuiz.Location = new Point(584, 368);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(204, 70);
            btnStartQuiz.TabIndex = 2;
            btnStartQuiz.Text = "Start Quiz!";
            btnStartQuiz.UseVisualStyleBackColor = false;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // btnGeneralQuiz
            // 
            btnGeneralQuiz.BackColor = Color.Black;
            btnGeneralQuiz.FlatAppearance.BorderSize = 0;
            btnGeneralQuiz.FlatStyle = FlatStyle.Flat;
            btnGeneralQuiz.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGeneralQuiz.ForeColor = Color.Red;
            btnGeneralQuiz.Location = new Point(12, 368);
            btnGeneralQuiz.Name = "btnGeneralQuiz";
            btnGeneralQuiz.Size = new Size(204, 70);
            btnGeneralQuiz.TabIndex = 3;
            btnGeneralQuiz.Text = "Speel General Quiz";
            btnGeneralQuiz.UseVisualStyleBackColor = false;
            btnGeneralQuiz.Click += btnGeneralQuiz_Click;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.BackColor = Color.Black;
            btnAdminPanel.FlatAppearance.BorderSize = 0;
            btnAdminPanel.FlatStyle = FlatStyle.Flat;
            btnAdminPanel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAdminPanel.ForeColor = Color.Red;
            btnAdminPanel.Location = new Point(320, 12);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(179, 81);
            btnAdminPanel.TabIndex = 4;
            btnAdminPanel.Text = "Admin Paneel";
            btnAdminPanel.UseVisualStyleBackColor = false;
            btnAdminPanel.Click += btnAdminPanel_Click;
            // 
            // btnTimeTrial
            // 
            btnTimeTrial.BackColor = Color.Black;
            btnTimeTrial.FlatAppearance.BorderSize = 0;
            btnTimeTrial.FlatStyle = FlatStyle.Flat;
            btnTimeTrial.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTimeTrial.ForeColor = Color.Red;
            btnTimeTrial.Location = new Point(300, 368);
            btnTimeTrial.Name = "btnTimeTrial";
            btnTimeTrial.Size = new Size(204, 70);
            btnTimeTrial.TabIndex = 5;
            btnTimeTrial.Text = "Time Trial";
            btnTimeTrial.UseVisualStyleBackColor = false;
            btnTimeTrial.Click += btnTimeTrial_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.akatsuki_wallpaper;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTimeTrial);
            Controls.Add(btnAdminPanel);
            Controls.Add(btnGeneralQuiz);
            Controls.Add(btnStartQuiz);
            Controls.Add(label1);
            Controls.Add(cmbCategories);
            Name = "MainMenu";
            Text = "MainMenu";
            Load += MainMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategories;
        private Label label1;
        private Button btnStartQuiz;
        private Button btnGeneralQuiz;
        private Button btnAdminPanel;
        private Button btnTimeTrial;
    }
}