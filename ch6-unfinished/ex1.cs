using System;

class ex1
{
	static void Main()
	{
		Console.WriteLine("Write a point number so we will print them from 1");
		
		ulong choiceN = 0;
		bool isTrueInt = false;
				
		while(!(isTrueInt))
		{
			Console.Write("Type a number  ->");
			isTrueInt = ulong.TryParse(Console.ReadLine(), out choiceN);
			
		}
		
		for(ulong x = 1; x <= choiceN; x++)
		{
			Console.WriteLine("{0}", x);
		}
		
		
		
		
	}
}

