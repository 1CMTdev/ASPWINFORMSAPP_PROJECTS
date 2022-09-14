using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        double grr, ded, net, ot;
        int r;
        public double Grr { get => grr; set => grr = value; }
        public double Ded { get => ded; set => ded = value; }
        public double Net { get => net; set => net = value; }
        public double Ot { get => ot; set => ot = value; }


         public void awitized(double hrs,string emptype,double hrsot)
        {
            Grr = 0;
            Ded = 0;
            Net = 0;
            Ot = 0;
            r = 0;

            //employee prompts
            if (emptype == "Contractual")
            {
                r = 450;
                Ded = 600;
            }
            else if (emptype == "Probationary")
            {
                r = 550;
                Ded = 875;
            }
            else if (emptype == "Permanent")
            {
                r = 800;
                Ded = 1250;
            }


            //OT compute
            if (hrsot > 0)
            {
                if (hrsot >= 1 && hrsot <= 2.99)
                {
                    Ot=((0.10 * r) + r)*hrsot;
                }
                else if (hrsot >= 3 && hrsot <= 4.99)
                {
                    Ot = ((0.15 * r) + r) * hrsot;
                }
                else if (hrsot >= 5 && hrsot <= 6.99)
                {
                    Ot = ((0.20 * r) + r) * hrsot;
                }
                else if (hrsot >= 7 && hrsot <= 9.99)
                {
                    Ot = ((0.25 * r) + r) * hrsot;
                }
                else if (hrsot >= 10)
                {
                    Ot = ((0.30 * r) + r) * hrsot;
                }
            }
            else if(hrsot==0)
            {
                Ot = 0;
            }

            //final comps
            Grr = (hrs * r) + Ot;
            Net = (Grr - Ded);

        }
    }
}
