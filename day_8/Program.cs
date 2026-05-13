using day_8.ClassFolder;
// Person file
Person person1 = new Person("Basel", "Abu Sablih");
person1.Greet();
Person person2 = new Person();
person2.Firstname = "Radwan";
person2.LastName = "Rahmoun";
person2.Greet();

// AgePerson file
AgePerson PersonAge = new AgePerson(25);
System.Console.WriteLine(PersonAge.Age);

// Rectangle file
Rectangle rectangle1 = new Rectangle(5, 3);
System.Console.WriteLine($"Area: {rectangle1.GetArea()}");
System.Console.WriteLine($"Perimeter: {rectangle1.GetPerimeter()}");

// • Instantiate 3 Person objects and store them in a List. Print all greetings.
List<Person> people = new List<Person>
{
    new Person("Alice", "Smith"),
    new Person("Bob", "Johnson"),
    new Person("Charlie", "Brown")
};
foreach (Person person in people)
{
    person.Greet();
}

// • Instantiate 3 Student objects with different grades. Print their average and letter grade.
List<Student> students = new List<Student>
{
    new Student("David", new List<double> { 85, 90, 78 }),
    new Student("Emma", new List<double> { 92, 88, 95 }),
    new Student("Frank", new List<double> { 70, 75, 80 })
};
foreach (Student student in students)
{
    System.Console.WriteLine($"{student.Name} - Average: {student.Average():F2}, Letter Grade: {student.LetterGrade()}");
}