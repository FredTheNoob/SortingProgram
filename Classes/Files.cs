using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingProgram.Classes
{
    public class Files
    {
        private StreamWriter sw;

        // Vores constructor som kaldes når nogen laver en ny fil.
        public Files(string _fileName)
        {
            string path = Directory.GetCurrentDirectory() + $@"\{_fileName}.csv"; // Vi laver en fil i vores nuværende mappe
            
            if (File.Exists(path)) File.Delete(path); // Hvis filen med det pågældende navn allerede eksisterer så sletter vi den
            sw = File.CreateText(path); // Vi laver en ny fil
            sw.WriteLine("Time,Checks,Modifications"); // Vi skriver den første linie
        }
        public void WriteNewLine(string _data)
        {
            sw.WriteLine(_data); // Vi skriver vores data til filen
        }
        public void SaveFile()
        {
            sw.Close(); // Vi lukker vores streamwriter da vi nu er færdig med at skrive til filen
        }
    }
}
