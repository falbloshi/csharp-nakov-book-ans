using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

class ex20
{
    static void Main()
    {
        Console.WriteLine("Write data to confirm dates: \n");

        StringBuilder myString = new StringBuilder();
        CultureInfo deDE = new CultureInfo("de-DE"); 
        

        Console.Write("Enter the data: ");
        myString.Append(Console.ReadLine());

        while(myString.ToString() == "")
        {   
            Console.Write("Please write something: ");
            myString.Append(Console.ReadLine());
        }
        DateTime myDate = new DateTime()        ;

        string germanDateRGX = @"(0?[1-9]|1[0-9]|2[0-9]|3[01])\.(0?[1-9]|1[012])\.(?:1[1-9]|20)[0-9]{2}";

        bool correctlyMatching = Regex.IsMatch(myString.ToString(), germanDateRGX);
  
        Console.WriteLine("Valid Matches: ");
        int count = 1;
        if(correctlyMatching)
        {
            Match germanDate = Regex.Match(myString.ToString(), germanDateRGX);
            while(germanDate.Success)
            {   
                myDate = DateTime.Parse(germanDate.ToString().Trim(' '), deDE);
                Console.WriteLine("{0}: {1: yyyy/MM/dd}", count, myDate);
                count++;
                germanDate = germanDate.NextMatch();
            }
        }
        else
        {
            Console.WriteLine("No Valid Matches");
        }


    }
}

// 14.06.1980. 3.7.1984.