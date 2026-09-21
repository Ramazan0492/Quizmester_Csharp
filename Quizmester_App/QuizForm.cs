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

        // Hier staat hij nu netjes bovenaan:
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
                // Check of we de General Quiz (0) spelen of een normale categorie
                if (currentCategoryId == 0)
                {
                    // Haal ALLE vragen uit de database op, zonder filter
                    var result = await Form1.supabase.From<Question>().Get();
                    categoryQuestions = result.Models;
                }
                else
                {
                    // Haal alleen de vragen van de specifieke categorie op
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

            // 1. Stop alle 4 de antwoorden in een tijdelijke lijst
            List<string> antwoordenLijst = new List<string>
            {
                huidigeVraag.CorrectAnswer,
                huidigeVraag.WrongAnswer1,
                huidigeVraag.WrongAnswer2,
                huidigeVraag.WrongAnswer3
            };

            // 2. Schud de lijst willekeurig door elkaar
            Random rnd = new Random();
            antwoordenLijst = antwoordenLijst.OrderBy(x => rnd.Next()).ToList();

            lblTimer.ForeColor = Color.LimeGreen; // Reset de kleur voor de nieuwe vraag

            // 3. Zet de geschudde antwoorden op je knoppen
            btnAnswer1.Text = antwoordenLijst[0];
            btnAnswer2.Text = antwoordenLijst[1];
            btnAnswer3.Text = antwoordenLijst[2];
            btnAnswer4.Text = antwoordenLijst[3];

            // Zet de timer op de limiet uit de database (bijv. 15 seconden)
            timeLeft = huidigeVraag.TimeLimit;
            lblTimer.Text = $"Tijd over: {timeLeft} seconden";
            questionTimer.Start();
        }

        private async void CheckAntwoord(string gekozenAntwoord)
        {
            questionTimer.Stop(); // De timer stopt, maar de tekst verandert NIET
            Question huidigeVraag = categoryQuestions[currentQuestionIndex];

            // 1. Laat de feedback zien in je NIEUWE label (lblFeedback)
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

                // NIEUW: Werk de score direct bij op het scherm!
                lblScore.Text = $"Score: {score} / {categoryQuestions.Count}";
            }
            else
            {
                lblFeedback.Text = $"Fout! Het was: {huidigeVraag.CorrectAnswer}";
                lblFeedback.ForeColor = Color.Red;
            }

            // 2. Wacht 2 seconden zodat de speler de uitslag kan lezen
            await Task.Delay(2000);

            // 3. Maak de feedback tekst weer leeg, zodat hij onzichtbaar wordt voor de volgende vraag
            lblFeedback.Text = "";

            // 4. Ga door naar de volgende vraag
            currentQuestionIndex++;

            if (currentQuestionIndex < categoryQuestions.Count)
            {
                ToonVraag();
            }
            else
            {
                // Einde van de quiz
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


        // Deze 4 zijn vrij duidelijk
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
            lblTimer.Text = $"Tijd over: {timeLeft} seconden";


            if (timeLeft <= 10)
            {
                lblTimer.ForeColor = Color.Red; // Maak de tekst rood als waarschuwing!
            }
            else
            {
                lblTimer.ForeColor = Color.LimeGreen; 
            }

            if (timeLeft <= 0)
            {
                questionTimer.Stop();

                // Stuur het lege antwoord door, ZONDER hier al een pop-up te laten zien
                CheckAntwoord("");
            }
        }

        private async void btnJoker_Click(object sender, EventArgs e)
        {
            // Stop de timer
            questionTimer.Stop();

            // Maak de knop onklikbaar zodat je hem maar 1 keer kunt gebruiken!
            btnJoker.Enabled = false;

            MessageBox.Show("Joker ingezet! We slaan deze vraag over zonder strafpunten.");

            // Ga door naar de volgende vraag
            currentQuestionIndex++;

            if (currentQuestionIndex < categoryQuestions.Count)
            {
                ToonVraag();
            }
            else
            {
                // Als je de Joker toevallig op de allerlaatste vraag inzet, 
                // moeten we de quiz wel netjes kunnen afsluiten!
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
            globalTimeLeft--; // Haal er 1 seconde van af
            lblGlobalTimer.Text = $"Totale tijd: {globalTimeLeft}"; // Laat het zien op het scherm

            if (globalTimeLeft <= 0)
            {
                // De minuut is voorbij! Stop alles.
                globalTimer.Stop();
                questionTimer.Stop();

                MessageBox.Show($"De tijd is om! Je minuut is voorbij. Jouw score: {score} van de {categoryQuestions.Count}");

                try
                {
                    // Sla de huidige score direct op
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

                // Open het scoreboard en sluit de quiz
                ScoreboardForm scoreboard = new ScoreboardForm();
                scoreboard.Show();
                this.Close();
            }
        }
    }
}