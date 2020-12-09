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
                        //insert문 내용 추가할것.
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
    }
}
