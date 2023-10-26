using System;
using System.Text;
class ex8
{
    static void Main()
    {
        Console.Write("Insert your line to convert to unicode: ");

        String mainStr = Console.ReadLine();
        
        StringBuilder sbMainStr = new StringBuilder();
        
        sbMainStr.Append(mainStr);

        char[] myCharArray = new char[mainStr.Length];
        
        myCharArray = sbMainStr.ToString().ToCharArray();

        foreach(char charElements in myCharArray)
        {   
            Console.Write("\\u{0:x4} ", (ushort)charElements);
        }

    }   
}
