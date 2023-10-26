using System;

class ex12
{
	static void Main() 
	{

		Console.WriteLine("We are gonna take a number from you and then print out the square of that number in different format");
		
		int[,] firstArr = new int[0,0];

		int num = int.MinValue;
		
		bool ifInt = false;

		while(ifInt == false)
		{
			Console.Write("Type for N - number of elements: ");
			ifInt = int.TryParse(Console.ReadLine(), out num);
			firstArr = new int[num, num];

		}	
		
		Console.WriteLine("\n");
		
		//first format
		int firstA = 0;
		for(int col = 0; col < firstArr.GetLength(1); col++) 
		{
			for(int row = 0; row < firstArr.GetLength(0); row++)
			{
				firstArr[row, col] = ++firstA;
			}	
		}
		
		//printing
		string elementA = "";
		for (int row = 0; row < firstArr.GetLength(0); row++)
		{
			for (int col = 0; col < firstArr.GetLength(1); col++)
			{
				elementA = Convert.ToString(firstArr[row, col], 10); //10 for base ten or decimals
				Console.Write(elementA.PadLeft(6));
			}
			Console.WriteLine();
		}
		
		//second format //num is same as GetLength(0) and GetLength(1) because it is the same since it is a square matrix
		int[,] secondArr = new int[num,num];
		int secondB = 0;
		for(int col = 0; col < num; col++) 
		{	
			if(col % 2 == 0){ //even numbered columns are normal 
				for(int row = 0; row < num; row++)
				{
					secondArr[row, col] = ++secondB;
				}
			}
			else
			{   //odd numbered starts from bottom to up 
				for(int row = num - 1; row >= 0; row--)
				{
					secondArr[row, col] =  ++secondB;
				}
			}
		}
		
		Console.WriteLine("\n");
		
		//printing
		string elementB = "";
		for (int row = 0; row < num; row++)
		{
			for (int col = 0; col < num; col++)
			{
				elementB = Convert.ToString(secondArr[row, col], 10); //10 for base ten or decimals
				Console.Write(elementB.PadLeft(6));
			}
			Console.WriteLine();
		}
		
		//third format 
		int[,] thirdArr = new int[num,num];
		int n = 0, thirdC = 0;
	
		//this gives me upper diag 
		//we are basically jumping up from a row to the next upper right element and then adding it up, from each new row	
		for(int row = 0; row < num; row++, n = 0) 
		{			
				while(n <= row)
				{				
					thirdArr[row-n, n] = ++thirdC; 
					n++;					
				}		
		}		
		//for lower diag - we start at 1 index column since we don't want the middle diag repeating from previous loop, and stay at the last row since all starting row element from the upper diag has been filled  
		int lastRows = num-1, add = 0;
		for(int col = 1; col <= num-1; col++, add = 0)
		{	
			while((add+col) <= num-1) //as per how many columns we have left, we need to repeat the iterations
			{
				thirdArr[lastRows - add, add + col] = ++thirdC;					
				add++;
			}
		}
		
		//we need to reverse the matrix 
		int[,] newthirdArr = new int[num, num];
		int bigIndex = num-1;
		for(int i = 0; i < num; i++)
		{
			for(int j = 0; j < num; j++)
			{
				newthirdArr[bigIndex-j, i] = thirdArr[j, i];  
			}
		}
		
		Console.WriteLine("\n");
		//printing
		string elementC= "";
		for (int row = 0; row < num; row++)
		{
			for (int col = 0; col < num; col++)
			{
				elementC = Convert.ToString(newthirdArr[row, col], 10); //10 for base ten or decimals
				Console.Write(elementC.PadLeft(6));
			}
			Console.WriteLine();
		}
		
		//fourth format 
		int[,] fourthArr = new int[num,num];
			
		int lastIndex = num-1, firstIndex = 0, increment = 0, fourthD = 0;	//commented writlines for debugging
		while(lastIndex >= 0)
		{
			//for going downwards - colum remain the same while increasing row
			for(int i = firstIndex; i <= lastIndex; i++)
			{
				fourthArr[i, firstIndex] = ++fourthD;
				//Console.WriteLine("Downward {0} - row index {1} - LastIndex {2}", fourthD, i, lastIndex);
			}
			increment++; 
			//for going rightwards - adding 1 to column once, then increasing column while row the same
			for(int i = firstIndex + increment; i <= lastIndex; i++)
			{
				fourthArr[lastIndex, i] = ++fourthD;
				//Console.WriteLine("rightward {0} - col index {1} - LastIndex {2}", fourthD, i, lastIndex);
			}
			//for going upwards - removing 1 from row then decreasing row, while column the same 
			for(int i = lastIndex - increment; i >= firstIndex; i--)
			{
				fourthArr[i, lastIndex] = ++fourthD;
				//Console.WriteLine("upwards {0} - row index {1} - LastIndex {2}", fourthD, i, lastIndex);
			}
			//for going leftward - removing 1 from column and adding 1 to row and then decreasing the column
			for(int i = lastIndex - increment; i >= firstIndex + increment; i--)
			{
				fourthArr[firstIndex, i] = ++fourthD;
				//Console.WriteLine("leftwards {0} - row index {1} - LastIndex {2}", fourthD, i, lastIndex);
			}
			
			lastIndex--; // decrease last index and increase first index for the next inner loop
			firstIndex++;
			increment = 0;
		}
		
		
		
		Console.WriteLine("\n");
		//printing
		for (int row = 0; row < num; row++)
		{
			for (int col = 0; col < num; col++)
			{
				Console.Write("{0,6}", fourthArr[row, col]);
			}
			Console.WriteLine();
		}

		
	}
}
