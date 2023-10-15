using System;
using System.IO;
using System.Collections.Generic;
namespace Employee
{
    class Program
    {
        //A következő feladatokat a program osztályban elhelyezett statikus metódusokkal oldd meg. (Aki szeret kísérletezni, teheti ezeket a metódusokat egy újabb osztályba.) Egyes feladatokat meg lehet oldani LINQ-val is, de ha belefér az időbe, kódoljátok le hagyományosan is.Ha van olyan feladat, ami nem egyértelmű, pl.az, hogyan kell kiírni, ott rád van bízva a megoldás.
        //Függvény segítségével írd ki az életkorok átlagát.
        #region statikus metódusok
        static double atlagEletkor(List<Dolgozok> k)
        {
            double osszegEletkor = 0;
            for (int i = 0; i < k.Count; i++)
            {
                osszegEletkor = osszegEletkor + k[i].Eletkor;
            }
            return osszegEletkor / k.Count;
        }
        //Függvény segítségével írd ki azon személyek számát, akiknek a városa 'Budapest'.
        static int szemelyekBp(List<Dolgozok> k)
        {
            int db = 0;
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Varos == "Budapest")
                {
                    db++;
                }
            }
            return db;
        }
        //Függvény segítségével keresd ki, majd a virtuális metódus segítségével írd ki a legidősebb személy adatait.
        //Ez a megoldás nem függvénnyel készült.
        static void legidosebbSzemely(List<Dolgozok> k)
        {
            int legidosebbEletkor = k[0].Eletkor;
            for (int i = 1; i < k.Count; i++)
            {
                if (k[i].Eletkor > legidosebbEletkor)
                {
                    legidosebbEletkor = k[i].Eletkor;
                }
            }            
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Eletkor == legidosebbEletkor)
                {
                    Console.WriteLine(k[i]);
                }
            }
        }

        //Függvény segítségével keresd ki, majd a virtuális metódus segítségével írd ki a legidősebb személy adatait.
        //Ez a megoldás függvénnyel készült.
        static Dolgozok legidosebbSzemely1(List<Dolgozok> k)
        {
            Dolgozok legidosebb = k[0];
            for (int i = 1; i < k.Count; i++)
            {
                if (k[i].Eletkor > legidosebb.Eletkor)
                {
                    legidosebb = k[i];
                }
            }
            return legidosebb;
        }
        //Függvény segítségével döntsd el, majd a főprogramban írd ki, hogy van - e 30 év fölötti személy, és emellett írd ki a nevét is. (Ez a függvény tehát két értéket kell, hogy generáljon, ezt egyetlen szövegként add vissza a főprogramnak, és a főprogram bontsa szét az adatokat, majd utána írja ki.)
        static string harmincFeletti(List<Dolgozok> k)
        {
            bool van = false;
            int i = 0;
            while (i < k.Count)
            {
                if (k[i].Eletkor > 30)
                {
                    van = true;
                }
                i++;
            }

            if (van)
            {
                return $"{"true"} {k[i - 1].Nev}";
            }
            else
            {
                return $"{"false"} {"nincs"}";
            }
        }
        //Függvénnyel válogasd ki azon személyek nevét egy új tömbbe (nem listába), akik 30 évnél fiatalabbak. Ennek a tömbnek a hasznos tartalmát írd ki a főprogramban.
        static string[] harmincAlatt(List<Dolgozok> k)
        {
            int x = 0;
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Eletkor < 30)
                {
                    x++;
                }
            }
            string[] harmincAlattTomb = new string[x];
            int j = 0;
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Eletkor < 30)
                {
                    harmincAlattTomb[j] = k[i].Nev;
                    j++;
                }
            }
            return harmincAlattTomb;
        }
        //Egyetlen függvénnyel keresd meg a legfiatalabb és a legidősebb személyt. A függvénynek legyen két olyan paramétere, amiben az eredményt vissza lehet juttatni a főprogramba, és ott ki lehet írni a nevüket és a korukat. A függvény visszatérési értéke pedig képes legyen azt jelezni, hogy van-e több ugyanolyan korú legfiatalabb személy.
        static bool legidosebbEsLegfiatalabbSzemely(List<Dolgozok> k, out string legidosebbNev, out string legfiatalabbNev)
        {
            int legidosebbEletkor = k[0].Eletkor;
            legidosebbNev = k[0].Nev;
            int szamlalo1 = 0;
            for (int i = 1; i < k.Count; i++)
            {
                if (k[i].Eletkor > legidosebbEletkor)
                {
                    legidosebbEletkor = k[i].Eletkor;
                    legidosebbNev = k[i].Nev;
                }
            }
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Eletkor == legidosebbEletkor) szamlalo1++;
            }

            int legfiatalabbEletkor = k[0].Eletkor;
            legfiatalabbNev = k[0].Nev;
            int szamlalo2 = 0;
            for (int j = 1; j < k.Count; j++)
            {
                if (k[j].Eletkor < legfiatalabbEletkor)
                {
                    legfiatalabbEletkor = k[j].Eletkor;
                    legfiatalabbNev = k[j].Nev;
                    szamlalo2++;
                }
            }
            for (int i = 0; i < k.Count; i++)
            {
                if (k[i].Eletkor == legfiatalabbEletkor) szamlalo2++;
            }
            //a legutolsó legidősebbet és a legutolsó legfiatalabbat adja meg
            //ez is jó:
            //if (szamlalo1 > 0 || szamlalo2 > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            //de ez még szebb:
            return szamlalo1 > 0 || szamlalo2 > 0 ? true : false;
        }
        //Készíts egy függvényt, ami átszámolja az euróban megadott havi fizetést éves fizetéssé, és az eredményt még váltsd át magyar forintba is.
        //ez az osztályban van

        //Készíts egy függvényt, amelynek visszatérési értéke egy objektumokat tartalmazó lista, amelyben szerepel az 5 millió forint éves fizetés feletti munkavállalók neve és az éves fizetésük forintban. (Az átszámításhoz használd az előző feladat függvényét.)  Az elkészült listát a főprogram írja ki egy új fájlba(a virtuális metódus segítségével).
        //itt folytatjuk
        static List<string> FajlbaIras(List<Dolgozok> k)
        {
            List<string> evesForint = new List<string>();
            foreach (var item in k)
            {
                if (item.EvesFizetesForintban() > 5000000)
                {
                    evesForint.Add($"Név: {item.Nev} Éves fizetés forintban: {item.EvesFizetesForintban()}");
                }
            }
            return evesForint;
        }
        //Írj egy függvényt, aminek a paramétere az eredeti adatokat tartalmazó listának megfelelő típusú. Ennek segítségével számold ki az összes alkalmazott átlagfizetését.
        static double atlag(List<Dolgozok> k)
        {
            double osszeg = 0;
            for (int i = 0; i < k.Count; i++)
            {
                osszeg = osszeg + k[i].Fizetes;
            }
            return Math.Round (osszeg / k.Count, 2);
        }
        #endregion
        static void Main(string[] args)
        {
            //Az osztály segítségével hozz létre egy listát, amely objektumpéldányokat tartalmaz a forrásfájlból beolvasott adatokkal.
            var dolgozok = new List<Dolgozok>();
            foreach (var i in File.ReadAllLines(@"../../src/employee.txt"))
            {
                if (i != "")
                {
                    dolgozok.Add(new Dolgozok(i));
                }
            }
            //A virtuális metódus segítségével írd ki az összes adatot.
            Console.WriteLine("7.feladat");
            Console.WriteLine();
            foreach (var item in dolgozok)
            {
                Console.WriteLine(item);
            }
            //Propertyk kidolgozása(Szorgalmi feladat)
            //Dolgozd ki a property-ket is, és használd őket az adatokhoz való korrekt hozzáférésre és módosításra.
            //Hibakezelés(Szorgalmi feladat)
            //Implementálj hibakezelést az alkalmazásban, például az adatok beolvasásakor vagy a fájlba írás során.      
            Console.WriteLine();
            Console.WriteLine("8.feladat");
            Console.WriteLine();
            Console.WriteLine($"Az átlagéletkor: {atlagEletkor(dolgozok):0.00}");
            Console.WriteLine();
            Console.WriteLine("9.feladat");
            Console.WriteLine();
            Console.WriteLine($"Budapesti lakosok száma: {szemelyekBp(dolgozok)}");
            Console.WriteLine();
            Console.WriteLine("10.feladat 1. megoldás");
            Console.WriteLine();
            legidosebbSzemely(dolgozok);
            Console.WriteLine();
            Console.WriteLine("10.feladat 2. megoldás");
            Console.WriteLine();
            Dolgozok legidosebbDolgozo = legidosebbSzemely1(dolgozok);
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Eletkor == legidosebbDolgozo.Eletkor)
                {
                    Console.WriteLine(dolgozok[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("11.feladat");
            Console.WriteLine();
            var valasz = harmincFeletti(dolgozok).Split(' ');
            if (valasz[0] =="true")
            {
                Console.WriteLine($"Van 30 év feletti személy, az elsőnek a neve: {valasz[1]}");
            }
            else
            {
                Console.WriteLine($"Nincs 30 év feletti személy. ");
            }
            Console.WriteLine();
            Console.WriteLine("12.feladat");
            Console.WriteLine();
            foreach (var item in harmincAlatt(dolgozok))
            {
                Console.WriteLine(item);
            }           
            Console.WriteLine();
            Console.WriteLine("13.feladat");
            Console.WriteLine();
            string legidosebb, legfiatalabb;
            legidosebbEsLegfiatalabbSzemely(dolgozok, out legidosebb, out legfiatalabb);
            Console.WriteLine($"Utolsó legidősebb: {legidosebb}, utolsó legfiatalabb: {legfiatalabb}");
            Console.WriteLine();
            Console.WriteLine("14.feladat");
            Console.WriteLine();
            Console.WriteLine("Kész");
            Console.WriteLine();
            Console.WriteLine("15.feladat Fájlba írás");
            Console.WriteLine();
            using (var sw = new StreamWriter(@"../../src/otmillio.txt"))
            {
                foreach (var item in FajlbaIras(dolgozok))
                {
                    sw.WriteLine(item);
                }
            }
            Console.WriteLine("Kész.");
            Console.WriteLine();
            Console.WriteLine("16.feladat");
            Console.WriteLine();
            Console.WriteLine($"Az átlag havi fizetés: {atlag(dolgozok)} Euró.");
            //Készíts a főprogramban egy olyan listát, amiben csak a developer beosztásúak találhatók, minden tulajdonságukkal. Hívd meg újra a főprogramból az előző függvényt, de most ez az új lista legyen a paramétere. A főprogram írja ki a developerek átlagfizetését.

            Console.WriteLine();
            Console.WriteLine("17.feladat");
            Console.WriteLine();
            var developerLista = new List<Dolgozok>();   
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Pozicio == "Developer")
                {
                    developerLista.Add(dolgozok[i]);
                }
            }
            Console.WriteLine($"A developerek átlagfizetése: {atlag(developerLista)} Euró");
            Console.WriteLine();
            Console.WriteLine("18.feladat");
            Console.WriteLine();
            //Számold ki a férfi és női alkalmazottak átlagfizetését tetszőleges módszerrel.
            var FerfiAtlag = new List<Dolgozok>();
            var NoiAtlag = new List<Dolgozok>();
            for (int i = 0; i < dolgozok.Count; i++)
            {
                if (dolgozok[i].Nem == "Male")
                {
                    FerfiAtlag.Add(dolgozok[i]);
                }
                else if (dolgozok[i].Nem == "Female")
                {
                    NoiAtlag.Add(dolgozok[i]);
                }
            }
            Console.WriteLine($"A férfiak átlagfizetése: {atlag(FerfiAtlag)} Euró");
            Console.WriteLine();
            Console.WriteLine($"A nők átlagfizetése: {atlag(NoiAtlag)} Euró");
            Console.ReadLine();
        }
    }
}
