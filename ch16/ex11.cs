using System;
using System.Collections.Generic;

public class ex11
{
    static void Main()
    {
        var newND = new DoublyLinkedList<int>();
        Console.WriteLine("5, 3, 8, 6, 11, 7\n");
        newND.Add(5);
        newND.Add(3);
        newND.Add(8);
        newND.Add(6);
        newND.Add(11);
        newND.Add(7);
        Console.WriteLine(newND.CountNodes());
        Console.WriteLine($"Head: {newND.Head.Element}\tTail: {newND.Tail.Element}");
        Console.WriteLine($"Head Next: {newND.Head.Next.Element}");
        Console.WriteLine("Count size " + newND.CountNodes());
        Console.WriteLine("Index of \"8\": " + newND.IndexOf(8));
        newND.Remove(6);
        Console.WriteLine($"Removing 6. Next of 8: {newND.PeekNext(8)}");
        Console.WriteLine("Count size " + newND.CountNodes());
        Console.WriteLine($"Tail  {newND.Tail.Element}");
        newND.Remove(7);
        Console.WriteLine($"Removing tail. New tail?: {newND.Tail.Element}");
        newND.Remove(5);
        Console.WriteLine($"Removing head. New head?: {newND.Head.Element}");
        Console.WriteLine("New count size " + newND.CountNodes());
        Console.WriteLine("Index of tail? " + newND.Tail.Element + " Its index? " + newND.IndexOf(11));
        Console.WriteLine("Adding 6 at tail");
        newND.Add(6);
        Console.WriteLine("New count size " + newND.CountNodes());
        Console.WriteLine("Adding 5 at index 2");
        newND.InsertAt(5, 2);
        Console.WriteLine("Peek 8: " + newND.PeekNext(8));
        Console.WriteLine("New count size " + newND.CountNodes());
        newND.InsertAt(4, 0);
        newND.InsertAt(2, newND.Size);
        Console.WriteLine($"Inserting 4 at index 0 aka head peek head \"{newND.PeekNext(newND.Head.Element)}\", and 2 at last index aka tail");
        Console.WriteLine($"Head: {newND.Head.Element}\tTail's Prev: {newND.Tail.Prev.Element}");
        Console.WriteLine("New count size " + newND.CountNodes());
        Console.WriteLine("Index of 11: " + newND.IndexOf(11) + " Removing 11");
        newND.RemoveAt(newND.IndexOf(11));
        
        var newls = newND.SetList();
        
        Console.WriteLine("Final list");
        foreach(var m in newls)
        {
            Console.Write(m + " ");
        }
        Console.WriteLine("\nFinal count size " + newND.CountNodes());


    }

    public class DoublyLinkedList<T>
    {     
        
        //DNode class container, contains a data aka element field, a next node reference field and a previous node reference field
        public class DNode
        {
            private T element;
            public DNode Next, Prev;

            public T Element
            {
                get { return element; }
                set { element = value; }
            }


            public DNode(T element, DNode prev, DNode next)
            {
                this.element = element;
                this.Next = next;
                this.Prev = prev;
            }

        }

        private int size { get; set; }
        private DNode head;
        private DNode tail;

        public int Size
        {
            get { return size; }
        }

        public DNode Head
        {
            get { return head; }
        }

        public DNode Tail
        {
            get { return tail; }
        }

        //a linked lists with size, a dnode head(first element) and dnode tail(last element).
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
                //if size 0 aka empty node lists, both head and taill will be the same elements
                this.head = this.tail = new DNode(element, null, null);
            }
            else
            {
                //add the neighbour of tail with a new element, and change the tail as the new element
                tail.Next = new DNode(element, tail, null);
                tail = tail.Next; //referencing itself
            }
            //increase size of the nodes
            this.size++;
        }

        public void Remove(T element)
        {
            //find the index of the element
            int index = IndexOf(element);
            //decrease size
            this.size--;
            //if index is 0, change head, if index is equal size of nodes, change tail, otherwise change the element requested in between head and taail.
            if (index == 0)
            {
                //if head is not null, change head to its neighbour and make its prev into null, else the head becomes null and create an empty head list
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
            //if index between 0 and size, deference the node requested,
            else if (index > 0 && index < size)
            {
                DNode current = head;
                current = ReturnCurrent(current, index);
                DNode nextNode = current.Next;
                DNode prevNode = current.Prev;

                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;

            }
            //same as head, but change the nighbour of tail to null and reference the tail to its neighbour
            else if (index == size)
            {
                this.tail = this.tail.Prev;
                this.tail.Next = null;
            }
            else
            {
                //if element not found aka -1 index, resize to old value
                this.size++;
            }
        }

        public void InsertAt(T insertElement, int index)
        {
            this.size++;
            var insertedNode = new DNode(insertElement, null, null);
            DNode frontNode;
            DNode backNode;
            if (index < size)
            {
                if (index == 0)
                {   //working no changes needed
                    //creating links for the new node
                    insertedNode.Next = head;
                    insertedNode.Prev = null;

                    //relinking
                    head = insertedNode;
                }
                else if (index == this.size - 1)
                {
                    //creating front and back nodes
                    frontNode = tail;
                    backNode = tail.Prev;
                    
                    //creating links for the new node
                    insertedNode.Next = frontNode;
                    insertedNode.Prev = backNode;
                    
                    //relinking
                    backNode.Next = insertedNode;
                    frontNode.Prev = insertedNode;
                }
                else
                {
                    //inbetween tail and head
                    backNode = head;
                    frontNode = head;
                    backNode = ReturnCurrent(backNode, index - 1);
                    frontNode = ReturnCurrent(frontNode, index);

                    //creating links for the new node
                    insertedNode.Prev = backNode;
                    insertedNode.Next = frontNode;

                    //relinking 
                    backNode.Next = insertedNode;
                    frontNode.Prev = insertedNode;
                }
            }
            else
            {
                Console.WriteLine("Inserted wrong index");
                this.size--;
            }
        }

        public void RemoveAt(int index)
        {
            this.size--;
            if (index <= size)
            {
                if (index == 0)
                {
                    //removing head, by giving a new head the old head next's and deferencing old head with null
                    DNode newHead = this.head.Next;
                    newHead.Prev = null;
                    this.head = newHead;
                }
                else if (index == this.size)
                {
                    //same process as above, but reversing head endings with tail endings
                    DNode newTail = this.tail.Prev;
                    newTail.Next = null;
                    this.tail = newTail;
                }
                else
                {   
                   DNode currentNode = head;
                   currentNode = ReturnCurrent(currentNode, index);
				   //referencing current's next prev's and current's prev next's to each other rather than current
                   currentNode.Next.Prev = currentNode.Prev;
                   currentNode.Prev.Next = currentNode.Next;
                }
            }
            else
            {
                Console.WriteLine("Inserted wrong index");
                this.size++;
            }

        }


        //returning the index location of first of the element requested found in the linked lists nodes
        public int IndexOf(T element)
        {
            int index = 0;
            DNode current = this.head;

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


        //peeks the element next to the element requested
        public T PeekNext(T element)
        {
            DNode current = this.head;
            while (current.Element != null)
            {
                if (object.Equals(current.Element, element))
                {
                    if (current.Next != null)
                    {
                        return current.Next.Element;
                    }
                }
                current = current.Next;
            }
            return default(T);
        }

        public DNode ReturnCurrent(DNode current, int index)
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
            DNode current = head;
            while(current !=null)
            {
                newList.Add(current.Element);
                current = current.Next;
            
            }
            return newList;
        }
        //count the amount of nodes available, should be the same as size, but this one counts each element rather than calculating size.
        public int CountNodes()
        {
            int count = 0;
            DNode current = this.head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}




