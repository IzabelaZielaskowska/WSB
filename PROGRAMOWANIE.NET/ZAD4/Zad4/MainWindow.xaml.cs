using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;

namespace Zad4
{
    public partial class MainWindow : Window
    {
        private XDocument xmlDoc;

        public MainWindow()
        {
            InitializeComponent();
            WczytajDaneXml();
        }

        private void WczytajDaneXml()
        {
            try
            {
                xmlDoc = XDocument.Load("produkty.xml");

                drzewoKategorii.Items.Clear();

                foreach (var category in xmlDoc.Root.Elements("kategoria"))
                {
                    KategoriaNode kategoriaNode = new KategoriaNode
                    {
                        Nazwa = category.Attribute("nazwa").Value,
                        Opis = category.Attribute("opis").Value
                    };

                    foreach (var podkategoria in category.Elements("podkategoria"))
                    {
                        PodkategoriaNode podkategoriaNode = new PodkategoriaNode
                        {
                            Nazwa = podkategoria.Attribute("nazwa").Value,
                            Opis = podkategoria.Attribute("opis").Value
                        };

                        foreach (var element in podkategoria.Element("szczegoly").Elements("produkt"))
                        {
                            ProduktNode produktNode = new ProduktNode
                            {
                                Nazwa = element.Attribute("nazwa").Value,
                                Cena = element.Attribute("cena").Value,
                                Producent = element.Attribute("producent").Value,
                                Opis = element.Attribute("opis").Value
                            };

                            podkategoriaNode.Produkty.Add(produktNode);
                        }

                        kategoriaNode.Podkategorie.Add(podkategoriaNode);
                    }

                    drzewoKategorii.Items.Add(kategoriaNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wczytywania danych: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void drzewoKategorii_WybieraniePrzedmiotow(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (drzewoKategorii.SelectedItem is PodkategoriaNode wybranaPodkategoria)
            {
                detailsDataGrid.ItemsSource = null;
                detailsDataGrid.Items.Clear();
                detailsDataGrid.ItemsSource = wybranaPodkategoria.Produkty;
            }
            else if (drzewoKategorii.SelectedItem is KategoriaNode wybranaKategoria)
            {
                detailsDataGrid.ItemsSource = null;
                detailsDataGrid.Items.Clear();
                var produkty = new ObservableCollection<ProduktNode>();
                foreach (var podkategoria in wybranaKategoria.Podkategorie)
                {
                    foreach (var produkt in podkategoria.Produkty)
                    {
                        produkty.Add(produkt);
                    }
                }
                detailsDataGrid.ItemsSource = produkty;
            }
            else
            {
                detailsDataGrid.ItemsSource = null;
                detailsDataGrid.Items.Clear();
            }
        }

        private void OtworzSzczegolyButton_Click(object sender, RoutedEventArgs e)
        {
            if (detailsDataGrid.SelectedItem is ProduktNode wybranyProdukt)
            {
                string details = $"Nazwa: {wybranyProdukt.Nazwa}\nCena: {wybranyProdukt.Cena}\nProducent: {wybranyProdukt.Producent}\nOpis: {wybranyProdukt.Opis}";
                SzczegolyWindow szczegolyWindow = new SzczegolyWindow(details);
                szczegolyWindow.ShowDialog();
            }
            else if (drzewoKategorii.SelectedItem is KategoriaNode wybranaKategoria)
            {
                string details = $"Kategoria: {wybranaKategoria.Nazwa}\nOpis: {wybranaKategoria.Opis}";
                SzczegolyWindow szczegolyWindow = new SzczegolyWindow(details);
                szczegolyWindow.ShowDialog();
            }
            else if (drzewoKategorii.SelectedItem is PodkategoriaNode wybranaPodkategoria)
            {
                string details = $"Podkategoria: {wybranaPodkategoria.Nazwa}\nOpis: {wybranaPodkategoria.Opis}";
                SzczegolyWindow szczegolyWindow = new SzczegolyWindow(details);
                szczegolyWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Proszę wybrać produkt, kategorię lub podkategorię z listy.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    public class KategoriaNode
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public ObservableCollection<PodkategoriaNode> Podkategorie { get; set; } = new ObservableCollection<PodkategoriaNode>();
    }

    public class PodkategoriaNode
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public ObservableCollection<ProduktNode> Produkty { get; set; } = new ObservableCollection<ProduktNode>();
    }

    public class ProduktNode
    {
        public string Nazwa { get; set; }
        public string Cena { get; set; }
        public string Producent { get; set; }
        public string Opis { get; set; }
    }
}
