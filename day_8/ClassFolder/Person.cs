using System;

namespace day_8.ClassFolder;

public class Person
{
    private string? firstname;
    private string? lastname;
    public Person()
    {
        
    }
    public Person(string firstname, string lastname)
    {
        Firstname = firstname;
        LastName = lastname;
    }
    public string? Firstname
    {
        get { return firstname; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                firstname = value;
            }
            else
            {
                System.Console.WriteLine("Firstname cannot be empty");
            }
        }
    }
    public string? LastName
    {
        get { return lastname; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                lastname = value;
            }
            else
            {
                System.Console.WriteLine("Lastname cannot be empty");
            }
        }
    }
    public void Greet()
    {
        System.Console.WriteLine("Hello " + Firstname + " " + LastName);
    }
}
