namespace UniversityDimDimich2.Models;

public class Student : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; init; }
    public string Department { get; init; }
    public DateTime DateOfBirth { get; init; }

    public override string ToString()
    {
        return $"|{Id, 5} | {Name, 20} | {Surname, 20} | {Department, 20} | {DateOfBirth, 20} |";
    }
} 