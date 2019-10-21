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
    /// Okno pozwalające na generowanie raportów miesięcznych.
    /// </summary>
    public partial class RapOk : Form
    {
        string connString = @"Data Source=DESKTOP-J0OFJTH\SQLEXPRESS;Initial Catalog=Sklep;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                                ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlDataAdapter DataAdapter; // ten obiekt pozwala na połączenie między programem a bazą danych
        DataTable table;
        string komendaSelect = "Select * from Zakupy";

        public RapOk()
        {
            InitializeComponent();
        }

        private void RapOk_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bindingSource2; // powiązanie okna do wyświetlania danych z bazą danych 
            GetData(komendaSelect); //kod sql wyświetlający dane z tabeli Klient
            cmbMiesiac.SelectedIndex = 0;
            cmbRok.SelectedIndex = 0;
        }

        private void GetData(string komendaSelect)
        {
            try
            {
                DataAdapter = new SqlDataAdapter(komendaSelect, connString);
                table = new DataTable(); //tworzenie nowego obiektu table typu DataTable
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                DataAdapter.Fill(table); //uzupełnia tabele
                bindingSource2.DataSource = table;
                DGV.Columns[0].ReadOnly = true; //zapobiega zmianie wartości ID
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbMiesiac.SelectedIndex == -1 || cmbRok.SelectedIndex == -1)
            {
                MessageBox.Show("Podaj miesiąc i rok!");
            }

            else
            {
                switch (cmbMiesiac.SelectedItem.ToString())
                {

                    case "Styczeń":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-01-01' and '" + cmbRok.SelectedItem.ToString() + "-01-31'");
                            break;
                        }
                    case "Luty":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-02-01' and '" + cmbRok.SelectedItem.ToString() + "-02-28'");
                            break;
                        }
                    case "Marzec":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-03-01' and '" + cmbRok.SelectedItem.ToString() + "-03-31'");
                            break;
                        }
                    case "Kwiecień":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-04-01' and '" + cmbRok.SelectedItem.ToString() + "-04-30'");
                            break;
                        }
                    case "Maj":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-05-01' and '" + cmbRok.SelectedItem.ToString() + "-05-31'");
                            break;
                        }
                    case "Czerwiec":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-06-01' and '" + cmbRok.SelectedItem.ToString() + "-06-30'");
                            break;
                        }
                    case "Lipiec":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-07-01' and '" + cmbRok.SelectedItem.ToString() + "-07-31'");
                            break;
                        }
                    case "Sierpień":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-08-01' and '" + cmbRok.SelectedItem.ToString() + "-08-31'");
                            break;
                        }
                    case "Wrzesień":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-09-01' and '" + cmbRok.SelectedItem.ToString() + "-09-30'");
                            break;
                        }
                    case "Październik":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-10-01' and '" + cmbRok.SelectedItem.ToString() + "-10-31'");
                            break;
                        }
                    case "Listopad":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-11-01' and '" + cmbRok.SelectedItem.ToString() + "-11-30'");
                            break;
                        }
                    case "Grudzień":
                        {
                            GetData("Select * from Zakupy where Data between '" + cmbRok.SelectedItem.ToString() + "-12-01' and '" + cmbRok.SelectedItem.ToString() + "-12-31'");
                            break;
                        }
                }

            }
        }
         
    }
}
