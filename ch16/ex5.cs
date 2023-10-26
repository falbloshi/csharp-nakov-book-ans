using System;
using System.Collections.Generic;

public class ex5
{
    static void Main()
    {
        Console.WriteLine("Enter a list of number per line. We will remove the negatives\n");
        List<int> intList = new List<int>();

        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(input))
                {
                    int ouputN = int.Parse(input);
                    if(ouputN > 0)
                    {
                        intList.Add(ouputN);
                    }
                }
                else
                {
                    break;
                }
            }
            catch (System.FormatException)
            {

                Console.WriteLine("Entered a letter character. Exiting program.");
                return;

            }
        }
        

        
        Console.Write("\nPositive Integers \n");
        foreach(var n in intList)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine("");

    }
}