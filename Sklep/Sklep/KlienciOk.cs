using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep
{
    /// <summary>
    /// Okno Klienci które pozwala na dodawanie, usuwanie oraz edytowanie Klientów.
    /// </summary>
    public partial class KlienciOk : Form 
    {
        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Ścieżka do połączenia z bazą
        SqlDataAdapter DataAdapter;
        DataTable table;
        SqlCommandBuilder commandBuilder;
        SqlConnection conn;
        string komendaSelect = "Select * from Klient"; //Komenda wyświetlająca zawartość tabeli Klient

        public static bool CzyNumer(string str) //sprawdza czy numer telefonu jest numerem
        {
            foreach (char c in str)
                {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        public KlienciOk()
        {
            InitializeComponent();
        }

        private void KlienciOk_Load(object sender, EventArgs e) //Domyślne (startowe) ustawienia
        {
            cboSearch.SelectedIndex = 0; //Ta linijka czyści Combo Box
            dataGridView1.DataSource = bindingSource1;
            GetData(komendaSelect); //Wyświetlenie danych w Gridzie
        }

        private void GetData(string selectCommand)
        {
            try
            {
                DataAdapter = new SqlDataAdapter(selectCommand, connString);
                table = new DataTable(); //Tworzenie nowego obiektu table typu DataTable
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter.Fill(table); //Uzupełnia tabele
                bindingSource1.DataSource = table;
                dataGridView1.Columns[0].ReadOnly = true; //Zapobiega zmianie wartości ID
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); //Wyświetla błąd jeśli try nie zostanie ukończone pomyślnie
            }   
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            if (txtFirma.Text == "" || txtImie.Text == "" || txtNazwisko.Text == "" || txtTelefon.Text == "") //Warunek dotyczący wypełnienia wymaganych pól
            {
                MessageBox.Show("Podaj niezbędne dane: Firma, Imię, Nazwisko, Telefon!");
            }
            else if(!CzyNumer(txtTelefon.Text))
            {
                MessageBox.Show("Numer telefonu nie może zawierać liter!");
            }
            else
            {
                SqlCommand command;
                string insert = @"insert into Klient(Firma, Imie, Nazwisko, Adres, Kod_Pocztowy,
                                                  Miasto, Email, Telefon, Notatki)
                              values(@Firma, @Imie, @Nazwisko, @Adres, @Kod_Pocztowy,
                                                  @Miasto, @Email, @Telefon, @Notatki)"; //String który wprowadza nowe dane do tabeli
                using (conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open(); //Powiązanie TextBoxów z poszczególnymi kolumnami w tabeli
                        command = new SqlCommand(insert, conn);
                        command.Parameters.AddWithValue(@"Firma", txtFirma.Text);
                        command.Parameters.AddWithValue(@"Imie", txtImie.Text);
                        command.Parameters.AddWithValue(@"Nazwisko", txtNazwisko.Text);
                        command.Parameters.AddWithValue(@"Adres", txtAdres.Text);
                        command.Parameters.AddWithValue(@"Kod_Pocztowy", txtKod.Text);
                        command.Parameters.AddWithValue(@"Miasto", txtMiasto.Text);
                        command.Parameters.AddWithValue(@"Email", txtEmail.Text);
                        command.Parameters.AddWithValue(@"Telefon", txtTelefon.Text);
                        command.Parameters.AddWithValue(@"Notatki", TxtRNotatki.Text);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message); //Wyświetla błąd jeśli jest coś nie tak
                    }
                }
                GetData(komendaSelect); //Wyświetla dane z tabeli Klient
                dataGridView1.Update(); //Odświeża wyświetlacz wyników
                MessageBox.Show("Pomyślnie dodano klienta!");
            }
        }

        private void BtnUsun_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;//Referencja do aktualnie wybranego rekordu
            string numer = row.Cells["Id_Klienta"].Value.ToString(); //Przypisanie zmiennej numer wyniku zaznaczonego rekordu z kolumny Id_Klienta
            string imie = row.Cells["Imie"].Value.ToString(); //Przypisanie zmiennej imie wartości z kolumny Imie
            string nazwisko = row.Cells["Nazwisko"].Value.ToString(); // J.w.
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć pozycje: " + imie + " " + nazwisko + ", rekord o numerze " + numer,
                                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                //Okienko z zapytaniem o potwierdzenie usunięcia rekordu, przypisanie rezultatu do zmiennej result
            string deleteState = @"Delete from Klient where Id_Klienta = " + numer + ";"; //Komenda usuwająca wybrany rekord
            if (result==DialogResult.Yes) //Jeśli wybrano tak to wykonać
            {
                using(conn = new SqlConnection(connString))
                {
                    try
                    {
                        
                        conn.Open(); //Próba rozpoczęcia połączenie
                        SqlCommand comm = new SqlCommand(deleteState, conn);
                        comm.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                GetData(komendaSelect); //Wyświetla dane z tabeli Klient
                dataGridView1.Update(); //Odświeża wyświetlacz wyników
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) //Edycja poszczególnej komórki
        {
            commandBuilder = new SqlCommandBuilder(DataAdapter);
            DataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            try
            {
                bindingSource1.EndEdit();
                DataAdapter.Update(table); // Aktualizuje baze danych
                MessageBox.Show("Zaktualizowany pomyślnie!"); //Komunikat o poprawności edytowania
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSzukaj_Click(object sender, EventArgs e) //Działania dla przycisku Szukaj
        {
            switch(cboSearch.SelectedItem.ToString())
            {
                case "Imie":
                    GetData("Select * from Klient where lower(Imie) like '%" + txtSearch.Text.ToLower() + "%'"); //Jeśli w combo boxie wybrano imie to szukaj w kolumnie imie
                    break;

                case "Firma":
                    GetData("Select * from Klient where lower(Firma) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;

                case "Nazwisko":
                    GetData("Select * from Klient where lower(Nazwisko) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }

        private void BindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
