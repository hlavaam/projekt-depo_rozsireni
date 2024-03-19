using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Schema;

namespace projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {







            Depo depo = new Depo();

            LinkedList<Vlak> vlaky = new LinkedList<Vlak>();
            Dictionary<string, Vozidlo> vozidlaMain = new Dictionary<string, Vozidlo>();

            Console.WriteLine("Vítej v depu, co chceš?");
            int x = 1; // je to pri vypisovani specifikaci


            while (true)
            {

                Console.WriteLine("1. Přidat vozidlo");
                Console.WriteLine("2. Vypsat vozdila");
                Console.WriteLine("3. Odebrat vozidlo");
                Console.WriteLine("4. Vytvořit vlak");
                Console.WriteLine("5. Vypsat soupravy");
                Console.WriteLine("6. Smazat soupravu");


                int volba;
                string input = Console.ReadLine();
                while (!int.TryParse(input, out volba))
                {
                    Console.WriteLine("Nezadal jsi číslo!");
                    Console.Write("znovu: ");
                    input = Console.ReadLine();


                }

                switch (volba)
                {
                    case 0:
                        Console.WriteLine("zatim nic");
                        break;


                    //PŘÍDÁNÍ VOZIDLA
                    case 1:
                        Console.WriteLine("1. Lokomotivu");
                        Console.WriteLine("2. Osoni vuz");
                        Console.WriteLine("3. Nakladni vuz");

                        int volbavozu;
                        input = Console.ReadLine();
                        while (!int.TryParse(input, out volbavozu))
                        {
                            Console.WriteLine("Nezadal jsi číslo!");
                            Console.Write("znovu: ");
                            input = Console.ReadLine();
                            while (!int.TryParse(input, out volbavozu)) ;

                        }

                        switch (volbavozu)
                        {

                            //PŘIDÁNÍ LOKOMOTIVI 
                            case 1:
                                Console.Clear();
                                Console.WriteLine("___LOKOMOTIVA___");

                                //REGISTRACNI CISLO
                                Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                string registracniCislo = Console.ReadLine();
                                bool overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                bool duplicita = depo.RegistracniDuplicita(registracniCislo);
                                while (overeni == false || duplicita == false)
                                {
                                    if (overeni == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco jsi zadal špatně!");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                    else
                                    {
                                        // Kontrola duplicity registrčního čísla
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vozidlo s tímto registračním číslem již existuje. Zadejte nové registrační číslo.");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                    duplicita = depo.RegistracniDuplicita(registracniCislo);
                                }
                                //KONTRLNI CISLO
                                int kontrolniCislo = depo.CisloLokomotivy(Convert.ToString(registracniCislo));
                                Console.WriteLine("Kontrolní číslice je " + kontrolniCislo);




                                //NAZEV
                                Console.Write("Zadejte název lokomotivy: ");
                                string nazev = Console.ReadLine();

                                Palivo palivoEnum;
                                //PALIVO
                                Console.Write("Zadejte na jaké palivo jezdí (Nafta, Elektrika, Uhlí): ");
                                string palivo = Console.ReadLine();
                                int palivoint;
                                while (int.TryParse(palivo, out palivoint))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Něco jsi zadal špatně!");
                                    Console.Write("Zadejte na jaké palivo jezdí (Nafta, Elektrika, Uhli): ");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    palivo = Console.ReadLine();
                                    overeni = Enum.TryParse<Palivo>(palivo, out palivoEnum);

                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                               
                                overeni = Enum.TryParse<Palivo>(palivo, out palivoEnum);
                                

                                while (overeni == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Něco jsi zadal špatně!");
                                    Console.Write("Zadejte na jaké palivo jezdí (Nafta, Elektrika, Uhli): ");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    palivo = Console.ReadLine();
                                    overeni = Enum.TryParse<Palivo>(palivo, out palivoEnum);

                                    Console.ForegroundColor = ConsoleColor.White;
                                }


                                Console.Write("Zadejte barvu: ");
                                string barva = Console.ReadLine();


                                Console.Write("Zadejte delku: ");
                                input = Console.ReadLine();
                                int delka;
                                while (!int.TryParse(input, out delka))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }


                                Console.Write("Zadejte maximalni rychlost v hodine (KM/H): ");
                                input = Console.ReadLine();
                                int Maxrychlost;
                                while (!int.TryParse(input, out Maxrychlost))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                bool pridana = false;
                                Lokomotiva nova = new Lokomotiva(registracniCislo, kontrolniCislo, nazev, palivoEnum, pridana);
                                nova.Barva = barva;
                                nova.Delka
                                    = delka;
                                nova.MaxRychlost = Maxrychlost;
                                depo.PridatLokomotivu(registracniCislo, nova);
                                Console.WriteLine("Lokomotiva byla přidána.");
                                Console.Clear();
                                break;

                            //PŘIDÁNÍ OSOBNÍHO VAGONU
                            case 2:
                                Console.Clear();
                                Console.WriteLine("___OSOBNI VUZ___");


                                //REGISTRACNI CISLO
                                Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                registracniCislo = Console.ReadLine();
                                overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                duplicita = depo.RegistracniDuplicita(registracniCislo);
                                while (overeni == false || duplicita == false)
                                {
                                    if (overeni == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco jsi zadal špatně!");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                    else
                                    {
                                        // Kontrola duplicity registrčního čísla
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vozidlo s tímto registračním číslem již existuje. Zadejte nové registrační číslo.");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                    duplicita = depo.RegistracniDuplicita(registracniCislo);
                                }
                                //KONTRLNI CISLO
                                kontrolniCislo = depo.CisloVozu((Convert.ToString(registracniCislo)));
                                Console.Write("Kontrolní číslice je: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(kontrolniCislo);
                                Console.ForegroundColor = ConsoleColor.White;




                                //BARVA
                                Console.Write("Zadejte barvu: ");
                                barva = Console.ReadLine();

                                //DELKA
                                Console.Write("Zadejte delku (v metrech): ");
                                input = Console.ReadLine();
                                while (!int.TryParse(input, out delka))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                //MAXRYCHLOST
                                Console.Write("Zadejte maximalni rychlost v hodine (KM/H): ");
                                input = Console.ReadLine();

                                while (!int.TryParse(input, out Maxrychlost))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                //POCET SEDADEL
                                Console.Write("Zadejte počet sedadel: ");
                                input = Console.ReadLine();
                                int pocetsedadel;
                                while (!int.TryParse(input, out pocetsedadel))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                bool pridano = false;

                                depo.PridatVagon(registracniCislo, kontrolniCislo, barva, delka, Maxrychlost, pocetsedadel, pridano);
                                Console.WriteLine("Lokomotiva byla přidána.");
                                Console.Clear();
                                break;

                            //PŘIDÁNÍ NÁKLADNÍHO VAGONU
                            case 3:
                                Console.Clear();
                                Console.WriteLine("___NAKLADNI VUZ___");


                                //REGISTRACNI CISLO
                                Console.Write("Zadejte registrační číslo nákladního vozu (11 číslic): ");
                                registracniCislo = Console.ReadLine();
                                overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                duplicita = depo.RegistracniDuplicita(registracniCislo);
                                while (overeni == false || duplicita == false)
                                {
                                    if (overeni == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco jsi zadal špatně!");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                    else
                                    {
                                        // Kontrola duplicity registrčního čísla
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vozidlo s tímto registračním číslem již existuje. Zadejte nové registrační číslo.");
                                        Console.Write("Zadejte registrační číslo lokomotivy (11 číslic): ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        registracniCislo = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    overeni = depo.RegistracniCisloOvereni(registracniCislo);
                                    duplicita = depo.RegistracniDuplicita(registracniCislo);
                                }
                                //KONTRLNI CISLO
                                kontrolniCislo = depo.CisloVozu((Convert.ToString(registracniCislo)));
                                Console.Write("Kontrolní číslice je: ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(kontrolniCislo);
                                Console.ForegroundColor = ConsoleColor.White;

                                //NAZEV
                                Console.Write("Zadejte název vagónu: ");
                                nazev = Console.ReadLine();

                                //BARVA
                                Console.Write("Zadejte barvu: ");
                                barva = Console.ReadLine();

                                //DELKA
                                Console.Write("Zadejte delku (v metrech): ");
                                input = Console.ReadLine();
                                while (!int.TryParse(input, out delka))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                //MAXRYCHLOST
                                Console.Write("Zadejte maximalni rychlost v hodine (KM/H): ");
                                input = Console.ReadLine();

                                while (!int.TryParse(input, out Maxrychlost))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }

                                Console.Write("Zadejte typ nákladního vozu: ");
                                string typ = Console.ReadLine();

                                Console.Write("Zadejte nosnost vozu (KG): ");
                                input = Console.ReadLine();
                                int nosnost;
                                while (!int.TryParse(input, out nosnost))
                                {
                                    Console.WriteLine("Spatně zadáno!");
                                    Console.Write("Znovu:  ");
                                    input = Console.ReadLine();
                                }
                                pridano = false;

                                depo.PridatNAKVagon(registracniCislo, kontrolniCislo, nazev, barva, delka, Maxrychlost, typ, nosnost, pridano);
                                Console.WriteLine("Nákladní vagon byl přidán.");
                                Console.Clear();


                                break;

                        }


                        break;

                    //VYPSANÁNÍ VOZŮ
                    case 2:
                        Console.Clear();
                        Console.WriteLine("_____VYBER SI KTERÉ VOZY CHCEŠ VYPSAT_____");
                        Console.WriteLine("1. Lokomotivy");
                        Console.WriteLine("2. Osoni vuzy");
                        Console.WriteLine("3. Nakladni vuzy");

                        int volbavypsani;
                        input = Console.ReadLine();
                        while (!int.TryParse(input, out volbavypsani))
                        {
                            Console.WriteLine("Nezadal jsi číslo!");
                            Console.Write("znovu: ");
                            input = Console.ReadLine();
                            while (!int.TryParse(input, out volbavypsani)) ;

                        }
                        switch (volbavypsani)
                        {
                            case 1:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();
                                Console.WriteLine("-----DEPO-----");

                                int lok = 1;
                                foreach (var pair in vozidlaMain)
                                {
                                    if (pair.Value.GetType() == typeof(Lokomotiva))
                                    {
                                        Console.WriteLine($"{lok}. {((Lokomotiva)pair.Value).Nazev} CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                        lok++;
                                    }
                                }
                                Console.WriteLine("---------------");
                                Console.WriteLine();
                                bool vypsano = false; 
                                int poetopak = 0;

                                while (poetopak < 5)
                                {
                                    Console.Write("_____Zadej číslo Lokomotivy (pro konec zadej 0)_____:   ");

                                    input = Console.ReadLine();
                                    while (!int.TryParse(input, out volbavypsani))
                                    {
                                        Console.WriteLine("Nezadal jsi číslo!");
                                        Console.Write("znovu: ");
                                        input = Console.ReadLine();
                                        while (!int.TryParse(input, out volbavypsani)) ;
                                    }
                                    x = 0;
                                    if (volbavypsani == 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }

                                    foreach (var pair in vozidlaMain)
                                    {
                                       

                                        if (pair.Value.GetType() == typeof(Lokomotiva))
                                        {
                                            x++;
                                            if (x == volbavypsani)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine($"Název: {((Lokomotiva)pair.Value).Nazev}");
                                                Console.WriteLine($"POUŽITO V SOUPRAVĚ: {((Lokomotiva)pair.Value).Pridan}");
                                                Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                Console.WriteLine($"PALIVO: {((Lokomotiva)pair.Value).Palivo} ");
                                                Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                vypsano = true;
                                                poetopak = 0;
                                                break;
                                            }
                                            else if (volbavypsani == 0)
                                            {
                                                Console.Clear();
                                                poetopak = 5;
                                                break;
                                            }
                                            
                                            
                                        }
                                    }
                                    if(vypsano == false)
                                    { 
                                        
                                            poetopak++;

                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Toto číslo nebylo najito!");
                                            Console.WriteLine("Maximální počet opakování " + poetopak + "/5");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        
                                    }
                                }
                                break;




                            case 2:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();
                                Console.WriteLine("-----OSOBNI VOZY-----");

                                int z = 1;
                                foreach (var pair in vozidlaMain)
                                {
                                    if (pair.Value.GetType() == typeof(OsobniVuz))
                                    {
                                        Console.WriteLine($"{z}. CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                        z++;
                                    }
                                }
                                Console.WriteLine("---------------");
                                poetopak = 0;

                                while (poetopak < 5 || volbavypsani > 0)
                                {
                                    Console.Write("_____Zadej číslo Osobního Vozu (pro konec zadej 0)_____:   ");

                                    input = Console.ReadLine();
                                    while (!int.TryParse(input, out volbavypsani))
                                    {
                                        Console.WriteLine("Nezadal jsi číslo!");
                                        Console.Write("znovu: ");
                                        input = Console.ReadLine();
                                        while (!int.TryParse(input, out volbavypsani)) ;
                                    }
                                    x = 0;
                                    if (volbavypsani == 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    vypsano = false;
                                    foreach (var pair in vozidlaMain)
                                    {
                                        

                                        if (pair.Value.GetType() == typeof(OsobniVuz))
                                        {
                                            x++;
                                            if (x == volbavypsani)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine($"POUŽITO V SOUPRAVĚ: {((OsobniVuz)pair.Value).Pridan}");
                                                Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                Console.WriteLine($"POČET SEDADEL: {((OsobniVuz)pair.Value).PocetSedadel} ");
                                                Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                vypsano = true;
                                                poetopak = 0;
                                                break;
                                            }
                                            else if (volbavypsani == 0)
                                            {
                                                Console.Clear();
                                                poetopak = 5;
                                                break;
                                            }
                                            

                                        }
                                        
                                    }
                                    if (vypsano == false)
                                    {

                                        poetopak++;

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Toto číslo nebylo najito!");
                                        Console.WriteLine("Maximální počet opakování " + poetopak + "/5");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                }
                                break;
                            case 3:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();
                                Console.WriteLine("-----NAKLADNI VOZY-----");

                                int i = 1;
                                foreach (var pair in vozidlaMain)
                                {
                                    if (pair.Value.GetType() == typeof(NakladniVuz))
                                    {
                                        Console.WriteLine($"{i}. CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                        i++;
                                    }
                                }
                                Console.WriteLine("---------------");
                                poetopak = 0;

                                while (poetopak < 5 || volbavypsani > 0)
                                {
                                    Console.Write("_____Zadej číslo Nakladního Vozu (pro konec zadej 0)_____:   ");

                                    input = Console.ReadLine();
                                    while (!int.TryParse(input, out volbavypsani))
                                    {
                                        Console.WriteLine("Nezadal jsi číslo!");
                                        Console.Write("znovu: ");
                                        input = Console.ReadLine();
                                        while (!int.TryParse(input, out volbavypsani)) ;
                                    }
                                    x = 0;
                                    if (volbavypsani == 0)
                                    {
                                        Console.Clear();
                                        break;
                                    }
                                    vypsano = false;

                                    foreach (var pair in vozidlaMain)
                                    {
                                       

                                        if (pair.Value.GetType() == typeof(NakladniVuz))
                                        {
                                            x++;
                                            if (x == volbavypsani)
                                            {
                                                
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.WriteLine($"POUŽITO V SOUPRAVĚ: {((NakladniVuz)pair.Value).Pridan}");
                                                Console.WriteLine($"TYP: {((NakladniVuz)pair.Value).Typ}");
                                                Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                Console.WriteLine($"NOSNOST: {((NakladniVuz)pair.Value).Nosnost} ");
                                                Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                vypsano = true;
                                                poetopak = 0;
                                                break;
                                            }
                                            else if (volbavypsani == 0)
                                            {
                                                Console.Clear();
                                                poetopak = 5;
                                                break;
                                            }
                                            

                                        }
                                        

                                    }
                                    if (vypsano == false)
                                    {

                                        poetopak++;

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Toto číslo nebylo najito!");
                                        Console.WriteLine("Maximální počet opakování " + poetopak + "/5");
                                        Console.ForegroundColor = ConsoleColor.White;

                                    }
                                }

                                break;
                        }
                        //ODSTRANĚNÍ  VOZŮ
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("_____VYBER SI TYP VOZU K  ODSTRANĚNÍ_____");
                        Console.WriteLine("1. Lokomotiva");
                        Console.WriteLine("2. Osoni vuz");
                        Console.WriteLine("3. Nakladni vuz");

                        int volbadelete;
                        input = Console.ReadLine();
                        while (!int.TryParse(input, out volbadelete))
                        {
                            Console.WriteLine("Nezadal jsi číslo!");
                            Console.Write("znovu: ");
                            input = Console.ReadLine();
                            while (!int.TryParse(input, out volbadelete)) ;

                        }
                        switch (volbadelete)
                        {
                            //ODSTRANENI LOKOMOTIVY 
                            case 1:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();

                                Console.WriteLine("-----DEPO-----");
                               int i = 0;
                                foreach (var pair in vozidlaMain)
                                {
                                    i++;
                                    if (pair.Value.GetType() == typeof(Lokomotiva))
                                    {
                                        Console.WriteLine($"{i}. {((Lokomotiva)pair.Value).Nazev} CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                    }
                                }
                                Console.WriteLine("---------------");

                                Console.Write("Zadej číslo (11) lokomotivi:  ");
                                string nazevloko = Console.ReadLine();

                                if (vozidlaMain.TryGetValue(nazevloko, out Vozidlo vozidloToDelete) && vozidloToDelete.GetType() == typeof(Lokomotiva))
                                {
                                    bool del = depo.delete(nazevloko);
                                    if (del)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Úspěšně smazáno!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco se pokazilo");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Tento název neexistuje nebo není lokomotivou!");
                                }
                                break;


                            //ODSTRANENI OSOBNI VUZ 
                            case 2:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();
                                Console.WriteLine("-----DEPO-----");
                                i = 0;
                                foreach (var pair in vozidlaMain)
                                {
                                    i++;
                                    if (pair.Value.GetType() == typeof(OsobniVuz))
                                    {
                                        Console.WriteLine($"{i}.  CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                    }
                                }

                                Console.WriteLine("---------------");

                                Console.Write("Zadej 11 cisel vozu:  ");
                                string nazevoso = Console.ReadLine();

                                if (vozidlaMain.TryGetValue(nazevoso, out Vozidlo vozidloToDeleteOs) && vozidloToDeleteOs.GetType() == typeof(OsobniVuz))
                                {
                                    bool del = depo.delete(nazevoso);
                                    if (del)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Úspěšně smazáno!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco se pokazilo");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Toto registrační číslo neexistuje nebo není osobním vozem!");
                                }
                                break;
                            //ODSTRANĚNÍ NÁKLADNÍ VUZ
                            case 3:
                                Console.Clear();
                                vozidlaMain = depo.seznamVozidel();
                                Console.WriteLine("-----DEPO-----");
                                i = 0;
                                foreach (var pair in vozidlaMain)
                                {
                                    if (pair.Value.GetType() == typeof(NakladniVuz))
                                    {
                                        Console.WriteLine($"{i}.  CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                    }
                                }

                                Console.WriteLine("---------------");

                                Console.Write("Zadej 11 cisel vozu:  ");
                                string nazevnak = Console.ReadLine();

                                if (vozidlaMain.TryGetValue(nazevnak, out Vozidlo vozidloToDeleteNak) && vozidloToDeleteNak.GetType() == typeof(NakladniVuz))
                                {
                                    bool del = depo.delete(nazevnak);
                                    if (del)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Úspěšně smazáno!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Něco se pokazilo");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Toto registrační číslo neexistuje nebo není nákladním vozem!");
                                }
                                break;



                        }break;

                        
                    //Tvorba Vlaku 
                    case 4:
                        bool lokomotivapridana= false;
                        int volbaTvor = 5;
                                Console.WriteLine("Vytej v tvorbě vlaku ");
                                Console.WriteLine("\nZadejte jméno soupravy vlaku:");
                                string jmeno = Console.ReadLine();

                                Vlak novaSouprava = new Vlak(jmeno);
                        
                                while (volbaTvor != 0 && lokomotivapridana != true )
                                {
                                    Console.WriteLine("Co chcete udělat?");
                                    Console.WriteLine("1. Přidat vagon");
                            Console.WriteLine("2. Uložit soupravu");
                            Console.WriteLine("0. Ukončit tvorbu souprav");


                                    input = Console.ReadLine();
                                    while (!int.TryParse(input, out volbaTvor))
                                    {
                                        Console.WriteLine("Nezadal jsi číslo!");
                                        Console.Write("znovu: ");
                                        input = Console.ReadLine();
                                        while (!int.TryParse(input, out volbaTvor)) ;

                                    }
                                    switch (volbaTvor)
                                    {
                                        case 1:

                                            Console.Clear();
                                                Console.WriteLine("_____VYBER SI KTERÝ VŮZ CHCEŠ PŘIDAD_____");
                                            Console.WriteLine("1. Lokomotivy");
                                            Console.WriteLine("2. Osoni vuzy");
                                            Console.WriteLine("3. Nakladni vuzy");


                                            input = Console.ReadLine();
                                            while (!int.TryParse(input, out volbavypsani))
                                            {
                                                Console.WriteLine("Nezadal jsi číslo!");
                                                Console.Write("znovu: ");
                                                input = Console.ReadLine();
                                                while (!int.TryParse(input, out volbavypsani)) ;

                                            }
                                            switch (volbavypsani)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    vozidlaMain = depo.seznamVozidel();
                                                    Console.WriteLine("-----DEPO-----");

                                                    int lok = 1;
                                                    foreach (var pair in vozidlaMain)
                                                    {
                                                        if (pair.Value.GetType() == typeof(Lokomotiva))
                                                        {
                                                    if ((((Lokomotiva)pair.Value).Pridan) == false)
                                                    {
                                                        Console.WriteLine($"{lok}. {((Lokomotiva)pair.Value).Nazev} CISLO: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                                        lok++;
                                                    }
                                                        }
                                                    }
                                                    Console.WriteLine("---------------");
                                                    Console.WriteLine();

                                                    int poetopak = 0;

                                            while (poetopak < 5 && lokomotivapridana != true)
                                            {
                                                Console.Write("_____Zadej číslo Lokomotivy (pro konec zadej 0)_____:   ");

                                                input = Console.ReadLine();
                                                while (!int.TryParse(input, out volbavypsani))
                                                {
                                                    Console.WriteLine("Nezadal jsi číslo!");
                                                    Console.Write("znovu: ");
                                                    input = Console.ReadLine();
                                                    while (!int.TryParse(input, out volbavypsani)) ;
                                                }
                                                x = 0;
                                                if (volbavypsani == 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }
                                                bool vypsano = false;
                                                while (vypsano != true)
                                                {
                                                    foreach (var pair in vozidlaMain)
                                                    {


                                                        if (pair.Value.GetType() == typeof(Lokomotiva))
                                                        {
                                                            if ((((Lokomotiva)pair.Value).Pridan) == false) { 
                                                                x++;
                                                            if (x == volbavypsani)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                                Console.WriteLine($"Název: {((Lokomotiva)pair.Value).Nazev}");
                                                                Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                                Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                                Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                                Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                                Console.WriteLine($"PALIVO: {((Lokomotiva)pair.Value).Palivo} ");
                                                                Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                vypsano = true;
                                                                lokomotivapridana = true;

                                                                poetopak = 0;
                                                                    if (vozidlaMain.ContainsKey(pair.Value.RegistracniCislo))
                                                                    {

                                                                        (((Lokomotiva)pair.Value).Pridan) = true;
                                                                    }
                                                                    novaSouprava.PridejLokomotivu((Lokomotiva)pair.Value);
                                                                Console.WriteLine("Lokomotiva byla úspěšně přidaná do vlaku");
                                                                Console.WriteLine("Vlak byl ukončen a uložen!!!!  ");
                                                                break;
                                                            }
                                                            else if (volbavypsani == 0)
                                                            {
                                                                Console.Clear();
                                                                poetopak = 5;
                                                                break;
                                                            }

                                                        }

                                                        }

                                                    }
                                                    break;
                                                }
                                            }
                                            break;



                                        case 2:
                                            Console.Clear();
                                            vozidlaMain = depo.seznamVozidel();
                                            Console.WriteLine("-----DEPO-----");

                                            x = 0;
                                            int OS = 1;

                                            foreach (var pair in vozidlaMain)
                                            {
                                                if (pair.Value.GetType() == typeof(OsobniVuz))
                                                {
                                                    if ((((OsobniVuz)pair.Value).Pridan) == false) { 
                                                        Console.WriteLine($"{OS}.Cislo: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                                    OS++;
                                                }
                                                }
                                            }
                                            Console.WriteLine("---------------");
                                            Console.WriteLine();

                                            poetopak = 0;

                                            while (poetopak < 5 || volbavypsani > 0)
                                            {
                                                Console.Write("_____Zadej číslo Vagonu (pro konec zadej 0)_____:   ");

                                                input = Console.ReadLine();
                                                while (!int.TryParse(input, out volbavypsani))
                                                {
                                                    Console.WriteLine("Nezadal jsi číslo!");
                                                    Console.Write("znovu: ");
                                                    input = Console.ReadLine();
                                                }

                                                if (volbavypsani == 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }

                                                foreach (var pair in vozidlaMain)
                                                {
                                                    if (pair.Value.GetType() == typeof(OsobniVuz))
                                                    {
                                                        if ((((OsobniVuz)pair.Value).Pridan) == false)
                                                        {
                                                            x++;
                                                            if (x == volbavypsani)
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Blue;

                                                                Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                                Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                                Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                                Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                                Console.WriteLine($"POCET SEDADEL: {((OsobniVuz)pair.Value).PocetSedadel} ");
                                                                Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                                Console.ForegroundColor = ConsoleColor.White;

                                                                poetopak = 0;

                                                                novaSouprava.PridejVagon((OsobniVuz)pair.Value);
                                                                if (vozidlaMain.ContainsKey(pair.Value.RegistracniCislo))
                                                                {

                                                                    (((OsobniVuz)pair.Value).Pridan) = true;
                                                                }
                                                                Console.WriteLine("Osobni vuz byl úspěšně přidán do vlaku");
                                                                break;
                                                            }
                                                            else if (volbavypsani == 0)
                                                            {
                                                                Console.Clear();
                                                                poetopak = 5;
                                                                break;
                                                            }
                                                            
                                                       
                                                        }
                                                    }
                                                    
                                                }


                                                break;
                                            }
                                            

                                            break;






                                            case 3:
                                            Console.Clear();
                                            vozidlaMain = depo.seznamVozidel();
                                            Console.WriteLine("-----DEPO-----");

                                            x = 0;
                                            int NV = 1;

                                            foreach (var pair in vozidlaMain)
                                            {
                                                if (pair.Value.GetType() == typeof(NakladniVuz))
                                                {
                                                    if ((((NakladniVuz)pair.Value).Pridan) == false)
                                                    {
                                                        Console.WriteLine($"{NV}.Cislo: {pair.Value.RegistracniCislo} {pair.Value.KontrolniCislo}");
                                                        NV++;
                                                    }
                                                    
                                                }
                                            }
                                            Console.WriteLine("---------------");
                                            Console.WriteLine();

                                            poetopak = 0;

                                            while (poetopak < 5 || volbavypsani > 0)
                                            {
                                                Console.Write("_____Zadej číslo Nakladního Vozu (pro konec zadej 0)_____:   ");

                                                input = Console.ReadLine();
                                                while (!int.TryParse(input, out volbavypsani))
                                                {
                                                    Console.WriteLine("Nezadal jsi číslo!");
                                                    Console.Write("znovu: ");
                                                    input = Console.ReadLine();
                                                }

                                                if (volbavypsani == 0)
                                                {
                                                    Console.Clear();
                                                    break;
                                                }

                                                foreach (var pair in vozidlaMain)
                                                {
                                                   
                                                    {
                                                        if (pair.Value.GetType() == typeof(NakladniVuz))
                                                        {

                                                            if ((((NakladniVuz)pair.Value).Pridan) == false) { 
                                                                x++;
                                                        if (x == volbavypsani)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Blue;

                                                            Console.WriteLine($"REGISTRACNI CISLO: {pair.Value.RegistracniCislo}  ");
                                                            Console.WriteLine($"KONTROLNI CISLICE: {pair.Value.KontrolniCislo} ");
                                                            Console.WriteLine($"BARVA: {pair.Value.Barva} ");
                                                            Console.WriteLine($"DELKA: {pair.Value.Delka} ");
                                                            Console.WriteLine($"NOSNOST: {((NakladniVuz)pair.Value).Nosnost} ");
                                                            Console.WriteLine($"MAXIMALNI RYCHLOST: {pair.Value.MaxRychlost} ");
                                                            
                                                            Console.ForegroundColor = ConsoleColor.White;

                                                            poetopak = 0;
                                                            
                                                            novaSouprava.PridejVagon((NakladniVuz)pair.Value);

                                                            if (vozidlaMain.ContainsKey(pair.Value.RegistracniCislo))
                                                            {
                                                                
                                                               (((NakladniVuz)pair.Value).Pridan) = true;
                                                            }
                                                            Console.WriteLine("Nakladní vůz byl úspěšně přidaný do vlaku");
                                                            break;
                                                        }
                                                        else if (volbavypsani == 0)
                                                        {
                                                            Console.Clear();
                                                            poetopak = 5;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            poetopak++;

                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.WriteLine("Toto číslo nebylo najito!");
                                                            Console.WriteLine("Maximální počet opakování " + poetopak + "/5");
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                        }
                                                        break;
                                                            }
                                                        }
                                                    }
                                                }

                                                break;
                                            }
                                            x = 0;

                                            break;



                                    }
                                    break;
                                        



                                    }
                                }
                        vlaky.AddLast(novaSouprava);


                        break;
                        
                            case 5:
                                ZobrazitSoupravyVlaku(vlaky);
                                break;
                    case 6:
                        Console.WriteLine("\nVýběr soupravy vlaku ke smazání:");
                        foreach (var souprava in vlaky)
                        {
                            Console.WriteLine($"- {souprava.Jmeno}");
                        }

                        Console.Write("\nZadej jméno soupravy vlaku, kterou chceš smazat (pro zrušení zadej 0): ");
                        string jmenoSoupravy = Console.ReadLine();

                        if (jmenoSoupravy == "0")
                        {
                            Console.WriteLine("Operace byla zrušena.");
                            break;
                        }

                        Vlak soupravaKeSmazani = null;
                        foreach (var souprava in vlaky)
                        {
                            if (souprava.Jmeno == jmenoSoupravy)
                            {
                                soupravaKeSmazani = souprava;
                                break;
                            }
                        }

                        if (soupravaKeSmazani != null)
                        {
                            foreach (Vozidlo vozidlo in soupravaKeSmazani)
                            {
                                vozidlo.Pridan = false; 
                                vozidlaMain[vozidlo.RegistracniCislo].Pridan = false; 
                            }

                            vlaky.Remove(soupravaKeSmazani); 
                            Console.WriteLine($"Souprava vlaku '{soupravaKeSmazani.Jmeno}' byla úspěšně smazána.");
                        }
                        else
                        {
                            Console.WriteLine($"Souprava vlaku se jménem '{jmenoSoupravy}' nebyla nalezena.");
                        }

                        break;
                }

                }






            }
        static void ZobrazitSoupravyVlaku(LinkedList<Vlak> vlaky)
        {
            Console.WriteLine("\nObsah souprav vlaků:");

            foreach (var souprava in vlaky)
            {
                Console.WriteLine($"Souprava vlaku '{souprava.Jmeno}':");

                foreach (Vozidlo vozidlo in souprava)
                {
                    Console.WriteLine($"- {vozidlo.GetType().Name} ({vozidlo.RegistracniCislo})");
                }

                Console.WriteLine();
            }

        }
        

    }

}


    



