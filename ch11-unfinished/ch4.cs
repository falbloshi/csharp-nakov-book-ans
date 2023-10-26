using System;
using System.Text;

class RandomPassGenerator
{
	private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
	private const string Digits = "0123456789";
	private const string SpecialChars = "~!@#$%^&*()_+=`{}[]\\|':;.,/?<>";
	private const string AllChars = CapitalLetters + SmallLetters + Digits + SpecialChars;
	
	private static Random rnd = new Random();
	
	static void Main()
	{
		
		StringBuilder password = new StringBuilder();
		
		for (int i = 1; i <= 2; i++){
			char capitalLetter = GenerateChar(CapitalLetters);
			InsertAtRandomPosition(password, capitalLetter);
		}
		
		for (int i = 1; i <= 2; i++){
			char smallLetters = GenerateChar(SmallLetters);
			InsertAtRandomPosition(password, smallLetters);
		}
		
		char digits = GenerateChar(Digits);
		InsertAtRandomPosition(password, digits);
		
		
		for (int i = 1; i <= 3; i++){
			char specialChar = GenerateChar(SpecialChars);
			InsertAtRandomPosition(password, specialChar);
		}
		
		
		int count = rnd.Next(8) + 1;
		for (int i = 1; i <= count; i++){
			char specialChar = GenerateChar(SpecialChars);
			InsertAtRandomPosition(password, specialChar);
		}
		
		Console.WriteLine(password);
		
	}
	
	private static void InsertAtRandomPosition(StringBuilder password, char character){
		int randomPosition = rnd.Next(password.Length + 1);
		password.Insert(randomPosition, character);
	}
	
	private static char GenerateChar(string availableChars){
		int randomIndex = rnd.Next(availableChars.Length);
		char randomChar = availableChars[randomIndex];
		return randomChar;
	}
	
}
	