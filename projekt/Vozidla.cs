using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace projekt
{
    internal abstract class Vozidlo
    {
        public bool Pridan { get; set; }
        public string Barva { get; set; }
        public int Delka { get; set; }
        public int MaxRychlost { get; set; }
        
        public string RegistracniCislo { get; set; }
        public int KontrolniCislo { get; set; }


        

    }



    enum Palivo
    {
        Nafta,
        Elektrika,
        Uhli,
    }
    internal class Lokomotiva : Vozidlo
    {
        
        public string Nazev { get; set; }
        public Palivo Palivo { get; set; }

        public Lokomotiva(string registracniCislo, int kontrolniCislo, string nazev, Palivo palivo, bool pridana)
        {
            RegistracniCislo = registracniCislo;
            KontrolniCislo = kontrolniCislo;
            Nazev = nazev;
            Palivo = palivo;
            Pridan = pridana;
        }
        

    }

    internal class OsobniVuz : Vozidlo
    {
      
        public int PocetSedadel { get; set;}
        public OsobniVuz(string registracniCislo, int kontrolniCislo, int pocetSedadel, bool pridan)
        {
            RegistracniCislo = registracniCislo;
            KontrolniCislo = kontrolniCislo;
            PocetSedadel = pocetSedadel;
            Pridan = pridan;
        }

    }

    internal class NakladniVuz : Vozidlo
    {
      
        public string Typ { get; set; }
        public int Nosnost {  get; set; }
        public NakladniVuz(string registracniCislo, int kontrolniCislo, string typ, int nosnost, bool pridan)
        {
            RegistracniCislo = registracniCislo;
            KontrolniCislo = kontrolniCislo;
            Nosnost = nosnost;
            Typ = typ;
            Pridan = pridan;
        }

    }

    internal class Vlak :IEnumerable<Vozidlo>
    {
        public string Jmeno { get; set; }
        private LinkedList<Vozidlo> vozidla;

        public Vlak(string jmeno)
        {
            Jmeno = jmeno;
            vozidla = new LinkedList<Vozidlo>();
        }
        public void PridejVagon(Vozidlo vozidlo)
        {
            vozidla.AddLast(vozidlo);
        }
        public void PridejLokomotivu (Lokomotiva vozidlo)
        {
            vozidla.AddFirst(vozidlo);
        }

        public IEnumerator<Vozidlo> GetEnumerator()
        {
            return vozidla.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
