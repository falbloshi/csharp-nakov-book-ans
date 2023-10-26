using System;

class ex3
{
	static void Main()
	{

		Console.WriteLine("We are gonna take two arrays from you - to check array of characters are lexicographically bigger");
		
		char[] firstArr = new char[0], secondArr = new char[0];
		
		
		int n1 = int.MinValue, n2 = int.MinValue;
		
		bool ifNumber1 = false, ifNumber2 = false;
		
		while(ifNumber1 == false) 
		{		
			Console.WriteLine("Type numbers of character for the first array: ");
			ifNumber1 = int.TryParse(Console.ReadLine(), out n1);
			firstArr = new char[n1];
		}
		
		while(ifNumber2 == false) 
		{		
			Console.WriteLine("Type numbers of character array for the second array: ");
			ifNumber2 = int.TryParse(Console.ReadLine(), out n2);
			secondArr = new char[n2];
		}
		
		
		if(n1 == n2) //check if they are of same size
		{
			
			Console.WriteLine("Type the elements for the first array: ");
			for(int x = 0; x <= n1 - 1; x++)
			{	
				Console.Write("Character {0}: ", x+1);
				firstArr[x] = char.Parse(Console.ReadLine());
			}
			
			Console.WriteLine("Type the elements for the second array: ");
			for(int x = 0; x <= n1 - 1; x++)
			{	
				Console.Write("Character {0}: ", x+1);
				secondArr[x] = char.Parse(Console.ReadLine());
			}
			
			
			
			
			//changing cases to lower case then comparing them
			for(int x = 0; x <= n1 - 1; x++)
			{
				firstArr[x] = Char.ToLower(firstArr[x]);
				secondArr[x] = Char.ToLower(secondArr[x]);
			}
			
			//check if which is smaller
			
			int countforOne = 0;
			int countforTwo = 0;
			
			for(int x = 0; x <= n1 - 1; x++)
			{
				if(firstArr[x] < secondArr[x])
				{
					countforOne++;
				}
				else if(firstArr[x] > secondArr[x])
				{
					countforTwo++;
				}
				else
				{
					continue;
				}
			}
			
			if(countforOne > countforTwo) 
			{
				Console.WriteLine("The first array is smaller lexicoraphically");
			}
			else if(countforOne < countforTwo) 
			{
				Console.WriteLine("The second array is smaller lexicographically");
			}
			else
			{
				Console.WriteLine("They are both equal");
			}
			
		}
		else
		{
			if(n1 > n2)
			{
				Console.WriteLine("Second Array is Smaller lexicographically");
			}
			else
			{
				Console.WriteLine("First Array is Smaller lexicographically");
			}
		}
		
	}
}
