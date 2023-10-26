using System;

class ex6
{
	static void Main()
	{
		Console.WriteLine("Type two numbers and we will find their factorial division N!/K!");
			
			
		ulong x = 1, y = x, factorialN = 1, factorialK = 1;
		ulong N = 0, K = 0;
		bool ifNumber = false;
		
		while(ifNumber == false)
			{		
				Console.Write("Type for N: ");
				ifNumber = ulong.TryParse(Console.ReadLine(), out N);
				
				Console.Write("Type for K: ");
				ifNumber = ulong.TryParse(Console.ReadLine(), out K);
				
				if(K > N)
				{
					ifNumber = false;
				}
				
				if(ifNumber == false)
				{
				Console.WriteLine("Please write a number and K < N");
				}
			}
		
		Console.WriteLine("\nCalculating For {0}!/{1}!", N, K);
		
		while(x <= N)
		{
			factorialN = factorialN*x;
			x++;
		}
		
		while(y <= K)
		{
			factorialK = factorialK*y;
			y++;
		}

		Console.WriteLine("\nNow Dividing {0}!/{1}!\nResult: {2:0.#####}", factorialN, factorialK,(factorialN/factorialK));
		
		ulong d = K + 1, c = N, result = d;
		
		for(ulong z = d; z < c; z++)
		{
			result = result  * (z +1); //have to use this to get correct case;
				}	
		
		Console.WriteLine("\nAdding K+1 to N Method {0}!/{1}!\nResult: {2:0.#####}", d, c, result);
			
	}
}

