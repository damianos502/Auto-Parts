using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sklep;
namespace SprawdzDostepnosc
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Dostepnosc()
        {
            // Arrange
            int liczba_zam = 2;
            int id_czesci = 1;
            bool expected = true;

            // Act
            SprzedOk frm = new SprzedOk();
            frm.SprawdzDostepnosc(liczba_zam, id_czesci);


            // Assert
            bool actual = frm.SprawdzDostepnosc(liczba_zam, id_czesci);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BrakDostepnosci()
        {
            // Arrange
            int liczba_zam = 10;
            int id_czesci = 1;
            bool expected = false;

            // Act
            SprzedOk frm = new SprzedOk();
            frm.SprawdzDostepnosc(liczba_zam, id_czesci);


            // Assert
            bool actual = frm.SprawdzDostepnosc(liczba_zam, id_czesci);
            Assert.AreEqual(expected, actual);
        }

    }
}