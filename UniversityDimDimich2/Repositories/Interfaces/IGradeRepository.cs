using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface IGradeRepository
{
    void AddGrade(Grades grade);
    void UpdateGrade(Grades grade);
    void DeleteGrade(Grades grade);
    List<float> GetStudentsGradesByCourseId(int studentId, int courseId);
    float GetStudentAverageGradeByCourseId(int studentId, int courseId);
    float GetStudentAverageGradeInGeneral(int studentId);
    float GetDepartmentAverageGrade(string department);
}