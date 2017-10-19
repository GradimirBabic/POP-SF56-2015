using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sf56_2015.model
{
    class AkcijskaProdaja
    {
        public int Id { get;set;}
        public DateTime DatumPocetka { get; set; }

        public DateTime DatumZavrsetka { get; set; }

        public double ProcenatPopusta { get; set; }
        public bool Obrisan { get; set; }
    }
}
