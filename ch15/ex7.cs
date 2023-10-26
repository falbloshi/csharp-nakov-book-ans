using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file
public class ex7
{    
    public static StringBuilder StartReplacer(StreamReader fileStr)
    {
        Regex startRGX = new Regex("start");
        var srSB = new StringBuilder();
        while(!fileStr.EndOfStream)
        {
            srSB.Append(fileStr.ReadToEnd());
        }
        srSB.Replace(srSB.ToString(), startRGX.Replace(srSB.ToString(), "finish"));

        return srSB;
    }

    //creating the result with date stamp and filename location
    public static void ResultCreation(StreamReader fileStreamIN, StreamWriter fileStreamOUT, FileInfo inf, FileInfo outf)
    {
        string warn = $"File creation failed. Created empty entry at {outf}";
        var replacedText = StartReplacer(fileStreamIN);

        try
        {
            if (!String.IsNullOrEmpty(replacedText.ToString()))
            {
                DateTime newDT = DateTime.Now;

                fileStreamOUT.Write($"\nFinish replaced created at {newDT:dd_MM_yyyy_HH:mm:ss} from {inf}\n\n");

                fileStreamOUT.WriteLine(replacedText.ToString());
                Console.WriteLine($"File creation successful created a new file at {outf}");
            }
            else
            {
                Console.WriteLine(warn);
            }
        }
        catch(SystemException)
        {
            Console.WriteLine(warn);
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
            var outputFile = new StreamWriter("defStrFin.txt");

            var filOut = new FileInfo("defStrFin.txt");

            using (inputFile)
            using (outputFile)
            {
                ResultCreation(inputFile, outputFile, filIn, filOut);
            }
        }

    }
}