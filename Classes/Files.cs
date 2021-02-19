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

        public Files()
        {
            string path = Directory.GetCurrentDirectory() + @"\data.csv";
            
            if (File.Exists(path)) File.Delete(path);
            sw = File.CreateText(path);
            sw.WriteLine("Time;Checks;Modifications");
        }
        public void WriteNewLine(string _data)
        {
            sw.WriteLine(_data);
        }
        public void SaveFile()
        {
            sw.Close();
        }
    }
}
