using System;
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
    
    public Students()
        : this("No name")
    {
       
    }
    public Students(string studentName)
        : this(NameCheck(studentName), "No Courses")
    {

    }

    public Students(string studentName, string courseName)
        : this(NameCheck(studentName), courseName, "No email")
    {

    }

    public Students(string studentName, string courseName, string email)
        : this(NameCheck(studentName), courseName, email, "No Phone number") 
    {

    }

    public Students(string studentName, string courseName, string email, string phoneNumber) 
    {
       this.studentName = NameCheck(studentName);
       this.courseName = courseName;
       this.email = email;
       this.phoneNumber = phoneNumber;     
    }

    static string NameCheck(string studentName)
    {
        Regex nameChecker = new Regex(@"^([A-z\.\-']+)\s([A-z\.\-']+)$|^([A-z\.\-']+)\s([A-z\.\-']+)\s([A-z\.\-']+)");  
        bool correctName = nameChecker.IsMatch(studentName);
        if(!correctName)
        {
             Console.WriteLine("You entered a wrong student name, please try again");
        }
        return studentName;
    }

    static void Main()
    {
        Students newStudent = new Students("try finder dwe", "Physics");
        Console.WriteLine(newStudent.studentName + " " + newStudent.courseName + " " + newStudent.email);    
    }
}

//^([A-z|\.\-']+)\s([A-z|\.\-']+)$|^([A-z|\.\-']+)\s([A-z|\.\-']+)\s([A-z|\.\-']+)

// asd awe aqwe
