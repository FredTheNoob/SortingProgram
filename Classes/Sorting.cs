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
        }

        public static SortingResult BubbleSort(int[] _unsortedArr)
        {
            Files file = new Files();

            SortingResult result = new SortingResult();
            result.time = Stopwatch.StartNew();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 200;
            timer.Start();
            timer.Elapsed += (sender, e) => OnTimer_Tick(sender, e, result, file);
            
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

            timer.Stop();
            result.time.Stop();
            file.SaveFile();
            result.sortedArr = _unsortedArr;
            return result;
        }

        public static void OnTimer_Tick(object sender, EventArgs e, SortingResult _result, Files _file)
        {
            _file.WriteNewLine($"{_result.time.ElapsedMilliseconds};{_result.checks};{_result.modifications}");
        } 

        public static int Factorial(int n)
        {
            if (n == 1) return 1;
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
