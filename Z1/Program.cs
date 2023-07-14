namespace Z1
{

    internal class Program
    {
        static void Main(string[] args)
        {



            Osoba NowaOsoba = new Osoba("Arek Kwiatkowski");
                  NowaOsoba.DataUrodzenia = new DateTime(2001, 10, 21);
            NowaOsoba.DataŚmierci = null;
            //NowaOsoba.DataŚmierci = new DateTime(2050, 12, 31);
            TimeSpan? wiekOsoby = NowaOsoba.Wiek;

            //Zrobiłem to dla czytelnośći
            if (wiekOsoby.HasValue)
            {
                int lata = (int)(wiekOsoby.Value.TotalDays / 365.25);
                Console.WriteLine($"Imię i nazwisko: {NowaOsoba.ImięNazwisko}");
                Console.WriteLine($"Wiek: {lata}");
            }
        }
    }

    class Osoba
    {
        public Osoba(string imięNazwisko)
        {
            ImięNazwisko = imięNazwisko;
        }

        string imię;
        string Nazwisko;
        public DateTime? DataUrodzenia = null;
        public DateTime? DataŚmierci = null;


        public string Imię
        {
            get => imię;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Imię nie może być puste.");
                }
                imię = value;
            }
        }

        public string ImięNazwisko
        {
            get { return $"{Imię} {Nazwisko}"; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Imię = string.Empty;
                    Nazwisko = string.Empty;
                }
                else
                {
                    string[] split = value.Split(' ');
                    Imię = split[0];
                    if (split.Length > 1) { 
                        Nazwisko = split[^1]; 
                    }else
                        Nazwisko = "";
                }


            }
        }

        public TimeSpan? Wiek
        {
            get
            {
                if (DataUrodzenia == null)
                    return null;

                DateTime endDate = DataŚmierci ?? DateTime.Now;
                return endDate - DataUrodzenia.Value;
            }
        }

    }
}
