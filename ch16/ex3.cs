using System;
using System.Collections.Generic;

public class ex3
{
    static void Main()
    {
        Console.WriteLine("Enter Non-Negative to print them in ascending order\n");
        List<uint> intList = new List<uint>();

        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                
                if (!String.IsNullOrEmpty(input))
                {
                    intList.Add(uint.Parse(input));
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
            catch (System.OverflowException)
            {
                Console.WriteLine("You entered negative values. Exiting program.");
                return;
            }
        }

        //sorting to ascending
        intList.Sort();

        Console.Write("\nSorted values\n{");
        foreach(var n in intList)
        {
            Console.Write(n + " ");
        }
        Console.Write("}\n");
    }
}