using System;

class ex6
{
	static void Main()
	{
		Console.WriteLine("To check which is the bigger number");
		
		Console.Write("First Number= ");
		int n1 = int.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		int n2 = int.Parse(Console.ReadLine());
		
		int next = Math.Max(n1, n2);	
			
		Console.WriteLine("{0} Is the Bigger Number", next);
	}
}

