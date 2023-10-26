using System;

class ex2
{
	static void Main()
	{
		Console.WriteLine("To find if the resultant is negative or positive");
		
		
		
		Console.Write("First Number= ");
		float n1 = float.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		float n2 = float.Parse(Console.ReadLine());
		Console.Write("Third Number = ");
		float n3 = float.Parse(Console.ReadLine());
		
		string negative = "The Result is -";
		string positive = "The Result is +";
		
		if (n1 < 0)
		{
			if(n2 < 0 && n3 < 0 || n2 > 0 && n3 > 0)
			{
				Console.WriteLine(negative);
			}
			
			else
			{
				Console.WriteLine(positive);
			}
			
			
		}
		else if (n2 < 0)
		{
			if(n1 < 0 && n3 < 0 || n1 > 0 && n3 > 0)
			{
				Console.WriteLine(negative);
			}
			
			else			{
				Console.WriteLine(positive);
			}
			
		}
		else if (n3 < 0)
		{
			
			if(n2 < 0 && n1 < 0 || n2 > 0 && n1 > 0)
			{
				Console.WriteLine(negative);
			}
			
			else
			{
				Console.WriteLine(positive);
			}
		}
		else
		{
			Console.WriteLine(positive);
		}
		
			
	}
}

