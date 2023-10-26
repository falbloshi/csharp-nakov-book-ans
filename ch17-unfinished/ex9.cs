using System;
using System.Collections.Generic;


//based from ex7
public class ex9
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

        Console.WriteLine("Recursion Search");
        graph.DFSR();
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

        public IList<int> GetSucessors(int v)
        {
            return childNodes[v];
        }

        public void DFSR(int node, bool[] mark, string m)
        {
            mark[node] = true;
            m += " ";
            Console.WriteLine($"< {m}{node}");

            foreach (int adjNode in GetSucessors(node))
            {
                if (mark[adjNode] != true)
                {
                    DFSR(adjNode, mark, m);
                }
            }
            return;
        }
        public void DFSR()
        {
            bool[] Mark = new bool[Size];
            this.DFSR(1, Mark, string.Empty);
        }
    }
}