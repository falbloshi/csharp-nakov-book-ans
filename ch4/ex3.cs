using System;

class ex3
{
	static void Main()
	{
		Console.WriteLine("Give me your information: ");
		
		Console.Write("Company Name = ");
		string cn = Console.ReadLine();
		Console.Write("Address = ");
		string ca = Console.ReadLine();
		Console.Write("Phone Number = ");
		int pn = int.Parse(Console.ReadLine());		
		Console.Write("Fax Number = ");
		int fn = int.Parse(Console.ReadLine());
		Console.Write("Website = ");
		string cw = Console.ReadLine();
		Console.Write("Manager Name = ");
		string mn = Console.ReadLine();
		Console.Write("Manager Surname = ");
		string ms = Console.ReadLine();
		Console.Write("Manager Phone Number = ");
		int mpn = int.Parse(Console.ReadLine());
		
		Console.WriteLine("{0}\n{1}\nTELE: {2:(##) ### ### ##}  FAX: {3:(#) ### ## #}\n{4}\n{5} {6}\nPHONE: {7}", cn, ca, pn, fn,cw, mn, ms, mpn );	
		
	}
}

