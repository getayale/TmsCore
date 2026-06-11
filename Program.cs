

var enrollService = new EnrollmentService();

// ===============================
// TEST 1: Normal case
// ===============================
var course = new Course
{
    Code = "CS-101",
    Title = "C# Basics",
    Capacity = 1,
    EnrolledCount = 0
};

var student = new Student
{
    Id = "S1",
    Name = "Abeba",
    Age = 20,
    GPA = 3.8m
};

try
{
    var result = enrollService.ProcessRegistration(student, course);
    course.EnrolledCount++;

    Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// ===============================
// TEST 2: Capacity exception
// ===============================
try
{
    enrollService.ProcessRegistration(
        new Student { Id = "S2", Name = "Test", Age = 20, GPA = 3.0m },
        course
    );
}
catch (CapacityReachedException ex)
{
    Console.WriteLine("\nDomain exception caught:");
    Console.WriteLine($"Course: {ex.CourseCode}");
    Console.WriteLine($"Message: {ex.Message}");
}