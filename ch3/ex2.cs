using System;

class ex2
{
	static void Main()
	{
		Console.WriteLine("To check your number is is divisble by 5 and 7");
		int theNumber = Convert.ToInt32(Console.ReadLine());
		
		int check5and7 = theNumber % 35;
		bool trueFor5n7 = check5and7 == 0;
	
		Console.WriteLine("Is the number divisible?: ");
		Console.Write(trueFor5n7);
				
		
	}
}

