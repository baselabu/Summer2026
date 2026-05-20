
using Student_Tracker.ClassesFolder;
List<Student> students = new List<Student>{
    new Student("Alice", new List<double> { 85, 90, 78 }),
    new Student("Bob", new List<double> { 92, 88, 95 }),
    new Student("Charlie", new List<double> { 70, 75, 80 })
};

foreach (Student student in students)
{
    student.ResultMessage();
}

Teacher teacher = new Teacher("Mr. Smith");
teacher.PrintClassReport(students);

List<CourseSection> courseSections = new List<CourseSection>
{
    new CourseSection("Math 101", "Mr. Smith"),
    new CourseSection("History 201", "Ms. Johnson")
};
foreach (CourseSection course in courseSections)
{
    Console.WriteLine($"Course: {course.CourseName}, Instructor: {course.Instructor}");
}