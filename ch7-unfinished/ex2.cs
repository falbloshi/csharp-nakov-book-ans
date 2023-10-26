using System;

class ex2
{
	static void Main()
	{

		Console.WriteLine("We are gonna take two arrays from you - to check if they are of the same size and elements");
		
		int[] firstArr = new int[0], secondArr = new int[0];
		int n1 = int.MinValue, n2 = int.MinValue;
		
		bool ifNumber1 = false, ifNumber2 = false;
		
		while(ifNumber1 == false) 
		{		
			Console.WriteLine("Type numbers for the first array: ");
			ifNumber1 = int.TryParse(Console.ReadLine(), out n1);
			firstArr = new int[n1];
		}
		
		while(ifNumber2 == false) 
		{		
			Console.WriteLine("Type number for the second array: ");
			ifNumber2 = int.TryParse(Console.ReadLine(), out n2);
			secondArr = new int[n2];
		}
		
		
		if(n1 == n2) //check if they are of same size
		{
			
			Console.WriteLine("Type the elements for the first array: ");
			for(int x = 0; x <= n1 - 1; x++)
			{	
				Console.Write("Element {0}: ", x);
				firstArr[x] = int.Parse(Console.ReadLine());
			}
			
			Console.WriteLine("Type the elements for the second array: ");
			for(int x = 0; x <= n1 - 1; x++)
			{	
				Console.Write("Element {0}: ", x);
				secondArr[x] = int.Parse(Console.ReadLine());
			}
			
			
			//check if elements are the same
			bool trueIfIdent = true; 
			
			for(int x = 0; x <= n1 - 1; x++)
			{
				if(firstArr[x] != secondArr[x])
				{
					trueIfIdent = false; break;
				}	
			}
			
			if(trueIfIdent == true) 
			{
				Console.WriteLine("The Arrays are Identical");
			}
			else
			{
				Console.WriteLine("The Arrays are not Identical");
			}
			
		}
		else
		{
			Console.WriteLine("The arrays are of different sizes, please try again later");
		}
		
	}
}
