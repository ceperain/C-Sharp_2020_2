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
        public static string myConnection = "datasource=localhost;port=3306;username=root;password=eoghks5953!fjqm1130!";

        public static void Load()
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand("select * bookmanagement.members;", myConn);
                myConn.Open();

                cmd.ExecuteReader();
                myConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static List<Member> Load(string query)
        {
            List<Member> selMembers = new List<Member>();
            try
            {
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
                        MemberJoined = reader["MemberJoined"].ToString().Substring(0, 10)
                    };
                    selMembers.Add(tMem);
                }
                
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
                MySqlConnection myConn = new MySqlConnection(myConnection);
                myConn.Open();
                
                foreach (var item in Members)
                {
                    string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    MySqlCommand cmd = new MySqlCommand(
                        "INSERT INTO bookmanagement.members VALUES(" + item.MemberId + ", '" + item.MemberName + "', '" + item.MemberPhoneNumber + "', '" + item.MemberState + "', '" + item.MemberAdress + "', '" + item.MemberMail + "', '" + date + "' );", myConn); ;
                    cmd.ExecuteNonQuery();
                }
                
                myConn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
