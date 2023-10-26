using System;
using System.Collections.Generic;
using System.Linq;

public class ex7
{

    static void Main()
    {
        Console.WriteLine("Enter a list of number and we will count how many each occurs\n");
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
        }


        //sorting a dictionary, found from here
        // sort dictionary
        //https://www.dotnetperls.com/sort-dictionary

        var OccuranceDict = NumberOccurance(intList);
     
        var newDict = OccuranceDict.Keys.ToList();
        newDict.Sort();


        Console.Write("No. of Occurances \n");
        foreach (var nkey in newDict)
        {
            if (OccuranceDict[nkey] != 1)
            {
                Console.Write($"{nkey} -> {OccuranceDict[nkey]} times");
            }
            else
            {
                Console.Write($"{nkey} -> {OccuranceDict[nkey]} time");
            }
            Console.WriteLine();
        }
        Console.WriteLine("");

    }
    public static Dictionary<int, int> NumberOccurance(List<int> myList)
    {
        var myListDict = new Dictionary<int, int>();

        if (myList.Count <= 1000)
        {
            //its asking for an array so we make one
            int[] myArray = new int[myList.Count];
            for (int i = 0; i < myList.Count; i++)
            {
                myArray[i] = myList[i];
            }

            for (int i = 0; i < myList.Count; i++)
            {
                try
                {
                    myListDict.Add(myArray[i], 1);
                }
                catch (ArgumentException)
                {
                    myListDict[myArray[i]] += 1;
                }
            }
            return myListDict;
        }
        return myListDict;
    }
}