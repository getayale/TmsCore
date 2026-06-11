var service = new EnrollmentService();
// Test 1: Valid registration
var validStudent = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m,
};

var validCourse = new Course
{
    Code = "CS-401",
    Title = "Advanced C#",
    Capacity = 30,
    EnrolledCount = 0,
};

var result = service.ProcessRegistration(validStudent, validCourse);

Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");

// Test 2: Null student
try
{
    service.ProcessRegistration(null, validCourse);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Guard caught: {ex.ParamName}");
}

// Test 3: Full course
var fullCourse = new Course
{
    Code = "CS-402",
    Title = "Full Course",
    Capacity = 1,
    EnrolledCount = 1,
};

try
{
    service.ProcessRegistration(validStudent, fullCourse);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Business rule: {ex.Message}");
}


// Exercise 5: LINQ Analytics Dashboard


// Step 1: Student List
List<Student> students =
[
    new Student
    {
        Id = "S1",
        Name = "Abeba",
        Age = 22,
        GPA = 3.8m,
    },
    new Student
    {
        Id = "S2",
        Name = "Kidane",
        Age = 21,
        GPA = 2.4m,
    },
    new Student
    {
        Id = "S3",
        Name = "Dawit",
        Age = 20,
        GPA = 3.1m,
    },
    new Student
    {
        Id = "S4",
        Name = "Sara",
        Age = 23,
        GPA = 3.9m,
    },
    new Student
    {
        Id = "S5",
        Name = "Frehiwot",
        Age = 19,
        GPA = 2.0m,
    },
    new Student
    {
        Id = "S6",
        Name = "Yonas",
        Age = 24,
        GPA = 3.5m,
    },
    new Student
    {
        Id = "S7",
        Name = "Meron",
        Age = 22,
        GPA = 1.8m,
    },
    new Student
    {
        Id = "S8",
        Name = "Tesfaye",
        Age = 21,
        GPA = 2.9m,
    },
];

// Step 2: Honors Leaderboard
var leaderboard = students
    .Where(s => s.GPA >= 3.5m)
    .OrderByDescending(s => s.GPA)
    .Select(s => s.Name)
    .ToList();

Console.WriteLine($"\nFound {leaderboard.Count} Honors Students:");

foreach (var name in leaderboard)
{
    Console.WriteLine($"- {name}");
}

// Step 3: Class Average GPA
decimal averageGpa = students.Average(s => s.GPA);

Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");

// Step 4: Group by Academic Standing
var standingGroups = students.GroupBy(s =>
    s.GPA switch
    {
        >= 3.5m => "Honors",
        >= 2.5m => "GoodStanding",
        >= 2.0m => "Probation",
        _ => "Academic Warning",
    }
);

Console.WriteLine("\n--- Academic Standing Report---");

foreach (var group in standingGroups)
{
    Console.WriteLine($"\n{group.Key} ({group.Count()}):");

    foreach (var s in group)
    {
        Console.WriteLine($" {s.Name} GPA: {s.GPA}");
    }
}

// Step 5: Collection Expressions (Spread Operator)
string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];

string[] allCourses = [.. backendCourses, .. frontendCourses, "Docker"];

Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");
