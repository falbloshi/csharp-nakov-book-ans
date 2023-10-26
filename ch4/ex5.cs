using System;

class ex5
{
	static void Main()
	{
		Console.WriteLine("Write two number - so that we can check how many numbers are divisible by 5 between them");
		
		Console.Write("Smaller number = ");
		int n1 = int.Parse(Console.ReadLine());
		Console.Write("Bigger Number = ");
		int n2 = int.Parse(Console.ReadLine());
		int c = 0;
		for(int x = n1; x <= n2; x++)
		{
			int d = x % 5;
			
			if(d == 0){
				c++;
				Console.Write(x);
			}
		}
			
		Console.WriteLine("Numbers that are divisible by 5 are: {0}", c);
	}
}

