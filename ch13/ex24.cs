using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
class ex24
{
    static void Main()
    {
        Console.WriteLine("\nWrite data to cancel repeating letters: \n");

        StringBuilder myStr = new StringBuilder();
        Console.Write("Enter the data: ");  
        String[] insertedData = Console.ReadLine().Split(' ');
        Regex myRGX = new Regex(@"(\w+)(?=\1)");
        
        foreach(String str in insertedData)
        {
            if(!String.IsNullOrEmpty(str))
            {
                myStr.Append(myRGX.Replace(str, ""));
            }
            myStr.Append(" ");
        }
        Console.WriteLine("{0}", myStr.ToString());

   }
}
