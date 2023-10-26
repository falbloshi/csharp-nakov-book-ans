using System;
using System.Collections.Generic;

class ex1
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
        tree.BFSTraversal();
        Console.WriteLine("Insert value to check number of occurances in our tree");
        tree.SearchOccurances(int.Parse(Console.ReadLine()));
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


        public void BFSTraversal()
        {

            if (this.root == null)
            {
                return;
            }
            Queue<TreeNode<T>> rootQ = new Queue<TreeNode<T>>();
            rootQ.Enqueue(this.root);

            while (rootQ.Count > 0)
            {
                var parent = rootQ.Dequeue();
                List<TreeNode<T>> childList = parent.children;

                foreach (TreeNode<T> child in childList)
                {
                    rootQ.Enqueue(child);
                }
            }
        }

        private int BFSTraversal(T value)
        {
            int valueCount = 0;

            if (this.root == null)
            {
                return 0;
            }
            Queue<TreeNode<T>> rootQ = new Queue<TreeNode<T>>();
            rootQ.Enqueue(this.root);

            while (rootQ.Count > 0)
            {
                var parent = rootQ.Dequeue();
                List<TreeNode<T>> childList = parent.children;

                if(object.Equals(value, parent.Element))
                {
                    valueCount++;
                }
                foreach (TreeNode<T> child in childList)
                {
                    rootQ.Enqueue(child);
                }
            }

            return valueCount;
        }

        public void SearchOccurances(T value)
        {
            int count = BFSTraversal(value);

            if(count > 0) Console.WriteLine($"Number of occurances for {value}: {count}");
            else
            {
                Console.WriteLine("0 occurances");
            }
        }

    }

}