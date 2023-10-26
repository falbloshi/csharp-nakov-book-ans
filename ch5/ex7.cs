using System;

class ex7
{
	static void Main()
	{
		Console.WriteLine("Write five numbers to find the biggest one");
		
			Console.Write("Number = ");
			int a =  nint.Parse(Console.ReadLine());
			
			Console.Write("Number = ");
			int b = int.Parse(Console.ReadLine());
			
			Console.Write("Number = ");
			int c = int.Parse(Console.ReadLine());
			
			Console.Write("Number = ");
			int d = int.Parse(Console.ReadLine());
			
			Console.Write("Number = ");
			int e = int.Parse(Console.ReadLine());
			
				
			
		if(a > b && a > c && a > d && a > e)
		{
			Console.WriteLine(a + " is the biggest number");		
		}	
		
		else if(b > a && b > c && b > d && b > e)
		{
			Console.WriteLine(b + " is the biggest number");		
		}

		else if(c > a && c > b && c > d && c > e)
		{
			Console.WriteLine(c + " is the biggest number");		
		}	
		
		else if(d > a && d > b && d > c && d > e)
		{
			Console.WriteLine(d + " is the biggest number");		
		}	
		
		else if(e > a && e > b && e > c && e > d)
		{
			Console.WriteLine(e + " is the biggest number");		
		}
		else
		{
			Console.WriteLine("No one is big");
		}
		
	
	}
}

