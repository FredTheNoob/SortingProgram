using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MetroFramework;
using MetroFramework.Forms;

namespace BubbleSort
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBubbleSort_Click(object sender, EventArgs e)
        {
            // Ryd alle items i listboxen, hvis der er nogen fra sidste klik
            lstSortedNumbers.Items.Clear();

            // Lav et int array som indeholder de items vi gerne vil sortere
            int[] input = new int[lstGeneratedNumbers.Items.Count];
            
            // Fyld input arrayet op med et for loop
            for (int i = 0; i < lstGeneratedNumbers.Items.Count; i++)
            {
                // Vi laver et cast og parser vores item til en int som vi forresten også skal lave til en string da listboxens items er en ObjectCollection
                input[i] = int.Parse(lstGeneratedNumbers.Items[i].ToString());
            }

            // Disse variabler holder styr på hvor mange cycles/checks vi laver, 
            // og derudover også hvor mange modifikationer vi foretager os (når vi flytter rundt på to tal)
            double checks = 0;
            double modifications = 0;

            // Start et stopur ved brug af System.Diagnostics.Stopwatch biblioteket
            Stopwatch watch = Stopwatch.StartNew();

            // Dette nestede for loop sørger for at vi kører det hele igennem, hvis der kun var et for loop ville der kun foregå en iteration med modifikationer
            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < input.Length - 1 - j; i++)
                {
                    checks++;

                    // Hvis det tal vi kigger på er større end det næste tal
                    if (input[i] > input[i + 1])
                    {
                        // Vi skal nu lave en modifikation
                        modifications++;
                        // Byt da rundt på deres pladser
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                    }
                }
            }

            // Stop stopuret når vi er ude af det nestede for loop
            watch.Stop();

            // Fyld vores sorterede listbox op
            foreach (int i in input)
            {
                lstSortedNumbers.Items.Add(i);
            }

            // Hvis statistik
            lblSortTime.Text = $"{watch.ElapsedMilliseconds} ms\n{watch.ElapsedMilliseconds / Convert.ToDecimal(1000)} s\nChecks: {checks.ToString("#,#")}\nModifications: {modifications.ToString("#,#")}";
        }

        private void btnGenerateNumbers_Click(object sender, EventArgs e)
        {
            // Hvis det brugeren har indtastet ikke er et tal
            if (!txtNumbers.Text.All(char.IsDigit)) {
                // Bruger feedback
                MetroMessageBox.Show(this.Owner ,"Invalid number format: the N input is only allowed to be a whole number excluding negative numbers, special characters, string letters, etc.", $"{txtNumbers.Text} - Error");
                return; // Fortsæt ikke til koden nedenfor men hop ud af denne metode
            }

            // Nyt tilfældigt tal
            Random rnd = new Random();
            // Ryd vores liste af items hvis brugeren forsøger at generere nye tilfældige tal
            lstGeneratedNumbers.Items.Clear();

            // Fyld listboxen op med tilfældige tal -> vi caster vores text til en int så for loopet ved hvor langt det skal køre
            for (int i = 0; i < Int32.Parse(txtNumbers.Text); i++)
            {
                // Vi tilføjer et tilfældige tal til listen mellem 0 og 999
                lstGeneratedNumbers.Items.Add(rnd.Next(0,999));
            }
        }
    }
}
