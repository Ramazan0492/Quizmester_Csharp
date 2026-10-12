using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Quizmester_App
{
    public partial class AdminForm : Form
    {
        private List<Question> alleVragen = new List<Question>();
        private Question geselecteerdeVraag = null;

        public AdminForm()
        {
            InitializeComponent();

            // Koppelingen voor de vragen
            this.Load += AdminForm_Load;
            lstQuestions.SelectedIndexChanged += lstQuestions_SelectedIndexChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;

            // NIEUW: Koppeling voor de gebruiker-verwijder knop
            btnDeleteUser.Click += btnDeleteUser_Click;
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            await LaadVragen();
            await LaadGebruikers(); // Laad nu ook direct de gebruikers in de rechterlijst
        }

        private async Task LaadVragen()
        {
            try
            {
                var result = await Form1.supabase.From<Question>().Get();
                alleVragen = result.Models;

                lstQuestions.DataSource = null;
                lstQuestions.DataSource = alleVragen;
                lstQuestions.DisplayMember = "QuestionText";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij laden van vragen: " + ex.Message);
            }
        }

        private void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstQuestions.SelectedItem is Question gekozen)
            {
                geselecteerdeVraag = gekozen;

                txtCorrect.Text = gekozen.CorrectAnswer;
                txtWrong1.Text = gekozen.WrongAnswer1;
                txtWrong2.Text = gekozen.WrongAnswer2;
                txtWrong3.Text = gekozen.WrongAnswer3;
                txtCategory.Text = gekozen.CategoryId.ToString();
                txtTime.Text = gekozen.TimeLimit.ToString();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var nieuweVraag = new Question
                {
                    QuestionText = txtQuestion.Text,
                    CorrectAnswer = txtCorrect.Text,
                    WrongAnswer1 = txtWrong1.Text,
                    WrongAnswer2 = txtWrong2.Text,
                    WrongAnswer3 = txtWrong3.Text,
                    CategoryId = int.Parse(txtCategory.Text),
                    TimeLimit = int.Parse(txtTime.Text)
                };

                await Form1.supabase.From<Question>().Insert(nieuweVraag);
                MessageBox.Show("Nieuwe vraag succesvol toegevoegd!");
                await LaadVragen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij toevoegen. Check of categorie/tijd wel nummers zijn! " + ex.Message);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (geselecteerdeVraag == null) return;

            try
            {
                geselecteerdeVraag.QuestionText = txtQuestion.Text;
                geselecteerdeVraag.CorrectAnswer = txtCorrect.Text;
                geselecteerdeVraag.WrongAnswer1 = txtWrong1.Text;
                geselecteerdeVraag.WrongAnswer2 = txtWrong2.Text;
                geselecteerdeVraag.WrongAnswer3 = txtWrong3.Text;
                geselecteerdeVraag.CategoryId = int.Parse(txtCategory.Text);
                geselecteerdeVraag.TimeLimit = int.Parse(txtTime.Text);

                await Form1.supabase.From<Question>().Update(geselecteerdeVraag);
                MessageBox.Show("Vraag succesvol bijgewerkt!");
                await LaadVragen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij updaten: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (geselecteerdeVraag == null) return;

            DialogResult antwoord = MessageBox.Show("Weet je zeker dat je deze vraag wilt verwijderen?", "Waarschuwing", MessageBoxButtons.YesNo);
            if (antwoord == DialogResult.Yes)
            {
                try
                {
                    await Form1.supabase.From<Question>().Where(x => x.Id == geselecteerdeVraag.Id).Delete();
                    MessageBox.Show("Vraag verwijderd!");

                    txtQuestion.Text = ""; txtCorrect.Text = ""; txtWrong1.Text = "";
                    txtWrong2.Text = ""; txtWrong3.Text = ""; txtCategory.Text = ""; txtTime.Text = "";
                    geselecteerdeVraag = null;

                    await LaadVragen();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij verwijderen: " + ex.Message);
                }
            }
        }

        // --- NIEUW GEDEELTE VOOR GEBRUIKERS ---

        private async Task LaadGebruikers()
        {
            try
            {
                var result = await Form1.supabase.From<User>().Get();
                lstUsers.DataSource = null;
                lstUsers.DataSource = result.Models;
                lstUsers.DisplayMember = "Username"; // We laten de gebruikersnaam in de lijst zien
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij laden van gebruikers: " + ex.Message);
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem is User gekozenSpeler)
            {
                // Extra beveiliging: Je mag jezelf (de ingelogde admin) niet weggooien!
                if (gekozenSpeler.Id == Form1.CurrentUser.Id)
                {
                    MessageBox.Show("Je kunt jezelf niet verwijderen!");
                    return;
                }

                DialogResult antwoord = MessageBox.Show($"Weet je zeker dat je het account van '{gekozenSpeler.Username}' wilt verwijderen?", "Speler verwijderen", MessageBoxButtons.YesNo);
                if (antwoord == DialogResult.Yes)
                {
                    try
                    {
                        await Form1.supabase.From<User>().Where(x => x.Id == gekozenSpeler.Id).Delete();
                        MessageBox.Show("Speler succesvol verwijderd!");
                        await LaadGebruikers(); // Ververs de rechterlijst
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fout bij verwijderen van speler: " + ex.Message);
                    }
                }
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MainMenu hoofdMenu = new MainMenu();
            hoofdMenu.Show();

            this.Close();
        }
    }
}