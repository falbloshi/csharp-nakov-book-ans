using System;

class ex6 // I still don't get it tobe honest - it's called Longest Increasing Subsequence 
{
	static void Main()
	{

		Console.WriteLine("We are gonna take an array from you and then find consequently sequence of increasing numbers");
		
		int[] arr = new int[0];
	
		
		int n1 = int.MinValue;
		
		Console.WriteLine("Type numbers of elements for the array: ");

		Console.WriteLine("Type the elements for the array: ");
		
		n1 = int.Parse(Console.ReadLine());
		arr = new int[n1];
		
		for(int x = 0; x < n1; x++)
		{	Console.Write("Element {0}: ", x);
			arr[x] = int.Parse(Console.ReadLine());
		}
		
		int[] len = new int[arr.Length];
			
		for(int i = 1; i < arr.Length; i++)
		{
			for(int j = 0; j < i; j++)
			{
				if(arr[i] > arr[j])
				{
					len[i] = Math.Max(len[i], len[j] + 1);
				}
			}
		}
	
			
		
	
		Console.Write(" {0} ", len[len.Length - 1]);
		
		
		/*
		Console.Write("}");
		
		Console.WriteLine("\nThe consequently increasing sequences are: ");
		
		Console.Write("{");
		
		
		//printing it 
		bestEnding += 1; //because best ends at the last x that doesn't end with the next one
		int[] newArr = new int[bestValue+1];
		for(int x = bestValue; x >= 0; x--) //to reverse print it
		{
			newArr[x] = bestEnding--;
		}
		
		foreach(int x in newArr) 
		{
			Console.Write(" {0} ", x);
		}
		
		Console.Write("}"); */
	}
}
