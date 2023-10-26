using System;

class ex12
{
	static void Main()
	{
		
		
		
		
		Console.WriteLine("Sum of fraction of 1/2 - 1/3 + 1/4... with 0.001 precision");		
		
		
		//I coppied this code from github - since I didn't get it to be fair.
			float sum = 0;
            float sumTest = 1;
            float fraction = 2F; 

            while (Math.Abs(sumTest - sum) > 0.001)
            {
                sum = sumTest;
                if (fraction % 2 == 0)
                {
					sumTest = sum + (1 / fraction);
                } 
				else
                {
                    sumTest = sum - (1 / fraction);
                }
                fraction++;
            }

            Console.WriteLine("Result: {0}", sum);
			
	}
}

