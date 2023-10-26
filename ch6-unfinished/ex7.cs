using System;

class ex7
{
	static void Main()
	{
		Console.WriteLine("Type two numbers to that calculate N!*K!/(N-K)! for given N and K (1<K<N).");
			
			
		ulong x = 1, y = x, factorialN = 1, factorialK = 1;
		ulong N = 0, K = 0;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
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
		
		ulong multiplication, division, z = 1, factorialNKSub = 1, NKSub = N-K;
		
		multiplication = factorialN * factorialK;
	
		
		while(z <= NKSub)
		{
			factorialNKSub = factorialNKSub*z;
			z++;
		}
		
		division = multiplication / factorialNKSub;

		
		Console.WriteLine("\nResult for {0}!*{1}!/({0}-{1})!\nResult: {2:0.#####}", N, K, division);
		
			
	}
}

