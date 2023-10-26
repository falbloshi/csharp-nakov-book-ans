using System;

class ex9
{
	static void Main()
	{
		
		Console.WriteLine("We are going to calculate the same of S = 1+ 1!/x + 2!/n^2 +... n1/x^n.");
			
			
		double n = 1, x = 1;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
			{		
				Console.Write("Type for n: ");
				ifNumber = double.TryParse(Console.ReadLine(), out n);
				
				Console.Write("Type for x: ");
				ifNumber = double.TryParse(Console.ReadLine(), out x);
				
				if(ifNumber == false)
				{
					Console.WriteLine("Please write a number for n and x!");
				}
			}
		
		double a, c = 1, innerFactorial = 1, sum = 1;
	
		for(a = 1; a <= n; a++)
		{
			
			double b = 1; 
			
			while(b <= a)
			{
				innerFactorial = innerFactorial * b;
				b++;
	
			} 	
				
			c = Math.Pow(x, a);

			sum += innerFactorial / c;

			innerFactorial = 1; //we have to return it back to one
		}
		
		
		Console.Write("Sum: {0:0.###}\nfor S = 1 ", sum);
		
		for(int j = 1; j <= n; j++)
		{
			Console.Write("+ {0}!/{1}^{0}", j, x);
		}
		
			
	}
}

