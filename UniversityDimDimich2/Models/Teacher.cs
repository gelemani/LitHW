namespace UniversityDimDimich2.Models;

public class Teacher
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Department { get; init; }

    public override string ToString()
    {
        return $"|{Id, 5} | {Name, 20} | {Surname, 20} | {Department, 20} |";
    }
}