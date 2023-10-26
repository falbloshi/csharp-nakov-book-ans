using System;
using System.Collections.Generic;


class ex12
{
    static void Main()
    {
        var newDS = new DynamicStack<int>();
        Console.WriteLine("Pushing 5, 11, 9");
        newDS.Push(5);
        newDS.Push(11);
        newDS.Push(9);
        Console.WriteLine(newDS.Count() + " <- Count? == Size? -> " + newDS.Size);
        Console.Write("Find top element ");
        Console.WriteLine(newDS.Top.Element);
        newDS.Pop();
        Console.Write("Popped previous element, next element? ");
        Console.WriteLine(newDS.Top.Element);
        newDS.Pop();
        Console.Write("Popped previous element, next element? ");
        Console.WriteLine(newDS.Top.Element);
        Console.WriteLine("Pushing 12, 10");
        newDS.Push(12);
        newDS.Push(10);
        Console.Write("Peeking: ");
        Console.WriteLine(newDS.Peek());
        Console.WriteLine(newDS.Count() + " <- Count? == Size? -> " + newDS.Size);
        Console.WriteLine("Clearing the nodes");
        newDS.Clear();
        Console.WriteLine(newDS.Count() + " <- Count? == Size? -> " + newDS.Size);



    }

    class DynamicStack<T>
    {
        //same as ex11, only difference, we have prev like linked list
        //and class field top instead of head and tail.

        public class Node
        {
            private T element;
            public Node Prev { get; set; }

            public T Element
            {
                get { return element; }
            }

            public Node(T element, Node prev)
            {
                this.element = element;
                this.Prev = prev;
            }
        }

        private int size;
        private Node top;

        public Node Top
        {
            get { return top; }
        }
        public int Size 
        {
            get {return size;}
        }
        
        public DynamicStack()
        {
            this.size = 0;
            top = null;
        }

        public void Push(T element)
        {
            if (this.size == 0)
            {
                this.top = new Node(element, null);
            }
            else
            {
                //adding a new node with the new element and referncing the previous top
                var pushed = new Node(element, top);
                top = pushed; //changing top to the new node
            }
            this.size++; //increase size eitherway
        }

        public void Pop()
        {
            switch (this.size)
            {
                case 1:
                    //making a default node
                    this.top = new Node(default(T), null);
                    this.size--; //this will handle pushing as it will become 0
                    break;
                case 0:
                    //if 0, means no element, just quits
                    break;
                default:
                    //just making the new top its previous neighbour
                    this.top = this.top.Prev;
                    this.size--;
                    break;
            }
        }

        public T Peek()
        {
            //returns top element
            return this.top.Element;
        }

        public void Clear()
        {
            //dereferencing top and its previous neighbour to null and changing size to 0
            this.top.Prev = null;
            this.top = null;
            this.size = 0;
        }
        
        //count vs size, count is inefficient, but it guarantees for null mistakes
        public int Count()
        {
            int count = 0;
            Node current = this.top;
            while (current != null)
            {
                count++;
                current = current.Prev;
            }
            return count;
        }
    }



}