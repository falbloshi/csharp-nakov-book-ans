using System;
using System.Collections.Generic;

public class ex6
{
    public static void CleanOdd(List<int> myList)
    {


        var myListDict = new Dictionary<int, int>();

        foreach (var integer in myList)
        {
            try
            {
                myListDict.Add(integer, 1);
            }
            catch (ArgumentException)
            {
                myListDict[integer] += 1;
            }
        }
        foreach (var kvpair in myListDict)
        {
            if (!(kvpair.Value % 2 == 0))
            {
                //this loop to remove all the elements in the list of the same key integer, 
                //if index of the key element is -1(i.e no longer exists) it breaks the loop
                while (true)
                {
                    myList.Remove(kvpair.Key);
                    if (myList.IndexOf(kvpair.Key) == -1)
                    {
                        break;
                    }
                }
            }
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter a list of number and we will remove numbers that appear odd numbers of time\n");
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
                Console.WriteLine("Entered a letter character. Exiting program.");
                return;
            }
            /*catch (ArgumentException)
            {
                intListDict[int.Parse(input)] += 1;
            }*/
        }

        CleanOdd(intList);

        Console.Write("Even Nos. \n");
        foreach (var n in intList)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine("");

    }
}