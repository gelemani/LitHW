namespace UniversityDimDimich2.DTOs;

public sealed class StudentExamGradeDto
{
    public int StudentId { get; init; }
    public string Surname { get; init; }
    public string CourseTitle { get; init; }
    public int Grade { get; init; }
    public DateTime Examdate { get; init; }
}