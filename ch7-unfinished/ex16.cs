using System;

class ex16
{
	static void Main() 
	{

		Console.WriteLine("We are gonna use binary search to find an element of an array, please state the size as well as the element to be found");
		
		
		
		int[] mainArr = new int[0];
		
		//input start
		bool ifInt = false;
		int num = int.MinValue;
		int elementRequested = int.MinValue;
		
		while(ifInt == false)
		{
			Console.Write("Type number of elements: ");
			ifInt = int.TryParse(Console.ReadLine(), out num);
			mainArr = new int[num];
			
			Console.Write("Type the requested element: ");
			ifInt = int.TryParse(Console.ReadLine(), out elementRequested);

		}	
		
		
		
		//inserting the elements
		Console.WriteLine("Type the elements for the array: ");
				
			for(int x = 0; x < num; x++)
			{	
				Console.Write("Element {0}: ", x);
				mainArr[x] = int.Parse(Console.ReadLine());

			}
		Console.WriteLine("Array Insertion Success ");
		
		bool elementFound = false;
		int midEle = 0, startingIndex = 0, endingIndex = num-1, getArrayNumb = 0, counter = 0; 
		while(elementFound == false){
					
			if(endingIndex >= startingIndex){	
				midEle = startingIndex + (endingIndex-startingIndex)/2;		
					
				if (elementRequested == mainArr[midEle])
				{
					elementFound = true;
					getArrayNumb = midEle; 
					Console.Write("The element you requested is {0} found at Index {1} using {2} cycles", elementRequested, getArrayNumb, counter);
				}			
				else if(elementRequested > mainArr[midEle])
				{
					startingIndex = midEle++;
				}
				else if (elementRequested < mainArr[midEle])
				{					
					endingIndex = midEle--;
					
				}
				else
				{
					Console.Write("The element you requested doesn't exist");
					elementFound = true; // to exit if it doesn't exist. // it get stuck when it doesn't find the element in the array 
				}
			}
			counter++;
		}		
		
		
		
		
	}
}
