using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories;
using UniversityDimDimich2.Repositories.Implementations;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Tests;

public class StudentRepositoryTests
{
    [Fact]
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
        
        student.Name = "Obama";
        
        repository.Update(student);
        var studentFromDb = repository.GetById(student.Id); 
        Assert.True(student.Name == studentFromDb.Name);
    }

    [Fact]
    public void DeleteStudent_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        var student = new Student()
        {
            Name = "Koh",
            Surname = "Smith",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Department = "Philosophy",
        };
        repository.Add(student);
        var studentFromDb = repository.GetById(student.Id);
        Assert.True(student.Id == studentFromDb.Id);
        
        repository.Delete(student);
        studentFromDb = repository.GetById(student.Id);
        Assert.Null(studentFromDb);
    }

    [Fact]
    public void GetStudentsByDepartmentId_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        var departmentId = Random.Shared.Next(100, 501).ToString();
        var student = new Student()
        {
            Name = "Homer",
            Surname = "Surname",
            Department = departmentId,
            DateOfBirth = DateTime.Today.AddYears(-20)
        };
        
        
        repository.Add(student);
        var students = repository.GetStudentsByDepartmentId(departmentId);
        Assert.Single(students);
    }

    [Fact]
    public void GetStudentsByEnrolledInCourse_Positive()
    {
        IStudentRepository repository = new StudentRepository();
        ICourseRepository courseRepository = new CourseRepository();
        // var student = new Student()
        // {
        //     // Id = 1,
        //     Name = "Homer",
        //     Surname = "Surname",
        //     Department = "Literature",
        //     DateOfBirth = DateTime.Today.AddYears(-20)
        // };
        
        // var teacher = new Teacher()
        // {
        //     Name = "Tatyana",
        //     Surname = "Konkova",
        //     Department = "Chemistry"
        // };
        
        
        
        // add student and teacher, insert id like student, use teacher ID in course entity, i hvatit
        // other entity's ought to inharitate from entitybase
        // refacrot repository methods like student
        // poka chto hvatit
        
        
        
        
        var course = new Courses()
        {
            Title = "Literature",
            TeacherId = 1,
            Description = "Afkasflaemfkelfe",
        };
        courseRepository.AddCourse(course);
        var students = repository.GetStudentsByEnrolledInCourse(course.Id);
        Assert.Single(students);
    }
}

// public class TeacherRepositoryTests
// {
//     // [Fact]
//     public void AddTeacher_Positive()
//     {
//         ITeacherRepository repository = new TeacherRepository();
//         var teacher = new Teacher()
//         {
//             Name = "Tatyana",
//             Surname = "Konkova",
//             Department = "Chemistry"
//         };
//         repository.AddTeacher(teacher);
//     }
// }