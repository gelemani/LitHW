namespace UniversityDimDimich2.Models;

public class Courses
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int TeacherId { get; init; }
    
    public override string ToString()
    {
        return $"|{Id, 5} | {Title, 20} | {Description, 20} | {TeacherId, 20} |";
    }
}