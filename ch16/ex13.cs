using System;
using System.Collections.Generic;

//constructing a Deque, using ex11 as basis
public class ex13
{
    static void Main()
    {
        var dnew = new Deque<int>();
        Console.Write("Adding first 2 -> ");
        dnew.AddFirst(2);
        Console.WriteLine(dnew.Head.Element);
        Console.Write("Adding first 5 -> ");
        dnew.AddFirst(5);
        Console.WriteLine(dnew.Head.Element);
       
        Console.Write("Updated last -> ");
        
        Console.WriteLine(dnew.Tail.Element); ///error was i added this.size++ before if statements for adding and initializing
        Console.Write("Adding last 1 -> ");
        dnew.AddLast(1);
        Console.WriteLine(dnew.Tail.Element);
        Console.Write("Removing last -> " + dnew.Tail.Element);
        dnew.RemoveLast();
        Console.Write("\nUpdated last -> ");
        Console.WriteLine(dnew.Tail.Element);
        Console.Write("Removing first and then adding 7 -> ");
        dnew.RemoveFirst();
        dnew.AddFirst(7);
        Console.WriteLine(dnew.Head.Element);
        
        int g = dnew.CountNodes();
        
        Console.WriteLine("Current Nodes: " + g);
        
        Console.WriteLine("Peeking first: " + dnew.PeekFirst());
        Console.WriteLine("Peeking last: " + dnew.PeekLast());
    }

    public class Deque<T>
    {
        public class Node
        {
            private T element;
            public Node Next, Prev;

            public T Element
            {
                get { return element; }
            }
            public Node(T element, Node prev, Node next)
            {
                this.element = element;
                this.Next = next;
                this.Prev = prev;
            }
        }

        private int size { get; set; }
        private Node head;
        private Node tail;

        public int Size
        {
            get { return size; }
        }

        public Node Head
        {
            get { return head; }
        }

        public Node Tail
        {
            get { return tail; }
        }

        public Deque()
        {
            this.size = 0;
            this.head = null;
            this.tail = null;
        }

        private void InitNodes(T element)
        {
            this.head = this.tail = new Node(element, null, null);
        }

        public void AddFirst(T element)
        {
            
            if (this.size == 0)
            {
                this.InitNodes(element);
            }
            else
            {
                var newNode = new Node(element, null, head);
                this.head = newNode;
            }
            this.size++;

        }

        public void AddLast(T element)
        {
            
            if (this.size == 0)
            {
                this.InitNodes(element);
            }
            else
            {
                var newNode = new Node(element, tail, null);
                this.tail = newNode;
            }
            this.size++;

        }

        public void RemoveFirst()
        {
            this.size--;
            if (head.Next != null)
            {
                this.head = this.head.Next;
                this.head.Prev = null;
            }
            else
            {
                this.head = null;
            }
        }

        public void RemoveLast()
        {
            this.size--;
            if (tail.Prev != null)
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }
            else
            {
                this.tail = null;
            }
        }

        
        private T Peeking(Node node)
        {
            if (node != null)
            {
                return node.Element;
            }
            return default(T);
        }
        public T PeekLast()
        {
            return this.Peeking(tail);
        }

        public T PeekFirst()
        {
            return this.Peeking(head);
        }
        public int CountNodes()
        {
            int count = 0;
            Node current = this.head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}




