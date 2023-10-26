using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
//use a console argument to access a file like ex4
public class test
{   

    public static List<String> CreateWordList(StreamReader fileStr)
    {

        var strmSB = new StringBuilder();
        List<String> strList = new List<String>();
                
        while(!fileStr.EndOfStream)
        {
            strmSB.Append(fileStr.ReadLine().Trim('\n'));
                       
            bool isSingle = Regex.IsMatch(strmSB.ToString(), @"^[A-z]+[\s]*$");

            bool isEmpty = String.IsNullOrEmpty(strmSB.ToString().Trim());

            //if it does not match the regex or it is not empty line, we return null list
            if(!isSingle && !isEmpty)
            {
                strList.Insert(0, "x");
                return strList;
            }
            else 
            {
                //else we add the single word to the list
                if(isSingle){ strList.Add(strmSB.ToString().Trim()); }
                else { continue; }
            }
    
            strmSB.Clear();

        }
        return strList;

    }
   
    static void Main(string[] args)
    {        
        var fileStr = new StreamReader(args[0]);
        var newList = new List<String>();
        using (fileStr)
        {
            newList = CreateWordList(fileStr);
        }

        foreach(var m in newList)
        {
            Console.WriteLine(m);
        }

    }
}