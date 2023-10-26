using System;

class ex16
{
	static void Main()
	{
		
		Console.WriteLine("Enter a number so we can print their number randomy from 1");
			
			
		int n = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
			{		
				Console.Write("Type for n: ");
				ifNumber = int.TryParse(Console.ReadLine(), out n);
				
				if(ifNumber == false)
				{
					Console.Write("Please type a number");
				}
			}
		
		new rand
			
			
		
	
	}
}

