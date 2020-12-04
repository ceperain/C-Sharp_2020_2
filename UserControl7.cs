using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class UserControl7 : UserControl
    {

        public int variable = 1;
        DataTable table = new DataTable();
        int selectedRow;
        string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";

        public UserControl7()
        {
            InitializeComponent();
            BookLoad_Form.toform1 += new toForm1(dataLoad);
        }

        void dataLoad(DataGridView dg)
        {
            dataGridView1.DataSource = dg.DataSource;
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
            table.Columns.Add("ISBN", typeof(long));
            table.Columns.Add("소장위치", typeof(string));
            table.Columns.Add("반입구분", typeof(string));
            table.Columns.Add("출판년도", typeof(string));
            table.Columns.Add("페이지", typeof(string));
            table.Columns.Add("사이즈", typeof(string));
            table.Columns.Add("가격", typeof(string));
            table.Columns.Add("총도서명", typeof(string));

            dataGridView1.DataSource = table;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int isnum = 0;
            if (txtISBN.Text == "")
            {
                MessageBox.Show("ISBN을 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("도서명을 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtAuthor.Text == "")
            {
                MessageBox.Show("저자를 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtPublish.Text == "")
            {
                MessageBox.Show("출판사를 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtSortId.Text == "")
            {
                MessageBox.Show("분류기호를 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtAuthorId.Text == "")
            {
                MessageBox.Show("저자기호를 입력해주세요!!!!", "필수항목 누락");
            }
            else if (txtRegisterNumber.Text == "")
            {
                MessageBox.Show("등록번호를 입력해주세요!!!!", "필수항목 누락");
            }
            else if (!(int.TryParse(txtISBN.Text, out isnum)))
            {
                MessageBox.Show("ISBN는 숫자만 입력해주세요!!!!", "필수항목 누락");
            }
            else if (!(int.TryParse(txtSortId.Text, out isnum)))
            {
                MessageBox.Show("분류기호는 숫자만 입력해주세요!!!!", "필수항목 누락");
            }
            else if (!(int.TryParse(txtRegisterNumber.Text, out isnum)))
            {
                MessageBox.Show("등록번호는 숫자만 입력해주세요!!!!", "필수항목 누락");
            }
            else
            {
                Book book = new Book()
                {
                    Num = variable++,
                    BookRegisterNumber = int.Parse(txtRegisterNumber.Text),
                    BookState = cbState.Text,
                    BookName = txtName.Text,
                    BookAuthor = txtAuthor.Text,
                    BookPublish = txtPublish.Text,
                    BookSortId = int.Parse(txtSortId.Text),
                    BookAuthorId = txtAuthorId.Text,
                    BookCharge = txtCharge.Text,
                    BookCopy = txtCopy.Text,
                    BookSeperate = txtSeperate.Text,
                    BookISBN = int.Parse(txtISBN.Text),
                    BookLocation = cbLocation.Text,
                    BookImport = cbImport.Text,
                    BookPublishDate = txtPublishDate.Text,
                    BookPage = txtPage.Text,
                    BookSize = txtSize.Text,
                    BookPrice = txtPrice.Text,
                    BookFullName = txtFullName.Text
                };

                BookManager.Books.Add(book);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BookManager.Books;

                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO bookmanagement.books VALUES(" + book.Num + ", " + book.BookRegisterNumber + ", '" + book.BookState + "', '" + book.BookName + "', '" + book.BookAuthor + "', '" + book.BookPublish + "', " +
                        book.BookSortId + ", '" + book.BookAuthorId + "', '" + book.BookCharge + "', '" + book.BookCopy + "', '" + book.BookSeperate + "', " + book.BookISBN + ", '" + book.BookLocation + "', '" + book.BookImport + "', '" + 
                        book.BookPublishDate + "', '" + book.BookPage + "', '" + book.BookSize + "', '" + book.BookPrice + "', '" + book.BookFullName + "')", myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("도서를 저장했습니다!!!!");
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = BookManager.Books.Single((x) => x.BookRegisterNumber == long.Parse(txtRegisterNumber.Text));
                book.BookRegisterNumber = int.Parse(txtRegisterNumber.Text);
                book.BookState = cbState.Text;
                book.BookName = txtName.Text;
                book.BookAuthor = txtAuthor.Text;
                book.BookPublish = txtPublish.Text;
                book.BookSortId = int.Parse(txtSortId.Text);
                book.BookAuthorId = txtAuthorId.Text;
                book.BookCharge = txtCharge.Text;
                book.BookCopy = txtCopy.Text;
                book.BookSeperate = txtSeperate.Text;
                book.BookISBN = int.Parse(txtISBN.Text);
                book.BookLocation = cbLocation.Text;
                book.BookImport = cbImport.Text;
                book.BookPublishDate = txtPublishDate.Text;
                book.BookPage = txtPage.Text;
                book.BookSize = txtSize.Text;
                book.BookPrice = txtPrice.Text;
                book.BookFullName = txtFullName.Text;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BookManager.Books;

                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE bookmanagement.books SET BookState = '" + book.BookState + "', BookName = '" + book.BookName + "', BookAuthor = '" + book.BookAuthor + "', BookPublish = '" + book.BookPublish +
                    "', BookSortId = " + book.BookSortId + ", BookAuthorId = '" + book.BookAuthorId + "', BookCharge = '" + book.BookCharge + "', BookCopy = '" + book.BookCopy + "', BookSeperate = '" + book.BookSeperate +
                    "', BookISBN = " + book.BookISBN + ", BookLocation = '" + book.BookLocation + "', BookImport = '" + book.BookImport + "', BookPublishDate = '" + book.BookPublishDate +
                    "', BookPage = '" + book.BookPage + "', BookSize = '" + book.BookSize + "', BookPrice = '" + book.BookPrice + "', FullName = '" + book.BookFullName + "' WHERE BookRegisterNumber = " + book.BookRegisterNumber, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("도서를 수정했습니다!!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("존재하지 않는 도서입니다!!!!");
            }
            
        }


        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = BookManager.Books.Single((x) => x.BookRegisterNumber == int.Parse(txtRegisterNumber.Text));
                BookManager.Books.Remove(book);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BookManager.Books;

                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM bookmanagement.books WHERE BookRegisterNumber = " + book.BookRegisterNumber, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();

                MessageBox.Show("도서를 삭제했습니다!!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("존재하지 않는 도서입니다!!!!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedRow];
            txtRegisterNumber.Text = row.Cells[1].Value.ToString();
            cbState.Text = row.Cells[2].Value.ToString();
            txtName.Text = row.Cells[3].Value.ToString();
            txtAuthor.Text = row.Cells[4].Value.ToString();
            txtPublish.Text = row.Cells[5].Value.ToString();
            txtSortId.Text = row.Cells[6].Value.ToString();
            txtAuthorId.Text = row.Cells[7].Value.ToString();
            txtCharge.Text = row.Cells[8].Value.ToString();
            txtCopy.Text = row.Cells[9].Value.ToString();
            txtSeperate.Text = row.Cells[10].Value.ToString();
            txtISBN.Text = row.Cells[11].Value.ToString();
            cbLocation.Text = row.Cells[12].Value.ToString();
            cbImport.Text = row.Cells[13].Value.ToString();
            txtPublishDate.Text = row.Cells[14].Value.ToString();
            txtPage.Text = row.Cells[15].Value.ToString();
            txtSize.Text = row.Cells[16].Value.ToString();
            txtPrice.Text = row.Cells[17].Value.ToString();
            txtFullName.Text = row.Cells[18].Value.ToString();
        }

    }
}
