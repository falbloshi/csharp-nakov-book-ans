using System;
using System.Text;
using System.IO;


public class ex1
{
    //print oddlines
    public static void Main(string[] args)
    {
        var sbRead = new StringBuilder();
        using (var reader = new StreamReader("numbers.txt"))
        {
            string line = "";
            for (int i = 0; line != null; i++)
            {
                line = reader.ReadLine();
                if (i % 2 == 0)
                {
                    if(!String.IsNullOrEmpty(line))
                        sbRead.AppendLine(line);
                }
            }
        }
        Console.WriteLine($"{sbRead.ToString()}");
        
    }

}
