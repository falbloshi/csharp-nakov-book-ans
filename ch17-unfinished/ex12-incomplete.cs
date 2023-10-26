using System;
using System.IO;
using System.Collections.Generic;

class ex12
{

    static void Main()
    {
        TreeBuilder("C:\\Windows\\");

        Console.ReadKey();
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

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }

            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }
    }

    /*
    public static Folder CreateFolder(DirectoryInfo dir)
    {
        FileInfo[] files = dir.GetFiles();
        File[] newFiles = new File[files.Length];

        for(int i = 0; i < files.Length; i++)
        {
            newFiles[i].Size = files[i].Length;
            newFiles[i].Name = files[i].Name;
        }

        DirectoryInfo[] childDirectories = dir.GetDirectories();
        Folder[] newFolders = new Folder[childDirectories.Length]; 
        for(int i = 0; i < childDirectories.Length; i++)
        {
            newFolders[i].Name = childDirectories[i].Name;
        }

        var returnFolder = new Folder(dir.Name, newFiles, newFolders);
        return returnFolder;
    }*/

    private static void TreeBuilder(DirectoryInfo dir)
    {       
        Tree<DirectoryInfo> root = new Tree<DirectoryInfo>(dir, dir.GetDirectories());

        foreach(var dirc in dir)
        {
            Tree<DirectoryInfo> root = new Tree<DirectoryInfo>(dir, dir.GetDirectories());
        }
    }

    public static void TreeBuilder(String directoryPath)
    {       
        TreeBuilder(new DirectoryInfo(directoryPath));
    }

        /*
        private static void TraverseDir(DirectoryInfo dir, string spaces)
        {
            try
            {
                FileInfo[] fileList = dir.GetFiles("*.exe");
                foreach (var finfo in fileList)
                {
                    Console.WriteLine($"\\{spaces}>{finfo.Name}");
                }

                DirectoryInfo[] children = dir.GetDirectories();
                foreach (DirectoryInfo child in children)
                {
                    TraverseDir(child, spaces + "-");
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                return;
            }

        }

        static void TraverseDir(string directoryPath)
        {
            TraverseDir(new DirectoryInfo(directoryPath),
            string.Empty);
        }*/


    
}