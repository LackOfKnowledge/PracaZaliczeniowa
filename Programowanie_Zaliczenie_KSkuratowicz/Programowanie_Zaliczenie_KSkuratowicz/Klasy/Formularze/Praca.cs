using System;
using System.Collections.Generic;

namespace pzalicz_KSkuratowicz.Formularze
{
    class Praca : Czlowiek
    {
        public string Płeć { get; set; }
        public int Wykształcenie { get; set; }
        public int Wiek { get; set; }
        public Praca(string Imie, string Nazwisko, List<string> ListaBledow, int wiek, string płeć, int wykształcenie)
        : base(Imie, Nazwisko, ListaBledow)
        {
            Płeć = płeć;
            Wykształcenie = wykształcenie;
            Wiek = wiek;
        }
        public Praca Sprawdz(string Imie, string Nazwisko, int Wiek, string Płeć, int Wykształcenie, List<string> ListaBledow)
        {
            base.Sprawdz(Imie, Nazwisko, ListaBledow);
            if (!SprawdzanieDanych.SprawdzWiek(Wiek, 18, 65))
            {
                ListaBledow.Add(Bledy[3] + " 18 a 65.");
            }

            if (Wykształcenie < 3)
            {
                ListaBledow.Add(Bledy[5]);
            }

            return new Praca(Imie, Nazwisko, ListaBledow, Wiek, Płeć, Wykształcenie);
        }
    }
}
