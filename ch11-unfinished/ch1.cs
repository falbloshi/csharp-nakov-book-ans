using System;

class ex1
{
	public class Cat
	{
		private string name;
		private string color;
		
		public string Name{
			get{
				return this.name;
			}
			
			set{
				this.name = value;
			}
		}
		
		public string Color{
			get{
				return this.color;
			}
			
			set{	
				this.color = value;
			}
		}
		
		public Cat(){
			this.name = "Unnamed";
			this.color = "gray";
		}
		
		public Cat(string name, string color){
			this.name = name;
			this.color = color;
		}
		
		public void SayMiau(){
			Console.WriteLine("Cat {0} said: Miaauuuuu!", name);
		}
	}
	static void Main()
	{
		Cat firstCat = new Cat();
		firstCat.Name = "Tony";
		firstCat.SayMiau();
		
		Cat secondCat = new Cat("Pepy", "Red");
		secondCat.SayMiau();
		Console.WriteLine("Cat {0} is {1} color, is friend of {2}", secondCat.Name, secondCat.Color, firstCat.Name);
	
		Cat myCat = new Cat();
		myCat.Name = "Hex";
		Console.WriteLine("The name of my cat is {0}", myCat.Name);
		myCat.SayMiau();
		
		Cat randomCat = new Cat();
		randomCat.SayMiau();
		Console.WriteLine("The name of random cat is {0}, its color is {1}", randomCat.Name, randomCat.Color);
	
		
		randomCat = new Cat("Johnny", "Blue"); // there is a mistake in the document, don't put 'Cat' again before  the same value already assigned
		randomCat.SayMiau();
		Console.WriteLine("The name of random cat is {0}, its color is {1}", randomCat.Name, randomCat.Color);
		
	}
}








