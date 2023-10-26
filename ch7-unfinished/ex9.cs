using System;

class ex9
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find the subsequence with the maximum sum");
		
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
		
		
		int sum = 0, maxSum = int.MinValue, startingIndex = 0, endingIndex = 0;  
		for(int x = 0; x <= n-1; x++) 
		{
			for(int j = x; j <= n-1; j++)
			{
				sum += firstArr[j];
				if(sum > maxSum)
				{
					maxSum = sum;
					startingIndex = x;			
					endingIndex = j;
				}
			
			}		
			sum = 0;	
		}
		
		Console.Write("{");
		foreach(int x in firstArr){ 
			Console.Write(" {0} ", x);} 
		Console.Write("}");

		{
			Console.Write(" --> Sequence {");
			for(int x = startingIndex; x <= endingIndex; x++) 
			{
				Console.Write(" {0} ", firstArr[x]);
			} 
			Console.Write("}"); Console.Write(" >> Maximal Sum -> {0}", maxSum);
		}
		
	}
}
