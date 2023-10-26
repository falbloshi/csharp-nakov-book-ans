using System;

class ex20
{
	static void Main() 
	{

		Console.WriteLine("Insert number of elements and their elements for an array, and a number we can find for their sum");
		
		
		//input start
		int[] mainArr = new int[0];

		int n = 0, k = 0, s = 0;
		
		bool ifint = false;

		while(ifint == false)
		{
			Console.Write("The number of elements: ");
			ifint = int.TryParse(Console.ReadLine(), out n);			
			mainArr = new int[n];
			Console.Write("\nWhat is the sum: ");
			ifint = int.TryParse(Console.ReadLine(), out s);		
		}		
		bool ifElInt = false; 
		while(ifElInt = false)
		{
			foreach(int i in mainArr)
			{
				int count;
				Console.WriteLine("Element {0}: ", count); count++;
				ifElint = int.TryParse(Console.ReadLine(), out k);	
				mainArr[i] = k;
			}
		}
		Console.WriteLine("Your elements");
		foreach(int i in mainArr)
		{
			Console.Write("{0} ", i);
		}
		
		
		
	}
	
}