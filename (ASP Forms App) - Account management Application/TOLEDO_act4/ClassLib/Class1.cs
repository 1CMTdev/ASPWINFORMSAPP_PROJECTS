using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassLib
{
    public class Class1
    {


        static string MyConnStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NAMELESS\source\repos\TOLEDO_act4\TOLEDO_act4\Database1.mdf;Integrated Security=True";
        SqlConnection myConn = new SqlConnection(MyConnStr);
        
        static string userAccount;
        static bool isLoggedIn;

        public static string UserAccount { get => userAccount; set => userAccount = value; }
        public static bool IsLoggedIn { get => isLoggedIn; set => isLoggedIn = value; }




        //SQL PROCEDURES

        public void registerAccount(string username, string password)
        {
            myConn.Open();
            SqlCommand regCmd = new SqlCommand("RegisterAccount", myConn);
            regCmd.CommandType = CommandType.StoredProcedure;
            regCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
            regCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
            regCmd.ExecuteNonQuery();
            myConn.Close();
        }


        public bool checkAccount(string username)
        {
            bool found = false;
            myConn.Open();
            SqlCommand readCmd = new SqlCommand("CheckRecords", myConn);
            readCmd.CommandType = CommandType.StoredProcedure;
            readCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
            SqlDataReader dr;
            dr = readCmd.ExecuteReader();

            while (!found && dr.Read())
            {
                found = true;
                UserAccount = dr.GetString(0);
                break;
            }
            myConn.Close();
            return found;
        }

        public bool validateUserAccount(string UserName, string Password)
        {
            bool found = false;
            myConn.Open();
            SqlCommand readCmd = new SqlCommand("ValidateAccount", myConn);
            readCmd.CommandType = CommandType.StoredProcedure;
            readCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
            readCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = Password;
            SqlDataReader dr;
            dr = readCmd.ExecuteReader();

            while (!found && dr.Read())
            {
                found = true;
                UserAccount = dr.GetString(1);
                break;
            }
            myConn.Close();
            return found;
        }



    }
}
