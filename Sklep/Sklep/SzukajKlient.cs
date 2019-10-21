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
    /// Okno pozwala na wybranie z dostępnej listy jednego klienta dla którego tworzymy Sprzedaż.
    /// </summary>
    public partial class SzukajKlient : Form
    {
        public SzukajKlient()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Ścieżka do połączenia z bazą
        SqlDataAdapter DataAdapter1; //Ten obiekt pozwala na połączenie między programem a bazą danych
        DataTable tabela;
        string komendaSelect = "Select * from Klient";
        public string ReturnedText = "";


        private void SzukajKlient_Load(object sender, EventArgs e) //Domyślne (startowe) ustawienia
        {
            cboKlient.SelectedIndex = 0; // Ta linijka czyści Combo Box
            DGW.DataSource = bindingSource1; //Powiązanie okna do wyświetlania danych z bazą danych 
            bindingSource1.DataSource = tabela;
            GetData(komendaSelect); //Kod sql wyświetlający dane z tabeli Klient
        }

        private void GetData(string komendaSelect)
        {
            try
            {
                DataAdapter1 = new SqlDataAdapter(komendaSelect, connString);
                tabela = new DataTable(); //Tworzenie nowego obiektu table typu DataTable
                tabela.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter1.Fill(tabela); //Uzupełnia tabele
                bindingSource1.DataSource = tabela;
                DGW.Columns[0].ReadOnly = true; //Zapobiega zmianie wartości ID
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


            private void BtnSzukaj_Click(object sender, EventArgs e)
            {
                switch (cboKlient.SelectedItem.ToString())
                {
                    case "Numer Klienta":
                        GetData("Select * from Klient where lower(Id_Klienta) like '%" + txtKlient.Text.ToLower() + "%'");
                        break;

                    case "Firma":
                        GetData("Select * from Klient where lower(Firma) like '%" + txtKlient.Text.ToLower() + "%'");
                        break;

                    case "Nazwisko":
                        GetData("Select * from Klient where lower(Nazwisko) like '%" + txtKlient.Text.ToLower() + "%'");
                        break;
                }
            }

        private void DGW_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int wybranyWiersz = DGW.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = DGW.Rows[wybranyWiersz];
            ReturnedText = selectedRow.Cells["Id_Klienta"].Value.ToString();
            this.Hide();
        }
    }
}
