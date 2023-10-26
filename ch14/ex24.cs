using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class GenericList<T>
{
    private const int DefaultItemLimit = 5;
    private T[] myGenericList;
    private int usedPlaces;

    public int Length
    {
        get { return usedPlaces; }
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

    private void Resize()
    {
        int limit = this.myGenericList.Length;
        T[] storageList = new T[limit];
        Array.Copy(myGenericList, storageList, limit);
        this.myGenericList = new T[limit * 2];
        Array.Copy(storageList, myGenericList, limit);
        Array.Clear(storageList, 0, limit - 1);

    }

    public void Add(T newItem)
    {
        if (this.usedPlaces >= this.myGenericList.Length)
        {
            Resize();
            //throw new InvalidOperationException("List is full!");
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
        var elementSB = new StringBuilder(element.ToString());
        bool ifFound = false;
        for (int i = 0; i < this.usedPlaces - 1; i++)
        {
            if (ifFound = Regex.IsMatch(this.myGenericList[i].ToString(), elementSB.ToString()))
            {
                Console.WriteLine($"Match found at {i}");
                ifFound = true;
                break;
            };
        }
        if (!ifFound) Console.WriteLine("Match not found");
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
        //default item limit 5
        GenericList<int> myInt = new GenericList<int>();
        myInt.Add(4);
        myInt.Add(12);
        myInt.Add(9);
        myInt.Add(0);
        myInt.Add(11);
        Console.WriteLine("Count Default " + myInt.Count());
        myInt.Add(15);
        myInt.Add(3);
        Console.WriteLine("Count Resize " + myInt.Count());
        for (int i = 0; i < myInt.Length; i++)
        {
            Console.WriteLine(myInt.Get(i));
        }
    }
}
