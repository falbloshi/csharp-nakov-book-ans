using System;
using System.Text;
using System.Text.RegularExpressions;

class Students
{
    enum Subjects
    {
        Mathematics,
        Literature,
        Physics,
        Chemistry,
        Biophysics,
    }

    enum Universities
    {
        UCLA,
        Berkeley,
        MIT,
        Chemistry,
        Biophysics,
    }
    
    public string studentName;
    public string courseName;
    public string email;
    public string phoneNumber;
    public static int instanceCount = 0;
    
    public Students()
        : this("No name")
    {
       
    }
    public Students(string studentName)
        : this(studentName, "No Courses")
    {

    }

    public Students(string studentName, string courseName)
        : this(studentName, courseName, "No email")
    {

    }

    public Students(string studentName, string courseName, string email)
        : this(studentName, courseName, email, "No Phone number") 
    {

    }

    public Students(string studentName, string courseName, string email, string phoneNumber) 
    {
       this.studentName = NameCheck(studentName);
       this.courseName = courseName;
       this.email = email;
       this.phoneNumber = phoneNumber;     
       instanceCount++;
    }

    static string NameCheck(string studentName)
    {   
        Regex nameChecker = new Regex(@"^([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)$|^([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)");  
        StringBuilder mySb = new StringBuilder();

        bool correctName = nameChecker.IsMatch(studentName);
        if(!correctName)
        {
            Console.WriteLine("\nYou entered a wrong student name, please try again!");         
            while(!correctName)
            {
                Console.Write("> ");
                mySb.Append(Console.ReadLine());
                correctName = nameChecker.IsMatch(mySb.ToString());
            }
            Console.WriteLine("Correct Name\n");         

        }
        return mySb.ToString();
    }

    static void Main()
    {
        Students newStudent = new Students("try", "Physics");
        Console.WriteLine(newStudent.studentName + " " + newStudent.courseName + " " + newStudent.email);
        Console.WriteLine(instanceCount);
    
    }
}

//^([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)$|^([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)\s([A-Z][a-z\.\-']+)

// asd awe aqwe
