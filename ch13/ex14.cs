using System;
using System.Text;

class ex14
{

    static void Main()
    {
        Console.WriteLine("Please enter a text to reverse it:");

        Console.Write("> ");
        string[] enteredString = Console.ReadLine().Split(' ');
        if (enteredString[0] == "")
        {
            return;
        }
        StringBuilder sbMain = new StringBuilder();

        for(int i = enteredString.Length - 1; i >=0 ; i--)
        {
            sbMain.Append(enteredString[i].Trim(' ') + " " );
        }

        Console.WriteLine(sbMain.ToString().TrimEnd(' '));


    }

}