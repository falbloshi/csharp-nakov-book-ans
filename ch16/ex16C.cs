using System;
using System.IO;
using System.Collections.Generic;

//breadth first traversal
class ex16
{
    
    //it takes command line argument for root file
    static void Main(string[] args)
    {
        try
        {
            Queue<string> rootQueue = new Queue<string>();

            DirectoryInfo rootDir = new DirectoryInfo(args[0]);

            //enquing the first root
            rootQueue.Enqueue(rootDir.FullName);
            int folderCounts = 0;


            //if counts are not zero, continue the loop
            while (rootQueue.Count > 0)
            {   
                //display the parent's folder name and child's folder name
                Console.WriteLine(rootDir.Parent.Name + "->" + rootDir.Name);

                //save all the directories found in children tree and put them in an array
                DirectoryInfo[] rootDirArr = rootDir.GetDirectories();


                //for every found directory, add them in queue
                foreach (DirectoryInfo dri in rootDirArr)
                {
                    rootQueue.Enqueue(dri.FullName);
                }
                //dequeue the first one 
                rootQueue.Dequeue();

                //make the rootdir the next on in queue
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