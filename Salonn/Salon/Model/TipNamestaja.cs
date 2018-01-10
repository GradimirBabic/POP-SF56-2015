using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Model
{
    public class TipNamestaja:INotifyPropertyChanged
    {
        /*
        private void dodajUListu() {

            ListePodataka l1 = new ListePodataka();
            l1.tipoviNametsaja.Add(new TipNamestaja(1, true, "1233"));
            l1.tipoviNametsaja.Add(new TipNamestaja(2, true, "432"));

            foreach (TipNamestaja tn in l1.tipoviNametsaja) {
                Console.WriteLine(tn.id + " " + tn.obrisan + " " + tn.naziv);//prikazace 2 elementa
            }

            ListePodataka l2 = new ListePodataka();
            foreach (TipNamestaja tn in l2.tipoviNametsaja)
            {
                Console.WriteLine(tn.id + " " + tn.obrisan + " " + tn.naziv);//nece nista prikazati
            }

        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private int id;
        
        private string naziv;
        private bool obrisan;

        public TipNamestaja() { }

        public TipNamestaja(int id, string naziv, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.obrisan = obrisan;
        }


        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public bool Obrisan
        {
            get
            {
                return obrisan;
            }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }
        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

       
    }
}
