using System;
using System.Diagnostics;

namespace Projekt1
{
    class Program
    {
        private static long Licznik;//licznik operacji
        private static long Suma;//suma elementów
        private static long Wynik;
        private static int NR;

        static void Main(string[] args)
        {
            long czasroznica;
            int indeks = 0;
            Console.WriteLine("LinioweŚrednie");
            Console.WriteLine("NR ; Rozmiar ; Szukana ; Nr indeksu ; Ilość operacji  ; Czas       ; Złożoność");

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
                SzukanaLiczba = Tablica.Length / 2;

                var czas = new System.Diagnostics.Stopwatch();//dodanie zmiennej czas
                czas.Start();//czas start
                indeks = WyszukiwanieLiniowePrzedInstrumentacja(Tablica, SzukanaLiczba);//Funkcja liniowa bez instrumentacji
                czas.Stop();//czas stop
                czasroznica = czas.ElapsedTicks;//obliczanie czasu w tikach procesora

                indeks = WyszukiwanieLiniowePoInstrumentacji(Tablica, SzukanaLiczba);
                Console.WriteLine(NR + " ; " + Tablica.Length + " ; " + SzukanaLiczba + " ; " + indeks + "    ; " + Licznik + "        ; " + czas.ElapsedTicks + " ; " + Wynik);


            }
            Console.ReadKey();
        }
        static int WyszukiwanieLiniowePoInstrumentacji(int[] Tablica2, int liczba2)//wyszukiwanie liniowe z instrumentacją
        {
            Suma = 0;
            Licznik = 0;
            for (int i = 0; i < Tablica2.Length; i++)
            {
                ++Licznik;
                Suma += Tablica2[i];
                Wynik = Suma / Licznik;//złożoność

                if (Tablica2[i] == liczba2)
                {
                    return i;
                }
            }
            return -1;

        }

        static int WyszukiwanieLiniowePrzedInstrumentacja(int[] Tablica2, int liczba2)//wyszukiwanie liniowe bez instrumentacji
        {

            for (int i = 0; i < Tablica2.Length; i++)
            {


                if (Tablica2[i] == liczba2)
                {
                    return i;
                }
            }
            return -1;

        }



    }
}
