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
            SuspendLayout();
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(285, 165);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(151, 28);
            cmbCategories.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 127);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 1;
            label1.Text = "Kies een categorie:";
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Location = new Point(458, 123);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(94, 29);
            btnStartQuiz.TabIndex = 2;
            btnStartQuiz.Text = "Start Quiz!";
            btnStartQuiz.UseVisualStyleBackColor = true;
            btnStartQuiz.Click += btnStartQuiz_Click;
            // 
            // btnGeneralQuiz
            // 
            btnGeneralQuiz.Location = new Point(321, 250);
            btnGeneralQuiz.Name = "btnGeneralQuiz";
            btnGeneralQuiz.Size = new Size(170, 75);
            btnGeneralQuiz.TabIndex = 3;
            btnGeneralQuiz.Text = "Speel General Quiz";
            btnGeneralQuiz.UseVisualStyleBackColor = true;
            btnGeneralQuiz.Click += btnGeneralQuiz_Click;
            // 
            // btnAdminPanel
            // 
            btnAdminPanel.Location = new Point(50, 61);
            btnAdminPanel.Name = "btnAdminPanel";
            btnAdminPanel.Size = new Size(144, 68);
            btnAdminPanel.TabIndex = 4;
            btnAdminPanel.Text = "Admin Paneel";
            btnAdminPanel.UseVisualStyleBackColor = true;
            btnAdminPanel.Click += btnAdminPanel_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}