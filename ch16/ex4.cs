using System;
using System.Collections.Generic;

public class ex4
{
    public static List<int> EqSubSeq(List<int> insertedList)
    {
        int finalCount = 0; 
        int count = 0; 
        int startingIndex= 0;
        int finalIndex = 0; 

        // .Count - 1 because we are not taking the last element to search for its neighbour
        for(int i = 0; i < insertedList.Count - 1; i++)
        {

            if(insertedList[i] == insertedList[i + 1])
            {
                count++;
                if(finalCount < count)
                {
                    finalCount = count;
                    
                    //this for startingIndex fixes a lot of issue
                    //problem was that starting index starts at the best 
                    //count not at the beginning of the count of the equal numbers
                    startingIndex = i - count + 1;
                }
            }
            else
            {
                count = 0;
            }
        }
        
        
        finalIndex = startingIndex + finalCount;

        List<int> returnList = new List<int>();
        
        for(int j = startingIndex; j <= finalIndex; j++)
        {
            returnList.Add(insertedList[j]);
        }

        return returnList;

    }
    static void Main()
    {
        Console.WriteLine("Enter a sequence of numbers to find the largest subsequence of equal numbers\n");
        List<int> intList = new List<int>();

        while (true)
        {
            try
            {
                string input = Console.ReadLine();
                
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
        

        
        Console.Write("\nLargest Equal Subsequence\n");
        foreach(var n in EqSubSeq(intList))
        {
            Console.Write(n + " ");
        }
        Console.WriteLine("");

    }
}