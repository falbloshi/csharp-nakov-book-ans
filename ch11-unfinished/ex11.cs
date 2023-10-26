using System;

class ex11
{
	
	
	static void Main()
	{	
		Console.Clear();	
	
		string[] laudatoryPhrases = {"The product is excellent.", "This is a great product.", "I use this product constantly.", "This is the best product from this category."};
			
		string[] laudatoryStories = {"Now I feel better.", "I managed to change.", "It made some miracle.", "I can’t believe it, but now I am feelin great.", "You should try it, too. I am very satisfied."};
		string[]  fnAuthor = {"Dayan", "Stella", "Hellen", "Kate"};
		string[] lnAuthor = {"Johnson", "Peterson", "Charls"};
		string[] cities = {"London", "Paris", "Berlin", "New York", "Madrid"};
		
		Random rand = new Random();
		int lpIndex = rand.Next(laudatoryPhrases.Length);
		int lsIndex = rand.Next(laudatoryStories.Length);
		int fnIndex = rand.Next(fnAuthor.Length);
		int lnIndex = rand.Next(lnAuthor.Length);
		int citIndex = rand.Next(cities.Length);
		
		Console.WriteLine("{0} {1} -- {2} {3}, {4}", laudatoryPhrases[lpIndex], laudatoryStories[lsIndex], fnAuthor[fnIndex], lnAuthor[lnIndex], cities[citIndex]);
		
		Console.WriteLine("\n\n\nDo you want to generate on more line? [Y or y to repeat]/Else press anything else to exit! >");
		string m =Console.ReadLine();
		if(m == "Y" || m == "y")
		{
			Main();
		}
	
	}
			
}