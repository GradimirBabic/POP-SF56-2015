using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf56_2015.model
{
    class Korisnik

    {
        public enum TipKorisnika
        {
            Administrator,
            Kupac,
        }

        public int Id { get; set; }
        public String Ime { get; set; }

        public String Prezime { get; set; }

        public string Lozinka { get; set; }

        public bool KorisnickoIme { get; set; }

        public string Obrisan { get; set; }
    }
}
