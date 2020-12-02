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
