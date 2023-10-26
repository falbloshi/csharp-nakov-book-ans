using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

//same as 23 just changing dictionary to sorted list
class ex25
{
    static void Main()
    {
        Console.WriteLine("\nWrite words seperated by comma to sort the words alphabetically: \n");

        StringBuilder myStr = new StringBuilder();
        SortedList<string, int> myList = new SortedList<string, int>();
        Console.Write("Enter the data: ");

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo; // t o capitalize the first letter
        
        String[] insertedData = Console.ReadLine().Split(',');
        Regex myRGX = new Regex(@"[\W\d]+");

        foreach(String str in insertedData)
        {
            myStr.Append(myRGX.Replace(str, ""));
            if(!String.IsNullOrEmpty(myStr.ToString()))
            {
                try
                {
                    myList.Add(ti.ToTitleCase(myStr.ToString().Trim(' ')), 1);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Duplicate Detected");
                }
            }
            myStr.Clear();
        }
        
        foreach(var kvPair in myList)
        {
            Console.WriteLine("{0}", kvPair.Key);
        }
   }
}
