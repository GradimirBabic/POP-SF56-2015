using System;
using sf56_2015.Tests;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sf56_2015.model;

namespace sf56_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Salon();
            s1.Naziv = "Salon1";

            Console.WriteLine("dobrodosli u salon" + s1.naziv);

            Console.WriteLine("dobrodosli u salon" + s1.naziv);
            Console.WriteLine("1. izlistaj namestaj");
        }
    }
}
