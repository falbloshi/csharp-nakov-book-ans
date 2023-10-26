using System;

class ex20
{
	static void Main() 
	{	//kinda works still needs improvements
		Console.WriteLine("Insert number of elements and their elements for an array, and a number we can find for their sum");
		int[] mainArr = new int[0];

		int n = 0, k = 0, s = 0;
		
		bool ifint = false;

		while(ifint == false)
		{
			Console.Write("The number of elements: ");
			ifint = int.TryParse(Console.ReadLine(), out n);			
			mainArr = new int[n];
			Console.Write("What is the sum: ");
			ifint = int.TryParse(Console.ReadLine(), out s);		
		}		
		bool ifElInt = false; 
		while(ifElInt == false)
		{
			for(int i = 0; i < n; i++)
			{
				Console.Write("Element {0}: ", i+1);
				ifElInt = int.TryParse(Console.ReadLine(), out k);	
				mainArr[i] = k;
			}
		}
		Console.WriteLine("Your elements");
		foreach(int i in mainArr)
		{
			Console.Write("{0} ", i);
		}
		
		//outer loops
		int[] tempArr = new int[n];

		int sum = 0, count = 0;
		
		//my idea was that from outer loop we select a number, and then from this number we add up to see if it adds to our sum, if not
		//moves to the next element and keep doing the same until it finds the correct number;
		for(int i = 0; i <= n-1; i++)
		{ 
	
			//Console.Write("\nDebug outer i : {0}", i);
			if(mainArr[i] < s)
			{
				for(int j = i; j <= n-1 ; j++)
				{
					//Console.Write("\nDebug inner j : {0}", j);
					if(sum < s && mainArr[j] < s) // to make sure it doesn't exceeds s
					{
						sum += mainArr[j];
						count++;
						tempArr[count] = mainArr[j];
						//Console.Write("\nDebug sum {0}", sum);
						//Console.Write("\nDebug count {0}", count);
					}
					else if(sum == s)
					{
					 //  Console.Write("\nTrue, we reached inner");
					   break;
					}
					else if (sum > s)	//to clear values if it gets above s
					{
					//	Console.Write("\nTrue: resetted sum and count");
						sum = 0; 
						count = 0;
						Array.Clear(tempArr, 0, tempArr.Length); //used this method to clear the array
						continue;
					}
				}
				if(sum == s)
				{
					//Console.Write("\nTrue, we reached second inner");
					break;
				}

				
			}
			else if(sum == s)
			{
				//Console.Write("\nTrue we reached outer");
				break;
			}
			
		}
		
		Console.WriteLine("\nThe element which sums in the array");
		Console.Write("{");
		foreach(int i in tempArr)
		{
			if(i > 0)
			{
				Console.Write(" {0}", i);
			}
		}Console.Write(" }\n");
		Console.WriteLine("Which sums up to {0}", s);
		
		
		
	}
	
}