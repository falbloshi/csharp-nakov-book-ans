using System;
using System.Text;
class ex9
{
    static void Main()
    {
        Console.Write("Insert your line to convert to unicode and encrypt using xor operation:\n> ");
        String lineStr = Console.ReadLine();
        Console.Write("Write your encryption code:\n> ");
        String codeStr = Console.ReadLine();

        StringBuilder sbLineStr = new StringBuilder();
        StringBuilder sbCodeStr = new StringBuilder();
        sbLineStr.Append(lineStr);
        sbCodeStr.Append(codeStr);

        char[] lineArray = new char[sbLineStr.ToString().Length];
        lineArray = sbLineStr.ToString().ToCharArray();

        char[] codeArray = new char[sbCodeStr.ToString().Length];
        codeArray = sbCodeStr.ToString().ToCharArray();
        int[] myCode = new int[lineArray.Length];

        int j = 0;
        for (int i = 0; i < lineArray.Length; i++)
        {
            if (j >= codeArray.Length)
            {
                j = 0;
            }
            myCode[i] = lineArray[i] ^ codeArray[j];
            j++;
        }

        foreach (ushort codeElements in myCode)
        {
            Console.Write("\\u{0:x4}", codeElements);
        }

    }
}
