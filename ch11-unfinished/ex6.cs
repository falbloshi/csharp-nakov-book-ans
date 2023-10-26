using System; 

class ex6
{
  static void MethodA()
  {
	  Console.WriteLine(" Insert the sides of the triangle: \n");
	  
	  double[] arr1 = new double[3];
	  
	  for(int i = 0; i < arr1.Length; i++)
	  {		
		  Console.Write("Side {0}: ", i+1);
		  arr1[i] = double.Parse(Console.ReadLine());
		  Console.WriteLine();
		  while(arr1[i] <= 0) 
		  {
			Console.Write("Side {0}: ", i+1);
			arr1[i] = double.Parse(Console.ReadLine());
			Console.WriteLine();			
		  }	  
	  }
	  
	  double perM = (arr1[0] + arr1[1] + arr1[2])/2;
	  
	  double area = Math.Sqrt(perM*((perM-arr1[0])*(perM-arr1[1])*(perM-arr1[2])));
	  Console.WriteLine("Area of Triangle: {0:0.00} cm", area);  
  }
  
  static void MethodB()
  {
	  Console.WriteLine(" Insert the base and height of the triangle: \n");
	  
	  double[] arr2 = new double[2];
	  
	  for(int i = 0; i < arr2.Length; i++)
	  {		
		  Console.Write("Side {0}: ", i+1);
		  arr2[i] = double.Parse(Console.ReadLine());
		  Console.WriteLine();
		  while(arr2[i] <= 0) 
		  {
			Console.Write("Side {0}: ", i+1);
			arr2[i] = double.Parse(Console.ReadLine());
			Console.WriteLine();			
		  }	  
	  }
	  
	  double area = (arr2[0] * arr2[1])/2;
	  
	  Console.WriteLine("Area of Triangle: {0:0.00} cm", area);  
  }
  
  static void MethodC()
  {
	 Console.WriteLine(" Insert the two sides of the triangle: \n");
	  
	  double[] arr3 = new double[3];
	  
	  for(int i = 0; i < arr3.Length; i++)
	  {	
		if(i != 2)
		{
		  Console.Write("Side {0}: ", i+1);
		  arr3[i] = double.Parse(Console.ReadLine());
		  Console.WriteLine();
		  while(arr3[i] <= 0) 
		  {
			Console.Write("Side {0}: ", i+1);
			arr3[i] = double.Parse(Console.ReadLine());
			Console.WriteLine();
		  }
		}
		else
		{
		  Console.Write("Write the Degree: " );
		  arr3[2] = double.Parse(Console.ReadLine());
		  while(arr3[2] >= 180 || arr3[2] <= 0)
		  {
			Console.Write("Write degree below 180 and above 0: ");
			arr3[2] = double.Parse(Console.ReadLine());
		  }
		}		  
	  }
	  
		double degree = (Math.PI * arr3[2])/180.00; 
		double area = (arr3[0]*arr3[1]*Math.Sin(degree))/2;
		Console.WriteLine("Area of Triangle: {0:0.00} cm", area);  

  }
		
		
  static void Main()
  {
	Console.Clear();
    Console.WriteLine("Triangle Calculator Copyright 2020");
    Console.WriteLine("This Program will take a User input and then calculate the area of the triangle use the options below:\n");

		
	Console.WriteLine(" a- Calculate the area of triangle by giving it three sides");
	Console.WriteLine(" b- Calculate the area of triangle by giving it a side and an altitude");
	Console.WriteLine(" c- Calculate the area of triangle by giving it two side and the angle between them");
	
	//menu
    while(true)
	{
		Console.Write("\n> ");
		string insert = Console.ReadLine();
		insert = insert.ToLower();
		switch(insert)
		{
			case "a": Console.WriteLine(); MethodA(); break;
			case "b": Console.WriteLine(); MethodB(); break;
			case "c": Console.WriteLine(); MethodC(); break;
			default: 
				Console.Clear();
				Console.WriteLine("You have written a wrong value, returning to main screen\n");
				Console.ReadLine();
				Main();
				break;
		}
		break;
	}
	
  }
}