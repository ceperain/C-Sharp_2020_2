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
    public delegate void toControl(DataGridView dg);
    public partial class MemberSearchForm : Form
    {
        public static event toControl ToControl;
        public MemberSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            string selected = "";
            selected = comboBox1.SelectedItem.ToString();
            Console.WriteLine(selected);
            
            string search = "";
            string keyword = textBox1.Text;
            
            switch (selected)
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
            Console.WriteLine("search = " + search);

            DataTable table = new DataTable();


            table.Columns.Add("회원번호", typeof(Int32));
            table.Columns.Add("이름", typeof(string));
            table.Columns.Add("상태", typeof(string));
            table.Columns.Add("주소", typeof(string));
            table.Columns.Add("전화번호", typeof(string));
            table.Columns.Add("이메일", typeof(string));
            table.Columns.Add("가입일", typeof(string));

            foreach (var item in MemberManager.Load(MemberSearch.searchQuery(keyword, search)))
            {
                table.Rows.Add(item.MemberId, item.MemberName, item.MemberState, item.MemberAdress, item.MemberPhoneNumber, item.MemberMail, item.MemberJoined);
            }
            dataGridView1.DataSource = table;
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToControl(dataGridView1);
            //control1.dataGridView1.DataSource = dataGridView1.DataSource;
        }

        
    }
}
