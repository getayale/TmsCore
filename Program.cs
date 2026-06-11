<<<<<<< HEAD
﻿void PrintGradeReport(IEnumerable<IGradable> assessments)
{
    Console.WriteLine("--- Grade Report ---");

    foreach (var item in assessments)
    {
        Console.WriteLine(
            $"{item.Title}: {item.CalculateGrade():F2}%");
    }
}

IGradable[] cohortAssessments =
[
    new Quiz
    {
        Title = "C# Basics",
        CorrectAnswers = 18,
        TotalQuestions = 20
    },

    new LabAssignment
    {
        Title = "Registration API",
        FunctionalityScore = 90m,
        CodeQualityScore = 85m
    }
];

PrintGradeReport(cohortAssessments);
=======
﻿string? studentRegion = null;

if (studentRegion is not null)
{
    Console.WriteLine(studentRegion.ToUpper());
}
else
{
    Console.WriteLine("Region not provided");
}
>>>>>>> ef28e79b41225b4cf2f647f6f4a5d3be75656e46
