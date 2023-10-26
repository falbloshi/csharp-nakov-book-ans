using System;

class ex4
{
	static void Main()
	{
		Console.WriteLine("We will print out All the cards of a full deck of cards");

            string clubs = "Clubs", spade = "Spades", heart = "Hearts", diamond = "Diamonds";
            string house = "";
            string clothes = "";
            for(int x = 0; x < 4; x++)
            {
                switch(x)
                {
                    case 0: house = spade; break;
                    case 1: house = clubs; break;
                    case 2: house = heart; break;
                    case 3: house = diamond; break;
                    default: house = ""; break;

                }

                for(int y = 1; y < 14; y++)
                {
                    switch(y)
                    {
                        case 1: clothes = "Two"; break;
                        case 2: clothes = "Three"; break;
                        case 3: clothes = "Four"; break;
                        case 4: clothes = "Five"; break;
                        case 5: clothes = "Six"; break;
                        case 6: clothes = "Seven"; break;
                        case 7: clothes = "Eight"; break;
                        case 8: clothes = "Nine"; break;
                        case 9: clothes = "Ten"; break;
                        case 10: clothes = "Jack"; break;
                        case 11: clothes = "Queen"; break;
                        case 12: clothes = "King"; break;
                        case 13: clothes = "Ace"; break;	
                        default: clothes = ""; break;
                        
                        
                    }
                    
                    Console.WriteLine("{0} of {1}", clothes, house);

                }
                
                Console.WriteLine("\n\n");
			}
		
		
		
		
	}
}

 