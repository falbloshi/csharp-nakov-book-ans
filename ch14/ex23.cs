using System;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class GenericList<T>
{
    private const int DefaultItemLimit = 5;
    private T[] myGenericList;
    private int usedPlaces;

    public int Length 
    {
        get {return usedPlaces;}
    }
    
    public GenericList()
        : this(DefaultItemLimit)
    {
    }

    public GenericList(int RoofLimit)
    {
        this.myGenericList = new T[RoofLimit];
        this.usedPlaces = 0;
    }
     
    public void Add(T newItem)
    {
        if (this.usedPlaces >= this.myGenericList.Length)
        {
            throw new InvalidOperationException("List is full!");
        }
        this.myGenericList[this.usedPlaces] = newItem;
        this.usedPlaces++;
    }

    public T InsertAt(int index, T newItem)
    {
        if (index < 0 || index >= this.usedPlaces)
        {
            throw new ArgumentOutOfRangeException($"Index \"{index}\" is out of bounds!");
        }
        for (int i = this.myGenericList.Length - 1; i > index; i--)
        {
            this.myGenericList[i] = this.myGenericList[i - 1];
        }
        this.myGenericList[index] = newItem;
        this.usedPlaces++;
        return newItem;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= this.usedPlaces)
        {
            throw new ArgumentOutOfRangeException($"Index \"{index}\" is out of bounds!");
        }
        return this.myGenericList[index];
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.usedPlaces)
        {
            throw new ArgumentOutOfRangeException($"Index \"{index}\" is out of bounds!");
        }
        T removedElement = this.myGenericList[index];
        for (int i = index; i < this.usedPlaces - 1; i++)
        {
            this.myGenericList[i] = this.myGenericList[i + 1];
        }
        this.myGenericList[this.usedPlaces - 1] = default(T);
        this.usedPlaces--;

        return removedElement;
    }

    public void Find(T element)
    {
        var elementSB  = new StringBuilder(element.ToString());
        bool ifFound = false;
        for (int i = 0; i < this.usedPlaces - 1; i++)
        {
            if(ifFound = Regex.IsMatch(this.myGenericList[i].ToString(), elementSB.ToString()))
            {
                Console.WriteLine($"Match found at {i}");
                ifFound = true;
                break;
            };
        }
        if(!ifFound)    Console.WriteLine("Match not found");
    }

    public void ClearAll()
    {
        this.myGenericList = new T[0];
        this.usedPlaces = 0;
    }

    public int Count()
    {
        return this.usedPlaces;
    }
}


class TestClass
{
    static void Main()
    {
        GenericList<int> myInt = new GenericList<int>(6);
        myInt.Add(4);
        myInt.Add(12);
        myInt.Add(9);
        myInt.Add(0);
        myInt.Add(11);
        myInt.Add(8);

        for(int i = 0; i < myInt.Length; i++)
        {
            Console.WriteLine(myInt.Get(i));
        }

        myInt.RemoveAt(4);
        Console.WriteLine("Removing at index 4");
        for(int i = 0; i < myInt.Length; i++)
        {
            Console.WriteLine(myInt.Get(i));
        }
        myInt.InsertAt(4, 15);
        Console.WriteLine("Adding at index 4");
        for(int i = 0; i < myInt.Length; i++)
        {
            Console.WriteLine(myInt.Get(i));
        }

        Console.WriteLine("Searching element \"9\"");
        myInt.Find(9);

        GenericList<String> myString = new GenericList<String>(3);
        myString.Add("subs");
        myString.Add("eat it");
        myString.Add("call me");

        for(int i = 0; i < myString.Length; i++)
        {
            Console.WriteLine(myString.Get(i));
        }
        myString.RemoveAt(1);
        Console.WriteLine("Removing at index 1");
        for(int i = 0; i < myString.Length; i++)
        {
            Console.WriteLine(myString.Get(i));
        }
        myString.InsertAt(1, "don't eat it");
        Console.WriteLine("Adding at index 1");
        for(int i = 0; i < myString.Length; i++)
        {
            Console.WriteLine(myString.Get(i));
        }
        Console.WriteLine(myString.Count());
        Console.WriteLine("Searching element \"caramel\"");
        myString.Find("caramel");
        Console.WriteLine("Searching element \"eat it\"");
        myString.Find("eat it");
        Console.WriteLine("Clearing");
        myString.ClearAll();
        for(int i = 0; i < myString.Length; i++)
        {
            Console.WriteLine(myString.Get(i));
        }
        Console.WriteLine(myString.Count());


    }
}
