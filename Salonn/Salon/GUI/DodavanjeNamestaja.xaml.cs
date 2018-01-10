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
    /// Interaction logic for DodavanjeNamestaja.xaml
    /// </summary>
    public partial class DodavanjeNamestaja : Window
    {
        public DodavanjeNamestaja()
        {
            InitializeComponent();

            foreach (TipNamestaja tip in ListePodataka.Instance.listaTipovaNamestaja) {
                komboIdTipaNamestaja.Items.Add(tip.ID);
            }
            komboIdTipaNamestaja.SelectedIndex = 0;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            int id=ListePodataka.Instance.noviIdNamestaja();
            string naziv=txtNaziv.Text.Trim();
            int idTipaNamestaja=Convert.ToInt32(komboIdTipaNamestaja.SelectedItem.ToString());
            string sifra= txtSifra.Text.Trim();
            double cena = Convert.ToDouble(txtCena.Text.Trim());
            int kolicinaUMagacinu = Convert.ToInt32(txtKolicina.Text.Trim());
            bool obrisan=false;

            Namestaj noviNamestaj = new Namestaj(id, naziv, idTipaNamestaja, sifra, cena, kolicinaUMagacinu, obrisan);
            ListePodataka.Instance.listaNamestaja.Add(noviNamestaj);

            BazaNamestaj.NamestajDodaj(noviNamestaj);

            this.Close();
    }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtSifra_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
