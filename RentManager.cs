using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagementSystem
{
    class RentManager
    {
        /*
         * save에서 Rent를 쓰기 위함.
         * 대체할 방법을 생각해보는것도 괜찮다.
         */
        public static List<Rent> Rent_M = new List<Rent>();

        public static List<Rent> Load(string query)
        {
            //출력(return)할 rent
            List<Rent> oRent = new List<Rent>();
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(query, myConn);
                myConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //oRent에 추가할 임시 rent
                    Rent tRent = new Rent()
                    {
                        MemberId = (int) reader["MemberId"],
                        BookRegisterNumber = (int) reader["BookRegisterNumber"],
                        Rent_Date = reader["Rent_Date"].ToString().Substring(0, 10),
                        Rent_Date_Last = reader["Rent_Date_Last"].ToString().Substring(0, 10)
                    };
                    oRent.Add(tRent);
                }

                //MessageBox.Show("연결됐습니다.");
                reader.Close();
                myConn.Close();
                return oRent;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void Save()
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                //string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();

                foreach (var item in Rent_M)
                {
                    string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    DateTime d = DateTime.Today.AddDays(7);
                    string date_last = d.Year + "-" + d.Month + "-" + d.Day;
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO bookmanagement.rent VALUES(" + item.MemberId + ", " + item.BookRegisterNumber + ", '" + date + "', '" + date_last + "' );", myConn); ;
                    cmd.ExecuteNonQuery();
                }

                myConn.Close();
                //MessageBox.Show("데이터베이스에 저장했습니다!!!!");
            }
            catch (Exception e)
            {
                MessageBox.Show("문제가 발생했습니다!!!!");
                MessageBox.Show(e.Message);
            }
        }

        //BookRegisterNumber / MemberId
        public static void RentBook(int rBookRN, int rMemberId)
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                //string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                bool chkBook = false;
                bool chkMember = false;
                bool rentAble = false;
                myConn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    SearchQueryManager.makeSearchQuery("books", "BookRegisterNumber", rBookRN.ToString()), myConn);
                MySqlDataReader reader_Book = cmd.ExecuteReader();
                if (!reader_Book.Read())
                {
                    chkBook = false;
                    MessageBox.Show("해당 책이 존재하지 않습니다.");
                }
                else if(((string)reader_Book["BookState"]).Equals("대출가능"))
                {
                    MessageBox.Show("111");
                    chkBook = true;
                    rentAble = true;
                }
                reader_Book.Close();

                cmd = new MySqlCommand(
                    SearchQueryManager.makeSearchQuery("members", "MemberId", rMemberId.ToString()), myConn);
                MySqlDataReader reader_Member = cmd.ExecuteReader();
                if (reader_Member != null)
                { 
                    chkMember = true;
                }
                else
                {
                    MessageBox.Show("존재하지 않는 회원번호 입니다.");
                }
                reader_Member.Close();

                if(chkBook && chkMember && rentAble)
                {
                    string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    DateTime d = DateTime.Today.AddDays(7);
                    string date_last = d.Year + "-" + d.Month + "-" + d.Day;
                    MySqlCommand cmdr = new MySqlCommand(
                        "INSERT INTO bookmanagement.rent VALUES(" + rMemberId + ", " + rBookRN + ", '" + date + "', '" + date_last + "' );", myConn);
                    MySqlCommand cmdb = new MySqlCommand(
                        "UPDATE bookmanagement.books SET BookState='대출중' WHERE BookRegisterNumber=" + rBookRN + ";", myConn);
                    cmdr.ExecuteNonQuery();
                    cmdb.ExecuteNonQuery();
                    MessageBox.Show("도서 대출 성공");
                }
                else if(!rentAble)
                {
                    MessageBox.Show("현재 대출이 불가능합니다.");
                }
                myConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("문제가 발생했습니다!!!!");
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(e.Message);
            }
        }


        //책 반납.
        public static void ReturnBook(int rBookRN, int rMemberId)
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                bool chkBook = false;
                bool chkMember = false;
                myConn.Open();
                
                //이 책은 반납할 수 있는 책인가? - rent에서 일치 검색.
                MySqlCommand cmd = new MySqlCommand(
                    SearchQueryManager.makeSearchQuery("rent", "BookRegisterNumber", rBookRN.ToString()),myConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    chkBook = true;
                }
                else
                {
                    MessageBox.Show("대출중인 책이 아닙니다.");
                }
                reader.Close();
                
                cmd = new MySqlCommand(
                    SearchQueryManager.makeSearchQuery("rent", "MemberId", rMemberId.ToString()), myConn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    chkMember = true;
                }
                else
                {
                    MessageBox.Show("error manager 190");
                }
                reader.Close();
                if(chkBook && chkMember)
                {
                    MySqlCommand cmdDel = new MySqlCommand(
                        "Delete from bookmanagement.rent where MemberId=" + rMemberId + " and BookRegisterNumber=" + rBookRN + " ;", myConn);
                    MySqlCommand cmdStat = new MySqlCommand(
                        "UPDATE bookmanagement.books SET BookState='대출가능' WHERE BookRegisterNumber=" + rBookRN + ";", myConn);
                    cmdDel.ExecuteNonQuery();
                    cmdStat.ExecuteNonQuery();
                    MessageBox.Show("도서 반납 성공");
                }
                myConn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(e.Message);
            }
        }
    }
}
