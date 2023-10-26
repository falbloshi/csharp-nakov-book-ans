using System;

class ex3
{
	//will be taking result from last digit
	static string ConvertToEnglishNumber(int num)
	{	
		if(num <= 9){ //better than switch statement, because, we are not doing any other operations
		string[] englishNames = {"Zero", "One", "Two", "Three", "Four"
		, "Five", "Six", "Seven", "Eight", "Nine"};		
		return englishNames[num];
		}
		else{
			string error = "There is an error!";
			return error;
		}
		
	}
	//taking from user input, and produce the last digit if it is greater than 2 digits
	static int GetLastDigit(int digit)
	{	
		if(digit > 9){
			//No need for loop, just div modulus by 10 to get last digit.
			digit %= 10;
		}
		return digit;	
			
	}
	
	static void Main()
	{
		Console.WriteLine("Please Insert an integer to check its last digit");
		Console.Write("Number: "); int number = int.Parse(Console.ReadLine());
		int lastDigit = GetLastDigit(number);
		string convertedEnglish = ConvertToEnglishNumber(lastDigit);
		
		Console.WriteLine("{0}<-- {1}", number, convertedEnglish);
	}
}