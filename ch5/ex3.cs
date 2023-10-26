using System;

class ex3
{
	static void Main()
	{
		Console.WriteLine("To find the bigger of three integers");
			
		Console.Write("First Number= ");
		float n1 = float.Parse(Console.ReadLine());
		Console.Write("Second Number = ");
		float n2 = float.Parse(Console.ReadLine());
		Console.Write("Third Number = ");
		float n3 = float.Parse(Console.ReadLine());
		
		string s = " is the greatest number";
		
		if (n1 > n2)
		{
			if(n1 > n3)
			{
				Console.WriteLine("{0} " + s, n1);
			}
			
			else
			{
				Console.WriteLine("{0} " + s, n3);
			}			
		}
		else if (n2 > n1)
		{
			if(n2 > n3)
			{
				Console.WriteLine("{0} " + s, n2);
			}
			
			else
			{
				Console.WriteLine("{0} " + s, n3);
			}
			
		}
		else if (n3 > n1)
		{
			
			if(n3 > n2)
			{
				Console.WriteLine("{0} " + s, n3);
			}
			
			else
			{
				Console.WriteLine("{0} " + s, n2);
			}
		}
		else
		{
			Console.WriteLine("They are all Equal");
		}
		
			
	}
}

