using Salon.BazaPodataka;
using Salon.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Salon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            ListePodataka.Instance.listaNamestaja.Add(new Namestaj(1, "fotelja", 1, "1", 5999, 15, false));
            ListePodataka.Instance.listaNamestaja.Add(new Namestaj(2, "krevet", 2, "2", 15999, 10, false));
            */

            BazaNamestaj.UcitajNamestaj();

            /*
            ListePodataka.Instance.listaTipovaNamestaja.Add(new TipNamestaja(1, "1233", false));
            ListePodataka.Instance.listaTipovaNamestaja.Add(new TipNamestaja(2, "453256", false));*/

            BazaTipNamestaja.UcitajTipoveNamestaja();

            BazaProdaja.UcitajProdaje();

            ListePodataka.instance.listaKorisnika.Add(new Model.Korisnik(1, "pera", "peric", "1", "1", false, TipKorisnika.Administrator));
            ListePodataka.Instance.listaKorisnika.Add(new Model.Korisnik(2, "marko", "markovic", "2", "2", false, TipKorisnika.Prodavac));



    }

        private void btPrijavaClick(object sender, RoutedEventArgs e)
        {

            foreach (Model.Korisnik korisnik in ListePodataka.instance.listaKorisnika){
                if (korisnik.UserName == tbKorisnickoIme.Text && korisnik.Password == tbSifra.Text)
                {

                    FrmPocetnaStrana frm = new FrmPocetnaStrana(korisnik.TipKor);
                    frm.Show();
                }
            }

            
        }          
    }
}
