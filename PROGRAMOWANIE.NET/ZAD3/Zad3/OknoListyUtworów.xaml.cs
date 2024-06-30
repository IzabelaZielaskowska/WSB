using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Zad3
{
    /// <summary>
    /// Logika interakcji dla klasy OknoListyUtworów.xaml
    /// </summary>
    public partial class OknoListyUtworów : Window
    {
        ICollection<Utwór> Utwory { get; } = new ObservableCollection<Utwór>();
        public OknoListyUtworów()
        {
            Importuj(this, new());
            DataContext = Utwory;
            InitializeComponent();
        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            Utwór edytowana = ListaOsób.SelectedItem as Utwór;
            if (edytowana != null)
                new OknoEdycjiUtworu(edytowana).Show();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Utwór nowa = new Utwór();
            Utwory.Add(nowa);
            new OknoEdycjiUtworu(nowa).Show();
        }

        private void Usuń(object sender, RoutedEventArgs e)
        {
            Utwór usuwana = ListaOsób.SelectedItem as Utwór;
            if (usuwana != null)
                new OknoPotwierdzeniaUsunięcia(usuwana, Utwory).Show();
        }

        private void Eksportuj(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Utwór>));
            TextWriter kanałZapisu = new StreamWriter("utwory.xml");
            serializator.Serialize(kanałZapisu, Utwory);
            kanałZapisu.Close();
        }

        private void Importuj(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(Collection<Utwór>));
            try
            {
                FileStream kanałOdczytu = new FileStream("utwory.xml", FileMode.Open);
                IEnumerable<Utwór> osoby = serializator.Deserialize(kanałOdczytu) as Collection<Utwór>;
                Utwory.Clear();
                foreach (Utwór osoba in osoby)
                    Utwory.Add(osoba);
                kanałOdczytu.Close();
            }
            catch (FileNotFoundException ex) { }
        }
    }
}
