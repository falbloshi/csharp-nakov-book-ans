using System;
using System.Collections.Generic;


//based on 8
public class ex13
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

        Console.WriteLine("Stack Search");
         Dictionary<int, int> llist = graph.DFS(1);

        if (llist.Count > 0)
        {
            foreach (var KVPair in llist)
            {
                Console.WriteLine($"{KVPair.Key} Loops {KVPair.Value} times");
            }
        }
        else
        {
            Console.WriteLine("Has no loops");
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

        public IList<int> GetSucessors(int v)
        {
            return childNodes[v];
        }

        public Dictionary<int, int> DFS(int node)
        {
            Stack<int> nStk = new Stack<int>();
            List<int> mark = new List<int>();
            Dictionary<int, int> LoopList = new Dictionary<int, int>();

            nStk.Push(node);
            while (nStk.Count > 0)
            {
                int parentNode = nStk.Pop();

                if (!mark.Contains(parentNode))
                {
                    mark.Add(parentNode);
                    Console.WriteLine($"> {parentNode}");                   
                }
                else
                {
                    continue;
                }
                //reversing so it doesnt go right first.    
                childNodes[parentNode].Reverse();

                foreach (int adjNode in GetSucessors(parentNode))
                {
                    
                    try
                    {                           
                        LoopList.Add(adjNode, 0);
                    }
                    catch (ArgumentException)
                    {
                        
                        LoopList[adjNode] += 1;
                    }

                    if (!mark.Contains(adjNode))
                    {
                        nStk.Push(adjNode);
                    }
                }
            }

            return LoopList;
        }

    }
}