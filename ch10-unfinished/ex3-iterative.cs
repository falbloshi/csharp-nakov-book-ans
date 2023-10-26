using System;

class ex3 //iterative version
{
	static int numberOfElements;
	static int numberOfIterations;
	static int[] mainArr;
	
	static void Main()
	{	
	  Console.Clear();
	  Console.Write("To Generate all combination with duplicates of N elements for a set of K elements\n");
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
		for(i = 0; i < numberOfIterations)
		{
			int n = 0;
			while(n < numberOfElements)
			{
				mainArr[n] = n++;
				PrintLoops(mainArr);
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