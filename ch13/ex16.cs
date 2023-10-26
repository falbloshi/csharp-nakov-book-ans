using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ex16
{
    static void Main()
    {
        Console.WriteLine("Please enter a text to to change the URL tag from HTML style to forum style:\n");

        StringBuilder sbMain = new StringBuilder();


        
        Console.Write("> ");
        string mainStr = Console.ReadLine();
        if(mainStr == "")
        {
            Console.WriteLine("You wrote an empty string, try again!");
            Console.ReadKey();
            Console.Clear();
            Main();
        };

        Regex hyperlinkRGX = new Regex("(<a\\shref=\"([0-9A-z\\s\\.\\/\\:]+)\">)([0-9A-z\\s]+)(<\\/a>)");
                
        bool isTagCorrect = hyperlinkRGX.IsMatch(mainStr);
        
        if(isTagCorrect)
        {
            Console.WriteLine("We reached here!");
            sbMain.Append(hyperlinkRGX.Replace(mainStr, @"[URL=$2]$3[/URL]"));
        }
            
        Console.WriteLine("\nYour new tag:\n\n" + sbMain.ToString() + "\n\n");
    }
}

