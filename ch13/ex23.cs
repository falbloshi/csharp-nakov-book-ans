using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


class ex23
{
    static void Main()
    {
        Console.WriteLine("\nWrite data to check occurance of words alphabetically: \n");

        StringBuilder myStr = new StringBuilder();
        SortedDictionary<string, int> myDictionary = new SortedDictionary<string, int>();
        Console.Write("Enter the data: ");

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo; // t o capitalize the first letter

        
        String[] insertedData = Console.ReadLine().Split(' ');
        Regex myRGX = new Regex(@"[\W\d]+");
        
        foreach(String str in insertedData)
        {
            int m = 1;
            myStr.Append(myRGX.Replace(str, ""));
            if(!String.IsNullOrEmpty(myStr.ToString()))
            {
                try
                {
                    myDictionary.Add(ti.ToTitleCase(myStr.ToString().Trim(' ')), m);
                }
                catch (ArgumentException)
                {
                    myDictionary[ti.ToTitleCase(myStr.ToString().Trim(' '))] += 1;
                }
            }
            myStr.Clear();
        }
        
        foreach(var kvPair in myDictionary)
        {
            Console.WriteLine("{0} x{1}", kvPair.Key, kvPair.Value);
        }
   }
}
