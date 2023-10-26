using System;
using System.Text;
using System.Collections.Generic;

class ex21
{
    static void Main()
    {
        Console.WriteLine("\nWrite data to check palindromes: \n");

        StringBuilder myPalindrome = new StringBuilder();
        List<string> myStringList = new List<string>();

        Console.Write("Enter the data: ");
        string[] textline = Console.ReadLine().Split(' ');

        foreach(String text in textline)
        {   
            if(!String.IsNullOrEmpty(text))
                myStringList.Add(text.Trim(' '));
        }

        foreach(String text in myStringList)
        {
            int textLength = text.Length;
            char[] mainChar = text.ToCharArray();
            char[] secondChar = text.ToCharArray();

            Array.Reverse(secondChar);

            int d = 1; 
            for(int i = textLength - 1; i >= 0; i--)
            {     
                if(!(mainChar[i] == secondChar[i]))
                {
                     d--;
                }
            }
            if(d == 1 && textLength > 2)
            {
                myPalindrome.AppendLine(text);
            } 
        }
        
         Console.WriteLine("Palindrome List:\n{0}", myPalindrome);
     
    
    }
}
