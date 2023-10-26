using System;

class ex10
{
	static void Main()
	{
		
		
		Console.WriteLine("Type in which number to find its range from 1");
		Console.Write("Which number you want them ranged: ");
		string inserted = (Console.ReadLine());
		int numbers = 0;
		bool ifNumber = Int32.TryParse(inserted, out numbers); 
					
		while(ifNumber == false) 
		{
			Console.WriteLine("\nYou inserted a string or an integral,\nplease write a non integer number!\n");
			Console.Write("Which number you want them ranged: ");
			inserted = (Console.ReadLine());
			ifNumber = Int32.TryParse(inserted, out numbers);
		}	
		
		for(int x = 1 ; x <= numbers; x++)
		{
			Console.WriteLine("{0}", x);
			
		}	
			
	}
}

