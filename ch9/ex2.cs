using System;

class ex2
{
	static int GetMax(int a, int b)
	{
		if(a > b){
			return a;
		}
		else if(b > a){
			return b;
		}
		else{
			return a;	// since a == b;
		}
	}
	
	static void Main()
	{
		Console.WriteLine("Please write three integers to check which is bigger");
		Console.Write("First Element: "); int a = int.Parse(Console.ReadLine());
		Console.Write("Second Element: "); int b = int.Parse(Console.ReadLine());
		Console.Write("Third Element: "); int c = int.Parse(Console.ReadLine());
		
		int largestNumber = GetMax(GetMax(a, b), c);
		Console.WriteLine(largestNumber);
	}
}