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
    /// Ekran Główny na którym wybieramy moduł do którego chcemy sie przenieść.
    /// </summary>
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Klienci_Click(object sender, EventArgs e)
        {
            KlienciOk frm = new KlienciOk(); //Tworzenie nowego okna do zarządzania bazą klientów.
            frm.Show(); //Wyświetlenie okna
        }

        private void Magazyn_Click(object sender, EventArgs e)
        {
            CzesciOk frm = new CzesciOk();
            frm.Show();
        }

        private void SprzedażToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SprzedOk frm = new SprzedOk();
            frm.Show();
        }

        private void raportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RapOk frm = new RapOk();
            frm.Show(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
