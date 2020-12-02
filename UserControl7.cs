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

        public static List<Books> Book = new List<Books>();
        public int variable = 1;
        DataTable table = new DataTable();
        int selectedRow;

        public UserControl7()
        {
            InitializeComponent();
        }

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

            Book.Add(new Books()
            {
                Num = variable,
                BookRegisterNumber = int.Parse(txtRegisterNumber.Text),
                BookState = cbState.Text,
                BookName = txtName.Text,
                BookAuthor = txtAuthor.Text,
                BookPublish = txtPublish.Text,
                BookNameId = int.Parse(txtNameId.Text),
                BookAuthorId = txtAuthorId.Text,
                BookBox = txtBox.Text,
                BookCopy = txtCopy.Text,
                BookSeperate = txtSeperate.Text,
                BookISBN = int.Parse(txtISBN.Text),
                BookLocation = cbLocation.Text,
                BookImport = cbImport.Text
            });

            table.Rows.Add(variable++, int.Parse(txtRegisterNumber.Text), cbState.Text, txtName.Text, txtAuthor.Text, txtPublish.Text, int.Parse(txtNameId.Text),
                txtAuthorId.Text, txtBox.Text, txtCopy.Text, txtSeperate.Text, int.Parse(txtISBN.Text), cbLocation.Text, cbImport.Text);

            dataGridView1.DataSource = table;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRow);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtRegisterNumber.Text = row.Cells[0].Value.ToString();
            cbState.Text = row.Cells[1].Value.ToString();
            txtName.Text = row.Cells[2].Value.ToString();
            txtAuthor.Text = row.Cells[3].Value.ToString();
            txtPublish.Text = row.Cells[4].Value.ToString();
            txtNameId.Text = row.Cells[5].Value.ToString();
            txtAuthorId.Text = row.Cells[6].Value.ToString();
            txtBox.Text = row.Cells[7].Value.ToString();
            txtCopy.Text = row.Cells[8].Value.ToString();
            txtSeperate.Text = row.Cells[9].Value.ToString();
            txtISBN.Text = row.Cells[10].Value.ToString();
            cbLocation.Text = row.Cells[11].Value.ToString();
            cbImport.Text = row.Cells[12].Value.ToString();
        }

        private void txtPublishDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
