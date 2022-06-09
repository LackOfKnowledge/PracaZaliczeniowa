using System.Collections.Generic;

namespace pzalicz_KSkuratowicz.Klasy
{
    class Błędy
    {
        private string nazwaFormularza;

        public string GetNazwaFormularza()
        {
            return nazwaFormularza;
        }

        public void SetnazwaFormularza(string value)
        {
            nazwaFormularza = value;
        }

        private string czyPoprawny;

        public string GetCzyPoprawny()
        {
            return czyPoprawny;
        }

        public void SetCzyPoprawny(string value)
        {
            czyPoprawny = value;
        }

        private List<string> ListaBledow;

        public List<string> GetListaBledow()
        {
            return ListaBledow;
        }

        public void SetListaBledow(List<string> value)
        {
            ListaBledow = value;
        }

        public Błędy(string nazwaFormularza, string czyPoprawny, List<string> ListaBledow)
        {
            SetnazwaFormularza(nazwaFormularza);
            SetCzyPoprawny(czyPoprawny);
            SetListaBledow(ListaBledow);
        }
    }
}
