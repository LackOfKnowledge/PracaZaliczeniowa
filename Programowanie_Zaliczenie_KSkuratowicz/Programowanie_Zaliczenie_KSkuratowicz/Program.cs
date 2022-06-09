using pzalicz_KSkuratowicz.Formularze;
using System;
using System.Collections.Generic;
using System.Threading;


namespace pzalicz_KSkuratowicz
{
    class Program
    {
        private static string[] names =
        {
            "Formularz do szkoły",
            "Formularz do pracy",
            "Formuarz do portalu społecznościowego"
        };

        public static string[] Names { get => names; set => names = value; }

        static void Main()
        {
            //Początek czysto "estetyczny" :)
            //Powielanie kodu można powiedzieć, że tutaj było "zamierzone" :)
            Console.WriteLine("Student: Krzysztof Skuratowicz");
            Console.WriteLine("Praca zaliczeniowa z przedmiotu Programowanie");
            Spowolnienie1();
           
            Console.WriteLine("Informatyka 1 - Studia niestacjonarne");
            Spowolnienie1();
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować.");
            Spowolnienie2();
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować..");
            Spowolnienie2();
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
            int wybór = 0;
            while (wybór < 1 || wybór > 3)
            {
                Console.WriteLine($"1\t{Names[0]}\n2\t{Names[1]}\n3\t{Names[2]}");
                wybór = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Wprowadź imię (musi się składać z minimum 5 znaków!)");
            string Imie = Console.ReadLine();
            Console.WriteLine("Wprowadź nazwisko (musi się składać z minimum 7 znaków!)");
            string Nazwisko = Console.ReadLine();
            Błędy log = new("", "", new List<string>());
            log = WyborForm(wybór, Imie, Nazwisko, log);
            Console.WriteLine("Naciśnij dowolny klawisz aby wyświetlić log...\n\n");
            Console.ReadKey();
            Console.Clear();
            PokazLogi(log);
            Console.ReadKey();
        }

        private static Błędy WyborForm(int wybór, string Imie, string Nazwisko, Błędy log)
        {
            switch (wybór)
            {
                case 1:
                    log = NowyFormularzSzkola(Imie, Nazwisko);
                    break;
                case 2:
                    log = NowyPracaFormularz(Imie, Nazwisko);
                    break;
                case 3:
                    log = NowySocialMediaFormularz(Imie, Nazwisko);
                    break;
            }

            return log;
        }

        static Błędy NowyFormularzSzkola(string Imie, string Nazwisko)
        {
            Console.WriteLine("Wprowadź numer PESEL (11 cyfr)");
            string pesel = Console.ReadLine();
            Szkola FormularzSzkola = new(Imie, Nazwisko, new List<string>(), pesel);
            FormularzSzkola = FormularzSzkola.Sprawdz(Imie, Nazwisko, new List<string>(), pesel);
            return new Błędy(Names[0], SprawdzanieDanych.CzyPoprawny(FormularzSzkola.BłędyLista), FormularzSzkola.BłędyLista);
        }
        static Błędy NowyPracaFormularz(string Imie, string Nazwisko)
        {
            Console.WriteLine("Wprowadź wiek");
            int Wiek = int.Parse(Console.ReadLine());
            Console.WriteLine("Wprowadź płeć (M/m lub K/k)");
            string Płeć = SprawdzanieDanych.GetPłeć();
            int Wykształcenie = SprawdzanieDanych.GetWykształcenie();
            Praca praca = new(Imie, Nazwisko, new List<string>(), Wiek, Płeć, Wykształcenie);
            Praca PracaFormularz = praca;
            PracaFormularz = PracaFormularz.Sprawdz(Imie, Nazwisko, Wiek, Płeć, Wykształcenie, new List<string>());
            return new Błędy(Names[1], SprawdzanieDanych.CzyPoprawny(PracaFormularz.BłędyLista), PracaFormularz.BłędyLista);
        }
        static Błędy NowySocialMediaFormularz(string Imie, string Nazwisko)
        {
            Console.WriteLine("Podaj e-mail");
            string Email = Console.ReadLine();
            Console.WriteLine("Podaj wiek");
            int Wiek = int.Parse(Console.ReadLine());
            SocialMedia SocialMedia = new(Imie, Nazwisko, new List<string>(), Wiek, Email);
            SocialMedia FormularzSocialMedia = SocialMedia;
            FormularzSocialMedia = FormularzSocialMedia.Sprawdz(Imie, Nazwisko, Email, Wiek, new List<string>());
            return new Błędy(Names[2], SprawdzanieDanych.CzyPoprawny(FormularzSocialMedia.BłędyLista), FormularzSocialMedia.BłędyLista);
        }
        static void PokazLogi(Błędy log)
        {
            Console.WriteLine($"Rodzaj:\t{log.GetNazwaFormularza()}\n");
            Console.WriteLine(log.GetCzyPoprawny());
            if (log.GetListaBledow().Count != 0)
            {
                Console.WriteLine("\nNr\tOpis błędu\n");
                List<string> list = log.GetListaBledow();
                for (int i = 0; i < list.Count; i++)
                {
                    string błąd = list[i];
                    Console.WriteLine($@"{log.GetListaBledow().IndexOf(błąd) + 1}	{błąd}");
                }

            }
        }

        public static void Spowolnienie2()
        {
            Thread.Sleep(500);
            Console.Clear();
        }

        public static void Spowolnienie1()
        {
            Thread.Sleep(1500);
            Console.Clear();
        }

    }
}

