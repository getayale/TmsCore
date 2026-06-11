
using System.Diagnostics;


Console.WriteLine("=== TMS Enrollment Engine (M1 Session 3) ===\n");

// ===============================
// STUDENT DATA (Exercise 5 requirement)
// ===============================
List<Student> students = [
    new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
    new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
    new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
    new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
    new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
    new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
    new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
    new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }
];

// ===============================
// EXERCISE 5: LINQ REPORT
// ===============================
var leaderboard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine($"Found {leaderboard.Count} Honors Students:");
foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}

// Average GPA
decimal averageGpa = students.Average(s => s.GPA);
Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

// Grouping
var standingGroups = students.GroupBy(s => s.GPA switch
{
    >= 3.5m => "Honors",
    >= 2.5m => "GoodStanding",
    >= 2.0m => "Probation",
    _ => "Academic Warning"
});

Console.WriteLine("\n--- Academic Standing Report ---");
foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key} ({group.Count()}):");
    foreach (var s in group)
    {
        Console.WriteLine($" {s.Name} GPA: {s.GPA}");
    }
}

// ===============================
// EXERCISE 6 + 7: ENROLLMENT ENGINE
// ===============================
var enrollCourse = new Course
{
    Code = "CRS-101",
    Title = "C# Mastery",
    Capacity = 2,
    EnrolledCount = 0
};

var enrollService = new EnrollmentService();

var enrollments = new List<EnrollmentRecord>();
var failures = new List<string>();

var sw = Stopwatch.StartNew();

foreach (var student in students)
{
    try
    {
        var record = enrollService.ProcessRegistration(student, enrollCourse);

        enrollCourse.EnrolledCount++;
        enrollments.Add(record);

        Console.WriteLine($" Enrolled: {student.Name}");
    }
    catch (InvalidOperationException ex)
    {
        failures.Add($"{student.Name}: {ex.Message}");
        Console.WriteLine($" Rejected: {student.Name} - {ex.Message}");
    }
}

// ===============================
// EXERCISE 7B: FINAL REPORT
// ===============================
sw.Stop();

decimal classAverage = students.Count > 0
    ? students.Average(s => s.GPA)
    : 0m;

Console.WriteLine("\n========== ENROLLMENT SUMMARY ==========");
Console.WriteLine($"Total students loaded: {students.Count}");
Console.WriteLine($"Successful enrollments: {enrollments.Count}");
Console.WriteLine($"Failed enrollments: {failures.Count}");
Console.WriteLine($"Class average GPA: {classAverage:F2}");
Console.WriteLine($"Total elapsed time: {sw.ElapsedMilliseconds}ms");

if (failures.Count > 0)
{
    Console.WriteLine("\n--- Failure Details ---");
    foreach (var failure in failures)
    {
        Console.WriteLine($"- {failure}");
    }
}

Console.WriteLine("========================================");

// ===============================
// OPTIONAL: Exercise 6B Email Simulation
// ===============================
async Task SendConfirmationAsync(Student student)
{
    try
    {
        await Task.Delay(100);
        Console.WriteLine($"Email sent to {student.Name}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Email failed for {student.Name}: {ex.Message}");
    }
}