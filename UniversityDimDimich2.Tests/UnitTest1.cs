using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories;
using UniversityDimDimich2.Repositories.Implementations;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Tests;

public class StudentRepositoryTests
{
    // [Fact]
    // public void GetStudentsByDepartmentId_Positive()
    // {
    //     IStudentRepository repository = new StudentRepository();
    //     var departmentId = "1";
    //     var student = new Student()
    //     {
    //         Id = 1,
    //         Name = "Homer",
    //         Surname = "Surname",
    //         Department = departmentId,
    //         DateOfBirth = DateTime.Today.AddYears(-20)
    //     };
    //     repository.Add(student);
    //     var students = repository.GetStudentsByDepartmentId(departmentId);
    //     Assert.Single(students);
    // }

    [Fact ]
    public void AddStudent_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        var student = new Student()
        {
            Name = "BEbesharky",
            Surname = "NameNogaSvelo",
            DateOfBirth = DateTime.Today.AddYears(-45),
            Department = "Philosophy",
        };
        repository.Add(student);
        var studentFromDb = repository.GetById(student.Id); 
        Assert.True(student.Id == studentFromDb.Id);
    }

    [Fact]
    public void UpdateStudent_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        var student = new Student()
        {
            Name = "BEbesharky",
            Surname = "NameNogaSvelo",
            DateOfBirth = DateTime.Today.AddYears(-45),
            Department = "Philosophy",
        };
        repository.Add(student);
        
        student = new Student()
        {
            Name = "Tim",
            Surname = "Cooked",
            DateOfBirth = DateTime.Today.AddYears(-400),
            Department = "Apples",
        };
        repository.Update(student);
        var studentFromDb = repository.GetById(student.Id); 
        Assert.True(student.Id == studentFromDb.Id);
    }
}   