using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Salon.Model
{
    public enum TipKorisnika { Administrator, Prodavac };

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        private int id;
        private String ime;
        private String prezime;
        private String userName;
        private String password;
        private Boolean obrisan;
        private TipKorisnika tipKorisnika;

        public Korisnik(int id, string ime, string prezime, string userName, string password, bool obrisan, TipKorisnika tipKorisnika)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.userName = userName;
            this.password = password;
            this.obrisan = obrisan;
            this.tipKorisnika = tipKorisnika;
        }

        public Korisnik() { }


        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public String Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public String Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public String UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public Boolean Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public TipKorisnika TipKor
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKor");
            }
        }

        public object Clone()
        {
            return new Korisnik()
            {
                id = ID,
                ime = Ime,
                prezime = Prezime,
                userName = UserName,
                password = Password,
                obrisan = Obrisan,
                tipKorisnika = TipKor
            };
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
