using System;
using System.Collections.Generic;

public class ex10
{
    static void Main()
    {
        //+1 for indexingg
        Graph graph = new Graph
        (new List<int>[]
            {

                new List<int>() {1},
                new List<int>() {2, 3, 4},
                new List<int>() {5, 6, 7},
                new List<int>() {4, 7},
                new List<int>() {5, 8}
            }
        );

        graph.BFS();
    }

    public class Graph
    {

        private List<int>[] childNodes;

        public List<int>[] NodeArr
        {
            get { return childNodes; }
        }

        public Graph(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Graph Size");
            }

            this.childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                this.childNodes[i] = new List<int>();
            }
        }

        //an array of child nodes
        public Graph(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        public int Size
        {
            get { return this.childNodes.Length; }
        }

        public IList<int> GetSucessors(int v)
        {
            return childNodes[v];
        }

   
        public void BFS(int node)
        {
            Queue<int> nQ = new Queue<int>();

            nQ.Enqueue(node);

            while (nQ.Count > 0)
            {
                int v = nQ.Dequeue();
                         
                Console.Write($") {v}: ");              
   
                foreach (int adjNode in GetSucessors(v))
                {
                       Console.Write(adjNode + " ");
                       if(adjNode < Size && !nQ.Contains(adjNode))
                       {
                           nQ.Enqueue(adjNode);
                       }
                }
                Console.WriteLine("");
            }
        }

        public void BFS()
        {
            this.BFS(0);
        }
    }
}
    