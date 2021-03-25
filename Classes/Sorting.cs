using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Diagnostics;

namespace SortingProgram.Classes
{
    static class Sorting
    {
        static System.Timers.Timer timer = new System.Timers.Timer(); // Denne globale timer bruges overalt, og bruger multithreading for at få mere præcise målinger

        // NestedClass fordi dette er en special class lavet til retunering af alle metoderne i Sorting classen
        public class SortingResult
        {
            // Disse variabler holder styr på hvor mange cycles/checks vi laver, 
            // og derudover også hvor mange modifikationer vi foretager os (når vi flytter rundt på to tal)
            public double checks { get; set; }
            public double modifications { get; set; }

            // Vi har et stopwatch som fortæller os hvor lang tid det tog at sortere en given talrække
            public Stopwatch time { get; set; }

            // Til sidst har vi det sorterede array
            public int[] sortedArr { get; set; }

            public SortingResult()
            {
                this.time = Stopwatch.StartNew();
            }
        }

        // Denne metode kaldes udefra når vi gerne vil bruge bubblesort, metoden er statisk da vi ikke er interesseret i at dem der bruger biblioteket skal instantiate en klasse, når det er et bibliotek
        public static SortingResult BubbleSort(int[] _unsortedArr)
        {
            Files file = new Files("bubblesort"); // Vi kalder på vores fil bibliotek og laver en ny fil ved navn bubblesort
            SortingResult result = new SortingResult(); // Vi laver et nyt sortingsresultat

            timer.Interval = 200; // We sætter en timer til at ticke hver 200 milisekund
            timer.Start(); // Vi starter timeren
            // Vi abonnerer på et OnTimer_Tick event og passerer vores resultat og fil så vi kan skrive til filen.
            timer.Elapsed += (sender, e) => OnTimer_Tick(sender, e, result, file);
            
            // Dette nestede for loop sørger for at vi kører det hele igennem, hvis der kun var et for loop ville der kun foregå en iteration med modifikationer
            for (int j = 0; j < _unsortedArr.Length; j++)
            {
                for (int i = 0; i < _unsortedArr.Length - 1 - j; i++)
                {
                    result.checks++; // Vi har lige kigget på et element

                    // Hvis det tal vi kigger på er større end det næste tal
                    if (_unsortedArr[i] > _unsortedArr[i + 1])
                    {
                        // Vi skal nu lave en modifikation
                        result.modifications++;
                        // Byt da rundt på deres pladser
                        int temp = _unsortedArr[i];
                        _unsortedArr[i] = _unsortedArr[i + 1];
                        _unsortedArr[i + 1] = temp;
                    }
                }
            }

            // Vi stopper timeren, fjerner abonnentet fra eventet OnTimer_Tick, samt gemmer vores fil
            timer.Stop();
            result.time.Stop();
            timer.Elapsed -= (sender, e) => OnTimer_Tick(sender, e, result, file);
            file.SaveFile();
            result.sortedArr = _unsortedArr;
            return result; // Til sidst returnerer vi result som er af typen SortingResult
        }

        public static SortingResult MergeSort(int[] _unsortedArr)
        {
            Files file = new Files("mergesort");
            SortingResult result = new SortingResult();

            timer.Interval = 200;
            timer.Start();
            timer.Elapsed += (sender, e) => OnTimer_Tick(sender, e, result, file);

            // Vi begynder at splitte vores array
            result.sortedArr = split(_unsortedArr);

            timer.Stop();
            timer.Elapsed -= (sender, e) => OnTimer_Tick(sender, e, result, file);
            file.SaveFile();
            result.time.Stop();
            return result;

            int[] split(int[] _unsplitArray)
            {
                if (_unsplitArray.Length <= 1) return _unsplitArray; // Hvis vi modtager et array som har en længde der er mindre end 1 er der ikke noget at sortere

                // Med take funktionen kan vi tage de første elementer og ignorere resten
                int[] left = split(_unsplitArray.Take(_unsplitArray.Length / 2).ToArray());
                // Med skip funktionen kan vi tage de sidste elementer og ignorere starten
                int[] right = split(_unsplitArray.Skip(_unsplitArray.Length / 2).ToArray());

                // Vi kalder på merge som sorterer vores array
                return merge(left, right);
            }

            int[] merge(int[] _left, int[] _right)
            {
                // Vi laver et nyt int array som holder det endelige resultat. Dette vil være både venstre og højresidens længde
                int[] merge_result = new int[_left.Length + _right.Length];

                // Vi har to pointers der peger på det element vi er kommet til i arrayet
                int pointerLeft = 0; 
                int pointerRight = 0;


                // Sorter mens der stadig er noget i begge arrays
                while (_left.Length != pointerLeft && _right.Length != pointerRight)
                {
                    result.checks++; // Vi har nu kigget på et element

                    // Hvis vores venstreside er mindre end vores højreside
                    if(_left[pointerLeft] < _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                        result.modifications++; // Vi har nu modificeret et element
                    }
                    // Hvis venstre- og højreside er ens
                    else if (_left[pointerLeft] == _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                        result.modifications += 2;
                    }
                    // Hvis vesntresiden er større end højresiden
                    else if (_left[pointerLeft] > _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                        result.modifications++;
                    }
                }
                
                //hvis der kun er tal tilbage i et array skal vi sætte det hele efter det vi har i merge result
                if(_left.Length == pointerLeft)
                {
                    while(pointerRight != _right.Length)
                    {
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                        result.modifications++;
                    }
                }
                else if (_right.Length == pointerRight)
                {
                    while (pointerLeft != _left.Length)
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                        result.modifications++;
                    }
                }

                return merge_result;
            }
            
        }

        public static void OnTimer_Tick(object sender, EventArgs e, SortingResult _result, Files _file)
        {
            // Vi skriver en ny linie til vores fil, hver linie fortæller hvor lang tid der er gået, hvor mange checks vi har lavet samt modifikationer
            _file.WriteNewLine($"{_result.time.ElapsedMilliseconds},{_result.checks},{_result.modifications}");
        } 
    }
}
