using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Zad3
{
    /// <summary>
    /// Logika interakcji dla klasy OknoPotwierdzeniaUsunięcia.xaml
    /// </summary>
    public partial class OknoPotwierdzeniaUsunięcia : Window
    {
        Utwór Utwór { get; }
        ICollection<Utwór> Utwory { get; }
        public OknoPotwierdzeniaUsunięcia(Utwór usuwana, ICollection<Utwór> osoby)
        {
            DataContext = Utwór = usuwana;
            Utwory = osoby;
            InitializeComponent();
        }

        private void Potwierdź(object sender, RoutedEventArgs e)
        {
            Utwory.Remove(Utwór);
            Close();
        }

        private void Anuluj(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
