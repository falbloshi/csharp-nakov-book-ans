using System;

class ex12
{
	static void Main()
	{
		Console.WriteLine("To check if a given number N bit number at position P is 1 or not");
		
		Console.Write("Number N = ");
		int nUmber = Convert.ToInt32(Console.ReadLine());
		Console.Write("Position P = ");
		int pOsition = Convert.ToInt32(Console.ReadLine());
		 
		int i = 1; 
		int P = i << pOsition;	
		
		Console.WriteLine("Is it a 1 at that position? Answer : {0}  ", ((nUmber & P) != 0 ? true : false));	
		
	}
}

