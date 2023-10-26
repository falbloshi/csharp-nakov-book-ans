using System;

class ex15
{
	static void Main() 
	{

		Console.WriteLine("We are gonna find the index of all the latin letter of your text:");
		
		
		
		char[] latinLetters = { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',  'V', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
				
		
		int length = latinLetters.GetLength(0);
		
		//input start
		Console.Write("Please Enter your Text: ");
		string input = Console.ReadLine();
		char[] inputChar = input.ToCharArray();
		
		Console.WriteLine("The indexes are ");
		for(int x = 0; x < inputChar.GetLength(0); x++)
		{
			for(int k = 0; k < length; k++)
			{
				if(inputChar[x] == latinLetters[k])
				{
					Console.Write("{0, 3}", k);
				}
			}
		}
	}
}
