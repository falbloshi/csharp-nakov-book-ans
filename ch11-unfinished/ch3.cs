using System;

class RandomNums
{
	
	static void Main()
	{
		Random myRandom = new Random();
		for(int number = 1; number 	<= 6; number++)
		{
			int randomNumber = myRandom.Next(49) +1;
			Console.Write("{0} ", randomNumber);
		}
	}

}
