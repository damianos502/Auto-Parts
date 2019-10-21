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
    /// Okno Magazynu które pozwala nam na zarządzanie dostępnymi częściami oraz ich stanem magazynowym.
    /// </summary>
    public partial class CzesciOk : Form
    {
        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlDataAdapter DataAdapter; //Ten obiekt pozwala na połączenie między programem a bazą danych
        DataTable table;
        SqlCommandBuilder commandBuilder;
        SqlConnection conn;
        string komendaSelect = "Select * from Czesci";

        public CzesciOk()
        {
            InitializeComponent();
        }

        private void CzesciOk_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0; // Ta linijka czyści Combo Box
            dataGridView1.DataSource = bindingSource1; //Powiązanie okna do wyświetlania danych z bazą danych 
            GetData(komendaSelect); //Kod sql wyświetlający dane z tabeli Czesci
        }

        private void GetData(string komendaSelect)
        {
            try
            {
                DataAdapter = new SqlDataAdapter(komendaSelect, connString);
                table = new DataTable(); //Tworzenie nowego obiektu table typu DataTable
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter.Fill(table); //Uzupełnia tabele
                bindingSource1.DataSource = table;
                dataGridView1.Columns[0].ReadOnly = true; //Zapobiega zmianie wartości ID
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            if (txtModel.Text == "" || txtNumer.Text == "" || txtStan.Text == "")
            {
                MessageBox.Show("Podaj niezbędne dane: Model, Numer Katalogowy, Stan Magazynowy!");
            }

            else
            {
                SqlCommand command;
                string insert = @"insert into Czesci(Marka, Model, Rodzaj_Paliwa, Silnik, Typ_Czesci,
                                                  Nazwa_Czesci, Numer_Katalogowy, Stan_Magazyn)
                              values(@Marka, @Model, @Rodzaj_Paliwa, @Silnik, @Typ_Czesci,
                                                  @Nazwa_Czesci, @Numer_Katalogowy, @Stan_Magazyn)";
                using (conn = new SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        command = new SqlCommand(insert, conn);
                        command.Parameters.AddWithValue(@"Marka", txtMarka.Text);
                        command.Parameters.AddWithValue(@"Model", txtModel.Text);
                        command.Parameters.AddWithValue(@"Rodzaj_Paliwa", cboPaliwo.SelectedItem.ToString());
                        command.Parameters.AddWithValue(@"Silnik", txtSilnik.Text);
                        command.Parameters.AddWithValue(@"Typ_Czesci", cboTyp.SelectedItem.ToString());
                        command.Parameters.AddWithValue(@"Nazwa_Czesci", txtCzesc.Text);
                        command.Parameters.AddWithValue(@"Numer_Katalogowy", txtNumer.Text);
                        command.Parameters.AddWithValue(@"Stan_Magazyn", txtStan.Text);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message); //Wyświetla błąd jeśli jest coś nie tak
                    }
                }

                GetData(komendaSelect); //Wyświetla dane z tabeli Czesci
                dataGridView1.Update(); //Odświeża wyświetlacz wyników
            }
        }

        private void BtnUsun_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;//Referencja do aktualnie wybranego rekordu
            string numer = row.Cells["Id_Czesci"].Value.ToString(); //Przypisanie zmiennej numer wyniku zaznaczonego rekordu z kolumny Id_Czesci
            string czesc = row.Cells["Nazwa_Czesci"].Value.ToString();
            string model = row.Cells["Model"].Value.ToString();
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć pozycje: " + czesc + " do " + model + ", rekord o numerze " + numer,
                                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Okienko z zapytaniem o potwierdzenie usunięcia rekordu, przypisanie rezultatu do zmiennej result
            string deleteState = @"Delete from Czesci where Id_Czesci = " + numer + ";"; //Komenda usuwająca wybrany rekord
            if (result == DialogResult.Yes) //Jeśli wybrano tak to wykonać
            {
                using (conn = new SqlConnection(connString))
                {
                    try
                    {

                        conn.Open(); //Próba rozpoczęcia połączenie
                        SqlCommand comm = new SqlCommand(deleteState, conn);
                        comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                GetData(komendaSelect); //Wyświetla dane z tabeli Czesci
                dataGridView1.Update(); //Odświeża wyświetlacz wyników
            }
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            commandBuilder = new SqlCommandBuilder(DataAdapter);
            DataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            try
            {
                bindingSource1.EndEdit();
                DataAdapter.Update(table); //Aktualizuje baze danych
                MessageBox.Show("Zaktualizowany pomyślnie!"); //Komunikat o poprawności edytowania
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSzukaj_Click(object sender, EventArgs e)
        {
            switch (cboSearch.SelectedItem.ToString())
            {
                case "Model":
                    GetData("Select * from Czesci where lower(Model) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;

                case "Numer Katalogowy":
                    GetData("Select * from Czesci where lower(Numer_Katalogowy) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;

                case "Nazwa Czesci":
                    GetData("Select * from Czesci where lower(Nazwa_Czesci) like '%" + txtSearch.Text.ToLower() + "%'");
                    break;
            }
        }
    }
}
