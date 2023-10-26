using System;

class ex1
{
	static void Main()
	{
		Console.WriteLine("Give me three numbers, and I will add them: ");
		
		Console.Write("Number 1 = ");
		int n1 = int.Parse(Console.ReadLine());
		Console.Write("Number 2 = ");
		int n2 = int.Parse(Console.ReadLine());
		Console.Write("Number 3 = ");
		int n3 = int.Parse(Console.ReadLine());

		
		
		Console.WriteLine("New Number : {0}  ", (n1+n2+n3));	
		
	}
}

