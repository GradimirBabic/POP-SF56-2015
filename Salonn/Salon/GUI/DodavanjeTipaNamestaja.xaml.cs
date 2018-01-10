using Salon.BazaPodataka;
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
    /// Interaction logic for Dodavanje.xaml
    /// </summary>
    public partial class DodavanjeTipaNamestaja : Window
    {
        public DodavanjeTipaNamestaja()
        {
            InitializeComponent();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = ListePodataka.Instance.noviIdTipNamestaja();
            bool obrisan = false;
            string naziv = tbNaziv.Text;

            ListePodataka.Instance.listaTipovaNamestaja.Add(new TipNamestaja(id, naziv, obrisan));

            BazaTipNamestaja.TipNamestajaDodaj(new TipNamestaja(id, naziv, obrisan));

            this.Close();
            
        }

        private void tbNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
