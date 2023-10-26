using System;

class test3
{
	static void Main()
	{
		Console.WriteLine("LinearEquation!!");
		LinearEquation();
			
	}
		//a * x + b = 0
		static void LinearEquation(){
		
		float forLiEqA, forLiEqB, a, b;
		
		Console.Write("Write for a: ");
		string answerA = Console.ReadLine();
			
		Console.Write("Write for b: ");
		string answerB = Console.ReadLine();
		
		bool ifNumberLEA = float.TryParse(answerA, out forLiEqA);
		bool ifNumberLEB = float.TryParse(answerB, out forLiEqB);
		
		if(ifNumberLEA == false || ifNumberLEB == false){
			Console.WriteLine("Please write numbers!");
			LinearEquation();
		} 
		
		if(ifNumberLEB == true && !(forLiEqA <= 0)){
			b = forLiEqB;
			a = forLiEqA;
			if(!(b == 0)){
				b = forLiEqB * -1;
				a = forLiEqA;
				Console.WriteLine("x = {0}/{1}", b, a); 
			}
			else{
				a = forLiEqA;
				Console.WriteLine("x = 1/{1}", b, a); 
			}
			
		}
	}
}


