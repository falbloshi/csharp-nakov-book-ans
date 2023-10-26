using System;


class ex1 //same as recursivenestedloops with one variable only = N;
{
	static int numberOfLoops;
	static int numberOfIterations;
	static int[] loops;
	static void Main()
	{
	  Console.Write("N = ");
	  numberOfLoops = int.Parse(Console.ReadLine());
	  loops = new int[numberOfLoops];
	  NestedLoops(0);
	  }
		static void NestedLoops(int currentLoop)
	  {
	  if (currentLoop == numberOfLoops)
		{
		  PrintLoops();
		  return;
		}
		for (int counter=1; counter<=numberOfLoops; counter++)
		{
		  loops[currentLoop] = counter;
		  NestedLoops(currentLoop + 1);
		}
	  }
	  static void PrintLoops()
	  {
	  for (int i = 0; i < numberOfLoops; i++)
	  {
	   Console.Write("{0} ", loops[i]);
	  }
	  Console.WriteLine();
	}
}