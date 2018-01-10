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
    /// Interaction logic for Izmena.xaml
    /// </summary>
    public partial class Izmena : Window
    {
       
        private Namestaj namestaj;
        public Izmena(Namestaj namestaj)
        {
            this.namestaj = (Namestaj)namestaj.Clone();
            InitializeComponent();

            foreach (TipNamestaja tip in ListePodataka.Instance.listaTipovaNamestaja)
            {
                cbIdtip.Items.Add(tip.ID);
            }
            cbIdtip.SelectedIndex = 0;

            tbNaziv.Text = namestaj.Naziv;
            tbSifra.Text = namestaj.Sifra;
            tbCena.Text = namestaj.Cena.ToString();
            tbKolicina.Text = namestaj.KolicinaUMagacinu.ToString();
            cbIdtip.SelectedItem = namestaj.IdTipaNamestaja.ToString();


            
            
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;

            foreach (Namestaj namestajIzmena in ListePodataka.Instance.listaNamestaja) {

                if (namestajIzmena.Id == namestaj.Id)
                {
                    namestajIzmena.Naziv = tbNaziv.Text;
                    namestajIzmena.Sifra = tbSifra.Text;
                    namestajIzmena.Cena = Convert.ToDouble(tbCena.Text);
                    namestajIzmena.KolicinaUMagacinu = Convert.ToInt32(tbKolicina.Text);
                    namestajIzmena.IdTipaNamestaja = Convert.ToInt32(cbIdtip.SelectedItem.ToString());

                    BazaNamestaj.NamestajIzmeni(namestajIzmena);
                }

            }
            this.Close(); 

     

        }
    }
}
