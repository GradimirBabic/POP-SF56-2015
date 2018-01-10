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
    /// Interaction logic for FrmProdaja.xaml
    /// </summary>
    public partial class FrmProdaja : Window
    {
        private List<int> listaIdKupljenihNamestaja = new List<int>();
        private List<int> listaKolicinaNamestaja = new List<int>();
        private List<double> listaUkupnihCena = new List<double>();
        public FrmProdaja()
        {
            InitializeComponent();

            if (ListePodataka.Instance.listaNamestaja.Count > 0)
            {
                foreach (Namestaj namestaj in ListePodataka.Instance.listaNamestaja)
                {
                    cbNamestajiId.Items.Add(namestaj.Id);
                }
                lblNazivOdabranogNamestaja.Content = "Naziv: " + ListePodataka.Instance.listaNamestaja.ElementAt(0).Naziv;
            }
        }

        private void cbNamestajiId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Namestaj namestaj in ListePodataka.Instance.listaNamestaja)
            {
                if (namestaj.Id == Convert.ToInt32(cbNamestajiId.SelectedItem.ToString())) {
                    lblNazivOdabranogNamestaja.Content = "Naziv: " + namestaj.Naziv;
                }
            }
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            int kolicina = Convert.ToInt32(tbKolicina.Text);
            bool dovoljnaKolicina = true;

            foreach (Namestaj namestaj in ListePodataka.Instance.listaNamestaja) {

                if (namestaj.Id == Convert.ToInt32(cbNamestajiId.SelectedItem.ToString()) && namestaj.KolicinaUMagacinu >= kolicina)
                {
                    listaIdKupljenihNamestaja.Add(Convert.ToInt32(cbNamestajiId.SelectedItem.ToString()));
                    listaKolicinaNamestaja.Add(kolicina); //na istim pozicijama za svaku stavku

                    tbListaNamestaja.Text += "Id namestaja: " + cbNamestajiId.SelectedItem.ToString() +
                                            "Kolicina: " + kolicina +
                                            "\n";

                    namestaj.KolicinaUMagacinu -= kolicina;
                }
                if (namestaj.Id == Convert.ToInt32(cbNamestajiId.SelectedItem.ToString()) && namestaj.KolicinaUMagacinu < kolicina)
                    dovoljnaKolicina = false;
            }

            if (!dovoljnaKolicina)
                MessageBox.Show("Nema dovoljno artikala u magacinu");

            

        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEvidencija_Click(object sender, RoutedEventArgs e)
        {
            int iD;
            int idNamestaja;
            int kolicina;
            string kupac = tbKorisnik.Text;
            string brRacuna = tbBrojRacuna.Text;

            Prodaja prodaja;

            for (int i = 0; i < listaIdKupljenihNamestaja.Count; i++) {

                prodaja = new Prodaja();
                //(int iD, int idNamestaja, int kolicina, DateTime datumProdaje, string kupac, string brojRacuna, double ukupnaCena, bool obrisan)

                double cena = 0;
                foreach (Namestaj nam in ListePodataka.Instance.listaNamestaja) {
                    if (nam.Id == listaIdKupljenihNamestaja.ElementAt(i))
                        cena = nam.Cena;
                }

                prodaja.ID = ListePodataka.Instance.noviIdProdaje();
                prodaja.IdNamestaja = listaIdKupljenihNamestaja.ElementAt(i);
                prodaja.DatumProdaje = DateTime.Now;
                prodaja.Kolicina = listaKolicinaNamestaja.ElementAt(i);
                prodaja.Kupac = tbKorisnik.Text;
                prodaja.BrojRacuna = tbBrojRacuna.Text;
                prodaja.UkupnaCena = prodaja.Kolicina * cena;

                listaUkupnihCena.Add(prodaja.UkupnaCena);

                ListePodataka.Instance.listaProdaja.Add(prodaja);

                BazaProdaja.ProdajaDodaj(prodaja);
            }

            double ukupnaCena = 0;
            foreach (double ukupnaCenaPoStavci in listaUkupnihCena) {
                ukupnaCena += ukupnaCenaPoStavci;
            }
            ukupnaCena += Convert.ToDouble(tbDodatneUslugeCena.Text);
            tbUkupnaCena.Text = ukupnaCena.ToString();


            /*
             * 
             *         private int iD;
        private int idNamestaja;
        private int kolicina;

        private DateTime datumProdaje;

        private String kupac;
        private int brojRacuna;
        private int ukupnaCena;
        private Boolean obrisan;
             
             */
        }
    }
}
