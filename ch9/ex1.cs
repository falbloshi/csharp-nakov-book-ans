using System;

class ex1
{

	static void GreetingName(string enteredName)
	{
		Console.WriteLine("Greetings {0}!", enteredName);
	}	
	static string GetName()
	{
		Console.Write("Please insert your name: ");
		string name = Console.ReadLine();
		Console.WriteLine();
		return name;
	}
	
	static void Main()
	{
		GreetingName(GetName());
	}
	
}