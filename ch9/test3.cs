using System;

class test3
{
	static void Main()
	{
		int x = 1;
		
		MainMenu(x);
			
	}
	
	
		static void MainMenu(int menuSelect){
		
		switch(menuSelect){
		case 1: 
			Console.Write("\nPlease insert a positive number not exceeding 50 million:");
			string answerOne = Console.ReadLine();
			int forReverseInteger;
			bool ifNumber = int.TryParse(answerOne, out forReverseInteger);
			if(ifNumber == true && forReverseInteger < 50000000 && !(forReverseInteger < 0)){
			Console.WriteLine("Good!");
			}
			else{
				Console.WriteLine("Please follow the instructions, taking you to main menu again...");
				MainMenu(1);
			}
			break;
		case 2:   
			Console.WriteLine("AveragingNumberSequence()"); break;
		case 3: 
			Console.WriteLine("Solve the linear equation a * x + b = 0. A must be non zero number"); break;
		default: 
			Console.WriteLine("You didn't insert a correct label!");
			Main();
			break;
		}
		}
}

