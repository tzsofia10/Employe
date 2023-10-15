using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Dolgozok
    {
        //name, age, city, department, position, gender, marital status, salary (EUR)
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public string Varos { get; set; }
        public string Osztaly { get; set; }
        public string Pozicio { get; set; }
        public string Nem { get; set; }
        public string CsaladiAllapot { get; set; }
        public double Fizetes { get; set; }


        public Dolgozok(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Eletkor = int.Parse(v[1]);
            Varos = v[2];
            Osztaly = v[3];
            Pozicio = v[4];
            Nem = v[5];
            CsaladiAllapot = v[6];
            Fizetes = Convert.ToDouble(v[7]);
        }

        public double EvesFizetesForintban()
        {
            return Fizetes * 12 * 390;
        }

        //Készíts egy osztályon belüli virtuális metódust az adatok kiírására.
        public override string ToString()
        {
            return $"{Nev}; {Eletkor}; {Varos}; {Osztaly}; {Pozicio}; {Nem}; {CsaladiAllapot}; {Fizetes}";
        }
    }
}
