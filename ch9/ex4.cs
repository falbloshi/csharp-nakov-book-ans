using System;

class ex4
{	
	static void ReturnOccurances(int selected, params int[] arrays)
	{	
		int i, count = 0, bestnumber = 0, arrayNumber = 0;
		
		
		for(i = 0; i < arrays.Length; i++){
						
				if(arrays[i] == selected){
					count++;
					bestnumber  = count;
					arrayNumber = arrays[i];
				}
			}
		
		Console.WriteLine("Array number {0}, its occurances {1}", arrayNumber, bestnumber);
	
	}

	static void Main()
	{
		Console.WriteLine("Checking repeated numbers in an array");
		int[] mainArr = {2, 2, 4, 3, 4, 1, 4, 2, 4, 2, 3, 1, 1, 4};
		Console.Write("Our array {"); 
		foreach(int element in mainArr){
			Console.Write(" {0} ", element);
		}Console.Write("}\n");
		
		int selectedNumber = 1; //assigned to one so that it can enter the while loop
		
		while(selectedNumber != 0 || selectedNumber >= 5)
		{ 
			Console.Write("Write which number to check its occurance(Write 0 to quit): ");
			
			selectedNumber = int.Parse(Console.ReadLine());
			if(selectedNumber == 0){
				break; //to exit from the while loop!
			}
			ReturnOccurances(selectedNumber, mainArr);
		}
	}
}