using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

class ex3
{
    static void Main(string[] args)
    {
        var inputFile = new StreamReader(args[0]);

        string m;

        using (inputFile)
        {
            m = inputFile.ReadToEnd();
        }
        string[] stringCollection = m.Split(' ', '.', ',', '–', '?', '!');

        IDictionary<string, int> newDict = new SortedDictionary<string, int>(new CaseInsensitiveComparer());

        foreach (string word in stringCollection)
        {
            if (!String.IsNullOrEmpty(word))
            {
                int n;

                if (!newDict.TryGetValue(word, out n))
                {
                    n = 0;
                }

                newDict[word] = n + 1;
            }
        }

        var sortedDict = newDict.OrderBy(p => p.Value);

        foreach (var kvpair in sortedDict)
        {
            Console.WriteLine($"{kvpair.Key.ToLower()} -> {kvpair.Value}");
        }
    }

    class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            return string.Compare(s1, s2, true);
        }
    }

}