using System;

class ex11
{
	static void Main()
	{
		Console.WriteLine("Write a point number between 1 and 999 and we will give you English reading of the Number");
		
		int choiceN;		
		Console.Write("Type a number between 1 and 999 or them!  ->  ");
		int.TryParse(Console.ReadLine(), out choiceN);
		
		
		while(!(choiceN >= 1 && choiceN <= 999))
		{
			Console.Write("Please type a number between 1 and 999 or them!  ->");
			int.TryParse(Console.ReadLine(), out choiceN);
			
		}
		
		string firstDigit = ""; 
		string secondDigit = "";
		string thirdDigit = "";
		
		int oneDigit, checkEr, threeDigit; 
		
		oneDigit = choiceN % 10;			
		checkEr = choiceN % 100;
		
		if(oneDigit < 10)
		{
			switch(oneDigit)
			{
				
				case 1: firstDigit = "One";  break;
				case 2: firstDigit = "Two"; break;
				case 3: firstDigit = "Three"; break;
				case 4: firstDigit = "Four"; break;
				case 5: firstDigit = "Five"; break;
				case 6: firstDigit = "Six"; break;
				case 7: firstDigit = "Seven"; break;
				case 8: firstDigit = "Eight"; break;
				case 9: firstDigit = "Nine"; break;
				default: firstDigit = ""; break; 
			}
		}	
		
		
		//to check for those odd named and remove the ones
		if(checkEr < 20)
		{
			int dDigit = checkEr;
			
			switch(dDigit)
			{
				
				case 11: secondDigit = "Eleven"; firstDigit = ""; break;
				case 12: secondDigit = "Twelve"; firstDigit = ""; break;
				case 13: secondDigit = "Thirteen"; firstDigit = ""; break;
				case 14: secondDigit = "Fourteen"; firstDigit = ""; break;
				case 15: secondDigit = "Fifteen"; firstDigit = ""; break;
				case 16: secondDigit = "Sixteen"; firstDigit = ""; break;
				case 17: secondDigit = "Seventeen"; firstDigit = ""; break;
				case 18: secondDigit = "Eighteen"; firstDigit = ""; break;
				case 19: secondDigit = "NineTeen"; firstDigit = "";	break;
				default: secondDigit = "";	break;
			}
		}
		else
		{
			int twoDigit = checkEr / 10; // to check for the ten multiples
			  
			switch(twoDigit)
			{
				case 1: secondDigit = "Ten"; break;
				case 2: secondDigit = "Twenty"; break;
				case 3: secondDigit = "Thirty"; break;
				case 4: secondDigit = "Fourty"; break;
				case 5: secondDigit = "Fifty"; break;
				case 6: secondDigit = "Sixty"; break;
				case 7: secondDigit = "Seventy"; break;
				case 8: secondDigit = "Eighty"; break;
				case 9: secondDigit = "Ninety"; break;	
				default: secondDigit = ""; break;
			}
		}

		threeDigit =  choiceN / 100;	
		
		if(threeDigit < 10)
		{
			switch(threeDigit)
			{
				case 1: thirdDigit = "One";  break;
				case 2: thirdDigit = "Two"; break;
				case 3: thirdDigit = "Three"; break;
				case 4: thirdDigit = "Four"; break;
				case 5: thirdDigit = "Five"; break;
				case 6: thirdDigit = "Six"; break;
				case 7: thirdDigit = "Seven"; break;
				case 8: thirdDigit = "Eight"; break;
				case 9: thirdDigit = "Nine"; break;
				default: thirdDigit = ""; break; 
			}
		}
		
		//print out for the hundred - checking digits are not zero 
		if((choiceN	> 100) && (choiceN % 10 != 0) && (choiceN % 100 > 10))
		{
			Console.WriteLine("{0} hundered and {1} {2}", thirdDigit, secondDigit, firstDigit);
		}
		else if((choiceN > 100) && (choiceN % 10 != 0) && (choiceN % 100 < 10))
		{
			Console.WriteLine("{0} hundered - O - {1}", thirdDigit, firstDigit);
		}
		else if((choiceN > 100) && (choiceN % 10 == 0) && (choiceN % 100 == 0))
		{
			Console.WriteLine("{0} hundered", thirdDigit);
		}		
		
		//less than hundred
		if((choiceN	< 100) && (choiceN > 10))
		{
			
			Console.WriteLine("{0} {1}", secondDigit, firstDigit);
		}
		else if(choiceN < 10)
		{
			Console.WriteLine("{0}", firstDigit);
		}
		
		
		
		
	}
}

