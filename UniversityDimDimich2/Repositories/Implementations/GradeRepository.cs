using System.Data;
using Dapper;
using Npgsql;
using UniversityDimDimich2.DTOs;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class GradeRepository : IGradeRepository
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;" +
                                                      "Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void AddGrade(Grades grade)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "INSERT INTO Grades (StudentID, ExamID, Score) VALUES (@StudentID, @examID, @score)";
            db.Execute(sqlQuery, new
            {
                studentId = grade.StudentId,
                examId = grade.ExamId,
                score = grade.Score
            });
        }
    }

    public void UpdateGrade(Grades grade)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = @"UPDATE Grades SET StudentID = @studentID, ExamID = @examID, Score = @score 
                WHERE ID = @gradeID";
            db.Execute(sqlQuery, new
            {
                studentID = grade.StudentId,
                score = grade.Score,
                gradeID = grade.StudentId
            });
        }
    }

    void IGradeRepository.DeleteGrade(Grades grade)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "DELETE FROM Grades WHERE ID = @gradeId";

            db.Execute(sqlQuery, new
            {
                gradeId = grade.Id
            });
        }
    }
    

    public List<StudentExamGradeDto> GetStudentsGradesByCourseId(int studentId, int courseId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            return db.Query<StudentExamGradeDto>(@"
                    SELECT s.Id, s.Surname, c.Title, g.Grade, e.Date 
                    FROM Students s 
                    JOIN Grades g ON s.ID = g.StudentID  
                    JOIN Exams e ON g.ExamID = e.ID  
                    JOIN Course c ON c.ID = e.CourseID
                    WHERE e.CourseID = @courseId AND s.ID = @studentId",
                    new { studentId, courseId }) 
                .ToList();
        }
    }

    public float GetStudentAverageGradeByCourseId(int studentId, int courseId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = @"
                        SELECT AVG(g.Score) 
                        FROM Grades g 
                        JOIN Exams e ON g.ExamID = e.ID 
                        WHERE g.StudentID = @studentID AND e.CourseID = @courseID";
            return db.Query<float>(sqlQuery, new { studentId, courseId }).FirstOrDefault();
        }
    }

    public float GetStudentAverageGradeInGeneral(int studentId)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = "SELECT AVG(g.Score) FROM Grades g WHERE g.StudentID = @studentId";
            return db.Query<float>(sqlQuery, new{studentId}).FirstOrDefault();
        }
    }

    public float GetDepartmentAverageGrade(string department)
    {
        using (IDbConnection db = new NpgsqlConnection(ConnectionString))
        {
            var sqlQuery = @"
                        SELECT AVG(g.Score) 
                        FROM Grades g 
                        JOIN Students s ON g.StudentID = s.ID 
                        WHERE s.Department = @department";
            return db.Query<float>(sqlQuery, new {department}).FirstOrDefault();
        }
    }
}