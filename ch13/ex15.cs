using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class ex15
{
    static void Main()
    {
        Console.WriteLine("Please enter a text to store it to the dictionary:");

        List<string> enteredString = new List<string>();
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        
        StringBuilder sbMain = new StringBuilder();
        StringBuilder sbSec = new StringBuilder();
        //adding items
        while(true)
        {
            Console.Write("> ");
            enteredString.Add(Console.ReadLine());
            if(enteredString[enteredString.Count - 1] == "")
            {
                break;
            }
        }  

        //checking to see if they fit the dictionary style
        foreach(string enStr in enteredString)
        {
            string myExp = @"(.*)\s-\s(.*)";
            Regex enStrRGX = new Regex(myExp);
            bool isCorrectFormat = enStrRGX.IsMatch(enStr);
            
            //if they are correct, we add them to the dictionary list
            if(isCorrectFormat)
            {
                string kvRGX = @"^(.*)\s-\s(.*)$";
           
                sbMain.Append(Regex.Replace(enStr, kvRGX, "$1"));
                sbSec.Append(Regex.Replace(enStr, kvRGX, "$2"));
                try
                {
                    myDictionary.Add(sbMain.ToString(), sbSec.ToString());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"An element with Key = \"{sbMain.ToString()}\" already exists.");
                }
            }
            sbMain.Clear();  
            sbSec.Clear();  
        }

        Console.WriteLine("\n\nSearch for a word in dictionary, press empty key to exit:\n");

        while(true)
        {
            Console.Write("> ");
            sbMain.Append(Console.ReadLine());
            if(sbMain.ToString() == "")
            {
                break;
            }
            
            try
            {
                Console.WriteLine($"\nThe meaning of the word {sbMain.ToString()} is:\n{myDictionary[sbMain.ToString()]}\n"); 
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Word does not exist, try again or exit\n");
                continue;
            }

            sbMain.Clear();
        }
   

    }

}