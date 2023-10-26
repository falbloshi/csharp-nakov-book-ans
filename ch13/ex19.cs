using System;
using System.Text;
using System.Text.RegularExpressions;

class ex19
{
    static void Main()
    {
        Console.WriteLine("Write a string to extract emails from.\n");

        StringBuilder myString = new StringBuilder();

        Console.Write("Enter the data: ");
        myString.Append(Console.ReadLine());

        while(myString.ToString() == "")
        {   
            Console.Write("Please write something: ");
            myString.Append(Console.ReadLine());	
        }

        string emailRGX = @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)";

        bool correctlyMatching = Regex.IsMatch(myString.ToString(), emailRGX);
        
        Console.WriteLine("Valid Emails: ");
        int count = 1;
        if(correctlyMatching)
        {
            Match myEmailRGXMatch = Regex.Match(myString.ToString(), emailRGX);

            while(myEmailRGXMatch.Success)
            {
                Console.WriteLine($"{count}: {myEmailRGXMatch.Value}");
                count++;
                myEmailRGXMatch = myEmailRGXMatch.NextMatch();
            }
        }
        else
        {
            Console.WriteLine("No Valid Matches");
        }


    }
}