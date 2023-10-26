using System;
using System.Text;
class ex6
{
    static void Main()
    {
        Console.Write("Insert your line with upppercase(<upcase>) tags: ");
        String mainStr = Console.ReadLine();
        
        StringBuilder sbMainStr = new StringBuilder();
        sbMainStr.Append(mainStr);

        String opTag  = "<upcase>";
        String clTag  = "</upcase>";

        int optIndex = mainStr.IndexOf(opTag);
        int cltIndex = mainStr.IndexOf(clTag);

        StringBuilder subStr = new StringBuilder();
        StringBuilder fullSbtr = new StringBuilder();
        //capitalizing
        while(optIndex != -1)
        {
            // +8/+9 is the size of the tag. Subtracting the first index with the start of the second index gives us the complete length of the items between the tags. 
            fullSbtr.Append(mainStr.Substring(optIndex, (cltIndex-optIndex+9)));
            subStr.Append(mainStr.Substring(optIndex+8, (cltIndex-(optIndex+8)))); //whatever in between the closing and opening tag
  
            //duplicate tags makes it return to the beginning
            if(subStr.ToString().Contains(opTag))
            {
                Console.WriteLine("Your line contains nested tag, please repeat again");
                sbMainStr.Clear();
                Main();
            }
            
            //removing the tags as well as making it to upper.
            sbMainStr.Replace(fullSbtr.ToString(), subStr.ToString().ToUpper());
            
            //clearing
            fullSbtr.Clear();
            subStr.Clear();
            
            optIndex = mainStr.IndexOf(opTag, optIndex+1);
            cltIndex = mainStr.IndexOf(clTag, cltIndex+1);
        }   
        Console.WriteLine("\n\n{0}", sbMainStr.ToString());
    }   
}