using System;

class ex13
{   
	static int[] MultiplyPoly(int[] fP, int[] sP)
	{

		//check which is bigger in size and reput them
		if(fP.Length < sP.Length)
		{
			int[] newArr = new int[fP.Length];
			Array.Copy(fP, newArr, fP.Length);
			Array.Resize<int>(ref fP, sP.Length);
			Array.Copy(sP, fP, sP.Length); 
			Array.Resize<int>(ref sP, newArr.Length);
			Array.Copy(newArr, sP, newArr.Length); 
		} 
		//printing statement
		printPoly(fP, fP.Length);
		Console.Write(" * ");
		printPoly(sP, sP.Length);


		int totalSize = fP.Length + sP.Length - 1;
		int[] finalArr = new int[totalSize]; // to add the values in 
		for (int i = 0; i < totalSize; i++)  
        { 
            finalArr[i] = 0; 
        } 
		for(int i = 0; i < fP.Length; i++)
		{
			for(int j = 0; j < sP.Length; j++)
			{
				finalArr[i+j] = finalArr[i+j] + fP[i] * sP[j];
			}
		}
		
		return finalArr;
	}

	static int[] GetPolynomials() 
	{
		bool ifNotText = false; 
		int polyNumbers = int.MinValue;
		int[] newArr = new int[0]; //the initialize main array
		int count = 0; //to get the size of the array
		
		Console.WriteLine("To exit insertion, Enter any letter or symbol");
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
	
	static void printPoly(int[] poly, int n) 
    { 
        for (int i = n-1; i >= 0; i--) 
		{ 
            Console.Write(poly[i]); 
            if (i > 1) { 
                Console.Write("x^" + i); 
            } 
            if (i == 1) { 
                Console.Write("x"); 
            } 
            if (i > 0) { 
                Console.Write(" + "); 
            } 
        } 
    } 
	
	static void Main()
    {	
		Console.Clear();
		Console.WriteLine("Polynomial Multiplier Copyright 2020");
		Console.WriteLine("Create two polynomials so that we can multiply them and find the final answer:");
		
		int[] firstPolynomial = GetPolynomials();
		int[] secondPolynomial = GetPolynomials();
				
		int[] finalPolynomial = MultiplyPoly(firstPolynomial, secondPolynomial); 
		
		Console.Write("\nFinal Answer : \n\n");
		printPoly(finalPolynomial, finalPolynomial.Length);
		
		Console.Write("\nDo you want to repeat the process? If Yes, press [Y]\nIf you want to exit press any other button: ");
		
		string repeatTrue = Console.ReadLine();
		
		if(repeatTrue == "y" || repeatTrue == "Y")
		{Main();}
		
	}
}