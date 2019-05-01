using System;
using System.Diagnostics;


namespace ConsoleApp19

{
    class Program
    {
        private static ulong Licznik;

        private static int NR;

        static void Main(string[] args)
        {

            int indeks = 0;
            long czasroznica;
            Console.WriteLine("Binarne pesymistyczne");
            Console.WriteLine("NR ; Rozmiar ; Szukana ; Nr indeksu ; Ilość operacji  ; Czas       ");

            for (int j = 4473924; j < (int)Math.Pow(2, 28); j += 4473924)
            {
                NR++;
                int SzukanaLiczba;


                int[] Tablica = new int[j];
                for (int i = 0; i < Tablica.Length; i++)
                {
                    Tablica[i] = i + 1;
                }
                Array.Sort(Tablica);
                SzukanaLiczba = j + 1;


                var czas = new System.Diagnostics.Stopwatch();//dodanie zmiennej czas
                czas.Start();//czas start
                indeks = WyszukiwanieBinarnePrzedInstrumentacja(Tablica, SzukanaLiczba, Tablica.Length);//Funkcja liniowa bez instrumentacji
                czas.Stop();//czas stop
                czasroznica = czas.ElapsedTicks; ;//obliczanie czasu w tikach procesora

                indeks = WyszukiwanieBinarnePoInstrumentacji(Tablica, SzukanaLiczba, Tablica.Length);

                Console.WriteLine(NR + " ; " + Tablica.Length + " ; " + SzukanaLiczba + " ; " + indeks + "    ; " + Licznik + "        ; " + czas.ElapsedTicks);

            }
            Console.ReadKey();
        }

        static int WyszukiwanieBinarnePoInstrumentacji(int[] Tablica2, int liczba2, int tablicadlugosc)//wyszukiwanie binarne pesymistyczne z instrumentacją
        {
            int prawa = tablicadlugosc - 1;
            int lewa = 0;
            int srodek;
            Licznik = 0;

            while (lewa <= prawa)
            {
                ++Licznik;

                srodek = (lewa + prawa) / 2;

                if (Tablica2[srodek] == liczba2)
                {
                    ++Licznik;

                    return srodek;

                }
                else if (Tablica2[srodek] < liczba2)
                {
                    lewa = srodek + 1;
                    ++Licznik;

                }
                else
                {
                    prawa = srodek - 1;
                    ++Licznik;

                }

            }
            return -1;

        }
        static int WyszukiwanieBinarnePrzedInstrumentacja(int[] Tablica2, int liczba2, int tablicadlugosc)//wyszukiwanie binarne pesymistyczne bez instrumentacji
        {
            int prawa = tablicadlugosc - 1;
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
