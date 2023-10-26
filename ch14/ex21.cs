using System;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;

/*
There is a book library. Define classes respectively for a book and a
library. The library must contain a name and a list of books. The books
must contain the title, author, publisher, release date and ISBN-number.
In the class, which describes the library, create methods to add a book to
the library, to search for a book by a predefined author, to display
information about a book and to delete a book from the library.
 
*/
public class Books
{
    private string title;
    private string author;
    private string publisher;
    private DateTime releaseDate;
    private string isbnNumber;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public DateTime ReleaseDate
    {
        get { return releaseDate; }
        set { releaseDate = value; }
    }

    public string ISBN
    {
        get { return isbnNumber; }
        set { isbnNumber = value; }
    }

    public Books()
        : this("No Title")
    { }
    public Books(string title)
        : this(title, "No Author")
    { }
    public Books(string title, string author)
       : this(title, author, "No Publisher")
    { }
    public Books(string title, string author, string publisher)
       : this(title, author, publisher, new DateTime(1900, 01, 01))
    { }
    public Books(string title, string author, string publisher, DateTime releaseDate)
       : this(title, author, publisher, releaseDate, "978-0000-000-00-0")
    { }
    public Books(string title, string author, string publisher, DateTime releaseDate, string isbnNumber)
    {
        Title = title;
        Author = AuthorCheck(author);
        ReleaseDate = DateChecker(releaseDate);
        Publisher = publisher;
        ISBN = ISBNChecker(isbnNumber);
    }


    private string AuthorCheck(string author)
    {
        Regex nameChecker = new Regex(@"([A-Z][a-z\.\-'A-z]+)\s([A-Z][a-z\.\-'A-z]+)(\s([A-Z][a-z\.\-'A-z]+))?");
        StringBuilder mySb = new StringBuilder();

        bool isCorrectName = nameChecker.IsMatch(author);
        if (!isCorrectName)
        {
            Console.WriteLine($"\nYou entered a wrong author name {author}, please try again!");
            while (!isCorrectName)
            {
                Console.Write("> ");
                mySb.Append(Console.ReadLine());
                isCorrectName = nameChecker.IsMatch(mySb.ToString());
            }
            return mySb.ToString();
        }
        else
        {
            return author;
        }
    }
    public DateTime DateChecker(DateTime theDateTime)
    {

        if (theDateTime == new DateTime(0001, 01, 01))
        {
            CultureInfo enEN = new CultureInfo("en-GB");
            DateTime myDate = new DateTime();
            StringBuilder myString = new StringBuilder();

            Console.Write("Enter correct date: ");
            myString.Append(Console.ReadLine());

            while (!(DateTime.TryParseExact(myString.ToString(), "dd/MM/yyyy", enEN, DateTimeStyles.None, out myDate)))
            {
                myString.Clear();
                Console.WriteLine("Please write correct format dd/MM/yyyy: ");
                Console.Write("Enter the date: ");
                myString.Append(Console.ReadLine());
            }
            return myDate;
        }
        else { return theDateTime; }
    }

    private string ISBNChecker(string isbnNumber)
    {
        //using a stringbuilder to store the isbnumber
        StringBuilder isbnSB = new StringBuilder(isbnNumber);

        //remove all whitespaces using regex
        isbnSB.Replace(isbnSB.ToString(), Regex.Replace(isbnSB.ToString(), " ", ""));

        //checking length
        int length = isbnSB.ToString().Length;

        if (length == 13)
        {
            //adding 978- if it is under 10 items excluding the 3 dashes
            isbnSB.Insert(0, "978-");
        }
        Regex isbnChecker = new Regex(@"^((978)|(\d{3}))([-][\d]{1,9})([-][\d]{1,9})([-][\d]{1,9})([-][\d]{1,9})$");

        bool isCorrectFormat = isbnChecker.IsMatch(isbnSB.ToString());

        length = isbnSB.ToString().Length;

        if (isCorrectFormat && (length == 17))
        {
            return isbnSB.ToString();
        }
        else
        {
            while (!(isCorrectFormat && (length == 17)))
            {   
                Console.Write("You have written in a wrong ISBN format, please type again: ");

                isbnSB.Clear();

                isbnSB.Append(Console.ReadLine());

                if (length == 13)
                {
                    isbnSB.Insert(0, "978-");
                }

                isCorrectFormat = isbnChecker.IsMatch(isbnSB.ToString());

                length = isbnSB.ToString().Length;
            }
            return isbnSB.ToString();
        }
    }
}

public class Library : Books
{
    private List<Books> bookList = new List<Books>();

    public List<Books> BookList
    {
        get { return bookList; }
        set { bookList = value; }
    }
    public void AddBook()
    {
        StringBuilder titleSB = new StringBuilder();
        StringBuilder authorSB = new StringBuilder();
        StringBuilder publisherSB = new StringBuilder();
        StringBuilder isbnSB = new StringBuilder();
        StringBuilder dateSB = new StringBuilder();

        Console.Write("\nPlease Insert Book Informations:\n");

        Console.Write("Book Name or Title: ");
        titleSB.Append(Console.ReadLine());

        Console.Write("Author: ");
        authorSB.Append(Console.ReadLine());

        Console.Write("Publisher: ");
        publisherSB.Append(Console.ReadLine());

        Console.Write("ISBN with dashes(10 or 13): ");
        isbnSB.Append(Console.ReadLine());

        Console.Write("Release date in dd/MM/yyyy format: ");
        dateSB.Append(Console.ReadLine());
        DateTime.TryParse(dateSB.ToString(), out DateTime dt);

        //BookList.Add(new Books(titleSB.ToString(), authorSB.ToString(), publisherSB.ToString(), dt, isbnSB.ToString()));
     }

    public void DeleteBook(string bookItem)
    {
        Console.WriteLine($"This will delete every book containing the detail: {bookItem}");
        foreach (Books storedBook in BookList.ToArray().Reverse())
        {
            if (storedBook.Author == bookItem || storedBook.Title == bookItem)
            {
                
                BookList.Remove(storedBook);
            }
        }
    }

    public void SearchByAuthor(string AuthorName)
    {
        Console.WriteLine($"Books by {AuthorName}:");
        int count = 1;
        bool noBookFlag = false;
        foreach (Books storedBook in BookList.ToArray())
        {
            if (storedBook.Author == AuthorName)
            {
                Console.WriteLine($"{count,10:##}: {storedBook.Title,15}");
                count++;
                noBookFlag = true;
            }
        }
        if (!noBookFlag)
        {
            Console.WriteLine("No Books by this author!");
        }
    }


    public void PrintBookInfo(string NameOfItem)
    {
        if (BookList.Count > 0)
        {
            //using LINQ linq for the first time - don't like it, but it is the only solution
            Books selectedBook = BookList.Find(x => (x.Title == NameOfItem));

            if (!(selectedBook.Title == "") && !(selectedBook.Title == null))
            {
                Console.WriteLine($" -==== Book Information ====-");
                Console.WriteLine($"Title: {selectedBook.Title}");
                Console.WriteLine($"Author: {selectedBook.Author}");
                Console.WriteLine($"Publisher: {selectedBook.Publisher}");
                Console.WriteLine($"Release Date: {selectedBook.ReleaseDate,0:dd-MM-yyyy}");
                Console.WriteLine($"ISBN: {selectedBook.ISBN}");

                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("No Books");
        }
    }

}

public class LibraryTest
{   
    public static void DeleteByAuthor(string AuthorName, Library finalLIb)
    {
        finalLIb.SearchByAuthor(AuthorName);
        finalLIb.DeleteBook(AuthorName);
    } 

    static void Main()
    {   //Using this currentculture so it doesnt affect my datetime in my programs
        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
        Library myLib = new Library();
        myLib.BookList.Add(new Books("Cujo", "Stephen King", "Viking Press", new DateTime(1981, 09, 8), "978-0-670-45193-7"));
        myLib.BookList.Add(new Books("The Running Man", "Stephen King", "Signet Books", new DateTime(1982, 05, 1), "978-0-451-11508-9"));
        myLib.BookList.Add(new Books("The Long Walk", "Stephen King", "Signet Books", new DateTime(1981, 09, 8), "978-0-451-08754-6"));
        myLib.BookList.Add(new Books("No Country for Old Men", "Cormac McCarthy", "Alfred A. Knopf", new DateTime(1981, 09, 8), "0-375-40677-8"));
        myLib.BookList.Add(new Books("Random Harvest", "James Hilton", "Macmillan", new DateTime(1941, 12, 01), "0-333-02681-0"));
        
        foreach(Books bookListing in myLib.BookList)
        {
                myLib.PrintBookInfo(bookListing.Title);
        }
        DeleteByAuthor("Stephen King", myLib);

        foreach(Books bookListing in myLib.BookList)
        {
                myLib.PrintBookInfo(bookListing.Title);
        }
        

    }
}



