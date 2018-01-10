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
    /// Interaction logic for IzmenaTipNamestaja.xaml
    /// </summary>
    public partial class IzmenaTipNamestaja : Window
    {
        private TipNamestaja tipnam;
        public IzmenaTipNamestaja(TipNamestaja tipnam)
        {
            this.tipnam = tipnam;
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (TipNamestaja tipnamIzmena in ListePodataka.Instance.listaTipovaNamestaja)
            {
                if (tipnamIzmena.ID == tipnam.ID)
                {
                    tipnamIzmena.Naziv = tbNaziv.Text;

                    BazaTipNamestaja.TipNamestajaIzmeni(tipnamIzmena);


                }
            }

            this.Close();
        }

        private void cbObrisan_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tbNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
