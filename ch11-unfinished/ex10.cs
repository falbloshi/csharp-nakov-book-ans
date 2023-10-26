using System;

class ex10
{
	static void Main()
	{
		Console.WriteLine("Write a number list to find out their sum seperated by Space");
		
		Console.Write("| > ");
		string[] myString = Console.ReadLine().Split(' ');
		int d = 0;
		foreach(string m in myString)
		{
			d += Convert.ToInt32(m);
		}
		Console.WriteLine("Your answer: {0}", d);
		
	}
}