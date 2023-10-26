using System;

class ex8
{
	static void Main()
	{
		
		//use double - using ulong kinda mucks it up
		Console.WriteLine("Type a number to find its catalan nth number.");
			
			
		double n = 1, factorialN = 1, factorial2x = 1, factorialN1 = 1;
		double N = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
			{		
				Console.Write("Type the Number: ");
				ifNumber = double.TryParse(Console.ReadLine(), out N);
				
				if(n <= 0)
				{
					ifNumber = false;
				}
			}
		
		double x = 1, y = 1, z = 1;
	
		while(x <= N)
		{
			factorialN = factorialN*x; x++;
		}

				
		while(y <= (N*2))
		{
			factorial2x  = factorial2x * y; y++;
		}

		
		while(z <= (N+1))
		{
			factorialN1  = factorialN1 * z; z++;
		}
	
		
		double multi = factorialN1 * factorialN;
		double divis = factorial2x / multi;
		
		Console.WriteLine("\nResult for 2*{0}!/({0}+1)!{0}!\nResult: {1}", N, divis);
		
			
	}
}

