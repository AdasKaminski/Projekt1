using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp19

{
    class Program
    {
        private static ulong Licznik;
        private static ulong Dluga;
        private static ulong Wynik;
        private static int NR;
        static void Main(string[] args)
        {
            int indeks = 0;
            long czasroznica;
            Console.WriteLine("Binarne średnie");
            Console.WriteLine("NR ; Rozmiar ; Szukana ; Nr indeksu ; Ilość operacji  ; Czas       ; Złożoność");
            for (int j = 4473924; j < (int)Math.Pow(2, 28); j += 4473924)
            {
                NR++;
                int SzukanaLiczba;


                int[] Tablica = new int[j];
                for (int i = 0; i < Tablica.Length; i++)
                {
                    Tablica[i] = i + 1;
                    Wynik += (ulong)Tablica[i];
                }
                Array.Sort(Tablica);
                SzukanaLiczba = j - 1;



                var czas = new System.Diagnostics.Stopwatch();//dodanie zmiennej czas
                czas.Start();//czas start
                indeks = WyszukiwanieBinarnePrzedInstrumentacja(Tablica, SzukanaLiczba, Tablica.Length);//Funkcja liniowa bez instrumentacji
                czas.Stop();//czas stop
                czasroznica = czas.ElapsedTicks;//obliczanie czasu w tikach procesora

                indeks = WyszukiwanieBinarnePoInstrumentacji(Tablica, SzukanaLiczba, Tablica.Length);

                Console.WriteLine(NR + " ; " + Tablica.Length + " ; " + SzukanaLiczba + " ; " + indeks + "    ; " + Licznik + "        ; " + czas.ElapsedTicks + " ; " + Wynik);


            }
            Console.ReadKey();
        }

        static int WyszukiwanieBinarnePoInstrumentacji(int[] Tablicabin, int liczba2, int TablicaDlugosc)//wyszukiwanie binarne z instrumentacją
        {
            int prawa = TablicaDlugosc - 1;
            int lewa = 0;
            int srodek;
            Licznik = 0;
            Dluga = 0;
            Wynik = 0;
            while (lewa <= prawa)
            {
                Licznik++;

                srodek = (lewa + prawa) / 2;
                Wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                Dluga += (ulong)Math.Pow(2, Licznik - 1);
                if (Tablicabin[srodek] == liczba2)
                {
                    Licznik++;
                    Wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    Dluga += (ulong)Math.Pow(2, Licznik - 1);
                    Wynik = Wynik / Dluga;

                    return srodek;

                }
                else if (Tablicabin[srodek] < liczba2)
                {
                    Licznik++;
                    Wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    Dluga += (ulong)Math.Pow(2, Licznik - 1);
                    lewa = srodek + 1;

                }
                else
                {
                    Licznik++;
                    Wynik += (ulong)Licznik * (ulong)Math.Pow(2, Licznik - 1);
                    Dluga += (ulong)Math.Pow(2, Licznik - 1);
                    prawa = srodek - 1;

                }

            }
            return -1;

        }
        static int WyszukiwanieBinarnePrzedInstrumentacja(int[] Tablica2, int liczba2, int TablicaDlugosc)//wyszukiwanie binarne bez instrumentacji
        {
            int prawa = TablicaDlugosc - 1;
            int lewa = 0;
            int srodek;

            while (lewa <= prawa)
            {


                srodek = (lewa + prawa) / 2;

                if (Tablica2[srodek] == liczba2)
                {

                    return srodek;


                }
                else if (Tablica2[srodek] < liczba2)
                {
                    lewa = srodek + 1;


                }
                else
                {
                    prawa = srodek - 1;


                }



            }

            return -1;

        }
    }
}
