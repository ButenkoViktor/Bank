using System;
using System.Security.Cryptography.X509Certificates;
namespace Bank
{
    public class Konto
    {
        private string klient;  //nazwa klienta
        private decimal bilans;  //aktualny stan środków na koncie
        private bool zablokowane = false; //stan konta
        private Konto() { }
        public Konto(string klient, decimal bilansNaStart = 0)
        {

            this.klient = klient;
            this.bilans = bilansNaStart;
        }
        // Read-only property for client's name
        public string Nazwa
        {
            get { return klient; }
        }

        // Read-only property for current balance
        public decimal Bilans
        {
            get { return bilans; }
        }

        // Read-only property for account status
        public bool Zablokowane
        {
            get { return zablokowane; }
        }
        public void Wpłata(decimal kwota)
        {
            if (zablokowane)
            {
                throw new InvalidOperationException("Konto zablokowane");
            }
            if (kwota <= 0)
            {
                throw new ArgumentOutOfRangeException("Kwota musi być dodatnia");
            }
            bilans += kwota;
        }
        public void Wypłata(decimal kwota)
        {
            if (zablokowane)
            {
                throw new InvalidOperationException("Konto zablokowane");
            }
            if (kwota <= 0)
            {
                throw new ArgumentOutOfRangeException("Kwota musi być dodatnia");
            }
            if (bilans < kwota)
            {
                throw new InvalidOperationException("Na koncie nie ma takiej kwoty");
            }
            bilans -= kwota;
        }
        public void BlokujKonto()
        {
            zablokowane = true;
        }
        public void OdblokujKonto()
        {
            zablokowane = false;
        }
    }
}
