using System;

class test1
{
	static void Main()
	{	
		
		Console.Write("\nPlease insert a positive number not exceeding 50 million to reverse it: ");
		
		string answerOne = Console.ReadLine();
		int forReverseinteger;
	
		bool ifNumber = int.TryParse(answerOne, out forReverseinteger);
		
		if(ifNumber == true && forReverseinteger <= 50000000 && forReverseinteger > 0){
	
			int num = forReverseinteger; 
			int i; 
			int byTen = 10;
			int digits = 0;

			while(num > 0){ // <- this is just to get the array number 
				Console.WriteLine(num);
				num = num / byTen; 
				digits++;
			}
			
			Console.WriteLine(digits);
			
			int[] reversedNumbers = new int[digits];
			num = forReverseinteger;
			for(int n = 0; n < digits; n++){ 
				Console.Write("{0} ", reversedNumbers[n]);
				reversedNumbers[n] = num % 10;
				num = num / byTen;
			}
			
			int incrementDigits = 1;
			byTen = 1;  
			for(i = digits - 1; i >= 0; i--){ 
				incrementDigits = reversedNumbers[i];
				num += incrementDigits * byTen; 
				byTen = byTen * 10;
			}
			
			Console.WriteLine("The reversed number: {0}", num);
			
		}
		
		else{
			Console.WriteLine("Please follow the instructions, taking you to main menu again...");
			Main();
		}
	
		
		
	}
}
	

		/*
		int num = 2634; 
		int x = num;
		int divTen = 10;
		int iterate = 0;
		while(num > 0){
			Console.WriteLine(num);
			num = num / divTen;
			iterate++;
		}
		
	int[] array = new int[iterate];
	Console.WriteLine(array.Length);
	
	int n = 1;
	for(x = 0; x < array.Length; x++){
		array[x] = n ;
		n++; 
		Console.WriteLine(array[x]); */