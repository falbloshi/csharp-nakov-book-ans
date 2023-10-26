using System;

class ex13
{
	static void Main()
	{
		Console.WriteLine("To change the value of number N at position P with V of value 1 or 0");
		
		Console.Write("Number N = ");
		int nUmber = Convert.ToInt32(Console.ReadLine());
		Console.Write("Position P = ");
		int pOsition = Convert.ToInt32(Console.ReadLine());
		Console.Write("Value V = ");
		int vAlue = Convert.ToInt32(Console.ReadLine());
		
		int i = 1; 
		int add0 = nUmber & (~(i << pOsition));	
		int add1 = nUmber | (i << pOsition);
		
		
		Console.WriteLine("Answer : {0}  ", (vAlue == 0 ? add0 : add1));	
		
	}
}

