using System;

class NewTest{
	
	static void PrintPoly(int[] printingPoly){
		
		int len = printingPoly.Length; 
		bool ifZero;	
		bool moreThanTwo = false;

			Console.Write("(");
			for(int i = len - 1/* this is wrong */; i >= 0; i--) 
			{	
		
				
				ifZero = !(printingPoly[i] == 0); //should be false case, which makes it true bool
		
				//printing largest element first	
				if(i == 2 && ifZero){
					Console.Write("{0}x^2", printingPoly[i]);
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
	 static void Main(){
		 
		 Console.Write(":  ");
	
		 int[] ourArray = {2, -1};
		 PrintPoly(ourArray);
	
		 
 
	 }
	 
	 }