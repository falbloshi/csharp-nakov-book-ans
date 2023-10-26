using System;
using System.Collections.Generic;


//binary tree
//how many vertices per height
class ex4
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

        mytree.BFSTraversal();

        Dictionary<int, int> myTreeDict = mytree.HeightWithVertix;

        foreach(KeyValuePair<int, int> kvpair in myTreeDict)
        {
            Console.WriteLine($"Height: {kvpair.Key} -> Vertices: {kvpair.Value}");
            
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
            return  (this.LeftChild != null) || (this.RightChild != null);
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


        //node with height
        public class NodeWD
        {
            public int height;
            public TreeNode<T> node;

            public NodeWD(TreeNode<T> node, int height)
            {
                this.height = height;
                this.node = node;
            }
        }

        Dictionary<int, int> heightVertix = new Dictionary<int, int>();

        public Dictionary<int, int> HeightWithVertix    
        {
            get {return heightVertix;}
        }
        

        public void BFSTraversal(TreeNode<T> treeNode)
        {

            Queue<NodeWD> tnQ = new Queue<NodeWD>();
            int height = 0;

            tnQ.Enqueue(new NodeWD(treeNode, height));

            while (tnQ.Count > 0)
            {
                var parentNW = tnQ.Dequeue();
                height = parentNW.height;
                TreeNode<T> parent = parentNW.node;



                //if it is a parent add it to the dictionary
                try
                {
                    if (parent.hasChildren() && height > 0)
                    {
                        heightVertix.Add(height, 1);
                    }
                }
                catch (ArgumentException)
                {
                    if (parent.hasChildren())
                    {
                        heightVertix[height] += 1;
                    }
                }


                //uncomment to display
                //Console.WriteLine($"Height {height} -> {parent.Element}");
                if (parent.LeftChild != null && parent.RightChild != null)
                {

                    tnQ.Enqueue(new NodeWD(parent.LeftChild, height + 1));
                    tnQ.Enqueue(new NodeWD(parent.RightChild, height + 1));
                    height++;

                }
                else if (parent.LeftChild != null)
                {
                    tnQ.Enqueue(new NodeWD(parent.LeftChild, height + 1));
                    height++;
                }
            }
        }

        public void BFSTraversal()
        {
            BFSTraversal(this.root);
        }
    }
}