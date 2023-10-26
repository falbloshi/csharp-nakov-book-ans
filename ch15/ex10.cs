using Internal;
using System;
using System.Text;
using System.IO;


//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file

public class ex10
{
    public static void TagRemoval(StreamReader fileStr)
    {   
        var sb = new StringBuilder();
        var sb2 = new StringBuilder();
        char start = '<';
        char end = '>';
        char myC;
        bool startEnd = false;
        Console.WriteLine();
        

        //best method for between tags using booleans than regular expression 
        while(!fileStr.EndOfStream)
        {   

            //reads a char to see if it is either > or <
            myC = (char)fileStr.Read();//we have to use casting otherwise returns integer


            //if > read the next char in the stream and flag true for recording
            if(myC == end)
            {   
                startEnd = true;
                myC = (char)fileStr.Read();

            }


            //if char is < it stops recording and add the whole char stream to an appended line with newlines trimmed and clear the char stream and flag starting as false
            if(myC == start)
            {   
                if(!String.IsNullOrEmpty(sb.ToString()))
                {
                    sb2.AppendLine(sb.ToString().Trim());
                    sb.Clear();
                }
                startEnd = false;
            }
            
            //if flag is true record the blocks
            if(startEnd)
            {
                sb.Append(myC.ToString().Trim());
            }
                
        }

        Console.WriteLine(sb2.ToString().Trim());
    }
    


    static void Main(string[] args)
    {

        
        try
        {
            var inputFile = new StreamReader(args[0]);

            if (!String.IsNullOrEmpty(args[0]))
            {
            //seperate using, since i cannot read and write the same document
                using (inputFile)
                {
                    TagRemoval(inputFile);
                }
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            
            Console.WriteLine("Please specify a file name like so:\n\tmono ex10.exe [xml or text file]");
        }
     
    }
}
