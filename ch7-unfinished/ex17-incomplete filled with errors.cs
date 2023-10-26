using System;

class ex17
{
	static void Main() 
	{

		Console.WriteLine("We are gonna use merge search to find an element of an array, please state the size as well as the elements to sort them out");		
		
		int[] mainArr = new int[0];
		
		//input start
		bool ifInt = false;
		int num = int.MinValue;
		
		while(ifInt == false)
		{
			Console.Write("Type number of elements: ");
			ifInt = int.TryParse(Console.ReadLine(), out num);
			mainArr = new int[num];
		}	
			
		//inserting the elements
		Console.WriteLine("Type the elements for the array: ");
				
			for(int x = 0; x < num; x++)
			{	
				Console.Write("Element {0}: ", x);
				mainArr[x] = int.Parse(Console.ReadLine());
			}
			
		Console.WriteLine("\nArray Insertion Success\n");
		
		Console.WriteLine("Merge Sorting\n");
		
		
		//geeksforgeeks implementation 
		
		class MergeSort{
			static public void merge(int[] arr, int l, int m, int r)
			{
				int i, j, k;
				int n1 = m - l + 1;
				int n2 = r - m; 
				
				int[] L = new int[n1];
				int[] R = new int[n2];
				
				for(i=0; i < n1; i++)
				{
					L[i] =arr[l + i];
				}
				for(j=0; j < n2; j++)
				{
					R[i] =arr[m + 1 + j];
				}
				
				i = 0;
				j = 0;
				k = l;
				
				while(i <n1 && j < n2)
				{
					 if (L[i] <= R[j]) 
					{ 
						arr[k] = L[i]; 
						i++; 
					} 
					else
					{ 
						arr[k] = R[j]; 
						j++; 
					} 
					k++; 
				}
			
				while(i < n1)
				{
					arr[k] = L[i];
					i++;
					k++;
				}
				
				while(j < n2)
				{
					arr[k] = R[j];
					i++;
					k++;
				}	
			}
			
			static public void mergeSort(int[] arr, int l, int r)
			{
				if(l < r)
				{
					int m = l+(r-1)/2;
					mergeSort(arr, l, m);
					mergeSort(arr, l, m);
					
					merge(arr, l, m, r);
				}
			}
		}
		
		mergeSort(mainArr, 0, mainArr.Length-1);
		
		Console.Write("{ ");
		foreach(int element in mainArr)
		{
			Console.Write(" {0} ", element);
		}
		
		
		
		
		
		//my implementation not working
		/*merge sort logic
		bool elementFound = false;
		int midEle = 0, getArrayNumb = 0, counter = 0, startingIndex = int.MinValue, endingIndex = int.MinValue; 
	
		while(elementFound == false){
					
			if(endingIndex >= startingIndex){	
				midEle = startingIndex + ((endingIndex-startingIndex)/2);		
					
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
		
		*/
		
	}	
}