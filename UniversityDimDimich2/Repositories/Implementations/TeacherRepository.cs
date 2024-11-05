using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class TeacherRepository : ITeacherRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void AddTeacher(Teacher teacher)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Teachers (Name, Surname, Department) VALUES (@name, @surname, @department)";
            db.Execute(sqlQuery, new
            {
                name = teacher.Name,
                surname = teacher.Surname,
                department = teacher.Department
            });
        }
    }

    public void UpdateTeacher(Teacher teacher)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "UPDATE Teachers SET Name = @name, Surname = @surname, Department = @department WHERE ID = @teacherID";
            db.Execute(sqlQuery, new
            {
                name = teacher.Name,
                surname = teacher.Surname,
                department = teacher.Department
            });
        }
    }

    public void DeleteTeacher(Teacher teacher)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "DELETE FROM Courses WHERE ID = @courseID";
            db.Execute(sqlQuery, new
            {
                name = teacher.Name,
                surname = teacher.Surname,
                department = teacher.Department
            });
        }
    }
}