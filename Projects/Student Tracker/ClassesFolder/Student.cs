using System;
using System.Collections.Generic;

namespace Student_Tracker.ClassesFolder;

public class Student
{
    private String? name;
    private List<double> grades = new List<double>();
    public String? Name
    {
        get => name;
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }
    public List<double> Grades { get => grades; set
        {
            if (value != null)
            {
                grades = value;
            }
        } }
    public Student(String? name, List<double> grades)
    {
        Name = name;
        Grades = grades ?? new List<double>();
    }

    public double GetAverageGrade()
    {
        if (Grades.Count == 0)
        {
            return 0;
        }
        double sum = 0;
        foreach (double grade in Grades)
        {
            sum += grade;
        }
        return sum / Grades.Count;
    }
    public string GetLetterGrade()
    {
        double average = GetAverageGrade();
        if (average >= 90)
        {
            return "A";
        }
        else if (average >= 80)
        {
            return "B";
        }
        else if (average >= 70)
        {
            return "C";
        }
        else if (average >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
    public void ResultMessage()
    {
        Console.WriteLine($"Student: {Name}, Average Grade: {GetAverageGrade():F2}, Letter Grade: {GetLetterGrade()}");
    }
}
