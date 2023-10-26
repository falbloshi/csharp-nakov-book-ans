using System;

class ex10
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find the frequently occuring elements");
		
		int[] firstArr = new int[0];
		int n = int.MinValue;
		bool ifInt = false;

		while(ifInt == false)
		{
			Console.Write("Type for N - number of elements: ");
			ifInt = int.TryParse(Console.ReadLine(), out n);
			firstArr = new int[n];
		
			if(!ifInt)
			{
				Console.WriteLine("Please type a number!");
			}
		}
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x < n; x++)
		{	
	
			Console.Write("Element {0}: ", x);
			firstArr[x] = int.Parse(Console.ReadLine());
		}
		
		
		int startingElement = 0, counter = 0, MaxCounter = 0;  
		for(int x = 0; x <= n-1; x++) 
		{
			if(startingElement == firstArr[x])
			{	continue;}
			else
			{	
				for(int j = x; j <= n-1; j++)
				{
					if(firstArr[j] ==firstArr[x])
					{ 
						counter++;
						if(counter > MaxCounter)
						{
							MaxCounter = counter;
							startingElement = firstArr[x];
						}
					}
				
				}
			}			
			counter = 0;	
		}
		
		int trick = startingElement;
		
		Console.Write("{");
		foreach(int y in firstArr)
		{ 
			if(y == trick)
			{
				Console.Write(" \'{0}\' ", y);
			}
			else
			{
				Console.Write(" {0} ", y);
			}
		}
		Console.Write("}");
		
		Console.Write(" -> {1} ({0} Times)", MaxCounter, trick);
		
		
	}
}
