using System;

class ex2
{
	static void Main()
	{
		Console.WriteLine("Write a point number so we will print them from 1 and remove those which are divisible by 3 and 7");
		
		ulong choiceN = 0;
		bool isTrueInt = false;
				
		while(!(isTrueInt))
		{
			Console.Write("Type a number -> ");
			isTrueInt = ulong.TryParse(Console.ReadLine(), out choiceN);
			
		}
		
		for(ulong x = 1; x <= choiceN; x++)
		{
			
			
			if(x % 3 == 0 && x % 7 == 0)
			{
				continue;
			}
		
			Console.WriteLine("{0}", x);
		
			
			
		}
		
		
		
		
	}
}

