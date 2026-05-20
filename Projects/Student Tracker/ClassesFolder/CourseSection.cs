using System;

namespace Student_Tracker.ClassesFolder;

public class CourseSection
{
    public string CourseName { get; set; }
    public string Instructor { get; set; }

    public CourseSection(string courseName, string instructor)
    {
        CourseName = courseName;
        Instructor = instructor;
    }

}
