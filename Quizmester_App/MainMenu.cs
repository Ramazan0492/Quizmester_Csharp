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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            // Check of de ingelogde gebruiker een admin is
            if (Form1.CurrentUser != null && Form1.CurrentUser.IsAdmin == true)
            {
                btnAdminPanel.Visible = true; // Laat de knop zien!
            }
            else
            {
                btnAdminPanel.Visible = false; // Verstop de knop voor normale spelers
            }

            try
            {
                // Haal alle categorieën op uit jouw database
                var response = await Form1.supabase.From<Category>().Get();
                var categories = response.Models;

                // Koppel de categorieën aan je uitklapmenu (ComboBox)
                cmbCategories.DataSource = categories;

                // Vertel het menuutje dat hij de 'Name' moet laten zien aan de speler
                cmbCategories.DisplayMember = "Name";

                // En dat hij op de achtergrond het 'Id' moet onthouden voor later
                cmbCategories.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het laden van de categorieën: " + ex.Message);
            }
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedValue != null)
            {
                // Haal het ID van de gekozen categorie op
                long selectedCategoryId = (long)cmbCategories.SelectedValue;

                // Open het nieuwe quiz scherm en geef het ID mee!
                QuizForm quiz = new QuizForm(selectedCategoryId);
                quiz.Show();

                // Verberg het hoofdmenu
                this.Hide();
            }
        }

        private void btnGeneralQuiz_Click(object sender, EventArgs e)
        {
            // We geven hier een '0' mee. Onze QuizForm weet nu dat dit de General Quiz is!
            QuizForm generalQuiz = new QuizForm(0);
            generalQuiz.Show();
            this.Hide(); // of this.Close(), afhankelijk van hoe je andere knoppen in je menu werken
        }

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }
    }
}
