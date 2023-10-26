using System;

class ex10
{
	static void Main()
	{
		Console.WriteLine("Write a point number between 1 and 9 and we will give you the final score ");
			
		sbyte choiceN;
		
		Console.Write("Type between 1 and 9 or them!  ->");
		sbyte.TryParse(Console.ReadLine(), out choiceN);
		
		if(choiceN >= 1 && choiceN <= 3)
		{
			Console.WriteLine("Your score is {0}", choiceN*10);
		}
		else if(choiceN >= 4 && choiceN <= 6)
		{
			Console.WriteLine("Your score is {0}", choiceN*100);
		}
		else if(choiceN >= 7 && choiceN <= 9)
		{
			Console.WriteLine("Your score is {0}", choiceN*1000);
		}
		else
		{
			Console.WriteLine("You inserted a string or a wrong number"	);
		}
					
			
	}
}

