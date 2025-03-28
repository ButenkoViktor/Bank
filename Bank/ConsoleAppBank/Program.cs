using System;

namespace BankLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Konto standardowe
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("      *** WITAMY W SYSTEMIE BANKOWYM *** ");
            Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA STANDARDOWEGO ***\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("+ Otwarcie konta standardowego: ");
            Console.ResetColor();
            Konto konto = new Konto("Viktor Butenko", 1000);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** + Wpłata 350 zł ***");
            Console.ResetColor();
            konto.Wpłata(350);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Nowy bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Próba wypłaty 2000 zł (za dużo) ***");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wypłaty 2000 zł...");
                Console.ResetColor();
                konto.Wypłata(2000);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Wypłata 900 zł ***");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Próba wypłaty 900 zł...");
            konto.Wypłata(900);
            Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Nowy bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** Blokowanie konta ***");
            konto.BlokujKonto();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** + Próba wpłaty 100 zł na zablokowane konto ***");
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wpłaty 100 zł...");
                Console.ResetColor();
                konto.Wpłata(100);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Próba wypłaty 100 zł z zablokowanego konta ***");
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wypłaty 100 zł...");
                Console.ResetColor();
                konto.Wypłata(100);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("***Odblokowanie konta ***");
            konto.OdblokujKonto();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {konto.Nazwa} | Bilans: {konto.Bilans} zł | Stan konta(zablokowane): {konto.Zablokowane} ]\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA STANDARDOWEGO ZAKOŃCZONA ***");
            Console.WriteLine(new string('-', 90));
            Console.ResetColor();

            // Konto Plus (limit 100 zł)
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  *** WITAMY W SYSTEMIE BANKOWYM *** ");
            Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA PLUS ***\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("+ Otwarcie konta plus (limit 100 zł): ");
            KontoPlus kontoPlus = new KontoPlus("Oleksandr Moskalenko", 1500, 100);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Wypłata 1450 zł ***");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Próba wypłaty 1450 zł...");
            kontoPlus.Wypłata(1450);
            Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Nowy bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Wypłata 200 zł ***");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wypłaty 200 zł...");
                Console.ResetColor();
                kontoPlus.Wypłata(200);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** + Wpłata 150 zł ***");
            Console.ResetColor();
            kontoPlus.Wpłata(150);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** Blokowanie konta plus ***");
            kontoPlus.BlokujKonto();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** + Próba wpłaty 100 zł na zablokowane konto plus ***");
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wpłaty 100 zł...");
                Console.ResetColor();
                kontoPlus.Wpłata(100);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Próba wypłaty 100 zł z zablokowanego konta plus ***");
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wypłaty 100 zł...");
                Console.ResetColor();
                kontoPlus.Wypłata(100);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("***Odblokowanie konta plus ***");
            kontoPlus.OdblokujKonto();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoPlus.Nazwa} | Bilans: {kontoPlus.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoPlus.Zablokowane} ]\n");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA PLUS ZAKOŃCZONA ***");
            Console.WriteLine(new string('-', 90));
            Console.ResetColor();

            // Konto Limit (limit 100 zł)
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  *** WITAMY W SYSTEMIE BANKOWYM *** ");
            Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA LIMIT ***\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("+ Otwarcie konta plus (limit 100 zł): ");
            KontoPlus kontoLimit = new KontoPlus("Vlad Vesnij", 500, 100);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa} | Bilans: {kontoLimit.Bilans} zł | Limit: {kontoLimit.LimitDebetowy} zł | Stan konta(zablokowane): {kontoLimit.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Wypłata 500 zł ***");
            kontoLimit.Wypłata(500);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa} | Nowy bilans: {kontoLimit.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoLimit.Zablokowane} ]\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*** - Wypłata 200 zł ***");
            Console.ResetColor();
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Próba wypłaty 200 zł...");
                Console.ResetColor();
                kontoLimit.Wypłata(200);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Błąd: {ex.Message}!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa}  | Bilans:  {kontoLimit.Bilans} zł | Limit: {kontoLimit.LimitDebetowy} zł | Stan konta(zablokowane): {kontoLimit.Zablokowane} ]\n");

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*** + Wpłata 150 zł ***");
                Console.ResetColor();
                kontoLimit.Wpłata(150);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa} | Bilans: {kontoLimit.Bilans} zł | Limit: {kontoLimit.LimitDebetowy} zł | Stan konta(zablokowane): {kontoLimit.Zablokowane} ]\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*** Blokowanie konta limit ***");
                kontoLimit.BlokujKonto();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa}  | Bilans:  {kontoLimit.Bilans}  zł | Limit:  {kontoLimit.LimitDebetowy}  zł | Stan konta(zablokowane):  {kontoLimit.Zablokowane} ]\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("***Odblokowanie konta limit ***");
                kontoLimit.OdblokujKonto();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ Konto klienta: {kontoLimit.Nazwa} | Bilans: {kontoLimit.Bilans} zł | Limit: {kontoPlus.LimitDebetowy} zł | Stan konta(zablokowane): {kontoLimit.Zablokowane} ]\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("*** SYMULACJA DZIAŁANIA KONTA LIMIT ZAKOŃCZONA ***");
                Console.WriteLine(new string('-', 90));
                Console.ResetColor();

            }
        }
    }
}


        }
    }
}