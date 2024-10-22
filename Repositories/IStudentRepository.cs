using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories;

public interface IStudentRepository
{
    void AddStudent(Student student);
    void UpdateStudent(Student student);
    void DeleteStudent(Student student);
    List<Student> GetStudentsByDepartmentId(int departmentId);
    void GetStudentsByEnrolledInCourse(int courseId);
    void GetStudentGradesByCourseId(Student student, int courseId);
    void GetStudentAverageGradeByCourseId(Student student, int courseId);
    void GetStudentOverallAverageGradeByCourseId(Student student, int courseId);
}