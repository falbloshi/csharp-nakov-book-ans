using System;

class ex13_1 
{   
	static int[] GetPolynomials() //done
	{
		bool ifNotText = false; 
		int polyNumbers = int.MinValue;
		int[] newArr = new int[0]; //the initialize main array
		int count = 0; //to get the size of the array
		
		Console.WriteLine("To exit, Enter any letter or symbol");
		Console.WriteLine("Please insert your polynomial starting from 0th degree:");
		do
		{

			switch (count)
			{
				case 1: 
					Console.Write("For {0}st degree: ", count); break;
				case 2: 
					Console.Write("For {0}nd degree: ", count); break;
				case 3: 
					Console.Write("For {0}rd degree: ", count); break;
				default: 
					Console.Write("For {0}th degree: ", count); break;
			}
			string poly = Console.ReadLine();
			ifNotText = int.TryParse(poly, out polyNumbers);
		
			if(ifNotText == true)
			{	
				++count; 
				Array.Resize<int>(ref newArr, count); //resizing array depending on the size of the counted elements
				newArr[count-1] = polyNumbers; 
				
			}
			
		}while(ifNotText == true);
		
		return newArr;
	}
	static void Main()
    {	
		Console.WriteLine("Test 1 for getting polynomials from user");
		
		int[] firstPolynomial = GetPolynomials();
		
		foreach(int element in firstPolynomial)
		{
			Console.WriteLine("{0} ", element);
		}		
	}
}