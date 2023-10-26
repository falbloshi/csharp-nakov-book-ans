using System;

class ex14 //incomplete will complete later 
{
	static void Main() 
	{

		Console.WriteLine("We are gonna find the longest sequence of a a string in a matrix, of same row, column or diagonal");
		
		
		//input start
		string[,] firstArr = { {"ha", "fifi", "ho", "hi"}, {"fo", "ha", "hi", "xx"},  {"xxx", "ho", "ha", "xx"} };
		
		string[,] secondArr = { {"s", "qq", "s"}, {"pp", "pp", "s"},  {"pp", "qq", "s"} };
		
		
		
		
		
		//to find the best maximal sum 3x3;
		
		int fx = firstArr.GetLength(0);
		int fy = firstArr.GetLength(1);
		int sx = firstArr.GetLength(0);
		int sy = firstArr.GetLength(1);
		
		//printing the array
		
		for(int row = 0; row < fx; row++) 
		{
			for(int col = 0; col < fy; col++)
			{
				
				Console.Write("{0,5}", firstArr[row, col]);
			}	
			Console.WriteLine();
		}
		
		int counterDiag = 0, bestCounterDiag = int.MinValue, bestRow = 0, bestCol = 0; // counterRow = 0, counterCol = 0,  bestCounter = 0, bestStartingElement = 0, ;
		for(int row = 0; row < fx; row++) //checking each element
		{
			for(int col = 0; col < fy; col++) 
			{
				
				/*
				//checking column wise
				for(int i = col+1; i < fy; i++)
				{
					if(firstArr[row, col] == firstArr[row, i])
					{
						counterCol++;
					}
				}
				//row wise
				for(int j = row+1; j < fx; j++)
				{
					if(firstArr[row, col] == firstArr[j, col])
					{
						counterRow++;
					}
				}
				*/
				
				//diag wise
				for(int k = row; k < fx - row; k++)
				{
					if(firstArr[row, col] == firstArr[row+k, k])
					{
						++counterDiag;
					}
				}
				
				if(counterDiag > bestCounterDiag)
				{
					bestCounterDiag = counterDiag;
					bestRow = row; 
					bestCol = col;
				}
				
				//Console.WriteLine("Element \"{0}\" at row {1} and col {2} - col counter: {3} - row counter: {4} - diag counter: {5}", firstArr[row, col] , row, col, counterCol, counterRow, counterDiag );
				
				
			}	
			
			Console.WriteLine("------------> Next Row <-----------");
			counterDiag = 0;
		}
		
		Console.WriteLine("Best element {0} with diag {1}", firstArr[bestRow, bestCol], bestCounterDiag );
		
	//	Console.WriteLine("\nThe best sum is: {0} at element {1} of row {2} and col {3} \n", bestSum, bestStartingElement, bestRow , bestCol);
		
		
		
	}
}
