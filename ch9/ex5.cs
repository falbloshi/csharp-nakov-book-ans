using System;

class ex5
{	

	//? getting out of bond error when i write 0; weird, now it is gone...
	static void GreaterThanNeighbours(int selected, int[] array)
	{	
		int arrayNumber = selected;
		bool leftSide = true;
		bool rightSide = true;
		
		
		//if it is at point 0, check at right side only
		if(array[arrayNumber] == array[0]){
			rightSide = array[arrayNumber] > array[arrayNumber + 1];
			
			Console.WriteLine("Which is bigger?\n{0} for right side", rightSide);
		}
				
		//if it is at point n-1, check at left side only
		else if(array[arrayNumber] == array[array.Length - 1]){		
			leftSide = array[arrayNumber] > array[array.Length - 2];
			Console.WriteLine("Which is bigger?\n{0} for left side", leftSide);
		}
		else{
			leftSide  = array[arrayNumber] > array[arrayNumber - 1];
			rightSide = array[arrayNumber] > array[arrayNumber + 1];
			
			Console.WriteLine("Which is bigger?\n{0} for right side, {1} for left side\n", rightSide, leftSide);
		}
		
		
		
	
	}

	static void Main()
	{
		Console.WriteLine("Review the main array, select the array position to see if it is bigger than its neighbours in main array");
		int[] mainArr = {3, 5, 2, 1, 3, 7, 2, 8, 1, 5, 6, 9, 4};
		int[] posArr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
		Console.Write("Our array {"); 
		foreach(int element in mainArr){
			Console.Write(" {0} ", element);
		}Console.Write("}\n");
		Console.Write("Pos array {"); 
		foreach(int element in posArr){
			Console.Write(" {0} ", element);
		}Console.Write("}\n");
		
		int selectedNumber = 0; 
		
		while(selectedNumber != 99)
		{ 
			Console.Write("Write which number to check its position\nand see if it is greater than its neighbours(Write 99 to quit): ");
			
			selectedNumber = int.Parse(Console.ReadLine());
			if(selectedNumber == 99)
			{
				break;
			}
		GreaterThanNeighbours(selectedNumber, mainArr);
	}
}
}