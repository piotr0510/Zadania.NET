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

namespace NET_INIS4_PR2._2_z4
{
    /// <summary>
    /// Logika interakcji dla klasy Szczegóły.xaml
    /// </summary>
    public partial class Szczegóły : Window
    {
        Osoba osoba;
        public Szczegóły(Osoba osoba)
        {
            this.osoba = osoba;
            DataContext = osoba;
            InitializeComponent();
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
