
using Student_Tracker.ClassesFolder;
List<Student> students = new List<Student>{
    new Student("Alice", new List<double> { 100, 90, 78 }),
    new Student("Bob", new List<double> { 92, 88, 95 }),
    new Student("Charlie", new List<double> { 70, 75, 80 }),
    new Student("Diana", new List<double> { 85, 87, 90 }),
    new Student("Ethan", new List<double> { 30, 45, 58 })
};

var topStudent = students.OrderByDescending(s => s.AverageGrade()).FirstOrDefault();
if (topStudent != null){
    Console.WriteLine($"Top student: {topStudent.Name} with average grade {topStudent.AverageGrade():F2} ({topStudent.LetterGrade()})");
}

var AverageStudents80OrAbove = students.Where(s => s.AverageGrade() >= 80).ToList();
Console.WriteLine("Students with average grade 80 or above:");
foreach (Student student in AverageStudents80OrAbove)
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