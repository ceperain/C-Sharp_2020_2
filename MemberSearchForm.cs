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
    public partial class MemberSearchForm : Form
    {
        public MemberSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = "";
            if(comboBox1.SelectedItem.ToString() != null)
            {
                selected = comboBox1.SelectedItem.ToString();
            }
            
            string search = "";
            string keyword = textBox1.Text;
            switch(selected)
            {
                case "회원번호":
                    search = "Where MemberId";
                    break;
                case "회원명":
                    search = "Where MemberName";
                    break;
                case "회원상태":
                    search = "Where MemberState";
                    break;
                case "주소":
                    search = "Where MemberAdress";
                    break;
                case "전화번호":
                    search = "Where MemberPhoneNumber";
                    break;
                case "이메일":
                    search = "Where MemberMail";
                    break;
                default:
                    break;
            }
            MemberManager.Load(MemberSearch.searchQuery(keyword, search));
        }
    }
}
