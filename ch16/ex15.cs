using System;
using System.Collections.Generic;

/*using ex11 and implementing bubble sort*/
public class ex15
{

    static void Main()
    {
        var newND = new DoublyLinkedList<int>();
        Console.WriteLine("Sorting elements added");
        newND.Add(5);
        newND.Add(3);
        newND.Add(8);
        newND.Add(2);
        newND.Add(6);
        newND.Add(7);
        newND.Add(16);
        newND.Add(18);
        newND.Add(26);
        newND.Add(999);
        newND.Add(-6);
        newND.Add(7);
        newND.Add(8);

        Console.WriteLine("Current list");
        newND.Print();

        Console.WriteLine("Sorting... ");
        newND.Sort();

        Console.WriteLine("Sorted list");
        newND.Print();

    }

    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        public class Node
        {
            private T element;
            public Node Next, Prev;

            public T Element
            {
                get { return element; }
                set { element = value; }
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


        public DoublyLinkedList()
        {
            this.size = 0;
            this.head = null;
            this.tail = null;
        }

        public void Add(T element)
        {
            if (this.size == 0)
            {

                this.head = this.tail = new Node(element, null, null);
            }
            else
            {

                tail.Next = new Node(element, tail, null);
                tail = tail.Next;
            }

            this.size++;
        }

        public void Remove(T element)
        {
            int index = IndexOf(element);

            this.size--;

            if (index == 0)
            {

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

            else if (index > 0 && index < size)
            {
                Node current = head;
                current = ReturnCurrent(current, index);
                Node nextNode = current.Next;
                Node prevNode = current.Prev;

                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;

            }

            else if (index == size)
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }
            else
            {

                this.size++;
            }
        }

        private void Swap(Node a, Node b)
        {
            if (this.size == 2)
            {
                //head swapping with tail
                a.Prev = b;
                b.Next = a;

                a.Next = null;
                b.Prev = null;

                tail = a;
                head = b;

                return;
            }
            if (a.Prev == null)
            {
                //swapping with head
                // null <-> a <-> b <-> c
                // null <-> b <-> a <-> c

                var c = b.Next;
                b.Next = a;
                b.Prev = null;

                a.Next = c;
                a.Prev = b;

                c.Prev = a;

                head = b;

                return;
            }
            if (b.Next == null)
            {   
                //swapping with tail
                // c <-> a <-> b <-> null
                // c <-> b <-> a <-> null

                var c = a.Prev;
                c.Next = b;

                b.Prev = c;
                b.Next = a;

                a.Prev = b;
                a.Next = null;

                tail = a;
                

                return;

            }
            else
            {   
                // relinking
                // x <-> a <-> b <-> z
                // x <-> b <-> a <-> z

                var x = a.Prev;
                var z = b.Next;
                x.Next = b;
                z.Prev = a;
                
                a.Next = z;
                a.Prev = b;

                b.Next = a;
                b.Prev = x;
                

                return;
            }
        }

        public void Sort()
        {

            Node current = head; // copying current from head
            bool swapped = true; //true just to pass the first one 


            //outerloop
            while (swapped)
            {
                //make swap false for the entirity of the current while loop
                //if it has no longer a positive swap, the loop breaks, however, if there is a positive loop
                //it will return here again
                swapped = false;

                //replacing current with head if changed, and recheck everything again
                current = head;

                //inner loop
                //continues on until current's neighbour is null i.e it contains no element to check with the current
                while (current.Next != null)
                {
                    //if current element is greater than its neighbour, Compareto returns 1
                    //commit swap
                    if (current.Element.CompareTo(current.Next.Element) > 0)
                    {
                        //if a <-> b swapped to b <-> a, a remains the current for the next loop check
                        //swap is flagged true to continue
                        Swap(current, current.Next);
                        swapped = true;
                    }
                    else
                    {
                        //if a < b, b becomes the new current
                        if (current.Next != null) current = current.Next;
                    }
                }
            }
        }

        public int IndexOf(T element)
        {
            int index = 0;
            Node current = this.head;

            //exit if last node is a null
            while (current != null)
            {
                //if objects of current node's element and the element requested are the same, return index
                if (object.Equals(current.Element, element))
                {
                    return index;
                }
                //add to index +1 and change current to its neighbour
                index++;
                current = current.Next;
            }
            return -1;
        }


        public Node ReturnCurrent(Node current, int index)
        {
            if (current != null && index < size)
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
            else
            {
                Console.WriteLine("You have insert wrong index size or a null current");
                return current;
            }

        }

        public List<T> SetList()
        {
            List<T> newList = new List<T>();
            Node current = head;
            while (current != null)
            {
                newList.Add(current.Element);
                current = current.Next;
            }
            return newList;
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

        public void Print()
        {
            var newls = this.SetList();
            foreach (var m in newls)
            {
                Console.Write(m + " ");
            }
            Console.WriteLine("");
        }
    }
}
