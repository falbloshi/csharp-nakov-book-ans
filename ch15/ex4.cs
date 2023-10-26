using System;
using System.IO;


public class ex4
{
    public class LineChecker
    {
        //remember to close the stream
        public static int LineCount(StreamReader fileStream)
        {
            var myStr = fileStream.ReadLine();

            int returningInt = 0;
            for (int i = 0; myStr != null; i++)
            {
                returningInt = i;
                myStr = fileStream.ReadLine();
            }

            return returningInt;
        }

        private static bool IsEqual(int a, int b)
        {

            bool m = (a == b);
            return m;
        }

        public static void StreamsEqual(StreamReader firstStream, StreamReader secondStream)
        {
            int a = LineCount(firstStream);
            int b = LineCount(secondStream);
            bool isEqual = IsEqual(a, b);

            if (isEqual)
            {
                Console.WriteLine("Number lines are equal");
            }
            else
            {
                Console.WriteLine("Number lines are not equal, please assign again");
            }

        }
    }
    //number line checker
    public static void Main(string[] args)
    {
        //first time using args, actually quite useful
        if (args[0] == "--help" || args[0] == "-h")
        {
            Console.WriteLine("NAME\n   ex4.exe of chapter 15 will display the equality of lines two text files\nSYNOPSIS\nex4.exe [file] [file]");
        }
        else
        {
            var firstFile = new StreamReader(args[0]);
            var secondFile = new StreamReader(args[1]);

            //we can nest using without curly on top of each other
            using (firstFile)
            using (secondFile)
            {
                LineChecker.StreamsEqual(firstFile, secondFile);
            }
        }

    }

}
