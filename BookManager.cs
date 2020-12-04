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
                string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from bookmanagement.books;", myConn);
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
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Save()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                foreach (var item in Books)
                {
                    int num = item.Num;
                    int brn = item.BookRegisterNumber;
                    string bs = item.BookState;
                    string bn = item.BookName;
                    string ba = item.BookAuthor;
                    string bp = item.BookPublish;
                    int bsi = item.BookSortId;
                    string bai = item.BookAuthorId;
                    string bc = item.BookCharge;
                    string bc2 = item.BookCopy;
                    string bs2 = item.BookSeperate;
                    int bisbn = item.BookISBN;
                    string bl = item.BookLocation;
                    string bi = item.BookImport;
                    string bpd = item.BookPublishDate;
                    string bp2 = item.BookPage;
                    string bs3 = item.BookSize;
                    string bp3 = item.BookPrice;
                    string bfn = item.BookFullName;
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO bookmanagement.books VALUES(" + num + ", " + brn + ", '" + bs + "', '" + bn + "', '" + ba + "', '" + bp + "', '" + 
                        bsi + "', " + bai + ", '" + bc + "', '" + bc2 + "', '" + bs2 + "', " + bisbn + ", '" + bl + "', '" + bi + "', '" + bpd + "', '" + bp2 + "', '" +
                        bs3 + "', '" + bp3 + "', '" + bfn + "')", myConn);
                    cmd.ExecuteNonQuery();
                }
                myConn.Close();
                MessageBox.Show("데이터베이스에 저장했습니다!!!!");
            }
            catch (Exception e)
            {
                MessageBox.Show("문제가 발생했습니다!!!!");
                MessageBox.Show(e.Message);
            }
            
        }

    }
}
