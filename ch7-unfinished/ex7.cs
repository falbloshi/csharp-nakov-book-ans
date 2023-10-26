using System;

class ex7  //Getting out of bound error when I have an odd K - Solved it - by having it (n-k)+1 kinda not go over index
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find K consecutive elements which have maximal sum");
		
		int[] firstArr = new int[0];
	
		
		int n = int.MinValue, k = int.MinValue;
		
		bool ifKGreater = false;

		while(ifKGreater == false)
		{
			Console.Write("Type for N - number of elements: ");
			ifKGreater = int.TryParse(Console.ReadLine(), out n);
			firstArr = new int[n];
			
			Console.Write("Type for K(number of elements with maximum sum) for K < N: ");
			ifKGreater = int.TryParse(Console.ReadLine(), out k);
			
			if(k >= n)
			{
				Console.WriteLine("Please type a number with K < N");
				ifKGreater = false;
			}
		}
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x < n; x++)
		{	
	
			Console.Write("Element {0}: ", x);
			firstArr[x] = int.Parse(Console.ReadLine());
		}
		
		
		int sum = 0, maxSum = int.MinValue, startingIndex = 0, endingIndex = 0, counter = 1;  
		bool ifKNumberTrue = false;
		for(int x = 0; x < n-k+1; x++) // Solved it - by having it (n-k)+1 kinda not go over index 
 		{
			sum = 0;
			for(int j = 0; j < k; j++)
			{
				sum += firstArr[x + j];
				if(sum > maxSum)
				{
					maxSum = sum;
					startingIndex = x;			
					endingIndex = x+j;
					counter++;
				
				}
				if(counter == k) // for printing
				{
					ifKNumberTrue = true;
				}
			}		
			counter = 0;
		}
		Console.Write("{");
		foreach(int x in firstArr){ 
			Console.Write(" {0} ", x);} Console.Write("}");
			
		
		
		if(ifKNumberTrue){
			Console.Write(" --> {");
			for(int x = startingIndex; x <= endingIndex; x++) 
			{
				Console.Write(" {0} ", firstArr[x]);
			} 
			Console.Write("}"); Console.Write(" >> Maximal Sum -> {0}", maxSum);
		}
		else
		{
		 Console.Write(" None of the K number of element has the Maximal Sum");
		}
	}
}
