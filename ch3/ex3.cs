using System;

class ex3
{
	static void Main()
	{
		Console.WriteLine("To check your number has a 7 at the end");
		int theNumber = Convert.ToInt32(Console.ReadLine());
		
		int checkEnd7 = theNumber % 100;
		checkEnd7 = checkEnd7 % 10;
		
		bool trueEnd7 = checkEnd7 == 7;
	
		Console.WriteLine("Does it have a 7? ");
		Console.Write(trueEnd7);
				
		
	}
}

