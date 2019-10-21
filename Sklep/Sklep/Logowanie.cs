using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep
{
    /// <summary>
    /// Ekran logowania który jako pierwszy ukazuje się po uruchomieniu aplikacji.
    /// </summary>
    public partial class Logowanie : Form 
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        public static string dostep;
        public void KontrolaDostepu(string login, string haslo) //Sprawdzanie poprawności danych logowania
        {
            if (login == "admin" && haslo == "admin")
                dostep = "tak";
            else
                dostep = "nie";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KontrolaDostepu(txtLogin.Text.ToString(), txtHaslo.Text.ToString()); //Jeśli dane poprawne to pozwolić na dostępn do aplikacji
            if (dostep == "tak")
            {
                this.Hide();
                Form1 ekrMain = new Form1();
                ekrMain.Show();
            }

            else if (dostep == "nie")
            {
                MessageBox.Show("Błędny login lub hasło!");
            }
        }

    }
}
