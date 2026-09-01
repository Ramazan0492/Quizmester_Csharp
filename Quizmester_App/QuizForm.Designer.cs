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
            SuspendLayout();
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(288, 20);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(202, 20);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Hier komt de vraag te staan...";
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(53, 161);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(150, 50);
            btnAnswer1.TabIndex = 1;
            btnAnswer1.Text = "button1";
            btnAnswer1.UseVisualStyleBackColor = true;
            btnAnswer1.Click += btnAnswer1_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(238, 161);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(150, 50);
            btnAnswer2.TabIndex = 2;
            btnAnswer2.Text = "button2";
            btnAnswer2.UseVisualStyleBackColor = true;
            btnAnswer2.Click += btnAnswer2_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(406, 161);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(150, 50);
            btnAnswer3.TabIndex = 3;
            btnAnswer3.Text = "button3";
            btnAnswer3.UseVisualStyleBackColor = true;
            btnAnswer3.Click += btnAnswer3_Click;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(589, 161);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(150, 50);
            btnAnswer4.TabIndex = 4;
            btnAnswer4.Text = "button4";
            btnAnswer4.UseVisualStyleBackColor = true;
            btnAnswer4.Click += btnAnswer4_Click;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(342, 325);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(90, 20);
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
            btnJoker.BackColor = Color.Gold;
            btnJoker.Location = new Point(107, 287);
            btnJoker.Name = "btnJoker";
            btnJoker.Size = new Size(119, 58);
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
            lblGlobalTimer.Location = new Point(632, 275);
            lblGlobalTimer.Name = "lblGlobalTimer";
            lblGlobalTimer.Size = new Size(99, 20);
            lblGlobalTimer.TabIndex = 7;
            lblGlobalTimer.Text = "Totale tijd: 60";
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}