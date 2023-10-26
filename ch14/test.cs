using System;
using System.Text;
using System.Text.RegularExpressions;


public class Whatever
{
    public class FractionCancelClass
    {
        public static Regex frStyle = new Regex(@"([-]?[1-9][0-9]*)[\/]([-]?[1-9][0-9]*)");

        public static decimal EuclidAlgo(decimal a, decimal b)
        {
            decimal[] returnDecimals = { a, b };
            decimal c = a % b;
            a = b;
            b = c;
            if (b == 0)
            {
                returnDecimals[0] = a;
                returnDecimals[1] = b;
                return a;
            }
            else
            {
                return EuclidAlgo(a, b);
            }
        }

        //chapter's exercise

        public static string FractionCancel(string mystr)
        {
            var numSB = new StringBuilder();
            var denSB = new StringBuilder();
            numSB.Append(frStyle.Replace(mystr, "$1"));
            denSB.Append(frStyle.Replace(mystr, "$2"));
            decimal num = Convert.ToDecimal(numSB.ToString());
            decimal den = Convert.ToDecimal(denSB.ToString());

            Console.WriteLine("Convert Okay");

            decimal finalFract = EuclidAlgo(num, den);
            Console.WriteLine("Final fract: " + finalFract);

            if (finalFract > 1)
            {

                num /= finalFract;
                den /= finalFract;
                String newStr = new String;
                return newStr;
            }
            else
            {
                return mystr;
            }
    
        }
        public static void Main()
        {

            Console.WriteLine(FractionCancel("10/15"));
        }
    }
}