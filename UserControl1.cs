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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            MemberSearchForm.ToControl += new toControl(dataLoad);
        }

        private void dataLoad(DataGridView dg)
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
    }
}
