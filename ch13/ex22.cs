using System;
using System.Text;


class ex22
{
    static void Main()
    {
        Console.WriteLine("\nWrite data to check occurance of letters: \n");

        StringBuilder myString = new StringBuilder();
        Console.Write("Enter the data: ");
        myString.Append(Console.ReadLine());

        while(String.IsNullOrEmpty(myString.ToString()))
        {   
            Console.Write("Please Enter the data or Ctrl+C to exit: ");
            myString.Append(Console.ReadLine());
        }

        char[] myCharArray = myString.ToString().ToCharArray();
        ushort charSize = myCharArray.Length - 1;
        ushort[] arrayCheck = new ushort[256];

        for(ushort i = 0; i <= charSize; i++)
        {
            ushort m = (ushort)myCharArray[i];
            arrayCheck[m] += 1;
        }

        Console.WriteLine("\nType which character you want to check the number of occurance: \n");

        StringBuilder letterCheck = new StringBuilder();
        Console.Write("Enter the letter: ");
        letterCheck.Append(Console.ReadLine());

        while(String.IsNullOrEmpty(letterCheck.ToString()))
        {   
            Console.Write("Please enter a single character to check or Ctrl+C to exit: ");
            letterCheck.Append(Console.ReadLine());

            while(letterCheck.Length > 1)
            {
                letterCheck.Clear();
                Console.Write("Please enter a single character to check: ");
                letterCheck.Append(Console.ReadLine());
            }
        }

        while(letterCheck.Length > 1)
        {
            letterCheck.Clear();
            Console.Write("Please enter a single character to check: ");
            letterCheck.Append(Console.ReadLine());
        }

        char[] checkChar = letterCheck.ToString().ToCharArray();
        ushort letterIndex = checkChar[0];

        Console.WriteLine($"Number of character \'{checkChar[0]}\' occurance is: {arrayCheck[letterIndex]}");
        


        
        
    
    }
}
