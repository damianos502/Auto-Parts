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
    /// Okno pozwalające na wyszukanie i wybranie konkretnej części którą będziemy sprzedawać.
    /// </summary>
    public partial class SzukajCzesci : Form
    {
        public SzukajCzesci()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Ścieżka do połączenia z bazą
        SqlDataAdapter DataAdapter; //Ten obiekt pozwala na połączenie między programem a bazą danych
        DataTable table;
        string komendaSelect = "Select * from Czesci";
        public string ReturnedText = "";


        private void SzukajCzesci_Load(object sender, EventArgs e) //Domyślne (startowe) ustawienia
        {
            cboCzesc.SelectedIndex = 0; //Ta linijka czyści Combo Box
            DGW.DataSource = bindingSource1; //Powiązanie okna do wyświetlania danych z bazą danych 
            GetData(komendaSelect); //Kod sql wyświetlający dane z tabeli Czesci
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
                DGW.Columns[0].ReadOnly = true; //Zapobiega zmianie wartości ID
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnSzukaj_Click(object sender, EventArgs e)
        {
            switch (cboCzesc.SelectedItem.ToString())
             {
                case "Model":
                    GetData("Select * from Czesci where lower(Model) like '%" + txtCzesc.Text.ToLower() + "%'");
                    break;

                case "Numer Katalogowy":
                    GetData("Select * from Czesci where lower(Numer_Katalogowy) like '%" + txtCzesc.Text.ToLower() + "%'");
                    break;

                case "Nazwa Czesci":
                    GetData("Select * from Czesci where lower(Nazwa_Czesci) like '%" + txtCzesc.Text.ToLower() + "%'");
                    break;
            }
        }

        private void DGW_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Podwójne kliknięcie na rekordzie powoduje przesłanie jego id do okna SprzedOk
        {
            if (DGW.SelectedCells.Count > 0)
            {
                int wybranyWiersz = DGW.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = DGW.Rows[wybranyWiersz];
                ReturnedText = selectedRow.Cells["Id_Czesci"].Value.ToString();
                this.Hide();
            }
        }
    }
}
