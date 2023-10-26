using System;

class RecursiveFactorial
{
	
	static decimal Factorial(int n)
		{
		// The bottom of the recursion
			if (n == 0)
			{
				return 1;
			}
		// Recursive call: the method calls itself
			else
			{
				return n * Factorial(n - 1);
			}
		}
			
	
	static void Main() //the cutoff is 27
	{
		Console.Write("Write a number to find its factorial: " );
		int me = int.Parse(Console.ReadLine());
		
		decimal factorial = Factorial(me);
		Console.WriteLine("{0}! = {1}", me, factorial);
		
	}
}


