using System;
using System.Text;
using System.IO;


public class ex3
{
    //number line writer
    public static void Main(string[] args)
    {
        var sbRead = new StringBuilder();
        var writer = new StreamWriter("lined.txt");
        var reader = new StreamReader("final.txt");
        using (writer)
        {
            int lineCounter = 1;

            var myStr = reader.ReadLine();
            while (myStr != null)
            {
                sbRead.Append(lineCounter + " ");
                sbRead.AppendLine(myStr);
                lineCounter++;
                myStr = reader.ReadLine();
            }
            reader.Close();
            writer.WriteLine(sbRead.ToString());
        }
        Console.WriteLine("lined.txt created");
    }

}
