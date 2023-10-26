using System;
using System.Text;
using System.Text.RegularExpressions;


class ex11Regex
{
    static void Main()
    {
        //using Regex this time
        Console.WriteLine("Give us a line and a list of forbidden words seperated by comma and we replace the forbidden words.\n");

        //taking user input
        Console.Write("Insert your line: ");
        String mainStr = Console.ReadLine(); //splitting from each '.'
        Console.Write("Insert your forbidden to search: ");
        String[] forbStr = Console.ReadLine().Split(',');
        Console.WriteLine();

        StringBuilder sbMainStr = new StringBuilder();
        StringBuilder sbReplaceStr = new StringBuilder();
        StringBuilder astrixBuilder = new StringBuilder();

        sbMainStr.Append(mainStr);

        int index = 0;
        foreach (String fbText in forbStr)
        {
            //creating a regex with the text provided in the forbidden list
            Regex myRGX = new Regex($@"\b{fbText.Trim(' ')}");
            index = fbText.Trim(' ').Length; //getting size to make the amount of astrix
            for (int i = 0; i < index; i++) astrixBuilder.Append("*");

            sbReplaceStr.Append(astrixBuilder.ToString());

            sbMainStr.Replace(sbMainStr.ToString(), myRGX.Replace(sbMainStr.ToString(), sbReplaceStr.ToString())); //replacing everytime we got a match 
            // we first replace with regex the original text from the forbidden list with the replaced astrix text, then we replace the whole text with the replaced regex text
            // firststring replace(firststring, secondstring rgxreplace(firststring, replacedstring))

            //clearing the string builder which we use over again
            sbReplaceStr.Clear();
            astrixBuilder.Clear();
        }
        Console.WriteLine("Your new text:\n{0}", sbMainStr.ToString());

    }
}