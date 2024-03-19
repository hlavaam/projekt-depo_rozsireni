using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace projekt
{
    internal class Depo
    {

 
       
        Dictionary<string, Vozidlo> vozidla = new Dictionary<string, Vozidlo>();
        private LinkedList<Vozidlo>vlaky = new LinkedList<Vozidlo>();
       // vozidlos.AddFirst(new Lokomotiva("",8,"", Palivo.Nafta));

        public int CisloLokomotivy(string cisla)
        {

            

            int[] cislice = cisla.Select(c => int.Parse(c.ToString())).ToArray();
            int soucet = 0;

            for (int i = 5; i < cislice.Length; i++)
            {
                int aktualniCislice = cislice[i];

                if ((i - 5) % 2 == 0)
                {
                    soucet += aktualniCislice;
                }
                else
                {
                    int vynasobenaCislice = 2 * aktualniCislice;
                    soucet += vynasobenaCislice > 9 ? (vynasobenaCislice % 10 + vynasobenaCislice / 10) : vynasobenaCislice;
                }
            }
 
            int kontrolniCislice = (soucet % 10 == 0) ? 0 : (10 - soucet % 10);
            return kontrolniCislice;
        }

        public int CisloVozu(string cisla)
        {
            int[] cislice = cisla.Select(c => int.Parse(c.ToString())).ToArray();
            int soucet = 0;

            for (int i = 0; i < cislice.Length; i++)
            {
                int aktualniCislice = cislice[i];

                if (i % 2 == 1) 
                {
                    int vynasobenaCislice = 2 * aktualniCislice;
                    soucet += (vynasobenaCislice > 9) ? (vynasobenaCislice % 10 + vynasobenaCislice / 10) : vynasobenaCislice;
                }
                else
                {
                    soucet += aktualniCislice; 
                }
            }

            int kontrolniCislice = (soucet % 10 == 0) ? 0 : (10 - soucet % 10);
            return kontrolniCislice;

        }

        public bool RegistracniCisloOvereni(string input)
        {

            int digitCount = 0;


            if (input.Length != 11)
                {
                return false;
                }

       
            foreach (char c in input)
            {
            
                if (int.TryParse(c.ToString(), out int result))
                {
                    digitCount++; 
                }
                else
                {
                    return false; 
                }
            }

            if (digitCount == 11)
            {
                return true;
            }else 
            {
                return false;
            }
            
            
         }


        public bool RegistracniDuplicita(string input)
        {
            if (vozidla.ContainsKey(input))
            {
                return false;
            }else
            {
                return true;
            }
        }
        public bool PalivoOvereni(string palivo)
        {
            if (palivo == "Nafta" || palivo == "Elektrika" || palivo == "Uhlí")
            {
                return true;
            }else
            {
                return false;
            }
        }
     

        public void PridatLokomotivu(string registracniCislo, Lokomotiva lokomotiva)
        {
           
            vozidla.Add(registracniCislo, lokomotiva);


        }


        public void PridatVagon(string registracniCislo, int kontorlniCislo, string barva, int delka, int Maxrychlost, int PocetSedadel, bool pridano)
        {
            OsobniVuz novyvuz = new OsobniVuz(registracniCislo, kontorlniCislo, PocetSedadel, pridano);
            novyvuz.Barva = barva;
            
            novyvuz.Delka = delka;
            novyvuz.MaxRychlost = Maxrychlost;
            vozidla.Add(registracniCislo, novyvuz);
        }

        public void PridatNAKVagon(string registracniCislo, int kontorlniCislo, string nazev, string barva, int delka, int Maxrychlost, string typ, int nosnost, bool pridano)
        {
            NakladniVuz novyvuznak = new NakladniVuz(registracniCislo, kontorlniCislo, typ, nosnost, pridano);
            novyvuznak.Barva = barva;
            novyvuznak.Delka = delka;
            novyvuznak.MaxRychlost = Maxrychlost;
            vozidla.Add(registracniCislo, novyvuznak);
        }
        public Dictionary<string, Vozidlo> seznamVozidel()
        {
            return new Dictionary<string, Vozidlo>(vozidla);
        }

   


        public bool delete(string key)
        {
            if (vozidla.ContainsKey(key))
            {
                vozidla.Remove(key);
                return true; 
            }
            else
            {
                return false; 
            }
        }
        

 
    }
}

