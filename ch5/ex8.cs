using System;

class ex8
{
	static void Main()
	{
		Console.WriteLine("Write an int or a double or a string and we will ammend it ");
			
			
		int numberInt = 0;
		double numberDouble = 0; 
		string infoString = ""; 
		sbyte choiceN;
		bool ifNumber = false;
		
		Console.Write("Type 0 For Int\n1 For Double\n2 For String\n  ->");
		sbyte.TryParse(Console.ReadLine(), out choiceN);
		
		switch(choiceN)
		{
			case 0: 
				
				while(ifNumber == false)
				{
					Console.Write("Type the int: ");
					infoString = Console.ReadLine();
					ifNumber = Int32.TryParse(infoString, out numberInt);
				}
				
				Console.WriteLine("The number is {0}", numberInt++);
				
				break;
			
			case 1: 
				
				while(ifNumber == false)
				{
					Console.Write("Type the double: ");
					infoString = Console.ReadLine();
					ifNumber = Double.TryParse(infoString, out numberDouble);
				}
				
				Console.WriteLine("The number is {0}", numberDouble++);

				break;
				
				case 2: 
					Console.Write("Type the string: ");
					infoString = Console.ReadLine();
							
				Console.WriteLine("The String is {0}", numberDouble + "*");

				break;
				
				default:
				break;

						
		}
		
			
	}
}

