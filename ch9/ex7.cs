using System;

class ex7
{
	static int ReverseInteger(int maiNum)
	{
		//implementation to get the number of digits
		int num = maiNum, i; 
		int byTen = 10;
		int digits = 0;

		while(num > 0){ // <- this is just to get the array number (2020: can't we get it by .length?, oh, we don't have an array, this is to get the array length for the new array below)
			num = num / byTen; //explanation down
			digits++;
		}
		
		//we found the array number, now we implement the array
		//we can do this without an array, and actually spit an int, <<<<>|
		//but that will be somewhat complicate in my skill level;   <<<<<| I actually did this! XD
		int[] reversedNumbers = new int[digits];
		num = maiNum;
		for(i = 0; i < digits; i++){ //0->n-1 - 0 is where the first digit on the right exists
			reversedNumbers[i] = num % 10;
			num /= byTen; //this is to concatinate the number to left side, since we are using int, not float
		}
		
		//^ we will reverse the operation from above, and do a multiplication of arrays, at 10 every new iteration		
		int incrementDigits = 1;
		byTen = 1; // !doing i = .length-1 and i >= 0 always results in correct decrementation in arrays
		for(i = digits - 1; i >= 0; i--){ // we decrement, because the first element is in the last
			incrementDigits = reversedNumbers[i];
			num += incrementDigits * byTen; 
			byTen *= 10;
		
		}
		
		return num; //^ I use a lot of structured styled programming
		
		
	}
	
	static void Main()
	{
		Console.WriteLine("Please Insert an integer value to reverse it: ");
		int integer = int.Parse(Console.ReadLine());
		
		Console.WriteLine("Printing result: {0}", ReverseInteger(integer));
	
	}
}