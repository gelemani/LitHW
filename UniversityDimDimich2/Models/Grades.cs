namespace UniversityDimDimich2.Models;

public class Grades
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public int ExamId { get; init; }
    public int Score { get; init; } 
    
    public override string ToString()
    {
        return $"|{Id, 5} | {StudentId, 20} | {ExamId, 20} | {Score, 20} |";
    }
}