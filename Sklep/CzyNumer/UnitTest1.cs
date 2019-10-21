using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sklep;

namespace CzyNumer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CzyNumerNeg()
        {
            //Arrange
            string tekst = "tekst123";
            bool expected = false;

            //Act
            KlienciOk.CzyNumer(tekst);

            //Assert
            bool actual = KlienciOk.CzyNumer(tekst);
            Assert.AreEqual(expected, actual, "Elementy porównywane nie zgodne");
        }
        [TestMethod]
        public void CzyNumerPoz()
        {
            //Arrange
            string tekst = "123456789";
            bool expected = true;

            //Act
            KlienciOk.CzyNumer(tekst);

            //Assert
            bool actual = KlienciOk.CzyNumer(tekst);
            Assert.AreEqual(expected, actual, "Elementy porównywane nie zgodne");
        }
    }
}
