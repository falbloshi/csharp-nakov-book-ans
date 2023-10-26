using System;

class ex5
{
	static void Main()
	{
		Console.WriteLine("Type a number and will find the exactly the fibbionaci number ");
			
			
		ulong firstNumber= 0, secondNumber = 1, savedNumber = 0;
		ulong choiceN = ulong.MinValue;
		bool ifNumber = false;
		
		while(ifNumber == false)
			{
				
				Console.Write("Type the iteration: ");
				ifNumber = ulong.TryParse(Console.ReadLine(), out choiceN);
			}
				
		for(ulong x = 0; x <= choiceN; x++)
		{
			Console.WriteLine("{0}) {1} <> {2}", x, firstNumber, secondNumber);
			savedNumber = firstNumber + secondNumber;
			
			firstNumber = secondNumber;
			secondNumber  = savedNumber;
			
		}

		
		
			
	}
}

