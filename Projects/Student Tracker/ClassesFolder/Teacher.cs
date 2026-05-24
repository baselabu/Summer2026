using System;

namespace Student_Tracker.ClassesFolder;

public class Teacher : Person
{
    public Teacher(String? name) : base(name)
    {
    }
//Grade Tracker: add LINQ-powered reports — top 3 students, class average, students below 60. 

    public void PrintClassReport(List<Student> students)
    {
        var top3Students = students.OrderByDescending(s => s.AverageGrade())
        .Take(3)
        .ToList();
        var classAverage = students.Average(s => s.AverageGrade());
        var failingStudents = students.Where(s => s.AverageGrade() < 60)
        .ToList();

        Console.WriteLine($"Class Report for Teacher: {Name}");
        Console.WriteLine($"Top 3 Students:");
        foreach (Student student in top3Students)
        {
            Console.WriteLine($"  {student.Name}: {student.AverageGrade():F2} ({student.LetterGrade()})");
        }
        Console.WriteLine($"Class Average: {classAverage:F2}");
        Console.WriteLine($"Students Below 60:");
        foreach (Student student in failingStudents)
        {
            Console.WriteLine($"  {student.Name}: {student.AverageGrade():F2} ({student.LetterGrade()})");
        }
    }

}
