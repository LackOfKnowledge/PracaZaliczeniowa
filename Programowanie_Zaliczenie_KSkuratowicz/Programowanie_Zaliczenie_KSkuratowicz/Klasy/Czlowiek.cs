using System;
using System.Collections.Generic;

namespace pzalicz_KSkuratowicz.Klasy
{
    public abstract class Czlowiek
    {
        public bool CzyPoprawne;
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public List<string> BłędyLista { get; set; }

        public string[] Bledy =
        {
            "BŁĄD: Imię MUSI zaczynać się wielką literą, zawierać min. 5 znaków oraz zabronione są znaki specjalne",
            "BŁĄD: Nazwisko MUSI zaczynać się wielką literą, zawierać min. 7 znaków oraz zabronione są znaki specjalne",
            "BŁĄD: PESEL MUSI składać się z 11 cyfr",
            "BŁĄD: Wiek powinien zawierać się w przedziale ",
            "BŁĄD: Adres e-mail jest nieprawidłowy",
            "BŁĄD: Minimalne wymagane wykształcenie to średnie lub wyższe"
        };

        public Czlowiek(string imie, string nazwisko, List<string> listabledow)
        {
            Imię = imie;
            Nazwisko = nazwisko;
            BłędyLista = listabledow;
        }
        public string[] Wyksztalcenie =
        {
            "Podstawowe",
            "Zawodowe",
            "Średnie",
            "Wyższe"
        };
        public override bool Equals(object czl)
        {
            return czl is Czlowiek czlowiek &&
                   CzyPoprawne == czlowiek.CzyPoprawne;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CzyPoprawne);
        }
        public virtual void Sprawdz(string Imie, string Nazwisko, List<string> ListaBledow)
        {
            if (!SprawdzanieDanych.SprawdzImie(Imie, 5))
            {
                ListaBledow.Add(Bledy[0]);
            }

            if (!SprawdzanieDanych.SprawdzImie(Nazwisko, 7))
            {
                ListaBledow.Add(Bledy[1]);
            }
        }
    }
}
