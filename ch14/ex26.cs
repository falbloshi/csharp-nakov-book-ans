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
        get {return outDecimal;}
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

    public static string Parse(string inputFraction)
    {
        var ifSB = new StringBuilder(inputFraction.Trim(' '));
        bool isMatch = frStyle.IsMatch(ifSB.ToString());
        if(isMatch)
        {
            return inputFraction;
        }
        else
        {
            while(!isMatch)
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

        return (num/den); 
    }

}

public class FractionsTest
{
    static void Main()
    {
        var myFraction1 = new Fractions("15/3");
        Console.WriteLine(myFraction1.Decimal);
        var myFraction2 = new Fractions("2/19");
        Console.WriteLine(myFraction2.Decimal);
        var myFraction3 = new Fractions("-15/-3");
        Console.WriteLine(myFraction3.Decimal);
        var myFraction4 = new Fractions("-15/3");
        Console.WriteLine(myFraction4.Decimal);
        var myFraction5 = new Fractions("15/-3");
        Console.WriteLine(myFraction5.Decimal);
         var myFraction6 = new Fractions("15/0");
        Console.WriteLine(myFraction6.Decimal);
    }
}