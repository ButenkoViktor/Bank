using BankLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace BankTestsProject;

[TestClass]
public class KontoPlusTests
{
    // Test 1 **Konstruktor inicjalizuje dane**
    [TestMethod]
    public void KontoPlus_Konstruktor_InicjalizujeDane()
    {
        //AAA

        // Arrange
        string klient = "Butenko";
        decimal bilans = 100;
        decimal limitDebetowy = 50;

        // Act
        KontoPlus konto = new KontoPlus(klient, bilans, limitDebetowy);

        // Assert
        Assert.AreEqual(klient, konto.Nazwa, "Nazwa klienta jest niepoprawna");
        Assert.AreEqual(bilans + limitDebetowy, konto.Bilans, "Bilans jest niepoprawny");
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane");
    }

    // Test 2 **Wypłata w granicach balansu**
    [TestMethod]
    public void KontoPlus_ZwykłaWypłata()
    {
        //AAA

        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        // Act
        konto.Wypłata(50);

        // Assert
        Assert.AreEqual(50 + 50, konto.Bilans);
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane");
    }

    // Test 3 **Wypłata przekraczająca limit debetowy**
    [TestMethod]
    public void KontoPlus_Wypłata_PrzekroczenieLimitu()
    {
        //AAA

        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        //Act and Assert
        var ex = Assert.ThrowsException<InvalidOperationException>(() => konto.Wypłata(160));
        Assert.AreEqual("Przekroczono limit debetowy.", ex.Message);
    }

    // Test 4 **Wypłata ujemnej kwoty**
    [TestMethod]
    public void KontoPlus_Wypłata_UjemnaKwota()
    {
        // AAA

        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        //Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.Wypłata(-10));
        Assert.AreEqual("Kwota wypłaty nie może być ujemna.", ex.Message);
    }

    // Test 5 **Wpłata ujemnej kwoty**
    [TestMethod]
    public void KontoPlus_Wpłata_UjemnaKwota()
    {
        // AAA

        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        //Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.Wpłata(-10));
        Assert.AreEqual("Kwota wpłaty nie może być ujemna.", ex.Message);
    }

    // Test 6 **Sprawdzenie domyślnego stanu konta**
    [TestMethod]
    public void KontoPlus_SprawdzenieDomyslnegoStanu()
    {
        // AAA

        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        //Act and Assert
        Assert.IsFalse(konto.Zablokowane, "Nowe konto nie powinno być zablokowane");
        Assert.AreEqual(150, konto.Bilans, "Bilans początkowy jest niepoprawny");
    }

    // Test 7 **Zmiana limitu debetowego**
    [TestMethod]
    public void KontoPlus_ZmianaLimituDebetowego()
    {
        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        // Act
        konto.LimitDebetowy = 70;

        // Assert
        Assert.AreEqual(70, konto.LimitDebetowy);
    }

    // Test 8 **Zmiana limitu debetowego na wartość ujemną**
    [TestMethod]
    public void KontoPlus_ZmianaLimituDebetowegoNaUjemny()
    {
        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        //Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.LimitDebetowy = -10);
        Assert.AreEqual("Limit debetowy nie może być ujemny.", ex.Message);
    }
    // Test 9 **Wpłata zwiększa bilans i nie zmienia statusu zablokowania, jeśli nie było debetu**
    [TestMethod]
    public void KontoPlus_Wplata_ZwiekszaBilansNieZmieniaStatusu()
    {
        // Arrange
        KontoPlus konto = new KontoPlus("Butenko", 100, 50);

        // Act
        konto.Wpłata(50);

        // Assert
        Assert.AreEqual(200, konto.Bilans, "Bilans po wpłacie powinien być zwiększony");
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane, ponieważ nie było debetu");
    }
}
