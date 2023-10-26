using System;
using System.Text;
using System.Globalization;


class ex17
{
    static void Main()
    {
        Console.WriteLine("Write two dates to see the difference between them(in d.MM.yyy format):\n");

        CultureInfo enEN = new CultureInfo("en-GB"); 
        DateTime[] myDays = new DateTime[2];
        StringBuilder myString = new StringBuilder();
        StringBuilder ofDay = new StringBuilder();

        ofDay.Append("first");
        for(int i = 0; i < 2; i++)
        {		   
            Console.Write($"Enter the {ofDay.ToString()} date: ");
            myString.Append(Console.ReadLine());

            while(!(DateTime.TryParseExact(myString.ToString(), "d.MM.yyyy", enEN, DateTimeStyles.None, out myDays[i])))
            {   
                myString.Clear();
                Console.WriteLine("Please write correct format: ");
                Console.Write($"Enter the {ofDay.ToString()} date: ");
                myString.Append(Console.ReadLine());	
            }
            myString.Clear();
            ofDay.Replace("first", "second");
        }
        
        TimeSpan daysDiff = (myDays[0] > myDays[1]) ? myDays[0] - myDays[1] : myDays[1] - myDays[0]; //ternary operation

        Console.WriteLine($"Distance: {daysDiff.Duration().Days} days");

    }
}

