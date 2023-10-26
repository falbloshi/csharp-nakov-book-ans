using System;

class ex8
{
	static void Main()
	{
		string hello = "Hello ";
		string world = "World! ";
		object OBHelWorld = hello + world;
		string HellWorld = (string)OBHelWorld;
		Console.WriteLine(HellWorld);
		
	}
}