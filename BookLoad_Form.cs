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
        public bool select = false;

        public BookLoad_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookManager.Books.Clear(); // 중복 불러오기 방지
            BookManager.Load();

            DataTable table = BookManager.TableMake();

            foreach (var item in BookManager.Books)
            {
                table.Rows.Add(item.Num, item.BookRegisterNumber, item.BookState, item.BookName, item.BookAuthor, item.BookPublish, item.BookSortId, item.BookAuthorId, item.BookCharge, item.BookCopy, item.BookSeperate, item.BookISBN,
                    item.BookLocation, item.BookImport, item.BookPublishDate, item.BookPage, item.BookSize, item.BookPrice, item.BookFullName);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toform1(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            select = !select;
            if (select)
            {
                dataGridView1.SelectAll();
                button3.Text = "선택 해제";
            }
            else
            {
                dataGridView1.ClearSelection();
                button3.Text = "전체 선택";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                textBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }
 
    }
}
