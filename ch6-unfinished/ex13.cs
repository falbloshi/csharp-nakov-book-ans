using System;

class ex13
{
	static void Main()
	{

		Console.WriteLine("Number Converter - from binary to decimal");
			
			
		ulong n = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
		{		
			Console.Write("Type for n: ");
			ifNumber = ulong.TryParse(Console.ReadLine(), out n);
	
			ulong d = n, checker = 0; // to check if a number is a binary
			bool ifBin = true;
			while((d > 0) && (ifBin == true))
			{
				checker = d % 10; //last digit
				d /= 10; //truncation 
				
				if(checker > 1) 
				{
					Console.WriteLine("Please write a binary number");
					ifBin = false;
					ifNumber = false;
				}
			}
		}
		
		ulong m = n, multi2 = 1,  remainder = 0, sumOfDiv = 0;
		
		while(m > 0)
		{
			remainder = m % 10; //last digit 10101 <- 1 // 101010 <- 0
			m /= 10; //truncation 10101 -> 1010...
			sumOfDiv += remainder * multi2; //adding it all
			multi2 *= 2; //2*2 = 4, 2*2*2 = 8... 
		}
	
	Console.WriteLine("The Decimal Representation: {1}\nThe Binary representation: {0}", n, sumOfDiv);
	

		
		
			
	}
}

