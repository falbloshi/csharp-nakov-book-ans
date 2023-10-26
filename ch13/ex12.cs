using System;
using System.Text;

class ex12
{
    static void Main()
    {
        Console.WriteLine("Please write a number to print it out in different notations.");
        
        decimal myInt = 0;
        try
        {   
            Console.Write("> ");
            var enteredNumber = Console.ReadLine();

            if(enteredNumber == "")
            {
                return;
            }

            myInt = Convert.ToDecimal(enteredNumber);
        }
        catch(FormatException)
        {
            Console.WriteLine("You have written a wrong number, please try again or press enter to exit:");
            Main();
        }

        int n = 1;
        while(n < 6)
        {
            switch(n)
            {
                case 1:
                Console.WriteLine("({1}) Decimal:  {0,15:#.#0}", myInt, n, " "); break;
                case 2:
                Console.WriteLine("({1}) Hexadecimal:  {0,15:X}", (int)myInt, n, " "); break;
                case 3:
                Console.WriteLine("({1}) Percentage:  {0,15:P}", myInt/100, n, " "); break;
                case 4:
                Console.WriteLine("({1}) Currency:  {0,15:C}", (float)myInt, n, " "); break;
                case 5:
                Console.WriteLine("({1}) Exponential: {0,15:E}", myInt, n, " "); break;

                default: break;
            }   
            n++;
        }
    }
}