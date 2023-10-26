using System;
using System.Text;
using System.Text.RegularExpressions;
class ex13
{

    static void Main()
    {
        Console.WriteLine("Please enter a valid URL to parse it(or press enter to exit): ");

        Console.Write("> ");
        var enteredString = Console.ReadLine();
        if (enteredString == "")
        {
            return;
        }
     
        string protocol = @"^(ht|f)tp(s?)";
        string doubleSlash = "://";
        StringBuilder sbMain = new StringBuilder();

        Regex ptclRGX = new Regex(protocol);
        bool ptclBool = ptclRGX.IsMatch(enteredString);

        //extracting protocol
        if(ptclBool)
        { 
            sbMain.AppendLine("[Protocol]= " + ptclRGX.Match(enteredString).ToString());
        }
        else
        {
            Console.WriteLine("Invalid Insertion try again!");
            Main();
        }
        //extracting after d.slash
       

        //Finding the match of the first instance of the double slash
        int dSlashIndex = enteredString.IndexOf(doubleSlash);

        //adding its length so that we can have the index of the first words in the url
        dSlashIndex += doubleSlash.Length;

        //we take protocolsize because it no longer exist in the substrings
        int protocolSize = ptclRGX.Match(enteredString).ToString().Length + 3;
        
        //if slash exists we take its index
        int slashIndex = 0; 
        if(enteredString.Substring(protocolSize).Contains("/"))
        {
            slashIndex = enteredString.Substring(dSlashIndex).IndexOf("/");
        }


        if(slashIndex > 0)
        { 
            sbMain.AppendLine("[Server]= " + enteredString.Substring(dSlashIndex, slashIndex+protocolSize-dSlashIndex));

            //whatever inbetween the slashes 
            //substring(starting index with protocol size, protocol size plus slash index minus the dlash index) 

            sbMain.AppendLine("[Source]= " + enteredString.Substring(slashIndex+protocolSize+1));
        }
        else
        {
            sbMain.AppendLine("[Server]= " + enteredString.Substring(dSlashIndex, enteredString.Length-dSlashIndex) + "\n[Source]= DOESN'T EXIST"); 
        }
        

        Console.WriteLine(sbMain.ToString());


    }

}