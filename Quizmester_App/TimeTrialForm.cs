using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmester_App
{
    public partial class TimeTrialForm : Form
    {
        public List<Question> alleVragen;
        public int currentQuestionIndex = 0;
        public int correctAnswers = 0; // We tellen nu goede antwoorden, doel is 10
        public int timeElapsed = 0; // Tijd telt nu op vanaf 0

        public TimeTrialForm()
        {
            InitializeComponent();
        }

        private async void TimeTrialForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Haal alle vragen op
                var result = await Form1.supabase.From<Question>().Get();
                alleVragen = result.Models;

                // Schud de vragen willekeurig
                Random rnd = new Random();
                alleVragen = alleVragen.OrderBy(x => rnd.Next()).ToList();

                if (alleVragen.Count >= 10)
                {
                    ToonVraag();
                    mainTimer.Start(); // Zorg dat je timer 'mainTimer' heet in je design!
                }
                else
                {
                    MessageBox.Show("Niet genoeg vragen in de database voor deze modus!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database fout: {ex.Message}\n\n(Tijdelijke melding) Jouw eindtijd is: {timeElapsed} seconden.");
            }
        }

        private void ToonVraag()
        {
            Question huidigeVraag = alleVragen[currentQuestionIndex];
            lblQuestion.Text = huidigeVraag.QuestionText;

            List<string> antwoorden = new List<string>
            {
                huidigeVraag.CorrectAnswer,
                huidigeVraag.WrongAnswer1,
                huidigeVraag.WrongAnswer2,
                huidigeVraag.WrongAnswer3
            };

            Random rnd = new Random();
            antwoorden = antwoorden.OrderBy(x => rnd.Next()).ToList();

            btnAnswer1.Text = antwoorden[0];
            btnAnswer2.Text = antwoorden[1];
            btnAnswer3.Text = antwoorden[2];
            btnAnswer4.Text = antwoorden[3];

            lblScore.Text = $"Goed: {correctAnswers} / 10";
        }

        private async void CheckAntwoord(string gekozenAntwoord)
        {
            // 1. Knoppen tijdelijk uitzetten om dubbelklikken te voorkomen
            btnAnswer1.Enabled = false;
            btnAnswer2.Enabled = false;
            btnAnswer3.Enabled = false;
            btnAnswer4.Enabled = false;

            Question huidigeVraag = alleVragen[currentQuestionIndex];

            if (gekozenAntwoord == huidigeVraag.CorrectAnswer)
            {
                lblFeedback.Text = "Goed!";
                lblFeedback.ForeColor = Color.LimeGreen;
                correctAnswers++;
            }
            else
            {
                timeElapsed += 5; // 5 seconden straftijd
                lblFeedback.Text = "+5 sec straf!";
                lblFeedback.ForeColor = Color.Red;
                lblTimer.Text = $"Tijd: {timeElapsed} sec";
            }

            // 2. Korte pauze van 1 seconde (zorg dat 'await' er echt staat!)
            await Task.Delay(1000);
            lblFeedback.Text = "";

            // 3. Check of het doel van 10 is bereikt
            if (correctAnswers >= 10)
            {
                lblScore.Text = $"Goed: {correctAnswers} / 10"; // Update score nog 1 keer
                mainTimer.Stop();

                try
                {
                    // Haal de absolute snelste tijd op uit de database (laagste tijd eerst)
                    var response = await Form1.supabase.From<TimeScore>()
                                        .Select("*")
                                        .Order("TimeInSeconds", Supabase.Postgrest.Constants.Ordering.Ascending)
                                        .Limit(1)
                                        .Get();

                    var snelsteRecord = response.Models.FirstOrDefault();

                    // Check of jij de snelste was, of dat er nog geen records zijn
                    if (snelsteRecord == null || timeElapsed < snelsteRecord.TimeInSeconds)
                    {
                        MessageBox.Show($"GEFELICITEERD!\n\nJouw eindtijd is: {timeElapsed} seconden.\nDit is de SNELSTE TIJD OOIT gespeeld!");
                    }
                    else
                    {
                        MessageBox.Show($"Jouw eindtijd is: {timeElapsed} seconden.\n\nDe snelste tijd ooit is {snelsteRecord.TimeInSeconds} seconden.");
                    }

                    // Sla jouw tijd op in de database
                    var nieuweTijd = new TimeScore
                    {
                        UserId = Form1.CurrentUser.Id.ToString(),
                        TimeInSeconds = timeElapsed,
                        CreatedAt = DateTime.UtcNow
                    };
                    await Form1.supabase.From<TimeScore>().Insert(nieuweTijd);
                }
                catch (Exception)
                {
                    // Mocht de database even niet meewerken, laat dan in ieder geval je tijd zien
                    MessageBox.Show($"Gefeliciteerd! Jouw eindtijd is: {timeElapsed} seconden.");
                }

                MainMenu hoofdMenu = new MainMenu();
                hoofdMenu.Show();
                this.Close();
            }
            else
            {
                // 4. Knoppen weer aanzetten en naar de volgende vraag
                btnAnswer1.Enabled = true;
                btnAnswer2.Enabled = true;
                btnAnswer3.Enabled = true;
                btnAnswer4.Enabled = true;

                currentQuestionIndex++;

                if (currentQuestionIndex < alleVragen.Count)
                {
                    ToonVraag(); // Dit updatet ook meteen de score in beeld
                }
                else
                {
                    mainTimer.Stop();
                    MessageBox.Show("Er zijn geen vragen meer over! Quiz beëindigd.");
                    this.Close();
                }
            }
        }

        // Dit is de methode die miste en de timer elke seconde laat optellen
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            timeElapsed++;
            lblTimer.Text = $"Tijd: {timeElapsed} sec";
        }

        // Zorg dat je knop-methodes er precies zo uitzien:
        private void btnAnswer1_Click(object sender, EventArgs e) { CheckAntwoord(btnAnswer1.Text); }
        private void btnAnswer2_Click(object sender, EventArgs e) { CheckAntwoord(btnAnswer2.Text); }
        private void btnAnswer3_Click(object sender, EventArgs e) { CheckAntwoord(btnAnswer3.Text); }
        private void btnAnswer4_Click(object sender, EventArgs e) { CheckAntwoord(btnAnswer4.Text); }
    }
}