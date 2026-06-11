
    public class EnrollmentService
    {
        public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
        {
            // Guard Clauses (fail fast)

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            if (course is null)
                throw new ArgumentNullException(nameof(course));

            if (course.Capacity <= 0)
                throw new InvalidOperationException("Course capacity is invalid.");

            if (course.EnrolledCount >= course.Capacity)
                throw new InvalidOperationException("Course is full.");

            //  Switch Expression (GPA classification)
            string standing = student.GPA switch
            {
                >= 3.5m => "Honors",
                >= 2.5m => "GoodStanding",
                _ => "AcademicWarning"
            };

            Console.WriteLine($"{student.Name} is in {standing}.");

            // (optional) simulate enrollment count increase
            course.EnrolledCount++;

            //  Return record
            return new EnrollmentRecord(
                student.Id,
                course.Code,
                DateTime.UtcNow
            );
        }
    }
