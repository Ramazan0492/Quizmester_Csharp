namespace Quizmester_App
{
    partial class AdminForm
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
            lstQuestions = new ListBox();
            txtCorrect = new TextBox();
            txtWrong1 = new TextBox();
            txtWrong2 = new TextBox();
            txtWrong3 = new TextBox();
            txtCategory = new TextBox();
            txtTime = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lstUsers = new ListBox();
            btnDeleteUser = new Button();
            SuspendLayout();
            // 
            // lstQuestions
            // 
            lstQuestions.FormattingEnabled = true;
            lstQuestions.Location = new Point(12, 12);
            lstQuestions.Name = "lstQuestions";
            lstQuestions.Size = new Size(390, 424);
            lstQuestions.TabIndex = 0;
            // 
            // txtCorrect
            // 
            txtCorrect.Location = new Point(408, 12);
            txtCorrect.Name = "txtCorrect";
            txtCorrect.Size = new Size(138, 27);
            txtCorrect.TabIndex = 2;
            // 
            // txtWrong1
            // 
            txtWrong1.Location = new Point(408, 45);
            txtWrong1.Name = "txtWrong1";
            txtWrong1.Size = new Size(138, 27);
            txtWrong1.TabIndex = 3;
            // 
            // txtWrong2
            // 
            txtWrong2.Location = new Point(408, 78);
            txtWrong2.Name = "txtWrong2";
            txtWrong2.Size = new Size(138, 27);
            txtWrong2.TabIndex = 4;
            // 
            // txtWrong3
            // 
            txtWrong3.Location = new Point(408, 111);
            txtWrong3.Name = "txtWrong3";
            txtWrong3.Size = new Size(138, 27);
            txtWrong3.TabIndex = 5;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(408, 144);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(138, 27);
            txtCategory.TabIndex = 6;
            // 
            // txtTime
            // 
            txtTime.Location = new Point(408, 177);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(138, 27);
            txtTime.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(408, 215);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(138, 42);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Toevoegen";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(408, 273);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(138, 42);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Opslaan";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(408, 333);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(138, 42);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Verwijderen";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lstUsers
            // 
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(552, 12);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(246, 364);
            lstUsers.TabIndex = 11;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(597, 394);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(154, 42);
            btnDeleteUser.TabIndex = 12;
            btnDeleteUser.Text = "Verwijder Speler";
            btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteUser);
            Controls.Add(lstUsers);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtTime);
            Controls.Add(txtCategory);
            Controls.Add(txtWrong3);
            Controls.Add(txtWrong2);
            Controls.Add(txtWrong1);
            Controls.Add(txtCorrect);
            Controls.Add(lstQuestions);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstQuestions;
        private TextBox txtQuestion;
        private TextBox txtCorrect;
        private TextBox txtWrong1;
        private TextBox txtWrong2;
        private TextBox txtWrong3;
        private TextBox txtCategory;
        private TextBox txtTime;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private ListBox lstUsers;
        private Button btnDeleteUser;
    }
}