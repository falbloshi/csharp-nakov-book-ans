using System; 

class ex3
{
  static void Main()
  {
    DayOfWeek dayNow = DateTime.Today.DayOfWeek;
    Console.WriteLine("Today's Day of Week is: {0}", dayNow); 
  }
}