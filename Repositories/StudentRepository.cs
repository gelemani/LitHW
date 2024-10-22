using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories;

public class StudentRepository : IStudentRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void AddStudent(Student student)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Students (Name, Surname, Department, DateOfBirth) VALUES (@Name, @Surname, @Department, @DateOfBirth)";
            db.Execute(sqlQuery, student);
        }
    }

    public void UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public List<Student> GetStudentsByDepartmentId(int departmentId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<Student>("SELECT * FROM Students WHERE Department = @department", new { departmentId })
                .ToList();
        }
    }

    public void GetStudentsByEnrolledInCourse(int courseId)
    {
        throw new NotImplementedException();
    }

    public void GetStudentGradesByCourseId(Student student, int courseId)
    {
        throw new NotImplementedException();
    }

    public void GetStudentAverageGradeByCourseId(Student student, int courseId)
    {
        throw new NotImplementedException();
    }

    public void GetStudentOverallAverageGradeByCourseId(Student student, int courseId)
    {
        throw new NotImplementedException();
    }
}