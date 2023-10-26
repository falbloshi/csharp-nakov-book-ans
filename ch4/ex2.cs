using System;

class ex1
{
	static void Main()
	{
		Console.WriteLine("I will find you the area and the perimeter of the circle, just give me the radius: ");
		
		Console.Write("Radius = ");
		double r = double.Parse(Console.ReadLine());
		
		double perimeter = 2 * (Math.PI) * r;
		double area = (Math.PI) * r * r ;
		
		
		Console.WriteLine("Perimeter: {0:0.###}\nArea: {1:0.###}  ", perimeter, area);	
		
	}
}

