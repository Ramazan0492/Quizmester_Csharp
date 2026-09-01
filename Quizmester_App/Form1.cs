using System;
using System.Windows.Forms;
using Supabase;

namespace Quizmester_App
{
    public partial class Form1 : Form
    {
        // Maak de supabase client aan
        public static Client supabase;
        public static User CurrentUser;

        public Form1()
        {
            InitializeComponent();
        }

        // De code die start zodra de app opent (let op het woordje 'async')
        private async void Form1_Load(object sender, EventArgs e)
        {
            // De keys van Supabase om connection mee te maken
            string url = "https://tmpcfqkcniruuigfvzfn.supabase.co";
            string key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRtcGNmcWtjbmlydXVpZ2Z2emZuIiwicm9sZSI6ImFub24iLCJpYXQiOjE3ODgxNTg1OTUsImV4cCI6MjEwMzczNDU5NX0.daw6FhxBGJezti2z0NCSq-hADPaFYaSs1sYU-D5yMtc";

            var options = new SupabaseOptions
            {
                AutoConnectRealtime = false
            };

            // Maakt verbinding met jouw database
            supabase = new Client(url, key, options);
            await supabase.InitializeAsync();
        }

        // Ik moest voor dit try/catch gebruiken anders crashed het
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Lees wat de speler heeft getypt
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            // 2. Check of ze de vakjes niet leeg hebben gelaten
            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Vul a.u.b. een gebruikersnaam en wachtwoord in!");
                return;
            }

            try
            { 
                // Controleer of de gebruikersnaam al bestaat in de database
                var checkResult = await supabase.From<User>()
                    .Where(x => x.Username == inputUsername)
                    .Get();

                if (checkResult.Models.Count > 0)
                {
                    MessageBox.Show("Deze gebruikersnaam is al bezet! Kies a.u.b. een andere.");
                    return; // Stop met registreren
                }

                // 3. Maak een nieuwe User aan
                var newUser = new User
                {
                    Username = inputUsername,
                    Password = inputPassword,
                    IsAdmin = false // Een nieuwe speler is natuurlijk geen admin
                };

                // 4. Stuur de nieuwe gebruiker naar de database
                await supabase.From<User>().Insert(newUser);
                MessageBox.Show("Registratie succesvol! Je staat in de database. Je kunt nu inloggen.");

                txtPassword.Text = ""; // Maak het wachtwoordvakje leeg na registratie
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er ging iets mis met de database-verbinding: " + ex.Message);
            }
        }

        // Ik moest voor dit try/catch gebruiken anders crashed het
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUsername = txtUsername.Text;
            string inputPassword = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Vul a.u.b. een gebruikersnaam en wachtwoord in!");
                return;
            }

            try
            {
                var result = await Form1.supabase.From<User>()
                    .Where(x => x.Username == inputUsername && x.Password == inputPassword)
                    .Get();

                var loggedInUser = result.Models.FirstOrDefault();

                if (loggedInUser != null)
                {
                    MessageBox.Show($"Welkom terug, {loggedInUser.Username}! Inloggen succesvol.");

                    // 1. Sla de speler op
                    CurrentUser = loggedInUser;

                    // 2. Open het nieuwe hoofdmenu
                    MainMenu menu = new MainMenu();
                    menu.Show();

                    // 3. Verberg dit inlogscherm
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Verkeerde gebruikersnaam of wachtwoord. Probeer het opnieuw.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het inloggen: " + ex.Message);
            }
        }
    }
}