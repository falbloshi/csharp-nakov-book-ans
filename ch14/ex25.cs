using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        numSB.Append(Regex.Replace(numSB.ToString(), frStyle.ToString(), "$1"));
        denSB.Append(frStyle.Replace(denSB.ToString(), "$2"));
        decimal num = Convert.ToDecimal(numSB);
        decimal den = Convert.ToDecimal(denSB);

        return (num/den); 
    }

    static void Main(String[] args)
    {
        new Fractions(args[0]);
    }

}