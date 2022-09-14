using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassLibrary1
{
    public class DataHelper
    {
        String[] ID = { "PRN", "MSE", "PRNDT", "MNTRLe" };
        String[] PName = { "Printer Laser", "Mouse", "Printer Dot Matrix", "LCD Monitor" };
        static int[] Stocks = { 100, 100, 100, 100 };
        double[] SKU = { 7000, 500, 7500, 6500 };
        double SRP;
        int determiner;
        int cur;
        double Nabili;
        string purchaselog;

        //array list declaration
        ArrayList prodId = new ArrayList();
        ArrayList prodName = new ArrayList();
        ArrayList prodStocks = new ArrayList();
        ArrayList prodSRP = new ArrayList();


        //encapsulation
        public ArrayList ProdId { get => prodId; set => prodId = value; }
        public ArrayList ProdName { get => prodName; set => prodName = value; }
        public ArrayList ProdStocks { get => prodStocks; set => prodStocks = value; }
        public ArrayList ProductSRP { get => prodSRP; set => prodSRP = value; }
        public int Cur { get => cur; set => cur = value; }
        public string Purchaselog { get => purchaselog; set => purchaselog = value; }
        public int Determiner { get => determiner; set => determiner = value; }



        //This is the Constuctor 
        public DataHelper()
        {
            int id = PName.Length;
            for (int i = 0; i < id; i++)
            {
                ProdId.Add(ID[i]);
                ProdName.Add(PName[i]);
                ProdStocks.Add(Stocks[i]);
                SRP = SKU[i] + (SKU[i] * 0.15);
                ProductSRP.Add(SRP);
            }
        }

        ~DataHelper() { }




        /**************************************/
        //Computes
        public void shinapi(string name, double quan)
        { 
            if(name== "Printer Laser")
            {
                Determiner = 0;
            }
            else if (name == "Mouse")
            {
                Determiner = 1;
            }
            else if (name == "Printer Dot Matrix")
            {
                Determiner = 2;
            }
            else if (name == "LCD Monitor")
            {
                Determiner = 3;
            }
            Cur = Stocks[Determiner];
            if (quan <= Cur)
            {
                Nabili = ((SKU[Determiner] * 0.15) + SKU[Determiner]) * quan;
                Stocks[Determiner] = Stocks[Determiner] - Convert.ToInt32(quan);
                Cur = Stocks[Determiner];
                Purchaselog ="["+ quan+"] pcs. of "+PName[Determiner] + " --- " + Nabili + "php"+"\n";
            }
            else
            {
                Purchaselog = "xxx";
            }
        }//END OF COMPUTE


    
















   







    }
}
