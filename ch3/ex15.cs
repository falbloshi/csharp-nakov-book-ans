using System;

class ex15
{
	static void Main()
	{
		Console.WriteLine("To change the value of number N at position P, 3, 4 and 5 with 24, 25, 26");
		
		Console.Write("Number N = ");
		int nUmber = Convert.ToInt32(Console.ReadLine());

		
		int bit3 = (nUmber >> 3) & 1; 
		int bit24 = (nUmber >> 24) & 1;
		nUmber = nUmber & (~(1 << 24)) | (bit3 << 24); 
		nUmber = nUmber & (~(1 << 3)) | (bit24 << 3);
		
		
		int bit4 = (nUmber >> 4) & 1; 
		int bit25 = (nUmber >> 25) & 1;
		nUmber = nUmber & (~(1 << 25)) | (bit4 << 25); 
		nUmber = nUmber & (~(1 << 4)) | (bit25 << 4);
		
		int bit5 = (nUmber >> 5) & 1; 
		int bit26 = (nUmber >> 26) & 1;
		nUmber = nUmber & (~(1 << 26)) | (bit5 << 26); 
		nUmber = nUmber & (~(1 << 5)) | (bit26 << 5);
		
		
		Console.WriteLine("New Number : {0}  ", nUmber);	
		
	}
}

