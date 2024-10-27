using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories;
using UniversityDimDimich2.Repositories.Implementations;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Tests;

public class UnitTest1
{
    [Fact]
    public void GetStudentsByDepartmentId_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        var departmentId = "1";
        var student = new Student()
        {
            Id = 1,
            Name = "Homer",
            Surname = "Surname",
            Department = departmentId,
            DateOfBirth = DateTime.Today.AddYears(-20)
        };
        repository.Add(student);
        var students = repository.GetStudentsByDepartmentId(departmentId);
        Assert.Single(students);
    }
}   