using System;

namespace Student_Tracker.ClassesFolder;

public class Person
{
    private String? name;
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
    public Person(String? name)
    {
        Name = name;
    }

}
