using System;

class ex10
{
	static void Main()
	{
		
		Console.WriteLine("Enter a number so we can make a nxn matrix!");
			
			
		sbyte n = sbyte.MinValue;
		bool ifNumber = false;
		
		while(ifNumber == false) //for checking the correct numbers
			{		
				Console.Write("Type for n: ");
				ifNumber = sbyte.TryParse(Console.ReadLine(), out n);
				
				if(n > 20)
				{
					Console.WriteLine("Please write a number less than 20");
					ifNumber = false;
				}
			}
			
		ushort j = 1, k = 1; //i = 0, d = 0;
		
		
		/* my method
		for(j = 1; j <= n; j++)
		{
			for(k = 1; k <= n; k++)
			{
				i = k;
				i += d; // d adds the new one +1 from the upper iteration
				Console.Write(" {0}", i);
			}
			
			d++; 
			Console.Write(" \n");
			
		} */
		
		//iv4opn method
		for(j = 0; j < n; j++)
		{
			for(k = 1; k <= n; k++)
			{
				Console.Write((k + j).ToString().PadLeft(3));; //this to padleft is useful for future codes
			}
			Console.WriteLine();
		}
		
			
	}
}

