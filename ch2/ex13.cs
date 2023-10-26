using System;

class ex13
{
	static void Main()
	{
		byte a = 5;
		byte b = 10; 
		byte c = a;
		
		Console.WriteLine(a);
		Console.WriteLine(b);
		a = b;
		b = c;
		Console.WriteLine("Swap \n");
		Console.WriteLine(a);
		Console.WriteLine(b);
	}
}

