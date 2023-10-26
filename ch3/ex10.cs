using System;

class ex10 {
	static void Main()
	{
		Console.WriteLine("Write a program that takes as input a four-digit number in format abcd (e.g 2011) and performs the following actions:");
 

			Console.Write("a) Calculates the sum of the digits"); 
			Console.Write("b) Prints on the console the number in reversed order: dcba ");
			Console.Write("c) Puts the last digit in the first position: dabc ");
			Console.Write("d) Exchanges the second and the third digits: acbd ");
		
		Console.Write("\nABCD = ");
		int abcd = Convert.ToInt32(Console.ReadLine());
		
		int d = abcd % 10;
		int c = (abcd / 10) % 10;
		int b = (abcd / 100) % 10;
		int a = (abcd / 1000) % 10;
		
		
		int sum = a + b + c + d;  
		string sb = d + "" + c + "" + b + "" + a; 
		string sc = d + "" + a + "" + b + "" + c;
		string sd = a + "" + c + "" + b + "" + d;
		
		Console.WriteLine("Sum: {0}", sum);
		Console.WriteLine(sb);
		Console.WriteLine(sc);
		Console.WriteLine(sd);
		
	}
}

