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

            public SortingResult()
            {
                this.time = Stopwatch.StartNew();
            }
        }

        public static SortingResult BubbleSort(int[] _unsortedArr)
        {
            Files file = new Files();

            SortingResult result = new SortingResult();

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

        public static SortingResult MergeSort(int[] _unsortedArr)
        {
            SortingResult result = new SortingResult();
            result.sortedArr = split(_unsortedArr);
            result.time.Stop();
            return result;


            int[] split(int[] _unsplitArray)
            {
                if (_unsplitArray.Length <= 1) return _unsplitArray; // Hvis vi modtager et array som har en længde der er mindre end 1 er der ikke noget at sortere

                // Med take funktionen kan vi tage de første elementer og ignorere resten
                int[] left = _unsplitArray.Take(_unsplitArray.Length / 2).ToArray();
                // Med skip funktionen kan vi tage de sidste elementer og ignorere starten
                int[] right = _unsplitArray.Skip(_unsplitArray.Length / 2).ToArray();

                // Vi kalder på merge som sorterer vores array
                return merge(left, right);
            }

            int[] merge(int[] _left, int[] _right)
            {
                int[] merge_result = new int[_left.Length + _right.Length];
                int pointerLeft = 0;
                int pointerRight = 0;


                //sortere mens der stadig er noget i begge arrays
                while (_left.Length != pointerLeft && _right.Length != pointerRight)
                {
                    // Hvis vores venstreside er mindre end vores højreside
                    if(_left[pointerLeft] < _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                    }
                    // Hvis venstre- og højreside er ens
                    else if (_left[pointerLeft] == _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                    }
                    // Hvis vesntresiden er større end højresiden
                    else if (_left[pointerLeft] > _right[pointerRight])
                    {
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                    }
                }
                
                //hvis der kun er tal tilbage i et array skal vi sætte det hele efter det vi har i merge result
                if(_left.Length == pointerLeft)
                {
                    while(pointerRight != _right.Length)
                    {
                        merge_result[pointerLeft + pointerRight] = _right[pointerRight];
                        pointerRight++;
                    }
                }
                else if (_right.Length == pointerRight)
                {
                    while (pointerLeft != _left.Length)
                    {
                        merge_result[pointerLeft + pointerRight] = _left[pointerLeft];
                        pointerLeft++;
                    }
                }

                return merge_result;
            }
            
        }

        public static void OnTimer_Tick(object sender, EventArgs e, SortingResult _result, Files _file)
        {
            _file.WriteNewLine($"{_result.time.ElapsedMilliseconds};{_result.checks};{_result.modifications}");
        } 
    }
}
