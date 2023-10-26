using System;

class ex15
{
	static void Main()
	{
		
		Console.WriteLine("Number Converter - Convert from hexadecimal to decimal");
			
		string hexaDec = "", myHexString = "";

		Console.Write("Type for 0x hexcode: "); //i will not write an entry check condition now
		hexaDec = Console.ReadLine();
		
		//reversing
		for(int j = hexaDec.Length - 1; j >= 0; j--)
		{
			myHexString += (hexaDec[j]); 
		} 	

		double number = 0, deCode = 0, resultMulti = 0, base16 = 1;	
		double length = myHexString.Length - 1;	
		for(int x = 0; x <= length; x++)
		{
			
			switch(myHexString[x])
			{
				case 'A': deCode = 10; break;
				case 'B': deCode = 11; break;
				case 'C': deCode = 12; break;
				case 'D': deCode = 13; break;
				case 'E': deCode = 14; break;
				case 'F': deCode = 15; break;
				default: deCode = (double)Char.GetNumericValue(myHexString[x]); break; //changing into numeric from char
			}	
			
			//math logic 
			resultMulti = deCode * base16;
			base16 *= 16;
			number += resultMulti;
		}
	
	Console.WriteLine("The Decimal Representation: {1}\nThe Hexadecimal representation: 0x{0}", hexaDec, number);
	
	}
}

