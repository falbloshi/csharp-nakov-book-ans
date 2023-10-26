using System;

class ex6
{
	static void Main()
	{
		Console.WriteLine("Write ax^2 + bx + c to find its quadratic equation and if it has real roots");
			
		double a = 0, b, c;
		
		
		
		while(a == 0){
			Console.Write("Insert for 'a' as a non zero: ");
			a = double.Parse(Console.ReadLine());
		}
		Console.Write("Insert for b: ");
		b = double.Parse(Console.ReadLine());
		Console.Write("Insert for c: ");
		c = double.Parse(Console.ReadLine());			
			
		double d = (Math.Pow(b, 2)) - (4*a*c);
		
		
		bool isPerfectSquare = (Math.Sqrt(d) % 1) == 0;  
		
		if(d == 0){
			Console.WriteLine("Has one real root: {0} It is Real and Equal ", (-b / (2 * a))); 
		}
		else if (d > 0){
			
			if(isPerfectSquare)
			{
				Console.WriteLine("Has two real roots: {0} Real, Rational and Unequal", ((-b) - (Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a)); 
			}
			else if(!(isPerfectSquare))
			{
				Console.WriteLine("Has two real roots: {0} Real, Irrational and Unequal", ((-b) + (Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / 2 * a)); 
			}
			
		}
		else
		{
			Console.WriteLine("Has no real roots: It's Unequal and Imaginary"); 
		}
		
			
	}
}

