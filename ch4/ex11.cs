using System;
using System.Numerics;

class ex11
{
	static void Main()
	{
		
		
		
		
		Console.WriteLine("This will print the first 100 fibionnaci stuff");		
		
		
		BigInteger firstNumberBI = (BigInteger) 0;
		BigInteger secondNumberBI = (BigInteger) 1.0;
		BigInteger savedNumberBI = (BigInteger) 0.0;
		
		for(int x = 1; x <= 100; x++)
		{
			
			savedNumberBI = firstNumberBI + secondNumberBI; 
			
			firstNumberBI = secondNumberBI;
			
			secondNumberBI = savedNumberBI; 
			
			Console.WriteLine("{0}) {1}", x, secondNumberBI);
			
		}	
			
	}
}

