using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }

        //저장버튼
        private void button7_Click(object sender, EventArgs e)
        {
            
            Member member = new Member()
            {
                MemberId = int.Parse(mId.Text),
                MemberName = mName.Text,
                MemberPhoneNumber = mPhone.Text,
                MemberState = mState.SelectedItem.ToString(),
                MemberAdress = mAdress.Text,
                MemberMail = mMail.Text,
                MemberJoined = DateTime.Now.ToString()
            };
            MemberManager.Members.Add(member);
            MemberManager.Save();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
