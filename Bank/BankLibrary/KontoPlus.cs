using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLibrary;

namespace BankLibrary
{
    class KontoPlus : Konto
    {
        private decimal jednorazowyLimitDebetowy;
        private bool wykorzystanyLimit = false;

        // Konstruktor klasy KontoPlus
        public KontoPlus(string klient, decimal bilansNaStart, decimal limitDebetowy)
                            : base(klient, bilansNaStart)
        {
            this.jednorazowyLimitDebetowy = limitDebetowy;
        }

        public decimal LimitDebetowy
        {
            get { return jednorazowyLimitDebetowy; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Limit debetowy nie może być ujemny.");
                if (Zablokowane)
                    throw new InvalidOperationException("Nie można zmieniać limitu dla zablokowanego konta.");

                jednorazowyLimitDebetowy = value;
            }
        }

        public new decimal Bilans
        {
            get { return base.Bilans + (wykorzystanyLimit ? 0 : jednorazowyLimitDebetowy); }
        }

        public new void Wypłata(decimal kwota)
        {
            if (Zablokowane)
                throw new InvalidOperationException("Konto jest zablokowane.");
            
            if (kwota < 0)
                throw new ArgumentException("Kwota wypłaty nie może być ujemna.");

            if (kwota <= base.Bilans)
                base.Wypłata(kwota);
            
            else if (!wykorzystanyLimit && kwota <= base.Bilans + jednorazowyLimitDebetowy)
            {
                wykorzystanyLimit = true;
                base.Wypłata(kwota);
                BlokujKonto();
            }
            else
                throw new InvalidOperationException("Przekroczono limit debetowy.");
            
        }

        public new void Wpłata(decimal kwota)
        {
            if (kwota < 0) 
                throw new ArgumentException("Kwota wpłaty nie może być ujemna.");

            base.Wpłata(kwota);

            if (base.Bilans > 0)
            {
                OdblokujKonto();
                wykorzystanyLimit = false;
            }
        }
    }
}