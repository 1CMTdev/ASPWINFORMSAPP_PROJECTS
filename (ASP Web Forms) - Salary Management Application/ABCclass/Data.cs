using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ABCclass
{
    public class Data
    {


        static string xemail = "";
 
      
        static double xmsal = 0;
        static double xmonthto = 0; //input
        static double xloanamm = 0;
        static double xinterest = 0;
        static double xthml = 0;
        static double xserv = 0;
        static double xmoarm = 0;





        static string myConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NAMELESS\Desktop\C\VS2019\TOLEDO_SlaryLoanWeb\WebApplication1\App_Data\Database1.mdf;Integrated Security=True";
        SqlConnection myConn = new SqlConnection(myConStr);

        public static double Xmsal { get => xmsal; set => xmsal = value; }
        public static double Xmonthto { get => xmonthto; set => xmonthto = value; }
        public static double Xloanamm { get => xloanamm; set => xloanamm = value; }
        public static double Xinterest { get => xinterest; set => xinterest = value; }
        public static double Xthml { get => xthml; set => xthml = value; }
        public static double Xserv { get => xserv; set => xserv = value; }
        public static double Xmoarm { get => xmoarm; set => xmoarm = value; }
        public static string Xemail { get => xemail; set => xemail = value; }
   

        public void SaveRecords(string pangalan, string num, string em, string px)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("SaveRec", myConn);
            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = pangalan;
            saveCmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar).Value = num;
            saveCmd.Parameters.Add("@Email", SqlDbType.NChar).Value = em;
            saveCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = px;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
            Xemail = em;


        }

        public DataSet DisplayMyRecords()
        {
            SqlDataAdapter da = new SqlDataAdapter("DisplayRecords", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "myRecords");
            return ds;
        }


       


        public bool CheckUserAccount(string em, string pa)
        {
            bool found = false;
            Xemail = em;
            myConn.Open();
            SqlCommand readCmd = new SqlCommand("CheckUserAccount", myConn);
            readCmd.CommandType = CommandType.StoredProcedure;
            readCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = em;
            readCmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = pa;
            SqlDataReader dr;
            dr = readCmd.ExecuteReader();

            while (dr.Read())
            {
                found = true;
                Xloanamm = dr.GetDouble(6);
                Xinterest = dr.GetDouble(7);
                Xthml = dr.GetDouble(8);
                Xserv = dr.GetDouble(9);
                Xmoarm = dr.GetDouble(10);
                break;
            }
            myConn.Close();
            return found;
        }


        public void computerx(double XMSAL, double XMONTHTO)
        {
            Xmsal = XMSAL;
            Xmonthto = XMONTHTO;



            Xloanamm = Xmsal * 2.5;

            if(Xmonthto>=1 && Xmonthto<=5)
            Xinterest = Xloanamm * Xmonthto * 0.0062;
            else if(Xmonthto >= 6 && Xmonthto <= 10)
            Xinterest = Xloanamm * Xmonthto * 0.0065;
            else if (Xmonthto >= 11 && Xmonthto <= 15)
            Xinterest = Xloanamm * Xmonthto * 0.0068;
            else if (Xmonthto >= 16 && Xmonthto <= 20)
            Xinterest = Xloanamm * Xmonthto * 0.0075;
            else if (Xmonthto >= 21 && Xmonthto <= 25)
            Xinterest = Xloanamm * Xmonthto * 0.0080;

            Xserv = 0.02 * Xloanamm;
            Xthml = Xinterest + Xserv;
            Xmoarm = Xloanamm / Xmonthto;



            myConn.Open();
            SqlCommand updateCmd = new SqlCommand("UpdateMyRecord", myConn);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.Add("@BasicSal", SqlDbType.Float).Value = Xmsal;
            updateCmd.Parameters.Add("@NumMonthsToPay", SqlDbType.Int).Value = Xmonthto;
            updateCmd.Parameters.Add("@LoanAmount", SqlDbType.Float).Value = Xloanamm;
            updateCmd.Parameters.Add("@Interest", SqlDbType.Float).Value = Xinterest;
            updateCmd.Parameters.Add("@TakeHome", SqlDbType.Float).Value = Xthml;
            updateCmd.Parameters.Add("@Service", SqlDbType.Float).Value = Xserv;
            updateCmd.Parameters.Add("@MonthlyAm", SqlDbType.Float).Value = Xmoarm;
            updateCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Xemail;
            updateCmd.ExecuteNonQuery();
            myConn.Close();




        }


        public void reset()
        {
            Xemail = "";
           Xmsal = 0;
            Xmonthto = 0; 
             Xloanamm = 0;
            Xinterest = 0;
             Xthml = 0;
             Xserv = 0;
            Xmoarm = 0;
        }








    }
}
