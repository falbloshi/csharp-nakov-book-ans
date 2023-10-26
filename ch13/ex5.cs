using System;
using System.Text;

class ex5
{
    static void Main()
    {
        Console.Write("Insert your line: ");
        String mainStr = Console.ReadLine();
        Console.Write("Insert your substring to search: ");
        String subStr = Console.ReadLine();        
        
        mainStr = mainStr.ToLower();
        String nSubStr =  subStr.ToLower();
        int counter = 0;
        int index = mainStr.IndexOf(nSubStr);

        while(index != -1)
        {
            index = mainStr.IndexOf(nSubStr, index+1);
            counter++;
        }   

         Console.Write($"Your substring \"{subStr}\" occurs {counter} times");

    }
}