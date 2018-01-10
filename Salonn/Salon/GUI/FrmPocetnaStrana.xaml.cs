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
    /// Interaction logic for FrmPocetnaStrana.xaml
    /// </summary>
    public partial class FrmPocetnaStrana : Window
    {
        private string odabirTabele = "Namestaj";

        public FrmPocetnaStrana(TipKorisnika tipKorisnika)
        {

            InitializeComponent();

            if (tipKorisnika == TipKorisnika.Prodavac)
            {
                lbPrikaz.Visibility = Visibility.Hidden;
                cbPrikaz.Visibility = Visibility.Hidden;
                btnDodaj.Visibility = Visibility.Hidden;
                btnIzmeni.Visibility = Visibility.Hidden;
                btnBrisi.Visibility = Visibility.Hidden;

                dataGrid.ItemsSource = ListePodataka.Instance.listaProdaja;
            }
            else
            {
                cbPrikaz.Items.Add("Namestaj");
                cbPrikaz.Items.Add("Tipovi namestaja");

                dataGrid.ItemsSource = ListePodataka.Instance.listaNamestaja;

                btnProdaja.Visibility = Visibility.Hidden;
            }

            
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (cbPrikaz.SelectedItem.ToString() == "Namestaj")
            {
                DodavanjeNamestaja frm = new DodavanjeNamestaja();
                frm.Show();
            }

            if (cbPrikaz.SelectedItem.ToString() == "Tipovi namestaja")
            {
                DodavanjeTipaNamestaja frm = new DodavanjeTipaNamestaja();
                frm.Show();
            }
        }

        private void cbPrikaz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPrikaz.SelectedItem.ToString() == "Namestaj") {
                dataGrid.ItemsSource = ListePodataka.Instance.listaNamestaja;
            }
            if (cbPrikaz.SelectedItem.ToString() == "Tipovi namestaja")
            {
                dataGrid.ItemsSource = ListePodataka.Instance.listaTipovaNamestaja;
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (cbPrikaz.SelectedItem.ToString() == "Namestaj")
            {
                if (dataGrid.SelectedIndex > -1 ) {

                    Namestaj nam = (Namestaj)dataGrid.SelectedItem;
                    Izmena izmena = new Izmena(nam);
                    izmena.Owner = this; //svaka potvrdjena izmena liste u formi za izmenu namestaja bice
                                         //prikazana u ovoj formi
                    izmena.ShowDialog();

                   

                }
            }

            if (cbPrikaz.SelectedItem.ToString() == "Tipovi namestaja")
            {
                if (dataGrid.SelectedIndex > -1)
                {
                    TipNamestaja tip = (TipNamestaja)dataGrid.SelectedItem;
                    IzmenaTipNamestaja izmena = new IzmenaTipNamestaja(tip);
                    izmena.Owner = this;
                    izmena.ShowDialog();
                    
                }
            }
        } 

        private void btnBrisi_Click(object sender, RoutedEventArgs e)
        {
            if (cbPrikaz.SelectedItem.ToString() == "Namestaj")
            {
                if (dataGrid.SelectedIndex > -1)
                {

                    Namestaj nam = (Namestaj)dataGrid.SelectedItem;

                    FrmBrisanje frm = new FrmBrisanje();
                    frm.ShowDialog();

                    if (frm.DialogResult.Value && frm.DialogResult.HasValue)
                    {

                        for (int i = 0; i < ListePodataka.Instance.listaNamestaja.Count; i++)
                        {
                            if (ListePodataka.Instance.listaNamestaja.ElementAt(i).Id == nam.Id)
                            {
                                ListePodataka.Instance.listaNamestaja.ElementAt(i).Obrisan = true;
                                dataGrid.Items.Refresh();

                                BazaNamestaj.NamestajIzbrisi(ListePodataka.Instance.listaNamestaja.ElementAt(i));
                            }
                        }
                    }



                }

            }

            if (cbPrikaz.SelectedItem.ToString() == "Tipovi namestaja")
            {
                if (dataGrid.SelectedIndex > -1)
                {
                    TipNamestaja tip = (TipNamestaja)dataGrid.SelectedItem;

                    FrmBrisanje frm = new FrmBrisanje();
                    frm.ShowDialog();

                    if (frm.DialogResult.Value && frm.DialogResult.HasValue)
                    {
                        for (int i = 0; i < ListePodataka.Instance.listaTipovaNamestaja.Count; i++)
                        {
                            if (ListePodataka.Instance.listaTipovaNamestaja.ElementAt(i).ID == tip.ID)
                            {
                                ListePodataka.Instance.listaTipovaNamestaja.ElementAt(i).Obrisan = true;
                                dataGrid.Items.Refresh();

                                BazaTipNamestaja.TipNamestajaIzbrisi(ListePodataka.Instance.listaTipovaNamestaja.ElementAt(i));
                            }
                        }
                    }
                }

            }
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid.ItemsSource = ListePodataka.Instance.listaProdaja;
            FrmProdaja frm = new FrmProdaja();
            frm.ShowDialog();
        }
    }
}
