using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTEKA
{
    internal class Ksiazka
    {
        public string opcja1 = "Fantastyka";
        public string ksiazka1 = "Wiedńmin";
        public string ksiazka2 = "Harry Potter";

        public string opcja2 = "Thriller";
        public string ksiazka3 = "Kasztanowy Ludzik";
        public string ksiazka4 = "Millennium";

        public string opcja3 = "Poezja";
        public string ksiazka5 = "Romeo i Julia";
        public string ksiazka6 = "Jej kwiaty";


        public string wybor(string gatunek, string tytul)
        {
            if (gatunek == "1")
            {
                if (tytul == "1")
                {
                    return "\nGatunek: " + opcja1 + "\nTytuł: " + ksiazka1;

                }
                if (tytul == "2")
                {
                    return "\nGatunek: " + opcja1 + "\nTytuł: " + ksiazka2;
                }
                else
                {
                    return " Nie istnieje";
                }
            }

            if (gatunek == "2")
            {
                if (tytul == "1")
                {
                    return "\nGatunek: " + opcja2 + "\nTytuł: " + ksiazka3;
                }
                if (tytul == "2")
                {
                    return "\nGatunek: " + opcja2 + "\nTytuł: " + ksiazka4;
                }
                else
                {
                    return " Nie istnieje";

                }
            }

            if (gatunek == "3")
            {
                if (tytul == "1")
                {
                    return "\nGatunek: " + opcja3 + "\nTytuł: " + ksiazka5;
                }
                if (tytul == "2")
                {
                    return "\nGatunek: " + opcja3 + "\nTytuł: " + ksiazka6;
                }
                else
                {
                    return " Nie istnieje";
                }
            }

            else
            {
                return "Nie ma takiego gatunku";
            }
        }
    }
}
