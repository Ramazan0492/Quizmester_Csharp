using System;
using System.Linq;
using System.Windows.Forms;

namespace Quizmester_App
{
    public partial class ScoreboardForm : Form
    {
        public ScoreboardForm()
        {
            InitializeComponent();

            this.Load += ScoreboardForm_Load;
        }

        private async void ScoreboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Haal de top 10 hoogste scores op uit de database
                var scoresResult = await Form1.supabase.From<Score>()
                    .Order(x => x.ScoreValue, Supabase.Postgrest.Constants.Ordering.Descending)
                    .Limit(10)
                    .Get();

                var topScores = scoresResult.Models;

                // Haal ook alle gebruikers op, zodat we ID's aan namen kunnen koppelen
                var usersResult = await Form1.supabase.From<User>().Get();
                var allUsers = usersResult.Models;

                lstScores.Items.Clear();

                int positie = 1;
                foreach (var score in topScores)
                {
                    var speler = allUsers.FirstOrDefault(u => u.Id == score.UserId);

                    // Controleer even of jouw variabele in User.cs echt Username heet!
                    string naam = speler != null ? speler.Username : "Onbekende speler";

                    lstScores.Items.Add($"{positie}. {naam} - {score.ScoreValue} punten");
                    positie++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het laden van het scoreboard: " + ex.Message);
            }
        }

        private void btnTerug_Click(object sender, EventArgs e)
        {
            // Ga terug naar het hoofdmenu
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}