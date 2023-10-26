using System;

class ex9
{
	static void Main()
	{
		Console.WriteLine("To check if {x, y} if it is within the circle K({0, 0}, R=5) and out of the rectangle [{-1, 1}, {5, 5}].");
		
		Console.Write("x = ");
		int cX = Convert.ToInt32(Console.ReadLine());
		Console.Write("y = ");
		int cY = Convert.ToInt32(Console.ReadLine());
		
		int x1 = -1, y1 = 1, x3 = 5, y3 = 5;
				
		//for circle
		bool forX = (cX <= 5) && (cX >= -5);
		bool forY = (cY <= 5) && (cY >= -5);
		
		bool boolCircle = forX && forY;
		
		//for rectangle - we reverse the answer since it results true for being inside
		bool forLL = (cX >= x1) && (cY >= y1); 
		bool forUR = (cX <= x3) && (cY <= y3);
		
		bool boolRectangle = forLL && forUR; 

		
		Console.WriteLine("Is it within the circle? Answer: {0} ", boolCircle);
		Console.WriteLine("Is it the outside the rectangle? Answer: {0} ", !boolRectangle);		
		
	}
}

