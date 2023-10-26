using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;


//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file

public class ex12
{
    public static List<String> CreateWordList(StreamReader fileStr)
    {

        var strmSB = new StringBuilder();
        List<String> strList = new List<String>();

        while (!fileStr.EndOfStream)
        {
            strmSB.Append(fileStr.ReadLine().Trim('\n'));

            bool isSingle = Regex.IsMatch(strmSB.ToString(), @"^[A-z]+[\s]*$");

            bool isEmpty = String.IsNullOrEmpty(strmSB.ToString().Trim());

            //if it does not match the single word regex or it is not empty line, we return null list
            if (!isSingle && !isEmpty)
            {
                strList.Insert(0, null);
                return strList;
            }
            else
            {
                //else we add the single word to the list if it is not empty
                if (isSingle) { strList.Add(strmSB.ToString().Trim()); }
                else { continue; }
            }

            strmSB.Clear();

        }
        return strList;
    }

    public static String ReadContent(StreamReader fileStr)
    {
        String mainString = fileStr.ReadToEnd();
        return mainString;

    }

    //creating the result with date stamp and filename location
    public static void DeleteOccurances(StreamWriter fileStreamOUT, List<String> strList, String strMain, FileInfo infI, FileInfo infO)
    {
        string warn = $"File creation failed.";
        var sbFinal = new StringBuilder(strMain);
        try
        {
            if (strList[0] != null)
            {

                foreach (var word in strList)
                {
                    sbFinal.Replace(sbFinal.ToString(), Regex.Replace(sbFinal.ToString(), word, ""));

                }
                //to remove empty spaces after removal of the texts
                sbFinal.Replace(sbFinal.ToString(), Regex.Replace(sbFinal.ToString(), @"[\s]{2,}", " "));

                fileStreamOUT.WriteLine(sbFinal.ToString());

                DateTime newDT = DateTime.Now;
                Console.WriteLine($"File edit {infO} sucessful at \t == {newDT:dd_MM_yyyy_HH:mm:ss}\n");

            }
            else
            {
                Console.WriteLine(warn + $" List file {infI} contains extra words per line.");
                fileStreamOUT.Write(strMain); //so that it doesn't creates an empty text and deletes old info
            }
        }
        catch (SystemException)
        {
            Console.WriteLine(warn);
            fileStreamOUT.Write(strMain);
        }
    }


    static void Main(string[] args)
    {

        try
        {
            var sourceFile = new StreamReader(args[0]);

            var outputFile = new StreamReader(args[1]);

            var filIn = new FileInfo(args[0]);

            var filOut = new FileInfo(args[1]);

            var stringList = new List<String>();

            String mainString = "";


            using (sourceFile)
            {
                stringList = CreateWordList(sourceFile);
            }

            using (outputFile)
            {
                mainString = ReadContent(outputFile);
            }

            var editFile = new StreamWriter(args[1]);

            using (editFile)
            {
                DeleteOccurances(editFile, stringList, mainString, filIn, filOut);
            }
        }
        catch (System.IO.FileNotFoundException e)
        {
            var fileName = e.FileName; 
            //shortining the file name to its name instead of the whole folder names
            Console.WriteLine($"\n!!! The file {fileName.Substring(fileName.LastIndexOf("/")+1)} does not exist. Exiting program\n");

        }
        catch(System.UnauthorizedAccessException e)
        {
            // Access to the path /folder/folder/file.txt" is denied original e.Message
            var pathName = e.Message;
            Console.WriteLine($"\n!!! {pathName} File has restricted access. Exiting program\n");

        }

        
    }
}
