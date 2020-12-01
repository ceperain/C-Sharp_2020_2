﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Base_Form : Form
    {
        public Base_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl1 userControl1 = new UserControl1();
            panel1.Controls.Add(userControl1);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl2 userControl2 = new UserControl2();
            panel1.Controls.Add(userControl2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl4 userControl = new UserControl4();
            panel1.Controls.Add(userControl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            UserControl7 userControl = new UserControl7();
            panel2.Controls.Add(userControl);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UserControl3 userControl = new UserControl3();
            panel1.Controls.Add(userControl);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Check_Form form = new Check_Form();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BookSearch bookSearchForm = new BookSearch();
            bookSearchForm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BarcodePrint barcodePrint = new BarcodePrint();
            barcodePrint.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BookInformation bookInformation = new BookInformation();
            bookInformation.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SignPrint signPrint = new SignPrint();
            signPrint.Show();
        }
    }
}
