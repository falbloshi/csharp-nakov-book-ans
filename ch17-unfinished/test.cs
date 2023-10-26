using System;
using System.Collections.Generic;



public class ex15
{
    static void Main()
    {
        /*
        var graph = new Graph(9);
        graph.AddEdge(0, 1, 4);
        graph.AddEdge(0, 7, 8);
        graph.AddEdge(1, 2, 8);
        graph.AddEdge(1, 7, 11);
        graph.AddEdge(2, 3, 7);
        graph.AddEdge(2, 8, 2);
        graph.AddEdge(2, 5, 4);
        graph.AddEdge(3, 4, 9);
        graph.AddEdge(3, 5, 14);
        graph.AddEdge(4, 5, 10);
        graph.AddEdge(5, 6, 2);
        graph.AddEdge(6, 7, 1);
        graph.AddEdge(6, 8, 6);
        graph.AddEdge(7, 8, 7);
        */


        //undirected
        var graph = new Graph(6);
        graph.UAddEdge(0, 1, 1);
        graph.UAddEdge(0, 2, 4);
        graph.UAddEdge(1, 4, 7);
        graph.UAddEdge(1, 2, 4);

        graph.BFS();
        graph.DSPF(0);

    }





    public class Graph
    {

        private List<int>[] childNodes;
        //first vertix, second vertix, weight
        private Dictionary<int, int>[] weightList;

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
            this.weightList = new Dictionary<int, int>[size];

            for (int i = 0; i < size; i++)
            {
                this.childNodes[i] = new List<int>();
                this.weightList[i] = new Dictionary<int, int>();
            }

        }

        //directed
        public void AddEdge(int u, int v, int w)
        {
            childNodes[u].Add(v);
            weightList[u].Add(v, w);
        }

        //undirected
        public void UAddEdge(int u, int v, int w)
        {
            childNodes[u].Add(v);
            weightList[u].Add(v, w);
            weightList[v].Add(u, w);
    
            if (!childNodes[v].Contains(u))
            {
                childNodes[v].Add(u);
            }
        }


        //u - list // v - adjacency
        public int Distance(int u, int v)
        {
            return weightList[u][v];
        }


        public int Size
        {
            get { return this.childNodes.Length; }
        }

        public List<int> GetSucessors(int v)
        {
            return childNodes[v];
        }


        //dijkstra shortest path first algo 
        public void DSPF(int parentNode)
        {
            var visited = new List<bool>(Size);
            var value = new List<int>(Size);
            var predecessor = new List<int>(Size);

            for(int i = 0; i < Size; i++)
            {
                value[i] = int.MaxValue;
                visited[i] = false;
            }
            value[parentNode] =  0;

            int parent = parentNode; 

            while(visited.Contains(false))
            {
                visited[parent] = true;
                var childrens = GetSucessors(parent);

                int finalVal = int.MaxValue;
                int newParent = 0;
                foreach(int child in childrens)
                {

                    if(value[parent] + Distance(parent, child) < value[child] && !visited[child])
                    {
                        value[child] = value[parent] + Distance(parent, child);
                        predecessor[child] = parent;

                        if(finalVal > value[child])
                        {
                            finalVal = value[child];
                            newParent = child;
                        }
                    }
                }

                parent = newParent;
                           
            }
            
            Console.Write("Predecessors: ");
            foreach(int m in predecessor)
            {
                Console.Write(m+ " ");
            }
            Console.Write("Value: ");
            foreach(int m in value)
            {
                Console.Write(m+ " ");
            }
            Console.Write("Visited: ");
            int t = 0;
            foreach(bool m in visited)
            {
                Console.Write($"{++t} {m}");
            }
            

        }

        public List<int> BFS(int node)
        {
            Queue<int> nQ = new Queue<int>();
            List<int> returnList = new List<int>();
            bool[] mark = new bool[Size];
            nQ.Enqueue(node);
            while (nQ.Count > 0)
            {
                var parentNode = nQ.Dequeue();

                if (!mark[parentNode])
                {
                    mark[parentNode] = true;
                    returnList.Add(parentNode);
                }

                foreach (var adjNode in childNodes[parentNode])
                {
                    if (!mark[adjNode])
                    {
                        nQ.Enqueue(adjNode);
                    }
                }
            }
            returnList.Sort();
            return returnList;
        }

        public void BFS()
        {
            var list = this.BFS(0);
            foreach (int m in list)
            {
                Console.Write($"{m})");
                foreach (int n in childNodes[m])
                {
                    Console.Write($" {n}");
                }
                Console.WriteLine("");
            }
        }

    }
}