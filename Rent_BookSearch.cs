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
    
    public partial class Rent_BookSearch : Form
    {
        public static event sendGridData SendData;
        public Rent_BookSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            string selected = "";
            if (comboBox1.SelectedItem != null)
            {
                selected = comboBox1.SelectedItem.ToString();
            }

            Console.WriteLine(selected);

            string tableName = "books";
            string search = "";
            string keyword = textBox1.Text;

            switch (selected)
            {
                case "등록번호":
                    search = "Where BookRegisterNumber";
                    break;
                case "서명":
                    search = "Where BookName";
                    break;
                case "총서명":
                    search = "Where BookFullName";
                    break;
                case "저자":
                    search = "Where BookAuthor";
                    break;
                default:
                    break;
            }

            DataTable table = new DataTable();
            /*
             * 순번        books
             * 도서상태     books
             * 등록번호     books
             * 도서명       books
             * 저자        books
             * 청구기호     books
             * 대출일자     ? - rent
             * 반납일자     ? - rent
             * 대출자      members
             * 예약자      members - 미사용
             * 소장위치     books
             * 반입구분     books
             * 등록일      books

             */

            //book
            table.Columns.Add("순번", typeof(int));
            table.Columns.Add("도서상태", typeof(string));
            table.Columns.Add("등록번호", typeof(int));
            table.Columns.Add("도서명", typeof(string));
            table.Columns.Add("저자", typeof(string));        
//            table.Columns.Add("청구기호", typeof(string));//미사용
            //rent
            table.Columns.Add("대출일자", typeof(string));
            table.Columns.Add("반납일자", typeof(string));
            table.Columns.Add("대출자", typeof(string));

//            table.Columns.Add("예약자", typeof(string));//미사용
            table.Columns.Add("소장위치", typeof(string));
            table.Columns.Add("반입구분", typeof(string));
            table.Columns.Add("등록일", typeof(string));

            /*
             * 수정 중
             */
            foreach (var item in BookManager.Load(SearchQueryManager.makeSearchQuery(tableName, search, keyword)))
            {
                Rent r;
                table.Rows.Add(item.Num, item.BookState, item.BookRegisterNumber, item.BookName, item.BookAuthor);
            }
            /*
             * 
             */
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
