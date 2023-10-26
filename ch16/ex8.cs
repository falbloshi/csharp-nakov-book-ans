using System;
using System.Collections.Generic;

class ex8
{
    static void Main()
    {
        Console.WriteLine("Enter a list of number and we will find the majorant\n");
        List<int> intList = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();
            try
            {

                if (!String.IsNullOrEmpty(input))
                {
                    intList.Add(int.Parse(input));
                }
                else
                {
                    break;
                }
            }
            catch (System.FormatException)
            {
                continue;
            }
        }

        MajorantFinder(intList);
    }

    public static void MajorantFinder(List<int> mList)
    {
        var majorantDict = new Dictionary<int, int>();

        foreach (var mInt in mList)
        {
            try
            {
                majorantDict.Add(mInt, 1);
            }
            catch (ArgumentException)
            {
                majorantDict[mInt] += 1;
            }
        }

        int majorant = (mList.Count / 2) + 1;
        int key = -1; 

        foreach (var kvpair in majorantDict)
        {
            if (kvpair.Value >= majorant)
            {
                key = kvpair.Key;
                break;
            }
        }

        //another ternary, better than if else
        String m = (key != -1) ? $"Majorant is {key}" : "There is no majorant"; 
        Console.WriteLine(m);

    }
}