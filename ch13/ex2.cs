using System;
using System.Text;

class ex2
{
    static void Main()
    {
        Console.Write("Insert word to reverse it: ");
        String mainStr = Console.ReadLine();    
        StringBuilder sbMainStr = new StringBuilder();

        for(int i = mainStr.Length - 1; i >= 0; i--)
        {
            char ch = mainStr[i];
            sbMainStr.Append(ch);
        }
        Console.WriteLine($"Reversed!\n{sbMainStr.ToString()}");

    }
}