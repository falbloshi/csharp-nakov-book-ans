using System;
using System.IO;
using System.Collections.Generic;


//same as 16 but using stack for a depth first traversal, to make it work, first pop at the top before searching
//It is naturally postfix, i.e, it will travel to the right most fo

class ex17
{
    //it takes command line argument for root file
    static void Main(string[] args)
    {
        try
        {
            //creating root stack
            Stack<string> rootQueue = new Stack<string>();

            //geting the root directory
            DirectoryInfo rootDir = new DirectoryInfo(args[0]);

            //pushing the first root from argument
            rootQueue.Push(rootDir.FullName);

            int folderCounts = 0;

            while (rootQueue.Count > 0)
            {
                //pop the root
                rootQueue.Pop();

                //display the parent's folder name and child's folder name
                Console.WriteLine(rootDir.Parent.Name + "->" + rootDir.Name);
                
                //save all the directories found in children tree and put them in an array
                DirectoryInfo[] rootDirArr = rootDir.GetDirectories();

                //for every found directory, add them in stack
                foreach (DirectoryInfo dri in rootDirArr)
                {
                    rootQueue.Push(dri.FullName);
                }
                //peeks the top of the rootqueue and make it the new root directory
                if (rootQueue.Count > 0) rootDir = new DirectoryInfo(rootQueue.Peek());
                folderCounts++;
            }

            Console.WriteLine("Total folders found: {0}", folderCounts);
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Path to \"{0}\" does not exists, please try again.\nTry putting the path in double quotes or hit tab to auto search filename", args[0]);
        }
        catch (System.ArgumentException)
        {
            Console.WriteLine("Path to {0} has invalid characters, please try again.\nTry putting the path in double quotes or hit tab to auto search filename and remove the slash before \" symbol", args[0]);
        }
    }
}