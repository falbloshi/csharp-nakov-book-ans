using System;

class ex4
{
	static void Main()
	{
		Console.WriteLine("Write a number between 1 and 9 and I will dispaly it in English words");
			
		string inserted;
		int numbers;
		
		Console.Write("Insert the Number: ");
		inserted = (Console.ReadLine());
			
		bool ifInteger = Int32.TryParse(inserted, out numbers); //to check if it is an integer if not, check the while loop
			
		while((ifInteger == false) && (numbers < 1 || numbers > 9)) //the while loop will continue check true until it hits a number --  The SECOND PART OF && CONDITION IS NOT WORKING IT DOESN'T LOOP BACK
		{	
				Console.WriteLine("\nYou inserted a non number or a number not between 1 and 9, please write again\n");
				Console.Write("Number = ");
				inserted = (Console.ReadLine());
				ifInteger = Int32.TryParse(inserted, out numbers);
		}

		string numWrote = "The number you wrote is ";
		
		switch(numbers)
		{
			case 1: 
				Console.WriteLine(numWrote + "One");
				break;
			case 2: 
				Console.WriteLine(numWrote + "Two");
				break;
			case 3: 
				Console.WriteLine(numWrote + "Three");
				break;
			case 4: 
				Console.WriteLine(numWrote + "Four");
				break;
			case 5: 
				Console.WriteLine(numWrote + "Five");
				break;
			case 6: 
				Console.WriteLine(numWrote + "Six");
				break;
			case 7: 
				Console.WriteLine(numWrote + "Seven");
				break;
			case 8: 
				Console.WriteLine(numWrote + "Eight");
				break;
			case 9: 
				Console.WriteLine(numWrote + "Nine");
				break;
			default: 
				Console.WriteLine(numWrote + "Not between 1 and 9");
				break;
			
			
		} 
		
		
		
		
			
	}
}

