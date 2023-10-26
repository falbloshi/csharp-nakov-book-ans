using System;

class ex11
{
	static void Main() //it takes the most amount of neighbouring elements for example (5, 5, 2 , 3, 1) will take {5,2,3,1} for 11 and {5,6,2,3,1}, will take 6,2,3 instead of 6, 5 for 11 as well
	{

		Console.WriteLine("We are gonna take an array from you and then find the neighbouring subsequence of elements with a sum S");
		
		int[] firstArr = new int[0];


		int n = int.MinValue, s = int.MinValue;
		
		bool ifInt = false;

		while(ifInt == false)
		{
			Console.Write("Type for N - number of elements: ");
			ifInt = int.TryParse(Console.ReadLine(), out n);
			firstArr = new int[n];
			
			Console.Write("Type for S - the request Sum: ");
			ifInt = int.TryParse(Console.ReadLine(), out s);

		}
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x < n; x++)
		{	
	
			Console.Write("Element {0}: ", x);
			firstArr[x] = int.Parse(Console.ReadLine());
		}
		
		
		int sum = 0, startingIndex = 0, endingIndex = 0;  
		bool thereISSum = false;
		for(int x = 0; x <= n-1; x++) 
		{
			for(int j = x; j <= n-1; j++)
			{
				sum += firstArr[j];
				if(sum == s)
				{
					startingIndex = x;			
					endingIndex = j;
					thereISSum 	= true;
				}
			
			}		
			sum = 0;	
		}
	
		
		Console.Write("{");
		foreach(int x in firstArr){ 
			Console.Write(" {0} ", x);} 
		Console.Write("}");
		
		if(thereISSum){
			Console.Write(" --> {");
			for(int x = startingIndex; x <= endingIndex; x++) 
			{
				Console.Write(" {0} ", firstArr[x]);
			} 
			Console.Write("}"); Console.Write(" >> Sum of Neighbouring Elements-> {0}", s);
		}
		else
		{
		 Console.Write(" None of the neighbouring elements has a the sum {0}", s);
		}
		
	}
}
