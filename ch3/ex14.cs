using System;

class ex14
{
	static void Main()
	{
		Console.WriteLine("To check a given number is a prime number between 1 and 100");
			
		Console.Write("Number N = ");
		int nUmber = Convert.ToInt32(Console.ReadLine());
	
		int d = 0;
		bool flagged = false;
		
		for(int x = 2; x <= nUmber/2 ; x++)
		{	
			d = nUmber % x;
			
			if(d == 0)
			{
				flagged = true;
			}
			
		}
		Console.WriteLine("Answer : {0}  ", (flagged == true ? false : true));	
		
	}
}

