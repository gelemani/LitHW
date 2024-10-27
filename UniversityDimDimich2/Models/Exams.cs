namespace UniversityDimDimich2.Models;

public class Exams
{
    public int Id { get; init; }
    public DateTime Date { get; init; }
    public int CourseId { get; init; }
    public int MaxScore { get; init; }
    
    public override string ToString()
    {
        return $"|{Id, 5} | {Date, 20} | {CourseId, 20} | {MaxScore, 20} |";
    }
}