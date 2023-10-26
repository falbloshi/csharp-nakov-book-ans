using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ex26
{
    static void Main()
    {
        Console.WriteLine("\nWrite data to remove html tags: \n");

        StringBuilder myStr = new StringBuilder();
        Console.Write("Enter the data: ");  
        String newStr = Console.ReadLine();
        Regex myRGX = new Regex("<([0-9A-z\\s.=\"\\':\\/]+)>");
        
        myStr.Append(myRGX.Replace(newStr, ""));


        Console.WriteLine("\nReplaced Data:\n");
        Console.WriteLine("{0}", myStr.ToString().TrimStart(' '));

   }
}

/*
<([0-9A-z\\s.=\"\\':\\/]+)>
<([0-9A-z\s.="':\/]+)>
<html>
<head><title>News</title></head>
<body><p><a href="http://softuni.org">Software
University</a>aims to provide free real-world practical
training for young people who want to turn into
skillful software engineers.</p></body>
</html>
*/
