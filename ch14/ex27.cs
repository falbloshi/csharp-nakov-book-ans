using System;
using System.Text;
using System.Text.RegularExpressions;

public class Fractions
{
    private string inputFraction;
    private Decimal outDecimal;
    private const string defaultFraction = "1/4";
    public static Regex frStyle = new Regex(@"([-]?[1-9][0-9]*)[\/]([-]?[1-9][0-9]*)");

    public Decimal Decimal
    {
        get { return outDecimal; }
    }

    public Fractions()
        : this(defaultFraction)
    {
    }

    public Fractions(string inputFraction)
    {
        this.inputFraction = Parse(inputFraction);
        this.outDecimal = ToDecimal(this.inputFraction);
    }


    //using the good old recursion to get the final answer 
    private static decimal EuclidAlgo(decimal a, decimal b)
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
    public string FractionCancel()
    {
        var numSB = new StringBuilder();
        var denSB = new StringBuilder();
        numSB.Append(frStyle.Replace(this.inputFraction, "$1"));
        denSB.Append(frStyle.Replace(this.inputFraction, "$2"));
        decimal num = Convert.ToDecimal(numSB.ToString());
        decimal den = Convert.ToDecimal(denSB.ToString());

        decimal finalFract = EuclidAlgo(num, den);

        if (finalFract > 1)
        {
           
            num /= finalFract;
            den /= finalFract;
            var finalSB = new StringBuilder($"{num.ToString()}/{den.ToString()}");
            return finalSB.ToString();
        }
        else
        {
            return this.inputFraction;
        }
    }


    public static string Parse(string inputFraction)
    {
        var ifSB = new StringBuilder(inputFraction.Trim(' '));
        bool isMatch = frStyle.IsMatch(ifSB.ToString());
        if (isMatch)
        {
            return inputFraction;
        }
        else
        {
            while (!isMatch)
            {
                ifSB.Clear();
                Console.Write("You wrote in a wrong format or with a 0 de/nominator, please try again: ");
                ifSB.Append(Console.ReadLine());
                isMatch = frStyle.IsMatch(ifSB.ToString());
            }
            return ifSB.ToString();
        }
    }
    public Decimal ToDecimal(string toD)
    {
        var numSB = new StringBuilder();
        var denSB = new StringBuilder();
        numSB.Append(frStyle.Replace(toD, "$1"));
        denSB.Append(frStyle.Replace(toD, "$2"));
        decimal num = Convert.ToDecimal(numSB.ToString());
        decimal den = Convert.ToDecimal(denSB.ToString());

        return (num / den);
    }

}

public class FractionsTest
{
    static void Main()
    {
        var myFraction1 = new Fractions("-1000/1500");
        Console.WriteLine(myFraction1.FractionCancel());
        Console.WriteLine(myFraction1.Decimal);

    }
}