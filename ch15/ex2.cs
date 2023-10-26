using System;
using System.Text;
using System.IO;


public class ex2
{
    //file joiner
    public static void Main(string[] args)
    {
        var sbRead = new StringBuilder();
        var firstText = new StreamReader("numbers.txt");
        var secondText = new StreamReader("sampletest.txt");
        var finalText = new StreamWriter("final.txt");

        using (finalText)
        {
            sbRead.AppendLine(firstText.ReadToEnd());
            sbRead.AppendLine(secondText.ReadToEnd());
            finalText.WriteLine(sbRead.ToString());
            firstText.Close();
            secondText.Close();
        }

        Console.WriteLine("Created file \"final.txt\" in current directory");
    }

}
