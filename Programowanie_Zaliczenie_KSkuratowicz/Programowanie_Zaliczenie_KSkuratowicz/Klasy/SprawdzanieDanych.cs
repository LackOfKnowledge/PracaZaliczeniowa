using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace pzalicz_KSkuratowicz.Klasy
{
    class SprawdzanieDanych
    {

        public static bool SprawdzImie(string imie, int minDlugosc)
        {
            foreach (char znak in imie)
            {
                if (!char.IsLetter(znak)) return false;
            }
            if (imie.Length < minDlugosc || imie[0] != char.ToUpper(imie[0]))
            {
                return false;
            }

            return true;
        }
        public static bool SprawdzPESEL(string pesel)
        {
            if (pesel.Length != 11)
            {
                return false;
            }

            foreach (char znak in pesel)
            {
                if (!char.IsDigit(znak))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool SprawdzWiek(int wiek, int minWiek, int maxWiek)
        {
            if (wiek < minWiek || wiek > maxWiek)
            {
                return false;
            }
            return true;
        }

        private const string Pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        public static bool SprawdzMaila(string email)

        {
            return Regex.IsMatch(email,
                   Pattern,
                   RegexOptions.IgnoreCase,
                   matchTimeout: TimeSpan.FromMilliseconds(250));
        }
        public static string CzyPoprawny(List<string> ListaBłędów)
        {
            if (ListaBłędów.Count == 0)
            {
                return "Formularz jest poprawny";
            }

            return "Formularz został błędnie wypełniony";
        }
        public static string GetPłeć()
        {
            string Płeć = "x";
            while (Płeć[0] is not 'M' and not 'm' and not 'K' and not 'k')
            {
                Console.WriteLine("Podaj płeć\nM\tMężczyzna\nK\tKobieta");
                Płeć = Console.ReadLine();
            }
            if (Płeć[0] == 'M' || Płeć[0] == 'm')
            {
                return "Mężczyzna";
            }

            return "Kobieta";
        }
        public static int GetWykształcenie()
        {
            int wybór = 0;
            while (wybór is < 1 or > 4)
            {
                Console.WriteLine("Podaj wykształcenie:");
                Console.WriteLine("1. Podstawowe");
                Console.WriteLine("2. Zawodowe");
                Console.WriteLine("3. Średnie");
                Console.WriteLine("4. Wyższe");
                wybór = int.Parse(Console.ReadLine());
            }
            return wybór;
        }
    }
}