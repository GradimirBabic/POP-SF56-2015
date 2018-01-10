using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Model
{
    public class ListePodataka
    {
        public static ListePodataka instance;
        public static ListePodataka Instance {
            get {
                if (instance == null)
                    instance = new ListePodataka();
                return instance;
            }
        }
        private ListePodataka() { }

        public ObservableCollection<TipNamestaja> listaTipovaNamestaja = new ObservableCollection<TipNamestaja>();
        public ObservableCollection<Namestaj> listaNamestaja = new ObservableCollection<Namestaj>();
        public ObservableCollection<Korisnik> listaKorisnika = new ObservableCollection<Korisnik>();
        public ObservableCollection<Prodaja> listaProdaja = new ObservableCollection<Prodaja>();

        public int noviIdTipNamestaja() {

            int max = 0;
            if (listaTipovaNamestaja.Count > 0)
            {
                foreach (TipNamestaja tn in listaTipovaNamestaja)
                {
                    if (tn.ID > max)
                    {
                        max = tn.ID;
                    }
                }
            }

            return max + 1;

        }

        public int noviIdNamestaja()
        {

            int max = 0;
            if (listaNamestaja.Count > 0)
            {
                foreach (Namestaj namestaj in listaNamestaja)
                {
                    if (namestaj.Id > max)
                    {
                        max = namestaj.Id;
                    }
                }
            }

            return max + 1;

        }

        public int noviIdProdaje()
        {

            int max = 0;
            if (listaProdaja.Count > 0)
            {
                foreach (Prodaja prodaja in listaProdaja)
                {
                    if (prodaja.ID > max)
                    {
                        max = prodaja.ID;
                    }
                }
            }

            return max + 1;

        }

        /*
        TipNamestaja tn = new TipNamestaja(1, false, "namestaj1");
        TipNamestaja tn2 = new TipNamestaja(2, true, "namestaj2");*/

    }
}
