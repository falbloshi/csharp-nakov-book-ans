using System;

class SystemTest
{
	static void Main(){
		int sum = 1;
		int startTime = Environment.TickCount;
		
		for(int i = 0; i < 1000000000; i++)
		{
			sum += 32*sum;
		}
		
		int endTime = Environment.TickCount;
		Console.WriteLine("The time elapsed is {0} sec.", (endTime - startTime)/1000.0);
		
	}
	
	
}