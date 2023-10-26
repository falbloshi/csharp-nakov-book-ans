using System;
using System.Collections.Generic;


class ex1
{
    static void Main()
    {
        int[] array = {3, 4, 4, 2, 3, 3, 4, 3, 2};


        Dictionary<int, int> dictArr = new Dictionary<int, int>();

        foreach(int number in array)
        {
            int n;

            if(!dictArr.TryGetValue(number, out n))
            {
                n = 0;
            }

            dictArr[number] = n + 1;
        }

        foreach(var kvpair in dictArr)
        {
            Console.Write($"{kvpair.Key} -> {kvpair.Value} # value {kvpair.GetHashCode()},\t");
        }
    }
    
}
