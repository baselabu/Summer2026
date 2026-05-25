# Student Tracker

Student Tracker is a minimal C# console application for managing students and their grades. It demonstrates simple object-oriented design, LINQ-powered reporting, and lightweight JSON persistence.

**Key Features**
- Add and represent students with a list of numeric grades.
- Compute average and letter grades per student.
- Teacher reports: top students, class average, and failing students using LINQ.
- Course section model for associating courses and instructors.
- Persistent storage: students are saved and loaded from `students.json` in the application's working directory.

**Project Layout**
- `Program.cs` — top-level program that loads students, runs reports, and demonstrates features.
- `ClassesFolder/Student.cs` — `Student` model and grading logic.
- `ClassesFolder/Teacher.cs` — `Teacher` class with report generation.
- `ClassesFolder/StudentStorage.cs` — `Load()` and `Save()` methods that read/write `students.json`.
- `InterfaceFolder/IGradeable.cs` — interface for gradeable objects.

**Running**
Build and run with the .NET SDK from the project root:

```bash
dotnet build "Student Tracker.sln"
dotnet run --project "Student Tracker.csproj"
```

On first run the app seeds sample students and writes `students.json` to the current working directory. Subsequent runs will load that file if present.

**Notes**
- `students.json` is stored in the working directory where you run the app (e.g., the project root when using `dotnet run`), so you will see the file appear next to the solution and project files.
- The JSON persistence uses System.Text.Json and writes indented, human-readable JSON.

This README was generated with assistance from an AI to quickly summarize the project's purpose and usage. Review and edit as needed to add project-specific details, contribution guidelines, or licensing information.
