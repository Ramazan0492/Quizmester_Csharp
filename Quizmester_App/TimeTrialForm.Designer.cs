namespace Quizmester_App
{
    partial class TimeTrialForm
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
            components = new System.ComponentModel.Container();
            lblScore = new Label();
            lblFeedback = new Label();
            lblTimer = new Label();
            btnAnswer4 = new Button();
            btnAnswer3 = new Button();
            btnAnswer2 = new Button();
            btnAnswer1 = new Button();
            lblQuestion = new Label();
            mainTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Black;
            lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(650, 21);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(87, 28);
            lblScore.TabIndex = 17;
            lblScore.Text = "Score: 0";
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.BackColor = Color.Black;
            lblFeedback.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeedback.ForeColor = Color.Transparent;
            lblFeedback.Location = new Point(339, 337);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(135, 28);
            lblFeedback.TabIndex = 16;
            lblFeedback.Text = "Fout of Goed";
            lblFeedback.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.Black;
            lblTimer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.LimeGreen;
            lblTimer.Location = new Point(50, 340);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(55, 25);
            lblTimer.TabIndex = 15;
            lblTimer.Text = "Tijd:";
            // 
            // btnAnswer4
            // 
            btnAnswer4.BackColor = Color.ForestGreen;
            btnAnswer4.FlatAppearance.BorderSize = 0;
            btnAnswer4.FlatStyle = FlatStyle.Flat;
            btnAnswer4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer4.Location = new Point(426, 197);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(185, 86);
            btnAnswer4.TabIndex = 14;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = false;
            btnAnswer4.Click += btnAnswer4_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.BackColor = Color.ForestGreen;
            btnAnswer3.FlatAppearance.BorderSize = 0;
            btnAnswer3.FlatStyle = FlatStyle.Flat;
            btnAnswer3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer3.Location = new Point(201, 197);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(185, 86);
            btnAnswer3.TabIndex = 13;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = false;
            btnAnswer3.Click += btnAnswer3_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.BackColor = Color.ForestGreen;
            btnAnswer2.FlatAppearance.BorderSize = 0;
            btnAnswer2.FlatStyle = FlatStyle.Flat;
            btnAnswer2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer2.Location = new Point(426, 83);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(185, 86);
            btnAnswer2.TabIndex = 12;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = false;
            btnAnswer2.Click += btnAnswer2_Click;
            // 
            // btnAnswer1
            // 
            btnAnswer1.BackColor = Color.ForestGreen;
            btnAnswer1.FlatAppearance.BorderSize = 0;
            btnAnswer1.FlatStyle = FlatStyle.Flat;
            btnAnswer1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer1.Location = new Point(201, 83);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(185, 86);
            btnAnswer1.TabIndex = 11;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = false;
            btnAnswer1.Click += btnAnswer1_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblQuestion.Location = new Point(255, 9);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(314, 58);
            lblQuestion.TabIndex = 10;
            lblQuestion.Text = "Hier komt de vraag te staan...";
            // 
            // mainTimer
            // 
            mainTimer.Enabled = true;
            mainTimer.Interval = 1000;
            mainTimer.Tick += mainTimer_Tick;
            // 
            // TimeTrialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Aot;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lblScore);
            Controls.Add(lblFeedback);
            Controls.Add(lblTimer);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Controls.Add(lblQuestion);
            Name = "TimeTrialForm";
            Text = "TimeTrialForm";
            Load += TimeTrialForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblScore;
        private Label lblFeedback;
        private Label lblTimer;
        private Button btnAnswer4;
        private Button btnAnswer3;
        private Button btnAnswer2;
        private Button btnAnswer1;
        private Label lblQuestion;
        private System.Windows.Forms.Timer mainTimer;
    }
}