using System; 


class ex1
{
  static void Main()
  {
    Console.Write("Enter year to check if Leap Year: ");
    int year  = int.Parse(Console.ReadLine());
    bool isTrue = DateTime.IsLeapYear(year);
    Console.WriteLine("Leap Year?  : {0}", isTrue);
  }
}