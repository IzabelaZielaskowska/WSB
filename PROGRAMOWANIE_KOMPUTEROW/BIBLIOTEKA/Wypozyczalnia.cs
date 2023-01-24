using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTEKA
{
    internal class Wypozyczalnia
    {
        public void Wypozyczenie()
        {

            // Dane wypożyczającego
            Osoba Wypozyczajacy = new Osoba();
            Console.Write("Podaj imię:");
            Wypozyczajacy.Imie = Console.ReadLine();
            Console.Write("Podaj nazwisko:");
            Wypozyczajacy.Nazwisko = Console.ReadLine();
            Console.Write("Podaj numer karty bibliotecznej:");
            Wypozyczajacy.NumerKarty = Console.ReadLine();
            Console.Clear();

            // Wybór książki
            Ksiazka ksiazka = new Ksiazka();
            Console.WriteLine("Wybierz gatunek książki");
            Console.WriteLine("1 - Fantastyka");
            Console.WriteLine("2 - Thriller");
            Console.WriteLine("3 - Poezja");
            string gatunek = Console.ReadLine();
            Console.Clear();

            if (gatunek == "1")
            {
                Console.WriteLine("Wybierz tytuł");
                Console.WriteLine("1 - Wiedźmin");
                Console.WriteLine("2 - Harry Potter");
            }
            else if (gatunek == "2")
            {
                Console.WriteLine("Wybierz tytuł");
                Console.WriteLine("1 - Kasztanowy Ludzik");
                Console.WriteLine("2 - Millennium");
            }
            else if (gatunek == "3")
            {
                Console.WriteLine("Wybierz tytuł");
                Console.WriteLine("1 - Romeo i Julia");
                Console.WriteLine("2 - Jej kwiaty");
            }
            else 
            {
                Console.WriteLine("Nie ma takiego gatunku");
                Console.WriteLine("Wyjście z programu");
                Console.ReadKey();
                return;
            }

            string tytul = Console.ReadLine();
            Console.Clear();

            string wybranaksiazka = ksiazka.wybor(gatunek, tytul);

            Console.WriteLine("Imie:" + Wypozyczajacy.Imie);
            Console.WriteLine("Nazwisko:" + Wypozyczajacy.Nazwisko);
            Console.WriteLine("Wiek:" + Wypozyczajacy.NumerKarty);
            Console.WriteLine("Wybrana książka:" + wybranaksiazka); 

            Console.ReadKey();
        }
    }
}
