using System;

namespace day_8.ClassFolder;

public class Student
{
    //Start: Student Grade Tracker console app. • Create class: Student { Name, List Grades }. • Add method: double Average(). Add method: string LetterGrade().
    private string name;
    private List<double> grades;

    public Student(string name, List<double> grades)
    {
        Name = name;
        Grades = grades;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<double> Grades
    {
        get { return grades; }
        set { grades = value; }
    }

    public double Average()
    {
        if (Grades.Count == 0)
            return 0;

        double sum = 0;
        foreach (double grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }

    public string LetterGrade()
    {
        double average = Average();
        if (average >= 90)
            return "A";
        else if (average >= 80)
            return "B";
        else
            return "C";
    }

}
