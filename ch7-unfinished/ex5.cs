using System;

class ex5
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find consequently increasing numbers");
		
		int[] firstArr = new int[0];
	
		
		int n1 = int.MinValue;
		

		Console.WriteLine("Type numbers of elements for the array: ");
		n1 = int.Parse(Console.ReadLine());
		firstArr = new int[n1];
		
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x < n1; x++)
		{	
			Console.Write("Element {0}: ", x);
			firstArr[x] = int.Parse(Console.ReadLine());
		
		}
		
		
		 // when i did 'int[] newArr = firstArr' - it kept editing firstArr despiting being nowhere in the editing code
		
		int firstElement  = 0, secondElement = 0;
		int bestValue = int.MinValue;
		int currentValue = 0;
		int currentBestValue = 0;
		int bestEnding = 0;
		for(int x = 0; x < n1 - 1; x++)
		{
			firstElement = firstArr[x];
			secondElement = firstArr[x+1] - 1;
			
			if(firstElement == secondElement)
			{
				currentValue++;
				currentBestValue = currentValue;
			}
			else
			{
				currentValue = 0;
			}
			
			if(currentBestValue > bestValue)
			{
				bestValue = currentBestValue;
				bestEnding = firstArr[x];
			}
			else if(bestValue > currentBestValue)
			{
				currentBestValue = 0;
			}
		}
		
		Console.Write("{");
		for(int j = 0; j <= n1 - 1; j++)
		{	
			Console.Write(" {0} ", firstArr[j], j);
		}
		Console.Write("}");
		
		Console.WriteLine("\nThe consequently increasing sequences are: ");
		
		Console.Write("{");
		
		
		//printing it 
		bestEnding += 1; //because best ends at the last x that doesn't end with the next one
		int[] newArr = new int[bestValue+1];
		for(int x = bestValue; x >= 0; x--) //to reverse print it
		{
			newArr[x] = bestEnding--;
		}
		
		foreach(int x in newArr) 
		{
			Console.Write(" {0} ", x);
		}
		
		Console.Write("}");
	}
}
