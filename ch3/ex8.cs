using System;

class ex8
{
	static void Main()
	{
		Console.WriteLine("To check if {x, y} if it is within the circle K({0, 0}, R=5)");
		
		Console.Write("x = ");
		int rA = Convert.ToInt32(Console.ReadLine());
		Console.Write("y = ");
		int rB = Convert.ToInt32(Console.ReadLine());
		
		bool forX = (rA <= 5) && (rA >= -5);
		bool forY = (rB <= 5) && (rB >= -5);
		
		bool boolLast = forX && forY;

		
		Console.WriteLine("Is it within the circle? Answer: {0} ", boolLast);
				
		
	}
}

