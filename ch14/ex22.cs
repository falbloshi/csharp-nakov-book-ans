using System;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class School
{

    public class SchoolClass
    {
        public string grade { get; set; }
        public int noOfDisciplines { get; set; }
        public int maxStudents { get; set; }

        public SchoolClass(string grade, int noOfDisciplines, int maxStudents)
        {
            this.grade = CheckGrade(grade);
            this.noOfDisciplines = noOfDisciplines;
            this.maxStudents = maxStudents;
        }

        private string CheckGrade(string grade)
        {
            Regex gradeRGX = new Regex(@"^(([L|U][K][G])|(\b[0-9]\b|\b[1][0-2]\b))[-][A-Z]");
            bool isCorrectGrade = gradeRGX.IsMatch(grade);
            if (!isCorrectGrade)
            {
                var answer = new StringBuilder();
                while (!isCorrectGrade)
                {
                    Console.Write("You wrote Wrong Grade, please type again: ");
                    answer.Append(Console.ReadLine());
                    gradeRGX.IsMatch(answer.ToString());
                }
                return answer.ToString();
            }
            return grade;
        }

        public void ClassInfo()
        {
            Console.WriteLine($"Class: {this.grade}\nDisciplines: {this.noOfDisciplines}\nStudent Capacity: {this.maxStudents}");
        }
    }

    public class Discipline
    {
        public string subjectName { get; set; }
        public int noOfLessons { get; set; }

        public Discipline(string subject, int noOfLessons)
        {
            this.subjectName = subject;
            this.noOfLessons = noOfLessons; 
        }
        
        public void SubjectInfo()
        {
            Console.WriteLine($"Class: {this.subjectName}\nNumber of Lessons: {this.noOfLessons}");
        }

    }

    public class SchoolMember : Discipline
    {
        public int id { get; set; }
        public string name { get; set; }
        public ushort age { get; set; }

        public SchoolMember()
            :base(null, 0)
        {

        }
    
    }

    public class Student : SchoolMember
    {   
        public string[] lessons; 

        public Student(int id, string name, ushort age, params string[] lessons)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.lessons = lessons;        
        }

        public void StudentInfo()
        {
            Console.WriteLine($"\nStudent Name: {this.name}\nRollNo: {this.id}\nClasses: ");
            foreach(String m in lessons)
            {
                Console.WriteLine(m);
            }
        }
    }

    public class Teacher : SchoolMember
    {
        public string teaching { get; set; }

        static int noOfTeachers = 0;

        public Teacher(string name, ushort age, string discipline)
        {
            this.name = name;
            this.age = age;
            this.teaching = discipline;
            noOfTeachers++;
        }

        public void PrintTeachInfo()
        {
            Console.WriteLine($"Teacher's Name: {this.name}\nSubject: {this.teaching}");
        }

    }
}

class ClassTest: School
{
    static void Main()
    {
        var Class9G = new SchoolClass("9-G", 5, 20);
        Class9G.ClassInfo();
        
        List<Student> studentList = new List<Student>();
        var studenta = new Student(5418, "Feo", 15, "Photography", "Swimming", "Calculations" );
        var studentb = new Student(5553, "Dex", 16, "Photography", "Swimming", "Music" );
        var studentc = new Student(2223, "Ren", 15, "Photography", "Dancing", "Calculations" );
        studentList.Add(studenta);
        studentList.Add(studentb);
        studentList.Add(studentc); 

        foreach(Student a in studentList)
        {
            a.StudentInfo();
        }
    }
}