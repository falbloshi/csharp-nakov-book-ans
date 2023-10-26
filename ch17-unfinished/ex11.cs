using System;
using System.IO;

class ex12
{

    static void Main()
    {
        TraverseDir("C:\\Windows\\");

        Console.ReadKey();
    }


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
    }


}