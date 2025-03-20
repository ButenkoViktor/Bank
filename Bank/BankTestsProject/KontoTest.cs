using BankLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace BankTestsProject
{
    [TestClass]
    public class KontoTest
    {
        //Test 1 **Konstruktor inicjalizuje dane**
        [TestMethod]
        public void Konto_Konstruktor_InicjalizujeDane()
        {
            //AAA

            //Arrange
            string klient = "Butenko";
            decimal bilans = 100;

            //Act
            Konto konto = new Konto(klient, bilans);

            //Assert
            Assert.AreEqual(klient, konto.Nazwa);
            Assert.AreEqual(bilans, konto.Bilans);
            Assert.IsFalse(konto.Zablokowane);
        }

        //Test 2 **Wpłata dodaje pieniądze**
        [TestMethod]
        public void Konto_Wpłata_DodajePieniądze()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);
            decimal kwota = 100;

            //Act
            konto.Wpłata(kwota);

            //Assert
            Assert.AreEqual(200, konto.Bilans);
        }

        //Test 3 **Wypłata odejmuje pieniądze**
        [TestMethod]
        public void Konto_Wypłata_OdejmowaniePieniędzy()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);
            decimal kwota = 40;

            //Act
            konto.Wypłata(kwota);

            //Assert
            Assert.AreEqual(60, konto.Bilans);
        }

        //Test 4 **Nie można wypłacić więcej niż jest na koncie**
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Konto_Wypłata_NieMożnaWypłacićWiększejKwoty()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 70);

            //Act
            konto.Wypłata(100);

            //Assert
        }

        //Test 5 **Blokowanie konta**
        [TestMethod]
        public void Konto_BlokujKonto_UstawiaNaZablokowane()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);

            //Act
            konto.BlokujKonto();

            //Assert
            Assert.IsTrue(konto.Zablokowane);
        }

        //Test 6 **Odblokowanie konta**
        [TestMethod]
        public void Konto_OdblokujKonto_UstawiaNaOdblokowane()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);

            //Act
            konto.OdblokujKonto();

            //Assert
            Assert.IsFalse(konto.Zablokowane);
        }

        //Test 7 **Wpłata nie działa gdy konto jest zablokowane**
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Konto_Wpłata_NieDziałaGdyZablokowane()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);
            konto.BlokujKonto();

            //Act
            konto.Wpłata(50);

            //Assert 
        }

        //Test 8 **Wypłata nie działa gdy konto jest zablokowane**
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Konto_Wyplata_NieDzialaGdyZablokowane()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);
            konto.BlokujKonto();

            //Act
            konto.Wypłata(50);

            //Assert 
        }

        //Test 9 **Wypłata nie działa gdy kwota jest ujemna
        [TestMethod]
        public void Konto_Wpłata_NieDziałaGdyKwotaJestUjemna()
        {
            //AAA

            //Arrange
            Konto konto = new Konto("Butenko", 100);

            //Act
            try
            {
                konto.Wpłata(-50);
            }
            catch (ArgumentOutOfRangeException)
            {
                //Assert
                return;
            }
            Assert.Fail();
        }
    }
}
