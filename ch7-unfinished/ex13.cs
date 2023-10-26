using System;

class ex13
{
	static void Main() 
	{

		Console.WriteLine("We are gonna take two number from you, one for length of array, one for width of array, then we are going to find the 3x3 maximal sum of that array");
		
		
		//input start
		int[,] firstArr = new int[0,0];

		int n = 0, k = 0;
		
		bool ifint = false;

		while(ifint == false)
		{
			Console.Write("Type for N - number of rows: ");
			ifint = int.TryParse(Console.ReadLine(), out n);			
			Console.Write("Type for K - number of columns: ");
			ifint = int.TryParse(Console.ReadLine(), out k);
			
			firstArr = new int[n, k];
			
			if(ifint == false || (n < 3) || (k < 3))
			{
				Console.Write("Please write a number that is 3 or greater\n");
				ifint = false;
			}
			
		}	
		
		Console.WriteLine("\nThe Randomly Generated Array: \n");
		
		Random rand = new Random();
		
		for(int row = 0; row < firstArr.GetLength(0); row++) 
		{
			for(int col = 0; col < firstArr.GetLength(1); col++)
			{
				Console.Write("{0,4}", (firstArr[row, col] = rand.Next(20)));
			}	
			Console.WriteLine();
		}
		//input end
		
		
		//to find the best maximal sum 3x3;
		
		int x = firstArr.GetLength(0);
		int y = firstArr.GetLength(1);
		int currentSum = int.MinValue, bestSum = int.MinValue, bestStartingElement = 0, bestRow = 0, bestCol = 0;
		
		//we got at each elements of the 2D array and find the maximal sums between them
		for(int row = 0; row < x-2; row++) //row < x-2 because last elements don't have a down or a right element to check with - out of bound expected
		{
			for(int col = 0; col < y-2; col++)
			{
				
				currentSum = firstArr[row, col] + firstArr[row+1, col] + firstArr[row+2, col]  + firstArr[row, col+1]  + firstArr[row, col+2] + firstArr[row+1, col+1]  + firstArr[row+1, col+2]  + firstArr[row+2, col+1]  + firstArr[row+2, col+2];

				if(currentSum > bestSum)
				{
					bestSum = currentSum;
					bestStartingElement = firstArr[row, col];
					bestCol = col;
					bestRow = row;
				}
			}	
		}
		
		Console.WriteLine("\nThe best sum is: {0} at element {1} of row {2} and col {3} \n", bestSum, bestStartingElement, bestRow , bestCol);
		
		//printing the 3x3
		int[,] printingArr = new int[3,3];
		
		for(int row = 0; row < 3; row++) 
		{
			for(int col = 0; col < 3; col++)
			{
				printingArr[row, col] = firstArr[bestCol+row, bestRow+col];
				
				Console.Write("{0,4}", printingArr[row, col]);
			}	
			Console.WriteLine();
		}
		
	}
}
