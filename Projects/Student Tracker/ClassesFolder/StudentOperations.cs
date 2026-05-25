using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Tracker.ClassesFolder
{
    public class StudentOperations
    {
        public static List<Student> GetTopStudents(List<Student> students, int topCount = 3)
        {
            return students.OrderByDescending(s => s.AverageGrade()).Take(topCount).ToList();
        }
        public static double CalculateClassAverage(List<Student> students)
        {
            return students.Average(s => s.AverageGrade());
        }
        public static List<Student> GetFailingStudents(List<Student> students, double threshold = 60)
        {
            return students.Where(s => s.AverageGrade() < threshold).ToList();  
    }
        public static void DisplayReport(List<Student> top3Students, double classAverage, List<Student> failingStudents)
        {
            Console.WriteLine("Top 3 Students:");
            foreach (var student in top3Students)
            {
                Console.WriteLine($"{student.Name} - Average: {student.AverageGrade():F2}, Letter Grade: {student.LetterGrade()}");
            }
            Console.WriteLine($"\nClass Average: {classAverage:F2}");
            Console.WriteLine("\nFailing Students:");
            foreach (var student in failingStudents)
            {
                Console.WriteLine($"{student.Name} - Average: {student.AverageGrade():F2}, Letter Grade: {student.LetterGrade()}");
            }
        }
}

}