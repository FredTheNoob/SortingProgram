
namespace SortingProgram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSortTime = new System.Windows.Forms.Label();
            this.btnBubbleSort = new MetroFramework.Controls.MetroButton();
            this.lstGeneratedNumbers = new System.Windows.Forms.ListBox();
            this.btnGenerateNumbers = new MetroFramework.Controls.MetroButton();
            this.txtNumbers = new MetroFramework.Controls.MetroTextBox();
            this.lstSortedNumbers = new System.Windows.Forms.ListBox();
            this.btnMergeSort = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblSortTime
            // 
            this.lblSortTime.AutoSize = true;
            this.lblSortTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lblSortTime.Location = new System.Drawing.Point(189, 342);
            this.lblSortTime.Name = "lblSortTime";
            this.lblSortTime.Size = new System.Drawing.Size(0, 17);
            this.lblSortTime.TabIndex = 3;
            // 
            // btnBubbleSort
            // 
            this.btnBubbleSort.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnBubbleSort.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnBubbleSort.Location = new System.Drawing.Point(186, 413);
            this.btnBubbleSort.Name = "btnBubbleSort";
            this.btnBubbleSort.Size = new System.Drawing.Size(120, 58);
            this.btnBubbleSort.Style = MetroFramework.MetroColorStyle.Red;
            this.btnBubbleSort.TabIndex = 2;
            this.btnBubbleSort.Text = "BubbleSort";
            this.btnBubbleSort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnBubbleSort.UseSelectable = true;
            this.btnBubbleSort.Click += new System.EventHandler(this.btnBubbleSort_Click);
            // 
            // lstGeneratedNumbers
            // 
            this.lstGeneratedNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lstGeneratedNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstGeneratedNumbers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGeneratedNumbers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lstGeneratedNumbers.FormattingEnabled = true;
            this.lstGeneratedNumbers.Location = new System.Drawing.Point(60, 63);
            this.lstGeneratedNumbers.Name = "lstGeneratedNumbers";
            this.lstGeneratedNumbers.Size = new System.Drawing.Size(120, 275);
            this.lstGeneratedNumbers.TabIndex = 5;
            // 
            // btnGenerateNumbers
            // 
            this.btnGenerateNumbers.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGenerateNumbers.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnGenerateNumbers.Location = new System.Drawing.Point(60, 413);
            this.btnGenerateNumbers.Name = "btnGenerateNumbers";
            this.btnGenerateNumbers.Size = new System.Drawing.Size(120, 58);
            this.btnGenerateNumbers.Style = MetroFramework.MetroColorStyle.Red;
            this.btnGenerateNumbers.TabIndex = 1;
            this.btnGenerateNumbers.Text = "Generate Numbers";
            this.btnGenerateNumbers.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnGenerateNumbers.UseSelectable = true;
            this.btnGenerateNumbers.Click += new System.EventHandler(this.btnGenerateNumbers_Click);
            // 
            // txtNumbers
            // 
            // 
            // 
            // 
            this.txtNumbers.CustomButton.Image = null;
            this.txtNumbers.CustomButton.Location = new System.Drawing.Point(53, 1);
            this.txtNumbers.CustomButton.Name = "";
            this.txtNumbers.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNumbers.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNumbers.CustomButton.TabIndex = 1;
            this.txtNumbers.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNumbers.CustomButton.UseSelectable = true;
            this.txtNumbers.CustomButton.Visible = false;
            this.txtNumbers.Lines = new string[] {
        "10"};
            this.txtNumbers.Location = new System.Drawing.Point(84, 384);
            this.txtNumbers.MaxLength = 32767;
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.PasswordChar = '\0';
            this.txtNumbers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNumbers.SelectedText = "";
            this.txtNumbers.SelectionLength = 0;
            this.txtNumbers.SelectionStart = 0;
            this.txtNumbers.ShortcutsEnabled = true;
            this.txtNumbers.Size = new System.Drawing.Size(75, 23);
            this.txtNumbers.TabIndex = 0;
            this.txtNumbers.Text = "10";
            this.txtNumbers.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtNumbers.UseSelectable = true;
            this.txtNumbers.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNumbers.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lstSortedNumbers
            // 
            this.lstSortedNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lstSortedNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSortedNumbers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSortedNumbers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.lstSortedNumbers.FormattingEnabled = true;
            this.lstSortedNumbers.Location = new System.Drawing.Point(186, 63);
            this.lstSortedNumbers.Name = "lstSortedNumbers";
            this.lstSortedNumbers.Size = new System.Drawing.Size(120, 275);
            this.lstSortedNumbers.TabIndex = 8;
            // 
            // btnMergeSort
            // 
            this.btnMergeSort.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnMergeSort.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnMergeSort.Location = new System.Drawing.Point(186, 477);
            this.btnMergeSort.Name = "btnMergeSort";
            this.btnMergeSort.Size = new System.Drawing.Size(120, 58);
            this.btnMergeSort.Style = MetroFramework.MetroColorStyle.Red;
            this.btnMergeSort.TabIndex = 9;
            this.btnMergeSort.Text = "MergeSort";
            this.btnMergeSort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnMergeSort.UseSelectable = true;
            this.btnMergeSort.Click += new System.EventHandler(this.btnMergeSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 545);
            this.Controls.Add(this.btnMergeSort);
            this.Controls.Add(this.lstSortedNumbers);
            this.Controls.Add(this.txtNumbers);
            this.Controls.Add(this.btnGenerateNumbers);
            this.Controls.Add(this.lstGeneratedNumbers);
            this.Controls.Add(this.btnBubbleSort);
            this.Controls.Add(this.lblSortTime);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Sorting Program";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LightSlateGray;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSortTime;
        private MetroFramework.Controls.MetroButton btnBubbleSort;
        private System.Windows.Forms.ListBox lstGeneratedNumbers;
        private MetroFramework.Controls.MetroButton btnGenerateNumbers;
        private MetroFramework.Controls.MetroTextBox txtNumbers;
        private System.Windows.Forms.ListBox lstSortedNumbers;
        private MetroFramework.Controls.MetroButton btnMergeSort;
    }
}

