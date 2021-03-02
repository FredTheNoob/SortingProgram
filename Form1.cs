﻿using System;
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
using SortingProgram.Classes;

namespace SortingProgram
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (lstGeneratedNumbers.Items.Count == 0)
            {
                MetroMessageBox.Show(this.Owner, "No numbers generated. Please generate some numbers before sorting", $"No Generated Numbers - Error");
                return;
            }

            switch (cmbSortingType.SelectedItem.ToString())
            {
                case "BubbleSort":
                    BubbleSort();
                    break;

                case "MergeSort":
                    MergeSort();
                    break;
            }
        }

        private void BubbleSort()
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

            Sorting.SortingResult sorted = Sorting.BubbleSort(input);

            // Stop stopuret når vi er ude af det nestede for loop

            // Fyld vores sorterede listbox op
            foreach (int i in sorted.sortedArr)
            {
                lstSortedNumbers.Items.Add(i);
            }

            // Hvis statistik
            lblSortTime.Text = $"{sorted.time.ElapsedMilliseconds} ms\n{sorted.time.ElapsedMilliseconds / Convert.ToDecimal(1000)} s\nChecks: {sorted.checks.ToString("#,#")}\nModifications: {sorted.modifications.ToString("#,#")}";
        }

        private void MergeSort()
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

            Sorting.SortingResult sorted = Sorting.MergeSort(input);

            // Stop stopuret når vi er ude af det nestede for loop

            // Fyld vores sorterede listbox op
            foreach (int i in sorted.sortedArr)
            {
                lstSortedNumbers.Items.Add(i);
            }

            // Hvis statistik
            lblSortTime.Text = $"{sorted.time.ElapsedMilliseconds} ms\n{sorted.time.ElapsedMilliseconds / Convert.ToDecimal(1000)} s\nChecks: {sorted.checks.ToString("#,#")}\nModifications: {sorted.modifications.ToString("#,#")}";
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

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSortingType.SelectedIndex = 0; // Set vores index så vores item er valgt når programmet er startet
            // Set the tooltip to the checkbox control and the text with some info for the user, so that he/she knows what the checkbox does.
            tltPerformance.SetToolTip(chkPerformance, "Uses various optimizations\nto improve the performance of\nthe selected sorting algorithm");
        }
    }
}
