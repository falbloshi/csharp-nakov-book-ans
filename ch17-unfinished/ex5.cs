using System;
using System.Collections.Generic;


//binary tree
// how many vertices with leaves
class ex5
{
    static void Main()
    {
        var mytree =
        new Tree<int>(1,
            new Tree<int>(2,
                new Tree<int>(4,
                    new Tree<int>(6),
                    new Tree<int>(7)),
                new Tree<int>(5)),
            new Tree<int>(3,
                new Tree<int>(8),
                new Tree<int>(9)));

        mytree.DFSTraversalStack();
        var mytreeList =  mytree.vertixList;
        foreach(var m in mytreeList)
        {
            Console.WriteLine($"Vertices with Leaves: {m.Element}");
        }

    }

    public class TreeNode<T>
    {
        private T element;
        public TreeNode<T> LeftChild;
        public TreeNode<T> RightChild;
        private bool hasParent;

        public T Element
        {
            get { return element; }
            set { element = value; }
        }

        public bool ParentExist
        {
            get { return hasParent; }
            set { hasParent = value; }
        }

        public TreeNode(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }
            this.element = element;
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

            if (this.LeftChild != null)
            {
                this.RightChild = child;
                this.RightChild.hasParent = true;
            }
            else
            {
                this.LeftChild = child;
                this.LeftChild.hasParent = true;
            }

        }

        public bool hasChildren()
        {
            return (this.LeftChild != null) || (this.RightChild != null);
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
        public Tree(T value, Tree<T> LeftTree)
            : this(value)
        {
            this.root.AddChild(LeftTree.root);
        }
        public Tree(T value, Tree<T> LeftTree, Tree<T> RightTree)
            : this(value, LeftTree)
        {
            this.root.AddChild(RightTree.root);
        }

        public int leafCount = 0;
        public int vertixCount = 0;

        public List<TreeNode<T>> vertixList = new List<TreeNode<T>>();


        internal void DFSTraversalStack()
        {

            if (this.root == null)
            {
                return;
            }
       

            Stack<TreeNode<T>> rootStk = new Stack<TreeNode<T>>();
            rootStk.Push(this.root);

            while (rootStk.Count > 0)
            {

                Console.WriteLine($"{rootStk.Peek().Element}");
                var treeNode = rootStk.Pop();


                if (treeNode.hasChildren())
                {
                    //if both children  are leaves add to list
                    if (!treeNode.LeftChild.hasChildren() && !treeNode.RightChild.hasChildren())
                    {
                        vertixList.Add(treeNode);
                    }
                    rootStk.Push(treeNode.LeftChild);
                    
                    if (treeNode.RightChild != null)
                    {
                        rootStk.Push(treeNode.RightChild);
                    }
                }
            }

        }

        /*
        public void DFSTraversalRecursive()
        {
            DFSTraversalRecursive(this.root, string.Empty);
        }*/
    }
}