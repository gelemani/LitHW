using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class ExamRepository : IExamRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void AddExam(Exams exam)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Exams (Date, CourseID, MaxScore) VALUES (@date, @courseID, @maxScore)";
            db.Execute(sqlQuery, exam);
        }
    }

    public void UpdateCourse(Exams exam)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "UPDATE Exams SET Date = @date, CourseID = @courseID, MaxScore = @maxScore WHERE ID = @examID";
            db.Execute(sqlQuery, exam);
        }
    }

    public void DeleteExam(Exams exam)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "DELETE FROM Exams WHERE ID = @examID";
            db.Execute(sqlQuery, exam);
        }
    }
}