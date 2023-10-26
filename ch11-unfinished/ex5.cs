using System; 

class ex5
{
  static void Main()
  {
    Console.WriteLine("Write Your side numbers to get hypotenuse; a and then b:");

    double d = 0; 
   
	double a = double.Parse(Console.ReadLine());
  	double b = double.Parse(Console.ReadLine());
	

    d = Math.Sqrt(Math.Pow(a, 2.0) + Math.Pow(b, 2.0));
    Console.WriteLine("Your answer is {0:0.00}", d);
  }
}