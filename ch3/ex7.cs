using System;

class ex7
{
	static void Main()
	{
		Console.WriteLine("Find your weight on the moon!");
		
		Console.Write("Your weight on Earth = ");
		float rA = Convert.ToSingle(Console.ReadLine());
		
		float moon = rA * 0.17f; 
		
		Console.WriteLine("Your weight on the Moon = {0}", moon);
				
		
	}
}

