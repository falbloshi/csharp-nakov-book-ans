using System;

class ex4
{
	static void Main()
	{
		Console.WriteLine("Give me your numbers so that I can change their formats in an aligned manner: ");
		
		Console.Write("Change to Hexa = ");
		int fs = int.Parse(Console.ReadLine());
		Console.Write("Positive Fraction = ");
		double ss = double.Parse(Console.ReadLine());
		Console.Write("Negative Fraction = ");
		double ts = double.Parse(Console.ReadLine());
		
		Console.WriteLine("\n{0,-8:X}|{1,-10:f2}|{2,-10:f2.##}", fs, ss, ts);
		
	}
}

