using System;

class ex12 //this program, needs fixing, in the goddamn printing things - otherwise, it kind of works
{
    static int[] CreatePolynomials()
    {
        Console.Write("Please define the degree of your polynomial(must not be greater than 3): ");

        string poly = Console.ReadLine();
        int polyNum;
        bool ifInt = int.TryParse(poly, out polyNum);

        if (ifInt == true && polyNum <= 3)
        {
            int[] arrayPoly = new int[polyNum];
            Console.WriteLine("Now please fill in the coefficient of the x polynomials:\n");

            for (int i = 0; i < polyNum; i++)
            {
                switch (i)
                {	
					//specific conditions for no x and single x
					case 0: Console.Write("For no x: "); arrayPoly[i] = int.Parse(Console.ReadLine()); break;
                    case 1: Console.Write("For x: "); arrayPoly[i] = int.Parse(Console.ReadLine()); break;
					case 2: Console.Write("For x^2: "); arrayPoly[i] = int.Parse(Console.ReadLine()); break;
				}
			}
			
			
			//printing structure
			Console.WriteLine();
			PrintPoly(arrayPoly);
			Console.WriteLine();
			
            return arrayPoly;
        }
        else
        {
            Console.WriteLine("Please write a number less than 4\n");
            CreatePolynomials();
            return null;
        }
    }
	
	
	
	//printing structure
	static void PrintPoly(int[] printingPoly)
	{	
		int len = printingPoly.Length; 
		bool ifZero;	
		bool moreThanTwo = false;

			Console.Write("(");
			for(int i = len - 1/* this is wrong */; i >= 0; i--) 
			{	
		
				ifZero = !(printingPoly[i] == 0); //should be false case, which makes it true bool
		
				//printing largest element first	
				if(i == 2 && ifZero){
					if(printingPoly[i] == -1){
							Console.Write("-x^2");
						}
					else if(printingPoly[i] == 1){
							Console.Write("x^2");
						}
					else{
					Console.Write("{0}x^2", printingPoly[i]);
					}
					moreThanTwo = true;
				}

				//first degree elements if there is a third element i.e 2 degree 
				else if(i > 0 && ifZero &&  moreThanTwo){
					
						if(printingPoly[i] == -1){
							Console.Write(" - x");
						}
						else if(printingPoly[i] == 1){
							Console.Write(" + x");
						}
						
						if(printingPoly[i] < -1){
						Console.Write(" - {0}x", (printingPoly[i] * -1));
						}
						else if(printingPoly[i] > 1){
						Console.Write(" + {0}x", (printingPoly[i]));
						}
						else{
							Console.Write("");
						}
					}
									
				//first degree elements if there is no third element i.e 2 degree 
				else if(i > 0 && ifZero && !(moreThanTwo)){
					
						if(printingPoly[i] == -1){
							Console.Write("-x");
						}
						else if(printingPoly[i] == 1){
							Console.Write("x");
						}
						
						else if(printingPoly[i] != 0){
							Console.Write("{0}x", printingPoly[i]);
						}
						else{
							Console.Write("");
						}
					}	

				//if it is zero
				else if(printingPoly[i] == 0){
						Console.Write("");	 
					}				
				
				//for no x <- Working
				else if(i == 0){
					if(printingPoly[i] == 0){
						Console.Write("");	 
					}
					else if(len > 1){
						if(printingPoly[i] < 0){
							Console.Write(" - {0}", (printingPoly[0] * -1));
						}
						else{
							Console.Write(" + {0}", printingPoly[0]);
						}
					}
					else if(len <= 1){
							Console.Write("{0}", printingPoly[0]);
						}
				}
				else{
					continue;
				}

			}Console.Write(")");
	
	}
 
	static void SumPolynomials(int[] firstPoly,  int[] secondPoly)
	{		
			Console.Write("\nNow we sum the polynomials:");
			PrintPoly(firstPoly); 
			Console.Write(" + ");
			PrintPoly(secondPoly);
			
			int lenF = firstPoly.Length;
			int lenS = secondPoly.Length;
			int dex; 
			bool isFL = false; // is first large
			bool isSL = false;
			bool isEQ = false;
			int lenP;
			int[] sumPoly;
			
			//two conditions lenF large or lenS large - so we repeat some codes
			if(lenF > lenS){
				sumPoly = new int[lenF];
				lenP = lenF;
				dex = lenS; //where the counter stop for the smallest array addition
				isFL = true;
			}
			else if(lenF == lenS){
				sumPoly = new int[lenF];
				dex = lenF;
				lenP = lenF;
				isEQ = true;
			}
			else{
				if(lenS > lenF){
					isSL = true;		
				}
				sumPoly = new int[lenS];
				dex = lenF;
				lenP = lenS;
			}
			
			for(int j = 0; j < lenP; j++){			
				if(j < dex){
					sumPoly[j] = (firstPoly[j] + secondPoly[j]);
				}
				else if(isEQ == true){				
					sumPoly[j] = (firstPoly[j] + secondPoly[j]);
				}
				else if (isFL == true){
					sumPoly[j] = firstPoly[j];
				}
				else if (isSL == true){
					sumPoly[j] = secondPoly[j];
				}
				else{
					continue;
				}
			}
			
			Console.Write("\n\nResult: ");
			PrintPoly(sumPoly);	
			Console.WriteLine();
			
	}

    static void Main()
    {	
		Console.WriteLine("Welcome to the Polynomial additions! Please write for two Polynomials:\n");
		
		Console.WriteLine("First Polynomial\n");
        int[] firstPoly = CreatePolynomials();
		
		Console.WriteLine("\nSecond Polynomial\n");
        int[] secondPoly = CreatePolynomials();
		
		SumPolynomials(firstPoly, secondPoly);	
    }
}