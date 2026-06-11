

public record EnrollmentRecord(string StudentId, string CourseCode, DateTime EnrolledAt);

public interface IGradable
{
    string Title { get; }
    decimal CalculateGrade();
}
public class Course
{
    public required string Code { get; set; }
    public required string Title { get; set; }

    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
}

public class Student
{
    public required string Id { get; set; }

    public required string Name
    {
        get;
        set =>
            field = !string.IsNullOrWhiteSpace(value)
                ? value
                : throw new ArgumentException("Name cannot be empty", nameof(value));
    }

    public int Age
    {
        get;
        set =>
            field = value is >= 16 and <= 100
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public decimal GPA
    {
        get;
        set =>
            field = value is >= 0.0m and <= 4.0m
                ? value
                : throw new ArgumentOutOfRangeException(nameof(value));
    }
}