using System; 

class ex2
{
  static void Main()
  {
    Console.WriteLine("Number Generator from 1 to 100");
    
    Random rand = new Random();

    for(int i = 0; i < 10 ; i++)
    { 
       Console.WriteLine(rand.Next(1, 100));
    }
  }
}