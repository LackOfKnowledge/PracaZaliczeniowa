using System.Collections.Generic;

namespace pzalicz_KSkuratowicz.Formularze
{
    public class Szkola : Czlowiek
    {
        public string Pesel { get; set; }
        public Szkola(string Imie, string Nazwisko, List<string> ListaBłędów, string pesel)
            : base(Imie, Nazwisko, ListaBłędów)
        {
            Pesel = pesel;
        }
        public Szkola Sprawdz(string Imie, string Nazwisko, List<string> ListaBłędów, string pesel)
        {
            base.Sprawdz(Imie, Nazwisko, ListaBłędów);
            if (!SprawdzanieDanych.SprawdzPESEL(pesel))
            {
                ListaBłędów.Add(Bledy[2]);
            }

            return new Szkola(Imie, Nazwisko, ListaBłędów, pesel);
        }
    }
}
