using System;

class ex2 //recursive version
{
	static int numberOfElements;
	static int numberOfIterations;
	static int[] mainArr;
	
	static void Main()
	{	
	  Console.Clear();
	  Console.Write("To Generate all variations with duplicates of N elements of class K\n");
	  Console.Write("N = ");
	  numberOfElements = int.Parse(Console.ReadLine()); //just to be clear the book has this as numberofiterations
	  Console.Write("K = ");
	  numberOfIterations = int.Parse(Console.ReadLine()); //and this as numberofloops
	  
	  mainArr = new int[numberOfIterations];
	  DuplicationOfElements(0);
	}
	
	static void DuplicationOfElements(int currentLoop)
	{ 
		
		if (currentLoop == numberOfIterations)
		{
			PrintLoops(mainArr);
			return;
		}
		for (int counter=1; counter<=numberOfElements; counter++)
		{
			mainArr[currentLoop] = counter;
			DuplicationOfElements(currentLoop + 1);
			Console.WriteLine();
		}
	}
	
	static void PrintLoops(int[] array)
    {
	   int arrSize = array.Length;
       for(int i = 0; i < arrSize; i++)
       {
			if(i == arrSize-1)
			{
				Console.Write(array[i]); Console.Write(")");
			}
			else if(i == 0)
			{
				Console.Write("(" + array[i] + ", ");
			}
			else
			{
				Console.Write(array[i] + ", ");
			}
		}
		Console.Write(" ");
    }
}