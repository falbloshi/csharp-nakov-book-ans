using System;
using System.IO;


public static class DirectoryTraverserDFS
{

    static void Main()
    {
        TraverseDir("C:\\Users\\Farisky\\Documents");
        Console.ReadKey();
    }
    
    private static void TraverseDir(DirectoryInfo dir,
    string spaces)
    {
        // Visit the current directory
        Console.WriteLine(spaces + dir.FullName);
        DirectoryInfo[] children = dir.GetDirectories();
        // For each child go and visit its sub-tree
        foreach (DirectoryInfo child in children)
        {
            TraverseDir(child, spaces + " ");
        }
    }

    static void TraverseDir(string directoryPath)
    {
        TraverseDir(new DirectoryInfo(directoryPath),
        string.Empty);
    }

}