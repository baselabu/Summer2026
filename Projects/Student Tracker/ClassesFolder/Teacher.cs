using System;

namespace Student_Tracker.ClassesFolder;

public class Teacher : Person
{
    public Teacher(String? name) : base(name)
    {
    }

    public void PrintClassReport(List<Student> students)
    {
        var top3Students = StudentOperations.GetTopStudents(students, 3);
        var classAverage = StudentOperations.CalculateClassAverage(students);
        var failingStudents = StudentOperations.GetFailingStudents(students, 60);

        StudentOperations.DisplayReport(top3Students, classAverage, failingStudents);
    }

}
