using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public  class KontoLimit
    {
        private Konto konto;
        private decimal jednorazowyLimitDebetowy;
        private bool wykorzystanyLimit = false;

        // Konstruktor klasy KontoLimit
        public KontoLimit(string klient, decimal bilansNaStart, decimal limitDebetowy)
        {
            if (limitDebetowy < 0)
                throw new ArgumentException("Limit debetowy nie może być ujemny.");

            konto = new Konto(klient, bilansNaStart);
            this.jednorazowyLimitDebetowy = limitDebetowy;
        }
        public decimal LimitDebetowy
        {
            get { return jednorazowyLimitDebetowy; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Limit debetowy nie może być ujemny.");
                if (konto.Zablokowane)
                    throw new InvalidOperationException("Nie można zmieniać limitu dla zablokowanego konta.");

                jednorazowyLimitDebetowy = value;
            }
        }
        public decimal Bilans
        {
            get { return konto.Bilans + (wykorzystanyLimit ? 0 : jednorazowyLimitDebetowy); }
        }

        public void Wypłata(decimal kwota)
        {
            if (konto.Zablokowane)
                throw new InvalidOperationException("Konto jest zablokowane.");

            if (kwota < 0)
                throw new ArgumentException("Kwota wypłaty nie może być ujemna.");

            if (kwota <= konto.Bilans)
                konto.Wypłata(kwota);
            
            else if (!wykorzystanyLimit && kwota <= konto.Bilans + jednorazowyLimitDebetowy)
            {
                wykorzystanyLimit = true;
                konto.Wypłata(kwota);
                konto.BlokujKonto();
            }
            else
                throw new InvalidOperationException("Przekroczono limit debetowy.");
            
        }

        public void Wpłata(decimal kwota)
        {
            if (kwota < 0)
                throw new ArgumentException("Kwota wpłaty nie może być ujemna.");

            konto.Wpłata(kwota);

            if (konto.Bilans > 0)
            {
                konto.OdblokujKonto();
                wykorzystanyLimit = false;
            }
        }

        public bool Zablokowane
        {
            get { return konto.Zablokowane; }
        }
    }
}
