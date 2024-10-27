using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class CourseRepository : ICourseRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void AddCourse(Courses courses)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Courses (Title, Description, TeacherID) VALUES (@title, @description, @teacherID)";
            db.Execute(sqlQuery, courses);
        }
    }

    public void UpdateCourse(Courses courses)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "UPDATE Courses SET Title = @title, Description = @description, TeacherID = @teacherID WHERE ID = @courseID";
            db.Execute(sqlQuery, courses);
        }
    }

    public void DeleteCourse(Courses courses)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "DELETE FROM Courses WHERE ID = @courseID";
            db.Execute(sqlQuery, courses);
        }
    }

    public List<Courses> GetCoursesByTeacher(int teacherId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<Courses>(
                "SELECT * FROM Courses WHERE TeacherID = @teacherID",
                new { teacherID = teacherId })
                .ToList();
        }
    }
}