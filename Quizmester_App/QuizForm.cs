using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmester_App
{
    public partial class QuizForm : Form
    {
        public long currentCategoryId;
        public List<Question> categoryQuestions;

        public int currentQuestionIndex = 0;
        public int score = 0;
        public int timeLeft;
        public int globalTimeLeft = 60;

        public QuizForm(long categoryId)
        {
            InitializeComponent();
            currentCategoryId = categoryId;
        }

        private async void QuizForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (currentCategoryId == 0)
                {
                    var result = await Form1.supabase.From<Question>().Get();
                    categoryQuestions = result.Models;
                }
                else
                {
                    var result = await Form1.supabase.From<Question>()
                        .Where(x => x.CategoryId == currentCategoryId)
                        .Get();
                    categoryQuestions = result.Models;
                }

                if (categoryQuestions.Count > 0)
                {
                    ToonVraag();
                    globalTimer.Start();
                }
                else
                {
                    MessageBox.Show("Er zijn nog geen vragen gevonden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het ophalen van de vragen: " + ex.Message);
            }
        }

        private void ToonVraag()
        {
            Question huidigeVraag = categoryQuestions[currentQuestionIndex];
            lblQuestion.Text = huidigeVraag.QuestionText;

            List<string> antwoordenLijst = new List<string>
            {
                huidigeVraag.CorrectAnswer,
                huidigeVraag.WrongAnswer1,
                huidigeVraag.WrongAnswer2,
                huidigeVraag.WrongAnswer3
            };

            Random rnd = new Random();
            antwoordenLijst = antwoordenLijst.OrderBy(x => rnd.Next()).ToList();

            lblTimer.ForeColor = Color.LimeGreen;

            btnAnswer1.Text = antwoordenLijst[0];
            btnAnswer2.Text = antwoordenLijst[1];
            btnAnswer3.Text = antwoordenLijst[2];
            btnAnswer4.Text = antwoordenLijst[3];

            // AANGEPAST: Timer staat nu vast op 5 seconden per vraag
            timeLeft = 5;
            lblTimer.Text = $"Tijd over: {timeLeft} seconden";
            questionTimer.Start();
        }

        private async void CheckAntwoord(string gekozenAntwoord)
        {
            questionTimer.Stop();
            Question huidigeVraag = categoryQuestions[currentQuestionIndex];

            if (gekozenAntwoord == "")
            {
                lblFeedback.Text = $"Tijd op! Het antwoord was: {huidigeVraag.CorrectAnswer}";
                lblFeedback.ForeColor = Color.Red;
            }
            else if (gekozenAntwoord == huidigeVraag.CorrectAnswer)
            {
                lblFeedback.Text = "Helemaal goed!";
                lblFeedback.ForeColor = Color.LimeGreen;
                score++;
                lblScore.Text = $"Score: {score} / {categoryQuestions.Count}";
            }
            else
            {
                lblFeedback.Text = $"Fout! Het was: {huidigeVraag.CorrectAnswer}";
                lblFeedback.ForeColor = Color.Red;
            }

            await Task.Delay(2000);
            lblFeedback.Text = "";
            currentQuestionIndex++;

            if (currentQuestionIndex < categoryQuestions.Count)
            {
                ToonVraag();
            }
            else
            {
                MessageBox.Show($"Einde van de quiz! Jouw score: {score} van de {categoryQuestions.Count}");

                try
                {
                    var nieuweScore = new Score
                    {
                        UserId = Form1.CurrentUser.Id,
                        ScoreValue = score,
                        CreatedAt = DateTime.UtcNow
                    };

                    await Form1.supabase.From<Score>().Insert(nieuweScore);
                    MessageBox.Show("Score succesvol opgeslagen in de database!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij het opslaan van de score: " + ex.Message);
                }

                ScoreboardForm scoreboard = new ScoreboardForm();
                scoreboard.Show();
                this.Close();
            }
        }

        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            CheckAntwoord(btnAnswer1.Text);
        }

        private void btnAnswer2_Click(object sender, EventArgs e)
        {
            CheckAntwoord(btnAnswer2.Text);
        }

        private void btnAnswer3_Click(object sender, EventArgs e)
        {
            CheckAntwoord(btnAnswer3.Text);
        }

        private void btnAnswer4_Click(object sender, EventArgs e)
        {
            CheckAntwoord(btnAnswer4.Text);
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblTimer.Text = $"Tijd over: {timeLeft}";

            // Blijft altijd groen
            lblTimer.ForeColor = Color.LimeGreen;

            if (timeLeft <= 0)
            {
                questionTimer.Stop();
                CheckAntwoord("");
            }
        }

        private async void btnJoker_Click(object sender, EventArgs e)
        {
            questionTimer.Stop();
            btnJoker.Enabled = false;
            MessageBox.Show("Joker ingezet! We slaan deze vraag over zonder strafpunten.");
            currentQuestionIndex++;

            if (currentQuestionIndex < categoryQuestions.Count)
            {
                ToonVraag();
            }
            else
            {
                MessageBox.Show($"Einde van de quiz! Jouw score: {score} van de {categoryQuestions.Count}");
                globalTimer.Stop();

                try
                {
                    var nieuweScore = new Score
                    {
                        UserId = Form1.CurrentUser.Id,
                        ScoreValue = score,
                        CreatedAt = DateTime.UtcNow
                    };

                    await Form1.supabase.From<Score>().Insert(nieuweScore);
                    MessageBox.Show("Score succesvol opgeslagen in de database!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij het opslaan van de score: " + ex.Message);
                }

                ScoreboardForm scoreboard = new ScoreboardForm();
                scoreboard.Show();
                this.Close();
            }
        }

        private async void globalTimer_Tick(object sender, EventArgs e)
        {
            globalTimeLeft--;
            lblGlobalTimer.Text = $"Totale tijd: {globalTimeLeft}";

            // AANGEPAST: Totale timer wordt rood bij 15 seconden of minder
            if (globalTimeLeft <= 15)
            {
                lblGlobalTimer.ForeColor = Color.Red;
            }
            else
            {
                lblGlobalTimer.ForeColor = Color.LimeGreen;
            }

            if (globalTimeLeft <= 0)
            {
                globalTimer.Stop();
                questionTimer.Stop();

                MessageBox.Show($"De tijd is om! Je minuut is voorbij. Jouw score: {score} van de {categoryQuestions.Count}");

                try
                {
                    var nieuweScore = new Score
                    {
                        UserId = Form1.CurrentUser.Id,
                        ScoreValue = score,
                        CreatedAt = DateTime.UtcNow
                    };

                    await Form1.supabase.From<Score>().Insert(nieuweScore);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij het opslaan van de score: " + ex.Message);
                }

                ScoreboardForm scoreboard = new ScoreboardForm();
                scoreboard.Show();
                this.Close();
            }
        }
    }
}