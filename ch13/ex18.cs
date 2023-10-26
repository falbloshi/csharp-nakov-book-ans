using System;
using System.Text;
using System.Globalization;


class ex18
{
    static void Main()
    {
        Console.WriteLine("Write a date in the format (in dd.MM.yyy hh:mm:ss format):\n");

        CultureInfo enEN = new CultureInfo("de-DE"); 
        DateTime myDate = new DateTime();
        StringBuilder myString = new StringBuilder();

        Console.Write("Enter the date: ");
        myString.Append(Console.ReadLine());

        while(!(DateTime.TryParseExact(myString.ToString(), "d.MM.yyyy HH:mm:ss", enEN, DateTimeStyles.None, out myDate)))
        {   
            myString.Clear();
            Console.WriteLine("Please write correct format: ");
            Console.Write("Enter the date: ");
            myString.Append(Console.ReadLine());	
        }

        TimeSpan timeAdd = new TimeSpan(0, 6, 30, 0);

        myDate = myDate.Add(timeAdd);
        Console.WriteLine("New time: {0: dd.MM.yyyy HH:mm:ss}", myDate);

    }
}

