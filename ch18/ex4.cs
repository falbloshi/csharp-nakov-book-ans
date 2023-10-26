using System;
using System.Collections.Generic;

namespace ex4
{

    public class DictHashSet<T>
    {
        static void Main()
        {

            //resolves collision
            LinkedList<string> m = new LinkedList<string>();


            string name = "Sue";

            Console.WriteLine($"Hash for Sue {HashFunc(name, 11)}");
        }


        public static int HashFunc(string element, int mapCount)
        {
            int index = 0;

            foreach (char chars in element.ToCharArray())
            {
                index += (int)chars;
            }
            return index % mapCount;
        }

    }