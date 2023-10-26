using System;

class ex10
{
	
	static string factorialCalc(string n)
	{
		int lengthOfN = n.Length;
		char[] numList = new char[lengthOfN];

		return lengthOfN;
	}
	
	
	
	static void Main()
	{
		Console.WriteLine("Please write a number between 1 and 100 to find its factorial n!");
	
			Console.Write("Type number: ");
			string theNumber = Console.ReadLine();	
		
		Console.Write("The n! is:\n{0}", factorialCalc(theNumber));

	}
}