using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class StudentRepository : IStudentRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void Add(Student student)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Students (Name, Surname, Department, DateOfBirth) VALUES (@Name, @Surname, @Department, @DateOfBirth)";
            db.Execute(sqlQuery, student);
        }
    }

    public void Update(Student student)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "UPDATE Students SET Name = @name, Surname = @surname, Department = @department, DateOfBirth = @dateOfBirth WHERE ID = @studentID";
            db.Execute(sqlQuery, student);
        }
    }

    public void Delete(Student student)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "DELETE FROM Students WHERE ID = @studentID";
            db.Execute(sqlQuery, student);
        }
    }

    public List<Student> GetEntities()
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "Select * from Students";
            return db.Query<Student>(sqlQuery).ToList();
        }
    }
    
    public List<Student> GetStudentsByDepartmentId(string departmentId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<Student>("SELECT * FROM Students WHERE Department = @departmentId", 
                    new { departmentId })
                .ToList();
        }
    }

    public List<Student> GetStudentsByEnrolledInCourse(int courseId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<Student>(
                    "SELECT s.* " +
                    "FROM Students s " +
                    "JOIN Grades g ON s.ID = g.StudentID " +
                    "JOIN Exams e ON g.ExamID = e.ID " +
                    "WHERE e.CourseID = @courseId", 
                    new { courseId })
                .ToList();
        }
    }

    public List<float> GetStudentGradesByCourseId(Student student, int courseId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<float>(
                    "SELECT g.Grade " + 
                    "FROM Students s " +
                    "JOIN Grades g ON s.ID = g.StudentID " +
                    "JOIN Exams e ON g.ExamID = e.ID " +
                    "WHERE e.CourseID = @courseId AND s.ID = @studentId",
                    new { courseId, studentId = student }) 
                .ToList();
        }
    }
}