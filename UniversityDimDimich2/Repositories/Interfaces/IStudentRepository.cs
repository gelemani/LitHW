using UniversityDimDimich2.Models;

namespace UniversityDimDimich2.Repositories.Interfaces;

public interface IStudentRepository : IEntityRepositoryBase<Student>
{
    List<Student> GetStudentsByDepartmentId(string departmentId);
    List<Student> GetStudentsByEnrolledInCourse(int courseId);
}