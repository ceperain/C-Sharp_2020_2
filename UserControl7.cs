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
    public partial class UserControl7 : UserControl
    {

        public static List<Books> Books = new List<Books>();

        public UserControl7()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        int selectedRow;

        private void UserControl7_Load(object sender, EventArgs e)
        {
            table.Columns.Add("순번", typeof(int));
            table.Columns.Add("등록번호", typeof(int));
            table.Columns.Add("도서상태", typeof(string));
            table.Columns.Add("도서명", typeof(string));
            table.Columns.Add("저자", typeof(string));
            table.Columns.Add("출판사", typeof(string));
            table.Columns.Add("분류기호", typeof(int));
            table.Columns.Add("저자기호", typeof(string));
            table.Columns.Add("권차", typeof(string));
            table.Columns.Add("복본", typeof(string));
            table.Columns.Add("별치", typeof(string));
            table.Columns.Add("ISBN", typeof(int));
            table.Columns.Add("소장위치", typeof(string));
            table.Columns.Add("반입구분", typeof(string));

            dataGridView1.DataSource = table;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Books book = new Books()
            {
                BookRegisterNumber = int.Parse(txtRegisterNumber.Text), BookState = cbState.Text, BookName = txtName.Text, BookAuthor = txtAuthor.Text,
                BookPublish = txtPublish.Text, BookNameId = int.Parse(txtNameId.Text), BookAuthorId = txtAuthorId.Text, BookBox = txtBox.Text,
                BookCopy = txtCopy.Text, BookSeperate = txtSeperate.Text, BookISBN = int.Parse(txtISBN.Text),
                BookLocation = cbLocation.Text, BookImport = cbImport.Text
            };


        }

    }
}
