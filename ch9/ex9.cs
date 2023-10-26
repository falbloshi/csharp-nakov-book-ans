using System;

class ex9{
	
	static void SortDescending(int[] mainArr)
	{
		
		int i, j, num, temp;
		for(i=0; i < mainArr.Length - 1; i++ ){
			num = i;  
		
			for(j=i+1; j < mainArr.Length; j++){
				if(mainArr[j] > mainArr[num]){ 
					num = j;    
				}
			}
		temp = mainArr[i];
		mainArr[i] = mainArr[num];
		mainArr[num] = temp;
		}
		
		Console.Write("{");
		foreach (int element in mainArr)
		{
			Console.Write(" {0} ", element);		
		}
		Console.Write("}");	
	}
		
	
		
	
	static void Main()
	{
		Console.WriteLine("This program method is going to take the largest element and sort the elements in descending order:");
		
		int[] mainArray = {12, 6, 23, 34, 13, 32, 21, 9, 11, 19, 21};
		Console.Write("Our sample array:");
			
		foreach(int element in mainArray){
				Console.Write(" {0}", element);
		}
		
		Console.WriteLine("\nSorting in Descending Order:"); SortDescending(mainArray);
		
	}
}
