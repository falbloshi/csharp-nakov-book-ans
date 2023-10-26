using System;
using System.Text;
using System.Collections.Generic;

public class ex2
{    
        static void Main()
        {
            Console.WriteLine("Enter numbers to print them in reverse\n:");
            Stack<int> intStk= new Stack<int>();
            
            string[] strm = Console.ReadLine().Split(' ');
                    
            for(int n = 0; n < strm.Length; n++)
            {   
               try
                {
                    intStk.Push(int.Parse(strm[n].Trim()));
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

            foreach(int m in intStk)
            {
                Console.WriteLine(m);
            }
        }
}