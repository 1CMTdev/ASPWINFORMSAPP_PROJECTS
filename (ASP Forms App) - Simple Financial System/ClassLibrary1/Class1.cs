using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassLibrary1
{
    public class Class1
    {
        static string myConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\NAMELESS\source\repos\toledocasestudy\toledocasestudy\master.mdf;Integrated Security=True";
        SqlConnection myConn = new SqlConnection(myConStr);

        static string curAccNo;
        static string curAccT;
        static string curBal;
        static string curReceiver;
        static string curMensahe;
        

        public static string CurAccNo { get => curAccNo; set => curAccNo = value; }
        public static string CurAccT { get => curAccT; set => curAccT = value; }
        public static string CurBal { get => curBal; set => curBal = value; }
        public static string CurReceiver { get => curReceiver; set => curReceiver = value; }
        public static string CurMensahe { get => curMensahe; set => curMensahe = value; }



        /***********************STORED*****************************************************************/

        //Login procedure
        public bool Loginer(string em, string pa)
        {
            bool found = false;
            myConn.Open();
            SqlCommand readCmd = new SqlCommand("Login", myConn);
            readCmd.CommandType = CommandType.StoredProcedure;
            readCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = em;
            readCmd.Parameters.Add("@PassWord", SqlDbType.NVarChar).Value = pa;
            SqlDataReader dr;
            dr = readCmd.ExecuteReader();
            while (dr.Read())
            {
                found = true;
                CurAccT = dr.GetString(5);
                CurBal = dr.GetString(6);
                break;
            }
            myConn.Close();
            CurAccNo = em;
            return found;  
        }


        //Create account
        public void Creater(string x1, string x2, string x3, string x4, string x5, string x6,string x7)
        {

            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("AccRegistration", myConn);
            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = x1;
            saveCmd.Parameters.Add("@First", SqlDbType.NVarChar).Value = x2;
            saveCmd.Parameters.Add("@Last", SqlDbType.NVarChar).Value = x3;
            saveCmd.Parameters.Add("@Em", SqlDbType.NVarChar).Value = x4;
            saveCmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = x5;
            saveCmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = x6;
            saveCmd.Parameters.Add("@Bal", SqlDbType.NVarChar).Value = x7;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
        }



        //Save Transaction
        public void Transactioner(string x1, string x2, string x3, string x4)
        {
            myConn.Open();
            SqlCommand saveCmd = new SqlCommand("Transave", myConn);
            saveCmd.CommandType = CommandType.StoredProcedure;
            saveCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = x1;
            saveCmd.Parameters.Add("@T", SqlDbType.NVarChar).Value = x2;
            saveCmd.Parameters.Add("@Am", SqlDbType.NVarChar).Value = x3;
            saveCmd.Parameters.Add("@D", SqlDbType.NVarChar).Value = x4;
            saveCmd.ExecuteNonQuery();
            myConn.Close();
  
        }

        //ViewTra
        public DataTable Viewtra()
        {
            SqlDataAdapter da = new SqlDataAdapter("Viewtra", myConn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = CurAccNo;
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }



        //Update Balance
        public void balancer(string acc, string balanse)
        {
            myConn.Open();
            SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = acc;
            updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = balanse;
            updateCmd.ExecuteNonQuery();
            myConn.Close();
        }



        /********************TRANSACTIONS************************************************/


        public string generatorist(string f, string l)
        {
            string x;
            f = f.ToUpper();
            l = l.ToUpper();
            x = "" + f[0] + l[0];
            Random rnd = new Random();
            x = x + rnd.Next(1000000, 10000000).ToString();
            return x;
        }

        public bool depositorist(string pera)
        {
            bool found = false;
            double x= Convert.ToDouble(pera);
            double y = Convert.ToDouble(CurBal);
            if (x >= 500)
            {
                y = y + x;
                CurBal = y.ToString();


                myConn.Open();
                SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
                updateCmd.CommandType = CommandType.StoredProcedure;
                updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurAccNo;
                updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = CurBal;
                updateCmd.ExecuteNonQuery();
                myConn.Close();
                found = true;
                CurMensahe = "Deposit Transaction - " + x + " PHP";
            }
            else found = false;

            return found;
        }



        public string withrawist(string pera)
        {
            string found = "";
            double x = Convert.ToDouble(pera);
            double y = Convert.ToDouble(CurBal);
            if (x >= 200)
            {
                y = y - x;
                if(curAccT== "Savings Account")
                {
                    if (y >= 7000)//7000 is the 70% of the maintaining balance for savings account
                    {
                        CurBal = y.ToString();
                        myConn.Open();
                        SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurAccNo;
                        updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = CurBal;
                        updateCmd.ExecuteNonQuery();
                        myConn.Close();
                        found = "Withdrawal complete!";
                        CurMensahe = "Withdraw Transaction - " + x + " PHP";
                        Transactioner(CurAccNo,CurMensahe,x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                    }
                    else found = "70% of the Maintaining balance is required in your account.";
                }
                else if(curAccT == "Checking Account")
                {

                    if (y >= 14000)//14000 is the 70% of the maintaining balance for checking account
                    {
                        CurBal = y.ToString();
                        myConn.Open();
                        SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurAccNo;
                        updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = CurBal;
                        updateCmd.ExecuteNonQuery();
                        myConn.Close();
                        found = "Withdrawal complete!";
                        CurMensahe = "Withdraw Transaction - " + x + " PHP";
                        Transactioner(CurAccNo, CurMensahe, x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                    }
                    else found = "70% of the Maintaining balance is required in your account.";
                }
                    
            }
            else found = "The minimum withrawal is 200 PHP";

            return found;
        }/*********************/



        public string senderist(string pera,string recei)
        {
            string found = "";
            double x = Convert.ToDouble(pera);
            double y = Convert.ToDouble(CurBal);
            if (x >= 1)
            {
                y = y - x;
                if (curAccT == "Savings Account")
                {
                    if (y >= 7000)//7000 is the 70% of the maintaining balance for savings account
                    {

                        /*********updates********************/
                        CurBal = y.ToString();
                        myConn.Open();
                        SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurAccNo;
                        updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = CurBal;
                        updateCmd.ExecuteNonQuery();
                        myConn.Close();

                        CurReceiver = recei;
                        myConn.Open();
                        SqlCommand updateCmd2 = new SqlCommand("Youngmoney", myConn);
                        updateCmd2.CommandType = CommandType.StoredProcedure;
                        updateCmd2.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurReceiver;
                        updateCmd2.Parameters.Add("@BB", SqlDbType.NVarChar).Value = x;
                        updateCmd2.ExecuteNonQuery();
                        myConn.Close();
                        /*****************************/

                        found = "Transfer complete!";
                        CurMensahe = "Transfer Transaction sending to ["+CurReceiver+"]";
                        Transactioner(CurAccNo, CurMensahe, x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                        CurMensahe = "Transfer Transaction receiving from [" + CurAccNo + "]";
                        Transactioner(CurReceiver, CurMensahe, x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                    }
                    else found = "70% of the Maintaining balance is required in your account.";
                }
                else if (curAccT == "Checking Account")
                {
                    if (y >= 14000)//14000 is the 70% of the maintaining balance for checking account
                    {

                        /*********updates********************/
                        CurBal = y.ToString();
                        myConn.Open();
                        SqlCommand updateCmd = new SqlCommand("UpdateBal", myConn);
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurAccNo;
                        updateCmd.Parameters.Add("@BB", SqlDbType.NVarChar).Value = CurBal;
                        updateCmd.ExecuteNonQuery();
                        myConn.Close();

                        CurReceiver = recei;
                        myConn.Open();
                        SqlCommand updateCmd2 = new SqlCommand("Youngmoney", myConn);
                        updateCmd2.CommandType = CommandType.StoredProcedure;
                        updateCmd2.Parameters.Add("@Acc", SqlDbType.NVarChar).Value = CurReceiver;
                        updateCmd2.Parameters.Add("@BB", SqlDbType.NVarChar).Value = x;
                        updateCmd2.ExecuteNonQuery();
                        myConn.Close();
                        /*****************************/

                        found = "Transfer complete!";
                        CurMensahe = "Transfer Transaction sending to [" + CurReceiver + "]";
                        Transactioner(CurAccNo, CurMensahe, x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                        CurMensahe = "Transfer Transaction receiving from [" + CurAccNo + "]";
                        Transactioner(CurReceiver, CurMensahe, x.ToString(), DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToLongTimeString());
                    }
                    else found = "70% of the Maintaining balance is required in your account.";
                }
            }
            else found = "Please check your input";
            return found;
        }











            }//end of
}
