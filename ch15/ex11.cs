using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file

public class ex11
{
    public static StringBuilder TestRemoval(StreamReader fileStr)
    {
        var sb = new StringBuilder();

        sb.Append(fileStr.ReadToEnd());

        sb.Replace(sb.ToString(), Regex.Replace(sb.ToString(), @"\s*(\btest[\w]+)\s*", " "));

        return sb; 

    }

    //creating the result with date stamp and filename location
    public static void ResultCreation(StreamWriter fileStreamOUT, StringBuilder sbStr)
    {
        string warn = $"File editing failed. Exiting.";
             
        try
        {
            if (!String.IsNullOrEmpty(sbStr.ToString()))
            {
                fileStreamOUT.WriteLine(sbStr.ToString());

                Console.WriteLine($"File editing successful, removed tests");
            }
            else
            {
                Console.WriteLine(warn);
            }
        }
        catch (SystemException)
        {
            Console.WriteLine(warn);
        }
    }


    static void Main(string[] args)
    {

        var inputFile = new StreamReader(args[0]);
        var myStr = new StringBuilder();

        //since it is active on the same file
        if (!String.IsNullOrEmpty(args[0]))
        {
            //seperate using, since i cannot read and write the same document
            using (inputFile)
            {
                myStr = TestRemoval(inputFile);
            }

        }

        StreamWriter outputFile = new StreamWriter(args[0]);

        using (outputFile)
        {
            ResultCreation(outputFile, myStr);
        }

    }
}
