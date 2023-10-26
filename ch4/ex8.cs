using System;

class ex8
{
	static void Main()
	{
		Console.WriteLine("You are going to type in 5 numbers, and print you out the greater of them");
		
		int oldBig = 0;
		int newBig = 0;
		int bestBig = 0;
		
		for(int x = 0 ; x < 5; x++)
		{
			Console.Write("{0}) Number = ", x + 1);
			string inserted = (Console.ReadLine());
			
			int numbers;
			
			bool ifInteger = Int32.TryParse(inserted, out numbers); //to check if it is an integer if not, check the while loop
			
			while(ifInteger == false) //the while loop will continue check false until it hits a pure number
			{
				Console.WriteLine("\nYou inserted a string or an integral,\nplease write a non integer number!\n");
				Console.Write("{0}) Number = ", x + 1);
				inserted = (Console.ReadLine());
				ifInteger = Int32.TryParse(inserted, out numbers);
			}
			
			newBig = numbers;
			
			
			//to find the biggest number
			if(newBig > oldBig)
			{
				bestBig = newBig;
				oldBig = bestBig;
			}
		
			
		
		}	
			
		Console.WriteLine("\n{0} Is the Biggest Number", bestBig);
	}
}

