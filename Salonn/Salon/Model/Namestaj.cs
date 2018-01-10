using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Salon.Model
{
    public class Namestaj: INotifyPropertyChanged
    {
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
        private int idTipaNamestaja;
        private string sifra;
        private double cena;
        private int kolicinaUMagacinu;
        private bool obrisan;

        public Namestaj() { }

        public Namestaj(int id, string naziv, int idTipaNamestaja, string sifra, double cena, int kolicinaUMagacinu, bool obrisan)
        {
            this.id = id;
            this.naziv = naziv;
            this.idTipaNamestaja = idTipaNamestaja;
            this.sifra = sifra;
            this.cena = cena;
            this.kolicinaUMagacinu = kolicinaUMagacinu;
            this.obrisan = obrisan;
        }

        public object Clone()
        {
            Namestaj kopija = new Namestaj();
            kopija.id = id;
            kopija.naziv = naziv;
            kopija.idTipaNamestaja = idTipaNamestaja;
            kopija.sifra = sifra;
            kopija.cena = cena;
            kopija.kolicinaUMagacinu = kolicinaUMagacinu;
            kopija.obrisan = obrisan;
            return kopija;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int IdTipaNamestaja
        {
            get
            {
                return idTipaNamestaja;
            }
            set
            {
                idTipaNamestaja = value;
                OnPropertyChanged("IdTipaNamestaja");
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

        public string Sifra
        {
            get
            {
                return sifra;
            }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

       


        public int KolicinaUMagacinu
        {
            get
            {
                return kolicinaUMagacinu;
            }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged(name: "KolicinaUMagacinu");
            }
        }





        public double Cena
        {
            get
            {
                return cena;
            }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
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




    }
}
