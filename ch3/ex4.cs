using System;

class ex4
{
	static void Main()
	{
		Console.WriteLine("To check your number has 1 or 0 at third bit count");
		int theNumber = Convert.ToInt32(Console.ReadLine());
		
		int checkFor3 = theNumber & 8; //It return back 8 if it is true
		bool checkFor3True = checkFor3 == 8;
	
		Console.WriteLine("Does it have a 1(True) or 0(False)? ");
		Console.Write(checkFor3True);
				
		
	}
}

