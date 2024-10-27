using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface ICourseRepository
{
    void AddCourse(Courses courses);
    void UpdateCourse(Courses courses);
    void DeleteCourse(Courses courses);
    List<Courses> GetCoursesByTeacher(int teacherId);
}