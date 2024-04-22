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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpravceUkolu spravceUkolu;

        public MainWindow()
        {
            InitializeComponent();
            spravceUkolu = new SpravceUkolu(); // Inicializace správce úkolů
            lstUkoly.ItemsSource = spravceUkolu.Ukoly; // Nastavení zdroje pro ListBox
        }

        private void BtnPridatUkol_Click(object sender, RoutedEventArgs e)
        {
            string nazevUkolu = txtNovyUkol.Text;
            spravceUkolu.PridatUkol(nazevUkolu); // Přidání nového úkolu pomocí správce úkolů
            txtNovyUkol.Text = ""; // Vymaž textové pole po přidání úkolu
        }

        private void BtnOznacitHotovo_Click(object sender, RoutedEventArgs e)
        {
            Ukol vybranyUkol = lstUkoly.SelectedItem as Ukol;
            if (vybranyUkol != null)
            {
                spravceUkolu.OznacitUkolHotovo(vybranyUkol); // Označení úkolu jako hotového pomocí správce úkolů
                AktualizovatSeznamUkolu();
            }
            else
            {
                MessageBox.Show("Vyberte úkol, který chcete označit jako hotový.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnOdstranitUkol_Click(object sender, RoutedEventArgs e)
        {
            Ukol vybranyUkol = lstUkoly.SelectedItem as Ukol;
            if (vybranyUkol != null)
            {
                spravceUkolu.OdstranitUkol(vybranyUkol); // Odstranění úkolu pomocí správce úkolů
                AktualizovatSeznamUkolu();
            }
            else
            {
                MessageBox.Show("Vyberte úkol, který chcete odstranit.", "Upozornění", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AktualizovatSeznamUkolu()
        {
            // Projdeme všechny položky v ListBoxu
            foreach (var item in lstUkoly.Items)
            {
                // Získáme ListBoxItem z položky
                var listBoxItem = lstUkoly.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (listBoxItem != null)
                {
                    // Ručně aktualizujeme styl podle hodnoty JeHotovo
                    var u = item as Ukol;
                    if (u != null && u.JeHotovo)
                    {
                        listBoxItem.Background = Brushes.LightGreen;
                    }
                    else
                    {
                        listBoxItem.Background = Brushes.Transparent;
                    }
                }
            }
        }

    }
}
