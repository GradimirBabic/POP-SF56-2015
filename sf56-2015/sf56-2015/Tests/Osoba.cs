using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf56_2015.Tests
{
    class Osoba
    {
        private string ime;

        public string GetIme()
        {
            return this.ime;
        }
        public void SetIme(string ime)
        {
            this.ime = ime;
        }

        public string Ime { get; set; }

    }
}
