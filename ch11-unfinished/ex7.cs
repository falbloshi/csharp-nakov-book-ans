using System;
//ex7
namespace CreatingAndUsingObjects
{
	public class Cat
	{
		private string name;
		private string color;
		public string Name
		{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
		}
			public string Color
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color = value;
			}
		}
		public Cat()
		{
			this.name = "Unnamed";
			this.color = "gray";
		}
		public Cat(string name, string color)
		{
			this.name = name;
			this.color = color;
		}
		public void SayMiau()
		{
			Console.WriteLine("Cat {0} said: Miauuuuuu!", name);
		}
	}
	
	public class Sequence
	{
		private static int currentValue = 0;
		private Sequence()
		{
		}
		public static int NextValue()
		{
			currentValue++;
			return currentValue;
		}
	}
}

namespace NewNameSpace
{
	using CreatingAndUsingObjects;
	
	public class NewInitiation
	{
		
		
		static void Main()
		{
			Cat mynewCat = new Cat("Daryll", "Grey");
			mynewCat.SayMiau();
			
			Console.WriteLine("Sequence[1...3]: {0}, {1}, {2}", Sequence.NextValue(), Sequence.NextValue(), Sequence.NextValue());
			
		}
	} 
}