using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Model
{
    public class Prodaja : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int iD;
        private int idNamestaja;
        private int kolicina;
        private DateTime datumProdaje;
        private string kupac;
        private string brojRacuna;
        private double ukupnaCena;
        private bool obrisan;

        public Prodaja() { }

        public Prodaja(int iD, int idNamestaja, int kolicina, DateTime datumProdaje, string kupac, string brojRacuna, double ukupnaCena, bool obrisan)
        {
            this.iD = iD;
            this.idNamestaja = idNamestaja;
            this.kolicina = kolicina;
            this.datumProdaje = datumProdaje;
            this.kupac = kupac;
            this.brojRacuna = brojRacuna;
            this.ukupnaCena = ukupnaCena;
            this.obrisan = obrisan;
        }

        public int ID
        {
            get { return iD; }
            set
            {
                iD = value;
                OnPropertyChanged("ID");
            }
        }

        public int IdNamestaja
        {
            get { return idNamestaja; }
            set
            {
                idNamestaja = value;
                OnPropertyChanged("IdNamestaja");
            }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }

        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set
            {
                ukupnaCena = value;
                OnPropertyChanged("UkupnaCena");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; }
        }

       

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
