using System;
using System.Collections.Generic;

class ex3
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
                new Tree<int>(6,
                    new Tree<int>(2)))
        );
        tree.DFSTraversalRecursive();
        Console.WriteLine($"Leaves count {tree.leafCount}");
        Console.WriteLine($"Vertices count {tree.vertixCount}");

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

        public bool ParentExist
        {
            get {return hasParent;}
            set {hasParent = value;}
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

        //first time i see ": this" is used in reverse
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

        private void DFSTraversalRecursive(TreeNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            foreach (TreeNode<T> child in treeNode.children)
            {
                DFSTraversalRecursive(child);
            }
        }

        public int leafCount = 0;
        public int vertixCount = 0;

        private void DFSTraversalRecursive(TreeNode<T> treeNode, string space)
        {

            bool isLeaf = treeNode.children.Count == 0;
            bool isVertix = treeNode.children.Count > 0 && treeNode.ParentExist;
            
            if (treeNode == null)
            {
                return;
            }

            //leaf - has parent but has no children
            if(isLeaf)
            {
                Console.WriteLine(space + $"Leaf->{treeNode.Element}");
                this.leafCount++;
            }
            else if(isVertix) //vertix - has parent and has children
            {   
                Console.WriteLine(space + $"Vrtx->{treeNode.Element}");
                this.vertixCount++;
            }
            else
            {
                Console.WriteLine(space + $"Root->{treeNode.Element}");
            }
            foreach (TreeNode<T> child in treeNode.children)
            {
                //recursive call
                DFSTraversalRecursive(child, space + " ");
            }
        }

    


        public void DFSTraversalRecursive()
        {
            DFSTraversalRecursive(this.root, string.Empty);
        }

    }

}