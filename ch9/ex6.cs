using System;

class ex6
{
	//? getting out of bond error when i write 0; weird, now it is gone...
	static void GreaterThanNeighbours(int[] array)
	{	
		bool isLeftSide = true;
		bool isRightSide = true;
		int arrayNumber = 0;
		int firstOccurance = 0;
		for(int i = 0; i < array.Length; i++){
			arrayNumber = i;

			//if it is at point 0, check at right side only
			if(array[arrayNumber] == array[0]){
				isRightSide = array[arrayNumber] > array[arrayNumber + 1];
			}
					
			//if it is at point n-1, check at left side only
			else if(array[arrayNumber] == array[array.Length - 1]){		
				isLeftSide = array[arrayNumber] > array[array.Length - 2];
			} 
			else{
				isLeftSide  = array[arrayNumber] > array[arrayNumber - 1];
				isRightSide = array[arrayNumber] > array[arrayNumber + 1];
				
				if((isLeftSide && isRightSide) == true){
					firstOccurance = array[arrayNumber];
					break;
				}
			}
		}
		
		
		Console.WriteLine("First Occurance of Biggest than left and right is {0}", firstOccurance);
	
	}

	static void Main()
	{
		Console.WriteLine("The program will return the first occurance where the number is greater than its neighbours");
		int[] mainArr = {1, 2, 5, 5, 2, 7, 4};
		Console.Write("Our array {"); 
		foreach(int element in mainArr){
			Console.Write(" {0} ", element);
		}Console.Write("}\n");


		Console.WriteLine("Checking which number is greater than its neighbours");
		
		GreaterThanNeighbours(mainArr);
}
}