using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zad3
{
    public enum Gatunek
    {
        Rock,
        Pop,
        Jazz,
        Klasyczna,
        HipHop,
        Metal,
        Elektroniczna,
        Reggae,
        Blues,
        Country,
        Dicopolo
    }

    public class Utwór : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void PowiadomOZmianieWłaściwości([CallerMemberName] string nazwaWłaściwości = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWłaściwości));
            foreach (string powiązanaWłaściwość in PowiązaneWłaściwości[nazwaWłaściwości])
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(powiązanaWłaściwość));
        }
        static readonly Dictionary<string, IEnumerable<string>> PowiązaneWłaściwości = new Dictionary<string, IEnumerable<string>>()
        {
            ["Tytuł"] = ["Tytuł", "Info", "TytułOknaEdycji", "TytułOknaUsuwania"],
            ["Zespół"] = ["Zespół", "Info", "TytułOknaEdycji", "TytułOknaUsuwania"],
            ["Gatunek"] = ["Gatunek", "Info"],
            ["RokWydania"] = ["Wiek", "Info"]
        };

        private string tytuł = "Podaj tytuł";
        private string zespół = "Podaj zespół";
        private Gatunek gatunek;
        private DateTime rokWydania = DateTime.Now;

        public string Tytuł
        {
            get => tytuł;
            set
            {
                tytuł = value;
                PowiadomOZmianieWłaściwości();
            }
        }

        public string Zespół
        {
            get => zespół;
            set
            {
                zespół = value;
                PowiadomOZmianieWłaściwości();
            }
        }

        public Gatunek Gatunek
        {
            get => gatunek;
            set
            {
                gatunek = value;
                PowiadomOZmianieWłaściwości();
            }
        }

        public DateTime RokWydania
        {
            get => rokWydania;
            set
            {
                rokWydania = value;
                PowiadomOZmianieWłaściwości();
            }
        }

        public string Info => $"{Tytuł} by {Zespół}, {Gatunek}, Wydany w {RokWydania.Year}";
        public string TytułOknaEdycji => $"Edycja tytułu: {Tytuł}";
        public string TytułOknaUsuwania => $"Usuwanie tytułu: {Tytuł}";
        public override string ToString() => $"{Tytuł} by {Zespół}, {Gatunek}, Wydany w {RokWydania.Year}";
        public static IEnumerable<Gatunek> Gatunki => Enum.GetValues(typeof(Gatunek)) as IEnumerable<Gatunek>;

    }

    public class ListaUtworów
    {
        public List<Utwór> Utwory { get; set; } = new List<Utwór>();
    }
}
