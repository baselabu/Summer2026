using System.IO;
using System.Text.Json; // for json serialization and deserialization

//File.WriteAllText("textfile.txt", "hello world"); // overwrites an exisiting file, if not existing it creates that file
File.AppendAllText("textfile.txt", "");
string[] textlines = File.ReadAllLines("textfile.txt");
System.Console.WriteLine(string.Join("\n", textlines)); // joins the array of strings into one string with \n as a separator, so it will print each line in a new line

Person p = new Person
{
    Name = "Hazim",
    Age = 21
};

string json = JsonSerializer.Serialize(p); // Converts the object p into a json string

File.WriteAllText("person.json", json); // creates the json file and writes the json string into it

string Json = File.ReadAllText("person.json"); // Reads the content of the json file and stores it in a string variable Json

Person P = JsonSerializer.Deserialize<Person>(Json)!;

Console.WriteLine($"{P.Age}, {P.Name}"); // prints the age and name of the person object P

// List<string> PeopleNames = new List<string>();
// PeopleNames.Add("Hazim");
// PeopleNames.Add("Ali");
// PeopleNames.Add("Omar");
// File.WriteAllLines("people.txt", PeopleNames); // creates a text file and writes each name in the list as a new line in the file
string[] names = File.ReadAllLines("people.txt"); // reads all lines from the text file and stores them in an array of strings
foreach (string name in names)
{
    Console.WriteLine(name); // prints each name in the array of names
}

var Options = new JsonSerializerOptions
{
    WriteIndented = true // this option makes the json string more readable by adding indentation and new lines
};
Student s = new Student
{
    Name = "Hazim",
    Age = 21,
    University = "University of Baghdad"
};
string studentJson = JsonSerializer.Serialize(s, Options); // Converts the student object s into a json string
File.WriteAllText("student.json", studentJson); // creates the json file and writes the json string into it
string studentJsonString = File.ReadAllText("student.json"); // Reads the content of the json file and stores it in a string variable studentJsonString
Student S = JsonSerializer.Deserialize<Student>(studentJsonString)!; // Converts the json string back into a student object
Console.WriteLine($"{S.Name}, {S.Age}, {S.University}"); // prints the name, age and university of the student object S

//• Serialize a List to JSON and back.
List<Student> students = new List<Student>
{
    new Student { Name = "Hazim", Age = 21, University = "University of Baghdad" },
    new Student { Name = "Ali", Age = 22, University = "University of Basra" },
    new Student { Name = "Omar", Age = 20, University = "University of Mosul" }
};
string studentsJson = JsonSerializer.Serialize(students, Options); // Converts the list of students into a json string
File.WriteAllText("students.json", studentsJson); // creates the json file and writes the json string into it
string studentsJsonString = File.ReadAllText("students.json"); // Reads the content of the json file and stores it in a string variable studentsJsonString
List<Student> Students = JsonSerializer.Deserialize<List<Student>>(studentsJsonString)!; // Converts the json string back into a list of student objects
foreach (Student student in Students)
{
    Console.WriteLine($"{student.Name}, {student.Age}, {student.University}"); // prints the name, age and university of each student in the list of students
}
internal class Person
{    public string? Name { get; set; } 
    public int Age { get; set; }
}

internal class Student : Person
{
    public string? University { get; set; }
}