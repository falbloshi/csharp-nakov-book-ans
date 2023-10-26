using System;

class ex2 //iterative version
{
	static int numberOfElements;
	static int numberOfIterations;
	static int[] mainArr;
	
	static void Main()
	{	
	  Console.Clear();
	  Console.Write("To Generate all variations with duplicates of N elements of class K\n");
	  Console.Write("N = ");
	  numberOfElements = int.Parse(Console.ReadLine());
	  Console.Write("K = ");
	  numberOfIterations = int.Parse(Console.ReadLine());
	  
	  mainArr = new int[numberOfIterations];
	  DuplicationOfElements();
	}
	
	static void DuplicationOfElements()
	{ 
		InitLoops();
		int currentPosition;
		while(true)
		{
		  PrintLoops(mainArr);
		  currentPosition = numberOfIterations - 1;
		  mainArr[currentPosition] = mainArr[currentPosition] + 1;
		  while(mainArr[currentPosition] > numberOfElements)
		  {
			mainArr[currentPosition] = 1;
			currentPosition--;
			Console.Write("\n");
			if(currentPosition < 0)
			{
			  return;
			}
			mainArr[currentPosition] = mainArr[currentPosition] + 1;
		  }
		}
	}
  
	static void InitLoops()
	{
		for (int i = 0; i < numberOfIterations; i++)
		{
		  mainArr[i] = 1;
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