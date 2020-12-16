using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace LibraryManagementSystem
{
    class BookManager
    {

        public static List<Book> Books = new List<Book>();
        public static List<Member> Members = new List<Member>();

        public static void Load()
        {
            try
            {
                string myConnection = DbConn.conn;
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand("select * from bookmanagement.books;", myConn);
                myConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book()
                    {
                        Num = reader.GetInt32(0),
                        BookRegisterNumber = reader.GetInt32(1),
                        BookState = reader.GetString(2),
                        BookName = reader.GetString(3),
                        BookAuthor = reader.GetString(4),
                        BookPublish = reader.GetString(5),
                        BookSortId = reader.GetInt32(6),
                        BookAuthorId = reader.GetString(7),
                        BookCharge = reader.GetString(8),
                        BookCopy = reader.GetString(9),
                        BookSeperate = reader.GetString(10),
                        BookISBN = reader.GetInt32(11),
                        BookLocation = reader.GetString(12),
                        BookImport = reader.GetString(13),
                        BookPublishDate = reader.GetString(14),
                        BookPage = reader.GetString(15),
                        BookSize = reader.GetString(16),
                        BookPrice = reader.GetString(17),
                        BookFullName = reader.GetString(18),
                    };
                    BookManager.Books.Add(book);
                }
                MessageBox.Show("데이터를 불러왔습니다!!!!");
                reader.Close();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 불러올 수 없습니다!!!!");
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * 테스트 중인 코드
         */
        public static List<Book> Load(string query)
        {
            List<Book> selBooks = new List<Book>();
            try
            {
                string myConnection = DbConn.conn;
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(query, myConn);
                myConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book tBook = new Book()
                    {
                        Num = (int)reader["Num"],
                        BookRegisterNumber = (int)reader["BookRegisterNumber"],
                        BookState = (string) reader["BookState"],
                        BookName = (string) reader["BookName"],
                        BookAuthor = (string) reader["BookAuthor"],
                        BookPublish = (string) reader["BookPublish"],
                        BookSortId = (int) reader["BookSortId"],
                        BookAuthorId = (string) reader["BookAuthorId"],
                        BookCharge = (string) reader["BookCharge"],
                        BookCopy = (string) reader["BookCopy"],
                        BookSeperate = (string) reader["BookSeperate"],
                        BookISBN = (int) reader["BookISBN"],
                        BookLocation = (string) reader["BookLocation"],
                        BookImport = (string) reader["BookImport"],
                        BookPublishDate = (string) reader["BookPublishDate"],
                        BookPage = (string) reader["BookPage"],
                        BookSize = (string) reader["BookSize"],
                        BookPrice = (string) reader["BookPrice"],
                        BookFullName = (string) reader["FullName"]

                    };
                    selBooks.Add(tBook);
                }

                reader.Close();
                myConn.Close();
                return selBooks;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /*
         */




        public static void Save()
        {
            try
            {
                string myConnection = DbConn.conn;
                //string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                foreach (var item in Books)
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO bookmanagement.books VALUES(" + item.Num + ", " + item.BookRegisterNumber + ", '" + item.BookState + "', '" + item.BookName + "', '" + item.BookAuthor + "', '" + item.BookPublish + "', " +
                        item.BookSortId + ", '" + item.BookAuthorId + "', '" + item.BookCharge + "', '" + item.BookCopy + "', '" + item.BookSeperate + "', " + item.BookISBN + ", '" + item.BookLocation + "', '" + item.BookImport + "', '" +
                        item.BookPublishDate + "', '" + item.BookPage + "', '" + item.BookSize + "', '" + item.BookPrice + "', '" + item.BookFullName + "')", myConn);
                    cmd.ExecuteNonQuery();
                }
                myConn.Close();
                MessageBox.Show("데이터베이스에 저장했습니다!!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("이미 존재하는 도서입니다!!!!");
            }         
        }

        public static DataTable TableMake()
        {
            DataTable table = new DataTable();

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
            table.Columns.Add("출판년도", typeof(string));
            table.Columns.Add("페이지", typeof(string));
            table.Columns.Add("사이즈", typeof(string));
            table.Columns.Add("가격", typeof(string));
            table.Columns.Add("총도서명", typeof(string));

            return table;
        }

    }
}
