using System;

class ex4 
{
    public static void Main() 
    {
		double result = Environment.TickCount;
		result = result/((1000.0)*60*60*24);
		Console.WriteLine("Your computer is running for\nDays: {0:0}", result);
		Console.WriteLine("Hours: {0:00}", result*24);
		Console.WriteLine("Minutes: {0:000}", result*24*60);
		Console.WriteLine("Seconds: {0:0000}", result*24*60*60);
    }
}