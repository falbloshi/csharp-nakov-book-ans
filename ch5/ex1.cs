using System;

class ex1
{
	static void Main()
	{
		Console.WriteLine("To check which is the bigger number using If-statements and exchange values if first is bigger");
		
		int a, b;
		
		Console.Write("First Number= ");
		int n1 = int.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		int n2 = int.Parse(Console.ReadLine());
		
		if(n1 > n2){
			b = n1; 
			a = n2;
			n1 = a;
			n2 = b; 
		}
		
		Console.WriteLine("\nSecond Iteration \nFirst Number= {0}\nSecond Number = {1}", n1, n2);
		
		
	}
}

