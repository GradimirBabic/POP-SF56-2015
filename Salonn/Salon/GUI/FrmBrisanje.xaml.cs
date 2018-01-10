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
    /// Interaction logic for FrmBrisanje.xaml
    /// </summary>
    public partial class FrmBrisanje : Window
    {
        public FrmBrisanje()
        {
            InitializeComponent();
        }

        private void btNE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btDA_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
