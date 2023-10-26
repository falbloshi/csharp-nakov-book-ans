using System;
using System.Text;


class ex10
{
    static void Main()
    {   
        //taking from user
        Console.WriteLine("String finder program. We will search for you a line with a specific text in it,\n");

        //taking user input
        Console.Write("Insert your line: ");
        String[] mainStr = Console.ReadLine().Split('.'); //splitting from each '.'
        Console.Write("Insert your substring to search: ");
        String subStr = Console.ReadLine();       
        Console.WriteLine(); 

        StringBuilder sbMainStr = new StringBuilder();
        StringBuilder sbSubStr = new StringBuilder();
        sbSubStr.Append(" " + subStr.ToLower() + ""); //the letter must not be joined with other texts
        
        int index = 0;
        int lineCount = 0;

        //processing for each row split from the main array
        foreach(string mstr in mainStr)
        {
            //finding the index of the element in each string
            index = mstr.ToLower().IndexOf(sbSubStr.ToString()); 
           //if it is not -1, it exists and will process it here
            if(index != -1)
            {   
                lineCount++;
                sbMainStr.Clear(); //clearing after each append
                Console.WriteLine("({0}): {1} ", lineCount, sbMainStr.Append(mstr.Trim(' ').ToString())); //appending, trimming extra space and then converting it to string
                
            }            
        }

    }
}