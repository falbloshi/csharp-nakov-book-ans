using System;

class Test5
{
	static void CreatePolynomials(){
	
	Console.Write("Please define the degree of your polynomial(must not be greater than 5)	: ");
		string poly = Console.ReadLine();
		int polyNum;
		bool ifInt = int.TryParse(poly, out polyNum);
		
	
		if(ifInt == true && polyNum <= 5)
		{
			polyNum += 1; //degree starts at x 	
			int[] arrayPoly = new int[polyNum]; //using global. which i learned from java
			Console.WriteLine("Now please fill in the coefficient of the x polynomials");
			
			for(int i = 0; i < polyNum; i++){
				switch(i){
					case 0: Console.Write("For no x: "); arrayPoly[i] = int.Parse(Console.ReadLine()); break;
					case 1: Console.Write("For x: "); arrayPoly[i] = int.Parse(Console.ReadLine()); break;
				}
				if(i > 1){
					Console.Write("For x^{0}:", i);
					arrayPoly[i] = int.Parse(Console.ReadLine());
				}	
					
			}
		}
		else{
			Console.WriteLine("Please write a number greather than 5");
			CreatePolynomials();
		}
	}	
	
	static void Main(){
		 CreatePolynomials();
	}
}