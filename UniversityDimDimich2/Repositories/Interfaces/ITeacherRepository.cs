using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface ITeacherRepository
{
    void AddTeacher(Teacher teacher);
    void UpdateTeacher(Teacher teacher);
    void DeleteTeacher(Teacher teacher);
}