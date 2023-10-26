
using System;
using System.IO;
using System.Collections.Generic;

class ex12
{

    static void Main()
    {
        //TreeBuilder("C:\\Windows\\");

        TreeBuilder(@"C:\Users\Farisky\Documents\A Desktop Stuff");

        //Console.ReadKey();
    }

    public class File
    {
        private string name;
        private int size;

        public string Name 
        {
            get {return name;}
            set {name = value;}
        }

        public int  Size 
        {
            get {return size;}
            set {size = value;}
        }
        

        public File(string name, int size)
        {
            this.name = name; 
            this.size  = size;
        }
    }

    public class Folder
    {
        private string name; 
        private File[] files;
        private Folder[] childFolders;

        public string  Name 
        {
            get {return name;}
        }

        public Folder(string name)
        {
            this.name = name;
        }

        public Folder(string name, File[] files)
            : this(name) 
        {
            this.files = files;
        }  

        public Folder(string name, File[] files, Folder[] childFolders)
            : this(name, files)
        {
            this.childFolders = childFolders;
        }
         
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
        private Tree<T>[] children;

        public T RootElement 
        {
            get {return root.Element;}
        }

        public Tree<T>[] Children 
        {
            get {return children;}
        }
            
        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, Tree<T>[] children)
            : this(value)
        {

            this.children = children;

            foreach (Tree<T> child in this.children)
            {
                this.root.AddChild(child.root);
            }
        }
    }



    //works
    private static Tree<DirectoryInfo> Create_SubTree(DirectoryInfo dir)
    {
        var children = dir.GetDirectories();
        var directoryChildren = new Tree<DirectoryInfo>[children.Length];
        for(int i = 0; i < children.Length; i++)
        {
            directoryChildren[i] = new Tree<DirectoryInfo>(children[i]);
        }

        return new Tree<DirectoryInfo>(dir, directoryChildren);

    }

    private static void TreeBuilder(DirectoryInfo dir)
    {   

        Tree<DirectoryInfo> rootTree = Create_SubTree(dir);
        
        Stack<DirectoryInfo> nStack = new Stack<DirectoryInfo>();

        nStack.Push(dir);

        while(nStack.Count > 0)
        {
            var newDir = nStack.Pop();

            Create_SubTree(newDir);

            Console.WriteLine();
            
            foreach(var child in newDir.GetDirectories())
            {

                nStack.Push(child); 
            }
        }
  
    }

    public static void TreeBuilder(String directoryPath)
    {       
        TreeBuilder(new DirectoryInfo(directoryPath));
    }


    /*
    private static void DFSTrav(Tree<DirectoryInfo> mainTree)
    {
        if(mainTree == null)
        {
            return;
        }
        Console.WriteLine("Parent: " + mainTree.RootElement);

        foreach(var child in mainTree.Children)
        {
            Console.WriteLine(child.RootElement);
            DFSTrav(child);
        }

        return;
    }*/
    
}


/*
public class Whatever
{
  
  static void Main()
  {
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    while(true)
    {
        string s = Console.ReadLine();
        if(String.IsNullOrEmpty(s))
        {
          stopWatch.Stop();
          break;
        }

    }
    TimeSpan ts = stopWatch.Elapsed;
    Console.Write("\r{0:hh\\:mm\\:ss}", ts);
    
  }
}*/