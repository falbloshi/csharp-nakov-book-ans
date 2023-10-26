using System;

class ex11
{
	static void Main()
	{
		Console.WriteLine("To check if a given number N bit number at position P is 0 or 1");
		
		Console.Write("Number N = ");
		int nUmber = Convert.ToInt32(Console.ReadLine());
		Console.Write("Position P = ");
		int pOsition = Convert.ToInt32(Console.ReadLine());
		 
		int i = 1; 
		int P = i << pOsition;	
		
		Console.WriteLine("Is it a 0 or a 1 at that position? Answer : {0}  ", ((nUmber & P) != 0 ? 1 : 0));	
		
	}
}

