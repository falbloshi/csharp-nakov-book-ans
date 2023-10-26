using System;

class ex9
{
	static void Main()
	{
		string Use = "The \"use\" of ";
		string Quotes = "Quotations causes difficulties";
		object UseQuotes = Use + Quotes;
		string USQUTS = (string)UseQuotes;
		Console.WriteLine(USQUTS);
		
	}
}

