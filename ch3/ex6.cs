using System;

class ex6
{
	static void Main()
	{
		Console.WriteLine("Perimeter and area of rectangle of your given Size: ");
		
		Console.Write("A= ");
		int rA = Convert.ToInt32(Console.ReadLine());
		Console.Write("B= ");
		int rB = Convert.ToInt32(Console.ReadLine());
		
		int peri = 2*rA + 2*rB;
		int area = rA * rB;
	
		Console.WriteLine("Perimeter {0} and Area {1}", peri, area);
				
		
	}
}

