using System;
using System.Collections.Generic;


//circular buffer
public class ex14
{
    static void Main()
    {
        var newCQ = new CQueue<string>(3);
        Console.WriteLine("Length " + newCQ.Length);
        Console.WriteLine("Size: " + newCQ.Size);
        //comments assuming buffer size is 3
        newCQ.Enqueue("G"); // 0 index
        newCQ.Enqueue("H"); // 1 index
        newCQ.Enqueue("I"); // 2 index
        newCQ.Enqueue("J"); // returns to 0, index 1 becomes new head
        newCQ.Enqueue("K"); // 1 index, make 2 index the new head(since 1 is replaced)
        newCQ.Dequeue(); //removes 2 index as it is the new head, makes 0 the head
        Console.WriteLine("Head: " + newCQ.Head);
        Console.WriteLine("Tail: " + newCQ.Tail);
        Console.WriteLine("Size: " + newCQ.Size);
    }

    public class CQueue<T>
    {
        //circular queue
        //takes an array, a default buffersize, head and tail and size of the elements inserted.
        private T[] mainArr;
        private const int defaultBufferSize = 7;
        private int head; //front index
        private int tail; //back index
        private int size = 0;
        

        //getters
        public int Length
        {
            get { return mainArr.Length; }
        }
        public int Size
        {
            get { return size; }
        }
        public T Head
        {
            get { return mainArr[head]; }
        }
        public T Tail
        {
            get { return mainArr[tail]; }
        }


        //constructor without arguments using default buffersize
        public CQueue()
        : this(defaultBufferSize)
        {
        }


        //main constructor
        public CQueue(int arrSize)
        {
            this.mainArr = new T[arrSize];
            this.tail = 0;
            this.head = 0;
        }

        public void Enqueue(T element)
        {   


            if (size == 0)
            {
                this.head = this.tail = 0; //putting them at zeroeth index in the array;
                //both head and tail are the same index since it is only one element
                this.mainArr[head] = this.mainArr[tail] = element;
            }
            else
            {
                //we increase the size of  tail, make a check if it is not exceeding the length of the array
                //make a check if index we are enqueing is not empty
                //if it is not empty, change head to its next element and lower size
                //add the element either cases
                this.tail++;
                this.tail = HeadTailNewVal(this.tail);
                if(!(object.Equals(this.mainArr[tail], default(T))))
                {
                    this.head = HeadTailNewVal(this.head + 1);
                    this.size--;
                }
                this.mainArr[tail] = element;
            }
            //increase size when done 
            this.size++;
        }

        public void Dequeue()
        {
            this.size--;
            if (size == 0)
            {
                this.head = this.tail = 0; //putting them at zeroeth index in the array;
                this.mainArr[this.head] = this.mainArr[this.tail] = default(T);
            }
            else
            {
                //storing old head value, and increasing head's index value by 1
                //make a check if it is not exceeding array size
                //and then make the previous index element the default value
                int headPrev= this.head;
                this.head++;
                this.head = HeadTailNewVal(this.head);
                this.mainArr[headPrev] = default(T);                
            }
        }

        //checks if they don't exceed the array size
        //return to 0 if they do
        public int HeadTailNewVal(int headTailVal)
        {
            if (headTailVal >= this.mainArr.Length)
            {
                headTailVal = 0;
            }
            return headTailVal;
        }
    }
}




