using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace StudentDatabase{}
    public enum Subjects
    {
        Mathematics,
        Literature,
        Physics,
        Chemistry,
        Biophysics,
    }

    public enum Universities
    {
        UCLA,
        Berkeley,
        MIT,
        JHK,
        TUJ,
    }
    class Students
    {
        public Subjects courses;
        public Universities uni;
        public string studentName;
        public string email;
        public string phoneNumber;
        
        public Students()
            : this("Empty Student Name")
        {
        
        }
        public Students(string studentName)
            : this(studentName, (Subjects)1)
        {

        }

        public Students(string studentName, Subjects courses)
            : this(studentName, courses, "No email")
        {

        }

        public Students(string studentName, Subjects courses, string email)
            : this(studentName, courses, email, "No Phone number") 
        {

        }

        
        public Students(string studentName, Subjects courses, string email, string phoneNumber)
            : this(studentName, courses, email, phoneNumber, (Universities)0) 
        {
        }

        public Students(string studentName, Subjects courses, string email, string phoneNumber, Universities univs) 
        {
            this.studentName = NameCheck(studentName);
            this.courses = courses;
            this.email = email;
            this.phoneNumber = phoneNumber;     
            this.uni = univs;
            studentRollNo++;
        }

        public string NameCheck(string studentName)
        {   
            Regex nameChecker = new Regex(@"([A-Z][a-z\.\-'A-z]+)\s([A-Z][a-z\.\-'A-z]+)(\s([A-Z][a-z\.\-'A-z]+))?");  
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
                return mySb.ToString();         
            }
            else
            {
                return studentName;
            }
        }

        public static int studentRollNo = 0;
        public static void PrintStudent(Students studentPrint)
        {
            Console.Write("\n--+=== Student Information ===+--\n");
            Console.WriteLine($"Student Name: {studentPrint.studentName}\nUniversity: {studentPrint.uni}\nCourse: {studentPrint.courses}\nRoll No: {studentRollNo,5:0000}\nEmail: {studentPrint.email}\nPhone Number: {studentPrint.phoneNumber}");
        }

       

    class StudentTest : Students
    {   
        public static Dictionary<string, Students> studentDB = new Dictionary<string, Students>();

            
        public static void CreatStudent()
        {   
            Console.Write("\r>");
            string stName = Console.ReadLine();
            Students newStudent = new Students();
            
            try
            {
                studentDB.Add(stName, newStudent);
            }
            catch (System.ArgumentException)
            {
            }
            //return studentDB[stName]; //using the Class as value to return the class to other methods that requires the class like PrintStudent
        }

         static void Main()
        {
            CreatStudent();
            Console.WriteLine("Write the name of student to extract info> ");
            string s = Console.ReadLine();
            
            try
            {
                PrintStudent(studentDB[s]);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Write Again");
                Main();
            }
                
        }
    }
}




//([A-Z][a-z\.\-'A-z]*)\s([A-Z][a-z\.\-'A-z]*)(\s([A-Z][a-z\.\-'A-z]*))?

