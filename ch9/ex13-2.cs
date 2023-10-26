using System;

class ex13_2
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
		
    int totalSize = fP.Length * sP.Length; Console.WriteLine("Total size {0} okay", totalSize);
    int count = 0;
		int[] finalArr = new int[totalSize]; // to add the values in 
		for(int i = 0; i < fP.Length; i++)
		{
      
      Console.WriteLine("Outerloop Okay: {0}", i);
			for(int j = 0; j < sP.Length; j++)
			{
        count++;  Console.WriteLine("Count++ Okay: {0}", count);
        Console.WriteLine("Innerloop Okay: {0}", j);
				finalArr[count-1] = fP[i] * sP[j];
			}


		}
		
		return finalArr;
	}
	static void Main()
    {	
		Console.WriteLine("Test 2 for multiplying polynomials from user");
		
		int[] firstPolynomial = {1, 2, 3};
		int[] secondPolynomial = {1, 3};
		
		int[] resultPoly = MultiplyPoly(firstPolynomial,secondPolynomial);
		
		foreach(int element in resultPoly)
		{
			Console.Write("{0} ", element);
		}
	}
}