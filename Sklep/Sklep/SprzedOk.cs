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
    /// Okno pozwalające na ewidencjonowanie sprzedaży, możemy wybrać Klienta oraz Część, wpisać ilość a także określić date Sprzedaży.
    /// </summary>
    public partial class SprzedOk : Form 
    {
        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlDataAdapter DataAdapter; //Ten obiekt pozwala na połączenie między programem a bazą danych
        DataTable table;
        SqlConnection conn;
        string komendaSelect = "Select Imie, Nazwisko, Nazwa_Czesci, Model, Numer_Katalogowy, Ilosc, Data from [dbo].[Zakupy] join[dbo].[Czesci] on[dbo].[Czesci].[Id_Czesci]=[dbo].[Zakupy].[Id_Czesci] join[dbo].[Klient] on[dbo].[Klient].[Id_Klienta]=[dbo].[Zakupy].[Id_Klienta]";
        int odczytanaLiczba = 0;

        public SprzedOk()
        {
            InitializeComponent();
        }

        private void SprzedOk_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1; //Powiązanie okna do wyświetlania danych z bazą danych 
            GetData(komendaSelect); //Kod sql wyświetlający dane z tabeli Zakupy
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
                if (txtCzesc.Text == "" || textKlient.Text == "" || textIlosc.Text == "") //Wszystkie TextBoxy muszą być uzupełnione
                {
                    MessageBox.Show("Wszystkie pola muszą zostać uzupełnione!");
                }

                else if (SprawdzDostepnosc(Int32.Parse(textIlosc.Text), Int32.Parse(txtCzesc.Text)))
                {
                    SqlCommand command;
                    string insert = @"insert into Zakupy(Id_Czesci, Id_Klienta, Ilosc, Data)
                              values(@Id_Czesci, @Id_Klienta, @Ilosc, @Data)";
                    string update = "update Czesci set Stan_Magazyn = " + (odczytanaLiczba - Int32.Parse(textIlosc.Text)) + " where id_czesci = " + txtCzesc.Text; //Zmiana wartośći stanu magazynowego w tabeli czesci

                    using (conn = new SqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();
                            command = new SqlCommand(insert, conn);
                            command.Parameters.AddWithValue(@"Id_Czesci", txtCzesc.Text);
                            command.Parameters.AddWithValue(@"Id_Klienta", textKlient.Text);
                            command.Parameters.AddWithValue(@"Ilosc", textIlosc.Text);
                            command.Parameters.AddWithValue(@"Data", DTP.Value);
                            command.ExecuteNonQuery();

                            command = new SqlCommand(update, conn);
                            command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message); //Wyświetla błąd jeśli jest coś nie tak
                        }
                    }

                    GetData(komendaSelect); //Wyświetla dane z tabeli Zakupy
                    dataGridView1.Update(); //Odświeża wyświetlacz wyników
                }

            else
            {
                MessageBox.Show("Podaj poprawną ilość!");
            }
        }

        public bool SprawdzDostepnosc(int liczba_zam, int id_czesci)    //Sprawdzanie dostępności
        {
            SqlCommand command;
            string select = @"select Stan_Magazyn from Czesci where id_czesci = " + id_czesci.ToString(); //Pobranie Stanu Magazynowego z tabeli Czesci
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(select, conn);
                    odczytanaLiczba = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //Wyświetla błąd jeśli jest coś nie tak
                }
            }

            if (liczba_zam > odczytanaLiczba) //Sprawdzenie czy liczba zakupu jest większa od liczby dostępnych części
                return false;
            else
                return true;
        }

        private void Button2_Click(object sender, EventArgs e) //Po kliknięciu szukaj wyświetla okno do wyboru Części
        {
            SzukajCzesci szukaj1 = new SzukajCzesci();
            szukaj1.ShowDialog();
            txtCzesc.Text = szukaj1.ReturnedText;
        }

        private void Button1_Click(object sender, EventArgs e) //Po kliknięciu Szukaj wyświetla okno do wyboru Klienta
        {
            SzukajKlient szukaj1 = new SzukajKlient();
            szukaj1.ShowDialog();
            textKlient.Text = szukaj1.ReturnedText;
        }
    }


}
