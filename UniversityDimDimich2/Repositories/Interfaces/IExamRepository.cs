using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface IExamRepository
{
    void AddExam(Exams exam);
    void UpdateCourse(Exams exam);
    void DeleteExam(Exams exam);
    
}