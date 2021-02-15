using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingProgram
{
    static class Sorting
    {
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
        }

        public static SortingResult BubbleSort(int[] _unsortedArr)
        {
            SortingResult result = new SortingResult();
            result.time = Stopwatch.StartNew();

            // Dette nestede for loop sørger for at vi kører det hele igennem, hvis der kun var et for loop ville der kun foregå en iteration med modifikationer
            for (int j = 0; j < _unsortedArr.Length; j++)
            {
                for (int i = 0; i < _unsortedArr.Length - 1 - j; i++)
                {
                    result.checks++;

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

            result.time.Stop();
            result.sortedArr = _unsortedArr;
            return result;
        }
    }
}
