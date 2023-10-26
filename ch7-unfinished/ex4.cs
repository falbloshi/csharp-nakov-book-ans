using System;

class ex4
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find the maximal sequence of equal element");
		
		int[] firstArr = new int[0];
		
		
		int n1 = int.MinValue;
		
		bool ifNumber1 = false;
		
		while(ifNumber1 == false) 
		{		
			Console.WriteLine("Type numbers of elements for the array: ");
			ifNumber1 = int.TryParse(Console.ReadLine(), out n1);
			firstArr = new int[n1];
		}
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x <= n1 - 1; x++)
		{	
			Console.Write("Element {0}: ", x+1);
			firstArr[x] = int.Parse(Console.ReadLine());
		
		}
		
		int bestValue = int.MinValue;
		int currentValue = 0;
		int currentBestValue = 0;
		int bestInt = 0;
		int elementY = 0;
		for(int x = 0; x < n1 - 1; x++)
		{
						
			if(elementY != firstArr[x])
			{
				elementY = firstArr[x];
				currentValue = 0;
			}
			if(elementY == firstArr[x])
			{
				++currentValue;
				currentBestValue = currentValue;
			}
			
			if(currentBestValue > bestValue)
			{
				bestValue = currentBestValue;
				bestInt = firstArr[x];
			}
			else if(bestValue > currentBestValue)
			{
				currentBestValue = 0;
			}
			
			
		}
		
		Console.Write("{");
		foreach(int x in firstArr)
		{
	
			Console.Write(" {0} ", x);
			
		}
		Console.Write("}");
		
		Console.WriteLine("\nThe maximal equal sequences are: ");
		
		Console.Write("{");
		while(bestValue > 0){
		Console.Write(" {0} ", bestInt);	
		bestValue--;
		}Console.Write("}");
	}
}
