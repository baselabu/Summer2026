using System;

namespace Student_Tracker.ClassesFolder;

public class Teacher : Person
{
    public Teacher(String? name) : base(name)
    {
    }
    public void PrintClassReport(List<Student> students)
    {
        Console.WriteLine($"Class Report for Teacher: {Name}");
        foreach (Student student in students)
        {
            Console.WriteLine($"{student.Name}: Average Grade = {student.GetAverageGrade():F2}, Letter Grade = {student.GetLetterGrade()}");
        }
    }

}
