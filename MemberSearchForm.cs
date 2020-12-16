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
    public delegate void sendGridData(DataGridView dg);
    public partial class MemberSearchForm : Form
    {
        public static event sendGridData SendData;
        public MemberSearchForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = "";
                string selected = "";
                if (comboBox1.SelectedItem != null)
                {
                    selected = comboBox1.SelectedItem.ToString();
                }
                Console.WriteLine(selected);
                string tableName = "members";
                string search = "";
                string keyword = textBox1.Text;
                switch (selected)
                {
                    case "회원번호":
                        search = "MemberId";
                        break;
                    case "회원명":
                        search = "MemberName";
                        break;
                    case "회원상태":
                        search = "MemberState";
                        break;
                    case "주소":
                        search = "MemberAdress";
                        break;
                    case "전화번호":
                        search = "MemberPhoneNumber";
                        break;
                    case "이메일":
                        search = "MemberMail";
                        break;
                    default:
                        break;
                }
                Console.WriteLine("search = " + search);

                DataTable table = new DataTable();


                table.Columns.Add("회원번호", typeof(int));
                table.Columns.Add("이름", typeof(string));
                table.Columns.Add("상태", typeof(string));
                table.Columns.Add("주소", typeof(string));
                table.Columns.Add("전화번호", typeof(string));
                table.Columns.Add("이메일", typeof(string));
                table.Columns.Add("가입일", typeof(string));

                foreach (var item in MemberManager.Load(SearchQueryManager.makeSearchQuery(tableName, search, keyword)))
                {
                    table.Rows.Add(item.MemberId, item.MemberName, item.MemberState, item.MemberAdress, item.MemberPhoneNumber, item.MemberMail, item.MemberJoined);
                }
                dataGridView1.DataSource = table;

            }
            catch(Exception ex)
            {
                MessageBox.Show("잘못된 검색입니다");
                //MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendData(dataGridView1);
            //control1.dataGridView1.DataSource = dataGridView1.DataSource;
        }

        
    }
}
