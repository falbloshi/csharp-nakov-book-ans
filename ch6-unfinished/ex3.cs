using System;

class ex3
{
	static void Main()
	{
		Console.WriteLine("Enter a number so that we print the smallest and biggest of the numbers - specify how many numbers you want");
		
		int choiceN = 0;
		bool isTrueInt = false;
				
		while(!(isTrueInt))
		{
			Console.Write("Type a number -> ");
			isTrueInt = int.TryParse(Console.ReadLine(), out choiceN);	
		}
		
		int lNumb = Int32.MinValue, sNumb = Int32.MaxValue;  // I made mistake here, I should put minvalue to the variable that to be set as largest - opposite effect
		int blNumb = Int32.MinValue, bsNumb = Int32.MaxValue;
			
		for(int x = 0; x < choiceN; x++)
		{
			int newNumber;
			
				
			Console.Write("{0}) Number -> ", x+1);
			int.TryParse(Console.ReadLine(), out newNumber);	
	
			if(newNumber > lNumb)
			{
				lNumb = newNumber;
				if(lNumb > blNumb)
				{
					blNumb = lNumb;
				}
			}
			
			if(newNumber < sNumb)
			{
				sNumb = newNumber;
				if(sNumb < bsNumb)
				{
					bsNumb = sNumb;
				}
			}
			
			
		}
		
		Console.WriteLine("Biggest Number: {0}\nSmallest Number: {1}", blNumb, bsNumb);
		
		
		
		
	}
}

