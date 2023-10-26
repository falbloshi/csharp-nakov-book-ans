using System;
using System.Collections.Generic;

class ex2
{
    static void Main()
    {
        Tree<int> tree =
        new Tree<int>(7,
            new Tree<int>(19,
                new Tree<int>(1),
                new Tree<int>(6),
                new Tree<int>(31)),
            new Tree<int>(21),
            new Tree<int>(14,
                new Tree<int>(23),
                new Tree<int>(6))
        );
        tree.DFSTraversalStack();
        Console.WriteLine("Insert value for the number of nodes of our subtrees");
        tree.SubTreeSearch(int.Parse(Console.ReadLine()));
    }


    public class TreeNode<T>
    {
        private T element;
        public List<TreeNode<T>> children;
        private bool hasParent;

        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        public TreeNode(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }
            this.element = element;
            this.children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            if (child.hasParent)
            {
                throw new ArgumentException("Child already has parent");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

    }


    public class Tree<T>
    {


        private TreeNode<T> root;

        //first time i see : this is used in reverse

        public Tree(T value)
        {
            if (value == null)
            {

                throw new ArgumentNullException("Cannot insert null value");

            }

            this.root = new TreeNode<T>(value);
        }

        //for adding children
        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }



        public void DFSTraversalStack()
        {
            string space = string.Empty;
            if (this.root == null)
            {
                return;
            }
            Stack<TreeNode<T>> rootStack = new Stack<TreeNode<T>>();
            rootStack.Push(this.root);

            bool added = false;

            while (rootStack.Count > 0)
            {
                Console.WriteLine($"{space}{rootStack.Peek().Element}");
                var parent = rootStack.Pop();

                List<TreeNode<T>> childList = parent.children;

                foreach (TreeNode<T> child in childList)
                {
                    rootStack.Push(child);

                    if(!added)
                    {
                        space += "  ";
                        added = true;
                    }                    
                }

                added = false;
            }
        }


        public List<T> DFSTraversalStack(int value)
        {

            var parentList = new List<T>();

            if (this.root == null)
            {
                return null;
            }
            Stack<TreeNode<T>> rootQ = new Stack<TreeNode<T>>();
            rootQ.Push(this.root);

            while (rootQ.Count > 0)
            {
                var parent = rootQ.Pop();
                List<TreeNode<T>> childList = parent.children;

                if (childList.Count == value)
                {
                    parentList.Add(parent.Element);
                }

                foreach (TreeNode<T> child in childList)
                {
                    rootQ.Push(child);
                }
            }
            return parentList;
        }


        public void SubTreeSearch(int value)
        {
            List<T> parentList = DFSTraversalStack(value);

            if (parentList.Count > 0)
            {
                Console.WriteLine($"List of root parents with {value} nodes");
                foreach (T parent in parentList)
                {
                    Console.WriteLine($"{parent} ");
                }

            }
            else
            {
                Console.WriteLine("Empty");
            }
        }

    }

}