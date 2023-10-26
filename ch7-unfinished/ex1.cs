using System;

class ex1
{
	static void Main()
	{

		Console.WriteLine("We gonna initialize an int array program that displays the elements as their index multiplied by 5");
		
		int[] n = new int[20];
		
		for(int x = 0; x <= n.Length - 1; x++)
		{	
			
			Console.WriteLine(n[x] = x *5);
		}
		
	}
}
