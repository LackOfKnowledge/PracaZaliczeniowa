using System.Collections.Generic;

namespace pzalicz_KSkuratowicz.Formularze
{
    class SocialMedia : Czlowiek
    {
        public int Wiek { get; set; }
        public string Email { get; set; }
        public SocialMedia(string Imie, string Nazwisko, List<string> ListaBledow, int wiek, string email)
        : base(Imie, Nazwisko, ListaBledow)
        {
            Wiek = wiek;
            Email = email;
        }
        public SocialMedia Sprawdz(string Imie, string Nazwisko, string email, int wiek, List<string> ListaBledow)
        {
            base.Sprawdz(Imie, Nazwisko, ListaBledow);
            if (!SprawdzanieDanych.SprawdzWiek(wiek, 13, 100)) ListaBledow.Add(Bledy[3] + " 13 a 100.");
            if (!SprawdzanieDanych.SprawdzMaila(email)) ListaBledow.Add(Bledy[4]);
            return new SocialMedia(Imie, Nazwisko, ListaBledow, wiek, email);
        }
    }
}
