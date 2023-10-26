using System;
using System.Collections.Generic;

//i dont understand this question, moving next 8:24 AM 02-Jul-20
class ex10
{
    static void Main()
    {
        Console.WriteLine("Please write N and M to find shortest subsequence:");

        Console.Write("N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("M: ");
        int m = int.Parse(Console.ReadLine());

        Queue<int> queue = new Queue<int>();

        int current = n;

        queue.Enqueue(current);

        Console.Write($"N = {n} -> ");

        int n1 = 0;
        int n2 = 0;
        int n3 = 0;

        while (true)
        {
            if (queue.Contains(m))
            {
                break;
            }

            current = queue.Dequeue();

            int s1 = current + 1;
            int s2 = s1 + 2;
            int s3 = s2 * 2;


            if ((s1 <= m) && !queue.Contains(s1)) { n1 = s1; queue.Enqueue(s1); }
            if ((s2 <= m) && !queue.Contains(s2)) { n2 = s2; queue.Enqueue(s2); }
            if ((s3 <= m) && !queue.Contains(s3)) { n3 = s3; queue.Enqueue(s3); }

            Console.Write($"{n1} -> {n2} -> {n3}");

            /*
            if(s1 <= m) queue.Enqueue(s1);
            if(s2 <= m) queue.Enqueue(s2);
            if(s3 <= m) queue.Enqueue(s3);*/
        }
    }
}
