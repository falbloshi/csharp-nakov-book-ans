using System;
using System.Collections.Generic;

class ex9
{
    static void Main()
    {
        Console.WriteLine("Please write N to finish ex9ch16 sequence:");
        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(n);
        Console.Write($"N = {n} -> ");
        int index = 0;
        while (index < 50)
        {
            index++;
            int current = queue.Dequeue();
            Console.Write(" " + current);

            queue.Enqueue(current + 1);
            queue.Enqueue(2 * current + 1);
            queue.Enqueue(current + 2);

        }
    }
}