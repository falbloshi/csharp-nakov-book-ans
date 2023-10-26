using System;

class test2
{
	static void Main()
	{
		Console.Write("\nPlease insert the size of your number sequence(how many numbers you want, must be greater than two/Write 'exit' to quit to main menu): ");
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
			
				// to insert user inputted element to the specified size ^
				string elementIn;
				bool ifElementNum;
				Console.WriteLine("Write the values;\nwrite 'n' to exit insertion:");
				do{
					Console.Write("Insert element #{0}: ", (whileIteration+1));
					elementIn = Console.ReadLine();
					ifElementNum = int.TryParse(elementIn, out elementInserted);
					
					if(ifElementNum == true){
						if(elementInserted == 0){
						Console.WriteLine("Sorry, we don't accept zero -> ");
						continue;
						}
						
						array[whileIteration] = elementInserted;
						whileIteration++;
					}
					

				
				}while(elementIn != "n" && whileIteration < sizeOfArray); //0 doesn't add, so we use it as an exit condition, as well as for the size of iteration.
				
				float sum = 0;
				float average;
				
				if(whileIteration < 0 && elementIn == "n"){ 
					return;
				}
				
				foreach(int element in array) 
				{
					if(!(element == 0)){ // to remove 0 elements if cut off earlier than the sizeOfArray;
					sum += element;
					}
				}
				
				average = sum/(float)whileIteration; // final calculation
				
				Console.WriteLine("Calculating the elements average: {0}", average);
			}
			else{
				Console.WriteLine("Please write a number greater than 2");
				Main(); // to repeat the line if user wants to 
			}
		}			
			
	}
}