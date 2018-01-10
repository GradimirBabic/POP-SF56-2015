using Salon.Model;
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

namespace Salon.GUI
{
    /// <summary>
    /// Interaction logic for Korisnik.xaml
    /// </summary>
    public partial class Korisnik : Window
    {
        public Korisnik()
        {
            InitializeComponent();

            cbTipKorisnika.Items.Add(TipKorisnika.Administrator.ToString());
            cbTipKorisnika.Items.Add(TipKorisnika.Prodavac.ToString());
            cbTipKorisnika.SelectedIndex = 0;



        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUloguj_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ClickZatvori(object sender, RoutedEventArgs e)
        {

        }

        private void ClickUnesi(object sender, RoutedEventArgs e)
        {

        }
    }
}
