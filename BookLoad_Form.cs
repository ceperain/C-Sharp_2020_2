using System;
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
    public delegate void toForm1(DataGridView dg);
    public partial class BookLoad_Form : Form
    {
        public static event toForm1 toform1;
        public BookLoad_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookManager.Books.Clear();
            BookManager.Load();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BookManager.Books;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toform1(dataGridView1);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
