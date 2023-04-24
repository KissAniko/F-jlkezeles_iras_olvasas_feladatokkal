using System;
using System.IO;

namespace _2022.12.06. - Fájlkezelés(StreamReader, StreamWriter)
{
    class Program
{
    static void Main(string[] args)
    {
        // 1.feladat
        //   A mellékelt fálból beolvasva az adatokat végezze el a következőket!

        //   a) Írassa képernyőre az 1998 - ban születettek adatait!

        string[] sorok = File.ReadAllLines("dates.txt");

        StreamReader sr = new StreamReader("dates.txt");

        int darab = 0;

        while (!sr.EndOfStream)
        {
            string sor = sr.ReadLine();
            if (sor.Substring(0, 2) == "98")
            {
                darab++;
            }
        }

        Console.WriteLine($"1998-ban születettek száma: {darab}.");

        sr.Close();

        //   b) Hozzon létre egy új fájlt ujak.txt néven, amibe írja bele a "00" kezdetű adatokat!

        StreamReader sr2 = new StreamReader("dates.txt");

        darab = 0;

        while (!sr2.EndOfStream)
        {
            string sor = sr2.ReadLine();
            if (sor.Substring(0, 2) == "00")
            {
                darab++;
            }
        }

        string[] newString = new string[darab];
        int sorIndex = 0;

        sr2.Close();

        StreamReader sr3 = new StreamReader("dates.txt");

        while (!sr3.EndOfStream)
        {
            string sor = sr3.ReadLine();
            if (sor.Substring(0, 2) == "00")
            {
                newString[sorIndex] = sor;
                sorIndex++;
            }
        }

        File.WriteAllLines("ujak.txt", newString);

        sr3.Close();

        //   2.feladat
        //   Kérjen be billentyűzetről szavakat, amiket egyből írjon a SZAVAK.TXT állományba!Ha eléri a 6 szót, akkor zárja le az állományt!

        string word;
        int szavakSzama = 0;
        StreamWriter sr4 = new StreamWriter("SZAVAK.TXT");

        do
        {
            Console.Write("Adjon meg egy szót. ");
            word = Console.ReadLine();
            sr4.WriteLine(word);
            szavakSzama++;
        } while (szavakSzama < 6);

        sr4.Close();

        //   3.feladat
        //   Kérjen be billentyűzetről egy nevet és egy testmagasságot. Az adatokat írja futok.csv fájlba a következő formátumban! Minden futó adata egy sor! A fájl akkor zárja le, ha nem ad meg nevet.
        //   név; magasság
        //    pld.
        //    Gipsz Jakab; 178

        StreamWriter sr5 = new StreamWriter("futok.csv");

        string row;
        bool futhat = true;

        do
        {
            Console.Write("Adja meg a futó nevét. ");
            row = Console.ReadLine();
            if (row != "")
            {
                Console.Write("Adja meg a magasságát ");
                row += "; " + Console.ReadLine();
                Console.WriteLine(row);
                sr5.WriteLine(row);
            }
            else
            {
                futhat = false;
            }

        } while (futhat);

        sr5.Close();
    }
}
}
