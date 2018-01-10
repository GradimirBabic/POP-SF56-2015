using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Salon.Model
{
    class Akcija : INotifyPropertyChanged,ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private bool Obrisan;
        private int Popust;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        public Boolean obrisan
        {
            get { return Obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("obrisan");
            }
        }

        public int popust
        {
            get { return Popust; }
            set
            {
                Popust = value;
                OnPropertyChanged("popust");
            }
        }

        public object Clone()
        {
            return new Akcija()
            {
                id = ID,
                datumPocetka = DatumPocetka,
                datumZavrsetka = datumZavrsetka,
                obrisan = Obrisan,
                popust = Popust
            };
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }


    }

}
