using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;


//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file

public class ex13
{
    public static Dictionary<String, int> CreateWordList(StreamReader fileStr)
    {

        var strmSB = new StringBuilder();
        var stringIntDict = new Dictionary<String, int>();
        var emptyDict = new Dictionary<String, int>();
        //first creating a list
        while (!fileStr.EndOfStream)
        {
            strmSB.Append(fileStr.ReadLine().Trim('\n'));

            bool isSingle = Regex.IsMatch(strmSB.ToString(), @"^[A-z]+[\s]*$");

            bool isEmpty = String.IsNullOrEmpty(strmSB.ToString().Trim());

            //if it does not match the single word regex or it is not empty line, we return null dict
            if (!isSingle && !isEmpty)
            {
                return emptyDict;
            }
            else
            {
                //else we add the single word to the dict if it is not empty
                //also check the dictionary if any other exists of the same value
                if (isSingle && !stringIntDict.ContainsKey(strmSB.ToString().Trim()))
                {
                    stringIntDict.Add(strmSB.ToString().Trim(), 0);
                }
                else { continue; }
            }
            strmSB.Clear();
        }
        return stringIntDict;
    }

    public static String ReadContent(StreamReader fileStr)
    {
        String mainString = fileStr.ReadToEnd();
        return mainString;

    }

    //creating the result with date stamp and filename location
    public static void CountOccurances(StreamWriter fileResulStream, Dictionary<String, int> strintDict, String strMain, FileInfo lst, FileInfo src, FileInfo res)
    {
        String warn = $"File creation failed.";
        List<string> listWordCountPair = new List<string>();
        String[] splitMain = strMain.Split(' ');

       // try
       // {
            if (strintDict.Count != 0)
            {
                //have to use linq
                foreach (var m in strintDict.Keys.ToList())
                {
                    foreach (String str in splitMain)
                    {
                        if(m == str.Trim())
                        { 
                            strintDict[m] += 1;
                        }
                    }
                }

                //from here https://stackoverflow.com/questions/289/how-do-you-sort-a-dictionary-by-value

                var finalList = strintDict.ToList();

                finalList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));

                foreach(var kvPair in finalList.OrderByDescending(key => key.Value))
                {
                    listWordCountPair.Add($"{kvPair.Key}\t\t{kvPair.Value}");
                }

                fileResulStream.WriteLine("Word:\t\tCount:");
                
                foreach(String m in listWordCountPair)
                {
                    fileResulStream.WriteLine(m);
                }

                DateTime newDT = DateTime.Now;
                Console.WriteLine($"File creation \"{res}\" sucessful at \t == {newDT:dd_MM_yyyy_HH:mm:ss}\n");

            }
            else
            {
                Console.WriteLine(warn + $" List file {lst} contains extra words per line.");
                fileResulStream.Write(strMain); //so that it doesn't creates an empty text and deletes old info
            }
        //}
        /*
        catch (SystemException)
        {
            Console.WriteLine(warn);
            fileResulStream.Write(strMain);
        }*/
    }


    static void Main(string[] args)
    {

        try
        {
            var fileList = new StreamReader(args[0]);

            var fileSource = new StreamReader(args[1]);

            var fileResult = new StreamWriter(args[2]);

            var infoList = new FileInfo(args[0]);
            
            var infoSource = new FileInfo(args[1]);

            var infoResult = new FileInfo(args[2]);

            var stringintDict = new Dictionary<String, int>();

            String fullString;


            using (fileList)
            {
                stringintDict = CreateWordList(fileList);
            }

            using (fileSource)
            {
                fullString = ReadContent(fileSource);
            }


            using (fileResult)
            {
                CountOccurances(fileResult, stringintDict, fullString, infoList, infoSource, infoResult);
            }
        }
        catch (System.IO.FileNotFoundException e)
        {
            var fileName = e.FileName;
            //shortining the file name to its name instead of the whole folder names
            if (args[2] == null)
            {
                Console.WriteLine("You did not specify a file name to create the word count file.");
            }
            else
            {
                //it is good for linux system, however, \ should be used in 
                Console.WriteLine($"\n!!! The file {fileName.Substring(fileName.LastIndexOf("/") + 1)} does not exist. Exiting program\n");
            }

        }
        catch (System.UnauthorizedAccessException e)
        {
            //file mem is inaccessible for testing using chmod 
            // Access to the path /folder/folder/file.txt" is denied original e.Message
            var pathName = e.Message;
            Console.WriteLine($"\n!!! {pathName} File has restricted access. Exiting program\n");

        }


    }
}
