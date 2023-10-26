using System;

class ex12
{
	static void Main()
	{
		
		Console.WriteLine("Number Converter - Convert from decimal to binary");
			
			
		ulong n = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
		{		
			Console.Write("Type for n: ");
			ifNumber = ulong.TryParse(Console.ReadLine(), out n);
			
		}
		
		ulong m = n, iteration = 0, multiTen = 1,  remainder = 0, sumOfMultiple = 0;
		
		for(iteration = n; iteration > 0; iteration /= 2) // Some error happening - using double keeps sending me to infinety
		{
			remainder = m % 2;
			m /= 2;
			sumOfMultiple += remainder * multiTen;
			multiTen *= 10;
		}
	
	Console.WriteLine("The Decimal Representation: {1}\nThe Binary representation: {0}", sumOfMultiple, n);
	

		
		
			
	}
}

