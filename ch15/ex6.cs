using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;

//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file
public class ex6
{
    public static SortedList<String, int> SortingList(StreamReader fileStr)
    {

        TextInfo ti = CultureInfo.CurrentCulture.TextInfo; // from chapter 13 ex25
        SortedList<String, int> nameList = new SortedList<string, int>();
        var flSB = new StringBuilder();

        //much better than the method used in the book
        while (!fileStr.EndOfStream)
        {
            flSB.Append(fileStr.ReadLine());
            if (!String.IsNullOrEmpty(flSB.ToString()))
            {
                try
                {
                    nameList.Add(ti.ToTitleCase(flSB.ToString().TrimEnd(' ')), 1);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Duplicate Detected");
                    nameList.Add(null, 1);
                }
            }
            flSB.Clear();
        }
        return nameList;

    }

    //creating the result with date stamp and filename location
    public static void ResultCreation(StreamReader fileStreamIN, StreamWriter fileStreamOUT, FileInfo inf, FileInfo outf)
    {
        SortedList<String, int> nameList = SortingList(fileStreamIN);

        try
        {
            if (!String.IsNullOrEmpty(nameList.Keys[0]))
            {
                DateTime newDT = DateTime.Now;

                fileStreamOUT.Write($"\nName List created at {newDT:dd_MM_yyyy_HH:mm:ss} from {inf}\n\n");

                foreach(var kvPair in nameList)
                {
                    if (!String.IsNullOrEmpty(kvPair.Key))
                    {
                        fileStreamOUT.WriteLine(kvPair.Key);
                    }
                }

                Console.WriteLine($"File written sucessfuly at {outf}");
            }
        }
        catch(SystemException)
        {
            Console.WriteLine($"File creation failed! Empty entry at {outf}");
        }
    }


    static void Main(string[] args)
    {
        var inputFile = new StreamReader(args[0]);
        var filIn = new FileInfo(args[0]);
        try
        {
            if (!String.IsNullOrEmpty(args[1]))
            {
                StreamWriter outputFile = new StreamWriter(args[1]);
                FileInfo filOut = new FileInfo(args[1]);

                using (inputFile)
                using (outputFile)
                {
                    ResultCreation(inputFile, outputFile, filIn, filOut);
                }
            }
        }//incase there is no argument, we make a default version
        catch (System.Exception)
        {
            var outputFile = new StreamWriter("defSortedNameList.txt");
            var filOut = new FileInfo("defSortedNameList.txt");

            using (inputFile)
            using (outputFile)
            {
                ResultCreation(inputFile, outputFile, filIn, filOut);
            }
        }

    }
}