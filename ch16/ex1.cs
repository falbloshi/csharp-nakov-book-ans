using System;
using System.Text;
using System.Collections.Generic;

public class ex1
{    
        static void Main()
        {
            Console.WriteLine("Enter Non-Negative numbers to find sum and average keep them in one line and press enter once done\n:");
            List<uint> intList = new List<uint>();
            
            string[] strm = Console.ReadLine().Split(' ');
           
            uint collection = 0;
           
            for(int n = 0; n < strm.Length; n++)
            {   
               try
                {
                    intList.Add(uint.Parse(strm[n].Trim()));
                    collection += intList[n];
                }
                catch(System.FormatException)
                {
                    if(!String.IsNullOrWhiteSpace(strm[n]))    
                    {
                        Console.WriteLine("Entered wrong info exiting program.");
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"\nSum: {collection}");
            Console.WriteLine($"Average: {collection/intList.Count}");




        }
}