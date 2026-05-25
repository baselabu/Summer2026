using System.Text.Json;

namespace Student_Tracker.ClassesFolder;

public static class StudentStorage
{
    private const string FileName = "students.json";

    public static List<Student> Load()
    {
        string filePath = GetFilePath();
        if (!File.Exists(filePath))
        {
            return new List<Student>();
        }

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
    }

    public static void Save(List<Student> students)
    {
        string filePath = GetFilePath();
        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    private static string GetFilePath()
    {
        return Path.Combine(Environment.CurrentDirectory, FileName);
    }
}