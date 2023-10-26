using System;

class ex1
{
	static void Main()
	{
		Console.WriteLine("To check your number is even or odd\n");
		int theNumber = Convert.ToInt32(Console.ReadLine());
		
		int checkEven = theNumber % 2;
		
		Console.WriteLine("Guide: If the remainder is 0, it is even. If it is 1, it is Odd");
		Console.WriteLine(checkEven);
				
		
	}
}

