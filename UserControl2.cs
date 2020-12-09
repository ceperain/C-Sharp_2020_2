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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            MemberSearchForm.SendData += new sendGridData(MemberDataLoad);
            Rent_BookSearch.SendData += new sendGridData(RentDataLoad);
        }

        private void RentDataLoad(DataGridView dg)
        {
            dataGridView2.DataSource = dg.DataSource;
        }

        private void MemberDataLoad(DataGridView dg)
        {
            dataGridView1.DataSource = dg.DataSource;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MemberSearch.PopUp();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Rent_BookSearch rent_bookSearch = new Rent_BookSearch();
            rent_bookSearch.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
                textBox6.Text = selectedRow.Cells[2].Value.ToString();
                textBox7.Text = selectedRow.Cells[3].Value.ToString();
                textBox3.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
