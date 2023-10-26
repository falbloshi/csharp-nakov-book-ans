/*
Write a program that solves the following tasks: 
-  Put the digits from an integer number into a reversed order. 
-  Calculate the average of given sequence of numbers. 
-  Solve the linear equation a * x + b = 0. 
Create appropriate methods for each of the above tasks. 
Make the program show a text menu to the user. By choosing an option 		
of that menu, the user will be able to choose which task to be invoked. 
Perform validation of the input data: 
-  The integer number must be a positive in the range [1…50,000,000]. 
-  The sequence of numbers cannot be empty. 
-  The coefficient a must be non-zero. 
*/


//wow, one big software this one - also proud of it. really good ui
using System;

class ex11
{	
	// Option 1; something wrong with it;
	static void ReverseInteger()
	{		
		
		Console.Write("\n Please insert a positive number not exceeding 50 million to reverse it: ");
		
		string answerOne = Console.ReadLine();
		int forReverseInteger;
	
		bool ifNumber = int.TryParse(answerOne, out forReverseInteger);
		
		if(ifNumber == true && forReverseInteger < 50000000 && !(forReverseInteger < 0))
		{

			int num = forReverseInteger; 
			int i; 
			int byTen = 10;
			int digits = 0;

			while(num > 0){ // <- this is just to get the array number 
				num = num / byTen; //explanation down
				digits++;
			}
			
			int[] reversedNumbers = new int[digits];
			num = forReverseInteger;
			for(i = 0; i < digits; i++){ //0->n-1 - 0 is where the first digit on the right exists
				reversedNumbers[i] = num % 10;
				num = num / byTen; //this is to concatinate the number to left side, since we are using int, not float
			}
			
			//^ we will reverse the operation from above, and do a multiplication of arrays, at 10 every new iteration		
			int incrementDigits = 1;
			byTen = 1; // !doing i = .length-1 and i >= 0 always results in correct decrementation in arrays
			for(i = digits - 1; i >= 0; i--){ // we decrement, because the first element is in the last
				incrementDigits = reversedNumbers[i];
				num += incrementDigits * byTen; 
				byTen = byTen * 10;
			
			}
			
			Console.WriteLine(" The reversed number: {0}", num);
			ExitMethod(1);
		
		}
		else{
			Console.WriteLine(" Please follow the instructions, taking you to main menu again...");
			Main();
		}
		
		
	}
	
	//option 2
	static void AveragingNumberSequence()
	{
		
		Console.Write("\n Please insert the size of your number sequence(how many numbers you want, must be greater than two\n Write 'exit' to quit to main menu): ");
		string userInput = Console.ReadLine();
		if(userInput == "exit"){
			Main();
		}
		int sizeOfArray = 0;
		bool ifNumber = int.TryParse(userInput, out sizeOfArray); // to check if we got a number, or a string 

		if(ifNumber == true){ //if we got the number, we test it if it is greater than two to start calculating
			if(sizeOfArray > 2){
				int[] array = new int[sizeOfArray];
				int elementInserted = 0, whileIteration = 0;	
				string elementIn;
				bool ifElementNum;
			
				// to insert user inputted element to the specified size ^
				Console.WriteLine(" Write the values;\n write 'n' to exit insertion:");
				do{
					Console.Write(" Insert element #{0}: ", (whileIteration+1));
					elementIn = Console.ReadLine();
					ifElementNum = int.TryParse(elementIn, out elementInserted);
					
					if(ifElementNum == true){
						if(elementInserted == 0){
						Console.WriteLine(" Sorry, we don't accept zero!");
						continue;
						}
							
						array[whileIteration] = elementInserted;
						whileIteration++;
					}		
				}while(!(elementIn == "n") && whileIteration < sizeOfArray); 
				
				//because if we don't add <= condition, it will stop completely the operation. 
				if(whileIteration <= 0 && elementIn == "n"){ 
					return;
				}
				
				float sum = 0;
				float average;
				
				foreach(int element in array) 
				{
					if(!(element == 0)){ // to remove 0 elements if cut off earlier than the sizeOfArray;
					sum += element;
					}
				}
				
				average = sum/(float)whileIteration; // final calculation
				
				Console.WriteLine(" Calculating the numbers' average: {0}", average);
				
				ExitMethod(2);
				
			}
			else{
				Console.Write(" Please write a number greater than 2.\n Write 'repeat' to start again, or any button to main menu by default: "); 
				string choice = Console.ReadLine();
				if(choice == "repeat"){
					AveragingNumberSequence(); // to repeat the line if user wants to
				}	
				else
					Main();	
				}
				
			}
		
	}
	
	//option 3 
	static void LinearEquation()
	{
		float forLiEqA, forLiEqB, a, b;
		
		Console.Write(" Write for a: ");
		string answerA = Console.ReadLine();
			
		Console.Write(" Write for b: ");
		string answerB = Console.ReadLine();
		
		if(answerA == "n" || answerB == "n"){
			Main();
		}
		
		bool ifNumberLEA = float.TryParse(answerA, out forLiEqA);
		bool ifNumberLEB = float.TryParse(answerB, out forLiEqB);
		
		if(ifNumberLEA == false || ifNumberLEB == false){
			Console.WriteLine(" Please write numbers!");
			LinearEquation();
		} 
		
		if(ifNumberLEB == true && !(forLiEqA <= 0)){
			b = forLiEqB;
			a = forLiEqA;
			if(!(b == 0)){
				b = forLiEqB * -1;
				a = forLiEqA;
				Console.WriteLine(" x = {0}/{1}", b, a); 
				ExitMethod(3);
			}
		}
		else{
			a = forLiEqA;
			Console.WriteLine(" x = 1/{1}", a); 
			ExitMethod(3);
		}

	}
	
	//option 3
	static void MainMenu(int menuSelect)
	{
		switch(menuSelect){
		case 1: 
			ReverseInteger();
			break;
		case 2:   
			AveragingNumberSequence(); 
			break;
		case 3: 
			Console.WriteLine("\n Solve the linear equation a * x + b = 0. Coefficient a must be non zero number\n Write 'n' to exit to main menu");
			LinearEquation();
			break;
		default: 
			Console.WriteLine(" You didn't write a correct option!");
			Main();
			break;		
		}
		
		
	}
	
	
	//exit method if people want to leave!
	static void ExitMethod(int x)
	{
		
		Console.Write("\n Do you want to exit completely(any button) or go to main menu('m') or\n repeat('r')': ");
		string finalAnswer = Console.ReadLine();
				
		switch(finalAnswer){
			case "m": 
			case "M":
				Main();
				break;
			case "R":
			case "r": 
				MainMenu(x);
				break;
			default:
				break;
					
		}
	}
	
	static void Main()
	{
		Console.Clear();
		
		//This is the main menu, the MainMenu method, just takes us to the specified methods
		Console.WriteLine(" Welcome to the Multi-Purpose Program TM 2017 COPYRIGHTED");
		Console.WriteLine(" Please choose from the menu below on which program to use.");
		Menu: 
		Console.WriteLine();
		Console.WriteLine("    1 - Reverse Integer: This will reverse an integer inputted by users");
		Console.WriteLine("    2 - Average of Sum : This will return the average of a sequence of numbers inserted by users");
		Console.WriteLine("    3 - Linear Equation: This will solve a linear equation, with coefficient inserted by users");
		Console.WriteLine("    4 - To quit the program");
		
		Console.Write("\n\n Insert your option >> ");
		int selectedNumber;
		string getInput = (Console.ReadLine()); 
		bool ifTrue = int.TryParse(getInput, out selectedNumber);
		
		if(ifTrue == true){
			if(selectedNumber == 4){
				return;
			}
			MainMenu(selectedNumber);
		}
		else{
			Console.WriteLine("\n Please select a correct input");
			goto Menu; //this is justified in this case imo
		}
		
		
	}
}