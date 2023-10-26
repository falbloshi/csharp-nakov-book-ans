using System;
using System.Text;


class ex11
{
    static void Main()
    {   
        Console.WriteLine("Give us a line and a list of forbidden words seperated by comma and we replace the forbidden words.\n");

        //taking user input
        Console.Write("Insert your line: ");
        String mainStr = Console.ReadLine(); //splitting from each '.'
        Console.Write("Insert your forbidden to search: ");
        String[] forbStr = Console.ReadLine().Split(',');       
        Console.WriteLine(); 

        StringBuilder sbMainStr = new StringBuilder();
        StringBuilder sbForbStr = new StringBuilder();
        sbMainStr.Append(mainStr);

        //appending for each new line to our sb forbidden list
        foreach(String forbiddenText in forbStr)
        {
            sbForbStr.AppendLine(forbiddenText.Trim(' '));
        }
        
        
        StringBuilder astrixBuilder = new StringBuilder();
        StringBuilder subString = new StringBuilder();
        int index = 0; 
        foreach(String fbText in forbStr)
        {
            //finding the index of the first occurance of the forbidden word
            //trim to remove excess space after comma split
            index = sbMainStr.ToString().IndexOf(fbText.Trim(' '));
            //building astrix string using the size of the forbidden word
            for(int i = 0; i < fbText.Length; i++)
            {
                astrixBuilder.Append("*");
            }
            //finding theforbidden word in the main string
            subString.Append(sbMainStr.ToString().Substring(index, fbText.Length));
            
            //replacing every occurance
            sbMainStr.Replace(subString.ToString(), astrixBuilder.ToString());

            //clearing after each iteration
            subString.Clear();  
            astrixBuilder.Clear();

        }

        Console.WriteLine("Your forbidden texts:\n{0}", sbForbStr.ToString());

        Console.WriteLine("Your new text:\n{0}", sbMainStr.ToString());
    }
}