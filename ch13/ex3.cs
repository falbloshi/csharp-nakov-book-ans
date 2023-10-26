using System;
using System.Text;

class ex3
{
    static void Main()
    {
        Console.Write("Insert your formula: ");
        String mainStr = Console.ReadLine();    
        ushort counter = 0;
        for(int i = mainStr.Length - 1; i >= 0; i--)
        {
            char ch = mainStr[i];
            if(ch == '(')
            {
                counter++;
            }
            else if(ch == ')')
            {
                counter--;
            }
        }
        String mainMsg; 
        mainMsg = (counter == 0) ? "Everything is correct" : "There is a mistake in the formula";

        Console.WriteLine(mainMsg);
    }
}