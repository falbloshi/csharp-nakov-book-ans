using System;

class ex11
{
	static void Main()
	{
		
		Console.WriteLine("Enter a number so we find its factorial and then find how many zero it ends with!");
			
			
		double n = double.MinValue;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
		{		
			Console.Write("Type for n: ");
			ifNumber = double.TryParse(Console.ReadLine(), out n);
			
			/*if(n > 100 || ifNumber == false)
			{
				Console.WriteLine("Please write a number less than 100");
				ifNumber = false;
			}*/
		}
			
		double x = 1, fact = 1;
		
		while(x <= n)
		{
			fact = fact * x;
			x++;
		}

		
		// found on the internet, looks sharp and small;
		//   for (int i = 5; n / i >= 1; i *= 5) 
        //    count += n / i; 
		
		
		//boooks method
		double sum = 0, iterator = 1, fivers = 1;
		while(iterator <= n)
		{
			fivers *=  5;
			if((n/fivers) >= 1) //this was the missing piece - found it from purple math factorial trailing zeroes
			{
				sum += Math.Floor(n/fivers); // .floor to get just the number without the decimal
			}
			else
			{
				break;
			}
			iterator++;
		}
		Console.Write("{1} The Factorial\n{0} <-- The number of trailing Zeroes",sum, fact);

		
		
			
	}
}

