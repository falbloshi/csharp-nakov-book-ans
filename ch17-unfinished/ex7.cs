using System;
using System.Collections.Generic;



public class ex7
{
    static void Main()
    {
        //+1 for indexingg
        Graph graph = new Graph
        (new List<int>[9] 
            {
                new List<int>() {}, // successors of vertice 0
                new List<int>() {2, 3, 4},
                new List<int>() {1, 3, 5, 6},
                new List<int>() {1, 2, 5, 6},
                new List<int>() {1, 7, 8},
                new List<int>() {2, 6},
                new List<int>() {2, 3, 5},
                new List<int>() {4, 8},
                new List<int>() {4, 7}
            }
        );


        /*
        Console.WriteLine("Stack Search");
        graph.DFS(1);
        Console.WriteLine("Recursion Search");
        graph.DFSR();
        Console.WriteLine("Breadth First ");
        graph.BFS(1);*/
        graph.ShortestPath(1, 8);
        Console.WriteLine("");
        graph.ShortestPath(5, 8);



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

        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }

        public void RemoveEdge(int u, int v)
        {
            childNodes[u].Remove(v);
        }

        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[u].Contains(v);
            return hasEdge;
        }

        public IList<int> GetSucessors(int v)
        {
            return childNodes[v];
        }

        public void DFS(int node)
        {
            Stack<int> nStk = new Stack<int>();
            List<int> mark = new List<int>();
            nStk.Push(node);
            while (nStk.Count > 0)
            {
                int parentNode = nStk.Pop();

                if (!mark.Contains(parentNode))
                {
                    mark.Add(parentNode);
                    Console.WriteLine($"> {parentNode}");
                }

                foreach (int adjNode in childNodes[parentNode])
                {
                    if (!mark.Contains(adjNode))
                    {
                        nStk.Push(adjNode);
                    }
                }
            }
        }

        public void DFSR(int node, bool[] mark)
        {
            mark[node] = true;
            Console.WriteLine($"< {node}");

            foreach (int adjNode in NodeArr[node])
            {
                if (mark[adjNode] != true)
                {
                    DFSR(adjNode, mark);
                }
            }
            return;
        }
        public void DFSR()
        {
            bool[] Mark = new bool[Size];
            this.DFSR(1, Mark);
        }

        public void BFS(int node)
        {
            Queue<int> nQ = new Queue<int>();
            bool[] mark = new bool[Size];
            nQ.Enqueue(node);
            while (nQ.Count > 0)
            {
                int parentNode = nQ.Dequeue();

                if (!mark[parentNode])
                {
                    mark[parentNode] = true;
                    Console.WriteLine($") {parentNode}");
                }

                foreach (int adjNode in childNodes[parentNode])
                {
                    if (!mark[adjNode])
                    {
                        nQ.Enqueue(adjNode);
                    }
                }
            }
        }

        //shortest path using stack
        public void ShortestPath(int x, int y)
        {
            Stack<int> nQ = new Stack<int>();
            List<int> pathList = new List<int>();
            List<int> mark = new List<int>();

            nQ.Push(y);

            while (nQ.Count > 0)
            {
                int parentNode = nQ.Pop();

                mark.Add(parentNode);
                pathList.Add(parentNode);

                if (parentNode == x)
                {
                    break;
                }

                childNodes[parentNode].Reverse();
                foreach (int adjNode in childNodes[parentNode])
                {
                    if (!mark.Contains(adjNode))
                    {
                        mark.Add(adjNode);
                        nQ.Push(adjNode);
                    }
                }
            }
            pathList.Reverse();
            foreach (int m in pathList)
            {
                Console.Write($"{m}->");
            }

        }



    }
}