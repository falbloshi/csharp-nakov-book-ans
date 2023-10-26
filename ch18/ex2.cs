using System;
using System.Collections.Generic;


class ex2
{   
    static void Main()
    {
        int[] array = {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6};


        Dictionary<int, int> dictArr = new Dictionary<int, int>();

        List<int> finalList = new List<int>();

        foreach(int number in array)
        {
            finalList.Add(number);
            int n;

            if(!dictArr.TryGetValue(number, out n))
            {
                n = 0;
            }

            dictArr[number] = n + 1;
        }


        
        var newDictArr = dictArr;
        foreach(var kvpair in newDictArr)
        {
            if(!(kvpair.Value % 2 == 0))
            {
                while(finalList.Remove(kvpair.Key));   
            }
        }
        Console.Write("{ ");
        foreach(var m in finalList)
        {
            Console.Write($"{m} ");
        }
        Console.Write("}");

        
    }
    
}
