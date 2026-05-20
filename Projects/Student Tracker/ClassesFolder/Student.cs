using System;
using System.Collections.Generic;
using Student_Tracker.InterfaceFolder;

namespace Student_Tracker.ClassesFolder;

public class Student : IGradeable
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

    public double AverageGrade()
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
    public string LetterGrade()
    {
        double average = AverageGrade();
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
        Console.WriteLine($"Student: {Name}, Average Grade: {AverageGrade():F2}, Letter Grade: {LetterGrade()}");
    }
}
