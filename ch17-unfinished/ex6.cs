using System;
using System.Collections.Generic;


//binary tree
// check perfectly balanced tree
class ex5
{
    static void Main()
    {
        var mytree1 =
        new Tree<int>(1,
            new Tree<int>(2,
                new Tree<int>(4),
                new Tree<int>(5)),
            new Tree<int>(3,
                new Tree<int>(6),
                new Tree<int>(7)));

        var mytree2 =
        new Tree<int>(1,
            new Tree<int>(2,
                new Tree<int>(4),
                new Tree<int>(5)),
            new Tree<int>(3,
                new Tree<int>(6,
                    new Tree<int>(8),
                    new Tree<int>(9)),
                new Tree<int>(7)));


        mytree1.DFSTR();
        Console.WriteLine("\\\\");
        mytree2.DFSTR();
        Console.WriteLine("\\\\");
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

        // DFSTR depth first search traversal recursive
        private int DFSTR(TreeNode<T> root, int number)
        {

            if (root == null)
            {
                return -1;
            }

            int left = DFSTR(root.LeftChild, number + 1);
            int right = DFSTR(root.RightChild, number + 1);

            //Console.WriteLine($"->{root.Element} Height: {Math.Abs(Math.Max(left, right) + 1)}");

            if (number == 0)
            {
                if (left == right)
                {
                    return 1;
                }
            }
            return Math.Abs(Math.Max(left, right) + 1);

        }
        public void DFSTR()
        {
            int final = DFSTR(this.root, 0);
            Console.WriteLine($"Final - {final}");
            if (final <= 1)
            {
                Console.WriteLine("Balanced Tree");
            }
            else
            {
                Console.WriteLine("Unbalanced Tree");
            }

        }
    }
}