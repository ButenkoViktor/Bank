using BankLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;
namespace BankTestsProject;


[TestClass]
public class KontoLimitTest
{
    private KontoLimit konto;

    // Test 1 **Konstruktor inicjalizuje dane**
    [TestMethod]
    public void KontoLimit_Konstruktor_InicjalizujeDane()
    {
        // AAA

        // Arrange
        string klient = "Butenko";
        decimal bilans = 100;
        decimal limitDebetowy = 50;

        // Act
        KontoLimit konto = new KontoLimit(klient, bilans, limitDebetowy);

        // Assert
        Assert.AreEqual(150, konto.Bilans, "Bilans jest niepoprawny");
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane");
    }

    // Test 2: Konstruktor rzuca wyjątek dla ujemnego limitu debetowego
    [TestMethod]
    public void KontoLimit_Konstruktor_UjemnyLimitDebetowy()
    {
        //AAA

        // Arrange 

        // Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => new KontoLimit("Butenko", 100, -50));
        Assert.AreEqual("Limit debetowy nie może być ujemny.", ex.Message);
    }

    // Test 3: Wypłata w granicach balansu
    [TestMethod]
    public void KontoLimit_ZwyklaWyplata()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act
        konto.Wypłata(50);

        // Assert
        Assert.AreEqual(100, konto.Bilans);
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane");
    }

    // Test 4: Wypłata przekraczająca limit debetowy
    [TestMethod]
    public void KontoLimit_Wyplata_PrzekroczenieLimitu()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act and Assert
        var ex = Assert.ThrowsException<InvalidOperationException>(() => konto.Wypłata(160));
        Assert.AreEqual("Przekroczono limit debetowy.", ex.Message);
    }
    // Test 5: Wypłata ujemnej kwoty
    [TestMethod]
    public void KontoLimit_Wyplata_UjemnaKwota()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.Wypłata(-50));
        Assert.AreEqual("Kwota wypłaty nie może być ujemna.", ex.Message);
    }
    // Test 6: Wpłata ujemnej kwoty
    [TestMethod]
    public void KontoLimit_Wplata_UjemnaKwota()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.Wpłata(-50));
        Assert.AreEqual("Kwota wpłaty nie może być ujemna.", ex.Message);
    }

    // Test 7: Sprawdzenie domyślnego stanu konta
    [TestMethod]
    public void KontoLimit_SprawdzenieDomyslnegoStanu()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act and Assert
        Assert.IsFalse(konto.Zablokowane, "Nowe konto nie powinno być zablokowane");
        Assert.AreEqual(150, konto.Bilans, "Bilans początkowy jest niepoprawny");
    }

    // Test 8: Zmiana limitu debetowego
    [TestMethod]
    public void KontoLimit_ZmianaLimituDebetowego()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act
        konto.LimitDebetowy = 70;

        // Assert
        Assert.AreEqual(70, konto.LimitDebetowy);
    }

    // Test 9: Zmiana limitu debetowego na wartość ujemną
    [TestMethod]
    public void KontoLimit_ZmianaLimituDebetowegoNaUjemny()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act and Assert
        var ex = Assert.ThrowsException<ArgumentException>(() => konto.LimitDebetowy = -50);
        Assert.AreEqual("Limit debetowy nie może być ujemny.", ex.Message);
    }

    // Test 10: Wpłata zwiększa bilans i nie zmienia statusu zablokowania, jeśli nie było debetu
    [TestMethod]
    public void KontoLimit_Wplata_ZwiekszaBilansNieZmieniaStatusu()
    {
        // Arrange
        KontoLimit konto = new KontoLimit("Butenko", 100, 50);

        // Act
        konto.Wpłata(50);

        // Assert
        Assert.AreEqual(200, konto.Bilans, "Bilans po wpłacie powinien być zwiększony");
        Assert.IsFalse(konto.Zablokowane, "Konto nie powinno być zablokowane, ponieważ nie było debetu");
    }
}
