using System;
using System.Text;
class ex7
{
    static void Main()
    {
        Console.Write("Insert your line with(Maximum 20 characters): ");

        String mainStr = Console.ReadLine();
        
        StringBuilder sbMainStr = new StringBuilder();
        
        sbMainStr.Append(mainStr);
        int size = sbMainStr.ToString().Length;
        if(sbMainStr.ToString().Length > 20)
        {
            //to remove excess items and keep it at 20 characters
            sbMainStr.Remove(20, size-20);
        }
        Console.WriteLine("{0}", sbMainStr.ToString().PadRight(20, '*'));
    }   
}
