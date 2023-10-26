using System;

class ex8  
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then sort it ascendingly");
		
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
				Console.WriteLine("Please type a number:");
			}
		}
			
		Console.WriteLine("Type the elements for the array: ");
		for(int x = 0; x < n; x++)
		{	
	
			Console.Write("Element #{0}: ", x+1);
			firstArr[x] = int.Parse(Console.ReadLine());
		}
		
		int tempInt = 0, jMin = 0, i = 0, j = 0;
		
		for( i = 0; i < firstArr.Length - 1; i++) 
 		{ 
	
			jMin = i;
			for(j = i+1; j < firstArr.Length; j++) //minimum element
			{
				if(firstArr[j] < firstArr[jMin])
				{
					jMin = j;
				}
			}
			
			if(jMin != i) //swap
			{
				tempInt = firstArr[i];
				firstArr[i] = firstArr[jMin];
				firstArr[jMin] = tempInt;	
			}
		}
		
		
		Console.Write("{");
		foreach(int x in firstArr){ 
			Console.Write(" {0} ", x);} 
		Console.Write("}");
			
		
	}
}
