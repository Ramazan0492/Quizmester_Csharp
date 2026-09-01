namespace Quizmester_App
{
    partial class ScoreboardForm
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
            lstScores = new ListBox();
            btnTerug = new Button();
            SuspendLayout();
            // 
            // lstScores
            // 
            lstScores.FormattingEnabled = true;
            lstScores.Location = new Point(178, 12);
            lstScores.Name = "lstScores";
            lstScores.Size = new Size(462, 324);
            lstScores.TabIndex = 0;
            // 
            // btnTerug
            // 
            btnTerug.Location = new Point(335, 366);
            btnTerug.Name = "btnTerug";
            btnTerug.Size = new Size(137, 50);
            btnTerug.TabIndex = 1;
            btnTerug.Text = "Terug naar menu";
            btnTerug.UseVisualStyleBackColor = true;
            btnTerug.Click += btnTerug_Click;
            // 
            // ScoreboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnTerug);
            Controls.Add(lstScores);
            Name = "ScoreboardForm";
            Text = "ScoreboardForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstScores;
        private Button btnTerug;
    }
}