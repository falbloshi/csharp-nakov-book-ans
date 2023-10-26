using System;
using System.Text;
using System.IO;

//use a console argument to access a file like ex4, it can take two arguments, one for inputfile and one for output file
public class ex5
{

    public static int[,] mySqm;
    public static int[,] InputFormatChecker(StreamReader inputStream)
    {
        try
        {
            var instSB = new StringBuilder();
            //var colSB = new StringBuilder();
            string[] coli;
            mySqm = new int[0, 0];


            //checking the first line
            instSB.Append(inputStream.ReadLine());
            int m = int.Parse(instSB.ToString().Trim(' '));


            //subsequent readlines are checked
            if (m > 0)
            {
                mySqm = new int[m, m]; //chapter 7 ex12

                //each row
                for (int i = 0; i < m; i++)
                {
                    instSB.Clear();
                    instSB.Append(inputStream.ReadLine());
                    coli = instSB.ToString().Split(' ');
                    if (coli.GetLength(0) != m)
                    {
                        Console.WriteLine("You have written in wrong format; wrong lengths.");
                        return new int[0,0];
                    }
                    else
                    {
                        //each column of the row 
                        int j = 0;
                        foreach (string s in coli)
                        {
                            //Console.WriteLine($"mySqm[{i}, {j}] = {s}");
                            mySqm[i, j] = int.Parse(s);
                            j++;
                        }
                    }
                    Array.Clear(coli, 0, coli.Length - 1);
                }

            }
            else
            {
                Console.WriteLine("You have wrong entry, try another file.");
                return new int[0,0];
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Format Exception: You have wrong entry, try another file.");
            return new int[0,0];
        }
        return mySqm;

    }
    public static string BestMatrixFinder(int[,] matrix)
    {
        int rowIndex = matrix.GetLength(0) - 1;
        int colIndex = matrix.GetLength(1) - 1;
        int currentCount = 0;
        // int finalCount = 0;
        int finalBest = 0;
        if ((rowIndex == colIndex) && ((matrix.GetLength(0) - 1) > 0))
        {
            for (int i = 0; i < rowIndex; i++)
            {

                for (int j = 0; j < rowIndex; j++)
                {
                    currentCount = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (currentCount > finalBest)
                    {
                        finalBest = currentCount;

                    }
                    currentCount = 0;
                }


            }
            return finalBest.ToString();
        }
        else
        {
            return null;
        }
        
    }

    //creating the result with date stamp and filename location
    public static void ResultCreation(StreamReader fileStreamIN, StreamWriter fileStreamOUT, FileInfo inf, FileInfo outf)
    {
        String finalBest = (BestMatrixFinder(InputFormatChecker(fileStreamIN)));
        if(!String.IsNullOrEmpty(finalBest))
        {
            DateTime newDT = DateTime.Now;
            fileStreamOUT.Write($"\nFinal best created at {newDT:dd_MM_yyyy_HH:mm:ss} from {inf}\n====> {finalBest}\n\n");
            Console.WriteLine($"File was written sucessfuly at {outf}");
        }
        else
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
            var outputFile = new StreamWriter("defaultsqm.txt");
            var filOut = new FileInfo("defaultsqm.txt");

            using (inputFile)
            using (outputFile)
            {
                ResultCreation(inputFile, outputFile, filIn, filOut);
            }
        }

    }
}