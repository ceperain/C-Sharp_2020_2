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
    class MemberManager
    {

        public static List<Member> Members = new List<Member>();

        public static void Load()
        {
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand("select * bookmanagement.members;", myConn);
                myConn.Open();

                cmd.ExecuteReader();
                //MessageBox.Show("연결됐습니다.");
                myConn.Close();
            }
            catch (Exception)
            {
                
            }
        }
        public static List<Member> Load(string query)
        {
            List<Member> selMembers = new List<Member>();
            try
            {
                string myConnection = "datasource=127.0.0.1;port=3306;username=root;password=jh123456";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(query, myConn);
                myConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Member tMem = new Member()
                    {
                        MemberId = (int)reader["MemberId"],
                        MemberName = (string)reader["MemberName"],
                        MemberPhoneNumber = (string)reader["MemberPhoneNumber"],
                        MemberState = (string)reader["MemberState"],
                        MemberAdress = (string)reader["MemberAdress"],
                        MemberMail = (string)reader["MemberMail"],
                        MemberJoined = reader["MemberJoined"].ToString()
                    };
                    selMembers.Add(tMem);
                }
                
                //MessageBox.Show("연결됐습니다.");
                reader.Close();
                myConn.Close();
                return selMembers;

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
                
                foreach (var item in Members)
                {
                    string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO bookmanagement.members VALUES(" + item.MemberId + ", '" + item.MemberName + "', '" + item.MemberPhoneNumber + "', '" + item.MemberState + "', '" + item.MemberAdress + "', '" + item.MemberMail + "', '" + date + "' );", myConn); ;
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
