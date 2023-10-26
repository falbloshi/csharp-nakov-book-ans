using System;

class ex14
{
	static void Main()
	{
		
		Console.WriteLine("Number Converter - Convert from decimal to hexadecimal");
			
			
		ulong n = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
		{		
			Console.Write("Type for n: ");
			ifNumber = ulong.TryParse(Console.ReadLine(), out n);
			
		}
		
		ulong m = n, iteration = 0, remainder = 0;
		string hexCode = "", myString = "", myNewString = "";
		
		for(iteration = n; iteration > 0; iteration /= 16) //
		{
			remainder = m % 16; 
			m /= 16;
			
			switch(remainder)
			{
				case 10: hexCode = "A"; break;
				case 11: hexCode = "B"; break;
				case 12: hexCode = "C"; break;
				case 13: hexCode = "D"; break;
				case 14: hexCode = "E"; break;
				case 15: hexCode = "F"; break;
				default: hexCode = Convert.ToString(remainder) ; break;
			}
			
			myString += hexCode; // !! it's coming reversed, so I have to reverse print it	
		}
	
	//reverse printing
	for(int j = myString.Length - 1; j >= 0; j--)
	{
		myNewString += (myString[j]); 
	} 	
	
	Console.WriteLine("The Decimal Representation: {1}\nThe Hexadecimal representation: {0}", myNewString, n);
	

		
		
			
	}
}

