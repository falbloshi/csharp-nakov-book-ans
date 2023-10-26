using System;
using System.Collections.Generic;



public class ex14
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
                new List<int>() {5, 8},
                new List<int>() {1, 2, 3, 4}
            }
        );

        var myListOfNodes = graph.BFS();

        for (int i = 0; i < myListOfNodes.Count; i++)
        {
            Console.Write($"Node #{i}: ");
            foreach (int n in myListOfNodes[i])
            {
                Console.Write($" {n}");
            }
            Console.WriteLine("");
        }



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

        public List<int> GetSucessors(int v)
        {
            return childNodes[v];
        }


        public List<List<int>> BFS(int node)
        {
            Queue<int> nQ = new Queue<int>();
            List<int> mark = new List<int>();
            List<List<int>> listOfNodes = new List<List<int>>();

            nQ.Enqueue(node);

            while (nQ.Count > 0)
            {
                int v = nQ.Dequeue();
            
                if (!mark.Contains(v))
                {
                    mark.Add(v);         
                }
                else
                {
                    continue;
                }
                listOfNodes.Add(GetSucessors(v));
                foreach (int adjNode in GetSucessors(v))
                {   

                    //in order not to add higher numbers in queue where the node not existing
                    if (adjNode < Size && !mark.Contains(adjNode))
                    {
                        nQ.Enqueue(adjNode);
                    }
                }
            }

            return listOfNodes;
        }

        public List<List<int>> BFS()
        {
            var myList = this.BFS(0);
            return myList;
        }
    }
}
