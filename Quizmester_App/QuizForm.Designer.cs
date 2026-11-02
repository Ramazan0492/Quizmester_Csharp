namespace Quizmester_App
{
    partial class QuizForm
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
            lblQuestion = new Label();
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer3 = new Button();
            btnAnswer4 = new Button();
            lblTimer = new Label();
            questionTimer = new System.Windows.Forms.Timer(components);
            btnJoker = new Button();
            globalTimer = new System.Windows.Forms.Timer(components);
            lblGlobalTimer = new Label();
            lblFeedback = new Label();
            lblScore = new Label();
            btnFiftyFifty = new Button();
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblQuestion.Location = new Point(253, 13);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(314, 58);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Hier komt de vraag te staan...";
            // 
            // btnAnswer1
            // 
            btnAnswer1.BackColor = Color.ForestGreen;
            btnAnswer1.FlatAppearance.BorderSize = 0;
            btnAnswer1.FlatStyle = FlatStyle.Flat;
            btnAnswer1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer1.Location = new Point(204, 108);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(185, 86);
            btnAnswer1.TabIndex = 1;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = false;
            btnAnswer1.Click += btnAnswer1_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.BackColor = Color.ForestGreen;
            btnAnswer2.FlatAppearance.BorderSize = 0;
            btnAnswer2.FlatStyle = FlatStyle.Flat;
            btnAnswer2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer2.Location = new Point(420, 108);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(185, 86);
            btnAnswer2.TabIndex = 2;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = false;
            btnAnswer2.Click += btnAnswer2_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.BackColor = Color.ForestGreen;
            btnAnswer3.FlatAppearance.BorderSize = 0;
            btnAnswer3.FlatStyle = FlatStyle.Flat;
            btnAnswer3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer3.Location = new Point(204, 213);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(185, 86);
            btnAnswer3.TabIndex = 3;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = false;
            btnAnswer3.Click += btnAnswer3_Click;
            // 
            // btnAnswer4
            // 
            btnAnswer4.BackColor = Color.ForestGreen;
            btnAnswer4.FlatAppearance.BorderSize = 0;
            btnAnswer4.FlatStyle = FlatStyle.Flat;
            btnAnswer4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAnswer4.Location = new Point(420, 213);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(185, 86);
            btnAnswer4.TabIndex = 4;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = false;
            btnAnswer4.Click += btnAnswer4_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.BackColor = Color.Black;
            lblTimer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTimer.ForeColor = Color.LimeGreen;
            lblTimer.Location = new Point(9, 356);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(133, 25);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "Tijd over: 15";
            lblTimer.Click += lblTimer_Click;
            // 
            // questionTimer
            // 
            questionTimer.Interval = 1000;
            questionTimer.Tick += questionTimer_Tick;
            // 
            // btnJoker
            // 
            btnJoker.BackColor = Color.DarkRed;
            btnJoker.FlatAppearance.BorderSize = 0;
            btnJoker.FlatStyle = FlatStyle.Flat;
            btnJoker.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnJoker.Location = new Point(9, 13);
            btnJoker.Name = "btnJoker";
            btnJoker.Size = new Size(157, 58);
            btnJoker.TabIndex = 6;
            btnJoker.Text = "Joker inzetten";
            btnJoker.UseVisualStyleBackColor = false;
            btnJoker.Click += btnJoker_Click;
            // 
            // globalTimer
            // 
            globalTimer.Interval = 1000;
            globalTimer.Tick += globalTimer_Tick;
            // 
            // lblGlobalTimer
            // 
            lblGlobalTimer.AutoSize = true;
            lblGlobalTimer.BackColor = Color.Transparent;
            lblGlobalTimer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblGlobalTimer.ForeColor = Color.LimeGreen;
            lblGlobalTimer.Location = new Point(615, 13);
            lblGlobalTimer.Name = "lblGlobalTimer";
            lblGlobalTimer.Size = new Size(144, 25);
            lblGlobalTimer.TabIndex = 7;
            lblGlobalTimer.Text = "Totale tijd: 60";
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.BackColor = Color.Black;
            lblFeedback.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeedback.ForeColor = Color.Transparent;
            lblFeedback.Location = new Point(311, 353);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(135, 28);
            lblFeedback.TabIndex = 8;
            lblFeedback.Text = "Fout of Goed";
            lblFeedback.TextAlign = ContentAlignment.BottomCenter;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Black;
            lblScore.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(615, 63);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(87, 28);
            lblScore.TabIndex = 9;
            lblScore.Text = "Score: 0";
            // 
            // btnFiftyFifty
            // 
            btnFiftyFifty.BackColor = Color.DarkRed;
            btnFiftyFifty.FlatAppearance.BorderSize = 0;
            btnFiftyFifty.FlatStyle = FlatStyle.Flat;
            btnFiftyFifty.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiftyFifty.Location = new Point(629, 341);
            btnFiftyFifty.Name = "btnFiftyFifty";
            btnFiftyFifty.Size = new Size(157, 58);
            btnFiftyFifty.TabIndex = 10;
            btnFiftyFifty.Text = "50/50 Joker";
            btnFiftyFifty.UseVisualStyleBackColor = false;
            btnFiftyFifty.Click += btnFiftyFifty_Click;
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.better_picture;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(798, 450);
            Controls.Add(btnFiftyFifty);
            Controls.Add(lblScore);
            Controls.Add(lblFeedback);
            Controls.Add(lblGlobalTimer);
            Controls.Add(btnJoker);
            Controls.Add(lblTimer);
            Controls.Add(btnAnswer4);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer1);
            Controls.Add(lblQuestion);
            Name = "QuizForm";
            Text = "QuizForm";
            Load += QuizForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuestion;
        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer3;
        private Button btnAnswer4;
        private Label lblTimer;
        private System.Windows.Forms.Timer questionTimer;
        private Button btnJoker;
        private System.Windows.Forms.Timer globalTimer;
        private Label lblGlobalTimer;
        private Label lblFeedback;
        private Label lblScore;
        private Button btnFiftyFifty;
    }
}