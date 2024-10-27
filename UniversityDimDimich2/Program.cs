using Npgsql;
using UniversityDimDimich2.Models;
using UniversityDimDimich2.Repositories.Implementations;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2;

class Program
{
    private static IStudentRepository _studentRepository = new StudentRepository();
    private static ITeacherRepository _teacherRepository = new TeacherRepository();
    private static ICourseRepository _courseRepository = new CourseRepository();
    private static IExamRepository _examRepository = new ExamRepository();
    private static IGradeRepository _gradeRepository = new GradeRepository();
    private static IGeneralDbRepository _generalDbRepository = new GeneralDbRepository();
    
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nUniversity Database Management System");
            Console.WriteLine("1. Add new record");
            Console.WriteLine("2. Update record");
            Console.WriteLine("3. Delete record");
            Console.WriteLine("4. Get students by department");
            Console.WriteLine("5. Get courses by teacher");
            Console.WriteLine("6. Get students enrolled in a course");
            Console.WriteLine("7. Get student grades for a course");
            Console.WriteLine("8. Get student average grade for a course");
            Console.WriteLine("9. Get student overall average grade");
            Console.WriteLine("10. Get department average grade");
            Console.WriteLine("157. Create new database");
            Console.WriteLine("159. Create new database");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewRecord();
                    break;
                case "2":
                    UpdateRecord();
                    break;
                case "3":
                    DeleteRecord();
                    break;
                case "4":
                    GetStudentsByDepartment();
                    break;
                case "5":
                    GetCoursesByTeacher();
                    break;
                case "6":
                    GetStudentsEnrolledInCourse();
                    break;
                case "7":
                    GetStudentGradesForCourse();
                    break;
                case "8":
                    GetStudentAverageGradeForCourse();
                    break;
                case "9":
                    GetStudentOverallAverageGrade();
                    break;
                case "10":
                    GetDepartmentAverageGrade();
                    break;
                case "157":
                    _generalDbRepository.CreateDatabase();
                    break;
                case "159":
                    _generalDbRepository.CreateTables();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    
    static void AddNewRecord()
    {
        Console.WriteLine("What type of record do you want to add?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Course");
        Console.WriteLine("4. Exam");
        Console.WriteLine("5. Grade");
        Console.WriteLine("0. Exit");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddStudent();
                break;
            case "2":
                AddTeacher();
                break;
            case "3":
                AddCourse();
                break;
            case "4":
                AddExam();
                break;
            case "5":
                AddGrade();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void AddStudent()
    {
        try
        {
            Console.Write("Enter student name: ");
            var name = Console.ReadLine();
            Console.Write("Enter student surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter student department: ");
            var department = Console.ReadLine();
            Console.Write("Enter student date of birth (yyyy-mm-dd): ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());
            
            var student = new Student
            {
                Name = name, 
                Surname = surname, 
                Department = department,
                DateOfBirth = dateOfBirth
            };
            
            _studentRepository.Add(student);
            Console.WriteLine("Student added");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding student: " + ex.Message);
        }
    }

    static void AddTeacher()
    {
        try
        {
            Console.Write("Enter teacher name: ");
            var name = Console.ReadLine();
            Console.Write("Enter teacher surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter teacher department: ");
            var department = Console.ReadLine();

            var teacher = new Teacher
            {
                Name = name, 
                Surname = surname, 
                Department = department,
            };
            
            _teacherRepository.AddTeacher(teacher);
            Console.WriteLine("Teacher added");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding teacher: " + ex.Message);
        }
    }

    static void AddCourse()
    {
        try
        {
            Console.Write("Enter course title: ");
            var title = Console.ReadLine();
            Console.Write("Enter course description: ");
            var description = Console.ReadLine();
            Console.Write("Enter teacher ID: ");
            var teacherId = int.Parse(Console.ReadLine());

            var course = new Courses
            {
                Title = title, 
                Description = description,
                TeacherId = teacherId
            };
            
            _courseRepository.AddCourse(course);
            Console.WriteLine("Course added");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding course: " + ex.Message);
        }
    }

    static void AddExam()
    {
        try
        {
            Console.Write("Enter exam date (yyyy-mm-dd): ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter max score: ");
            var maxScore = int.Parse(Console.ReadLine());

            var exam = new Exams
            {
                Date = date, 
                CourseId = courseId,
                MaxScore = maxScore
            };
            
            _examRepository.AddExam(exam);
            Console.WriteLine("Exam added");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding exam: " + ex.Message);
        }
    }

    static void AddGrade()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter exam ID: ");
            var examId = int.Parse(Console.ReadLine());
            Console.Write("Enter score: ");
            var score = int.Parse(Console.ReadLine());

            var grade = new Grades
            {
                StudentId = studentId,
                ExamId = examId,
                Score = score
            };
            
            _gradeRepository.AddGrade(grade);
            Console.WriteLine("Grade added");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding grade: " + ex.Message);
        }
    }

    static void UpdateRecord()
    {
        Console.WriteLine("What type of record do you want to update?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Course");
        Console.WriteLine("4. Exam");
        Console.WriteLine("5. Grade");
        Console.WriteLine("0. Exit");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                UpdateStudent();
                break;
            case "2":
                UpdateTeacher();
                break;
            case "3":
                UpdateCourse();
                break;
            case "4":
                UpdateExam();
                break;
            case "5":
                UpdateGrade();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void UpdateStudent()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter new student name: ");
            var name = Console.ReadLine();
            Console.Write("Enter new student surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter new student department: ");
            var department = Console.ReadLine();
            Console.Write("Enter new student date of birth (yyyy-mm-dd): ");
            var dateOfBirth = DateTime.Parse(Console.ReadLine());

            var student = new Student
            {
                Id = studentId,
                Name = name, 
                Surname = surname, 
                Department = department,
                DateOfBirth = dateOfBirth
            };
            
            _studentRepository.Update(student);
            Console.WriteLine("Student updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating student: " + ex.Message);
        }
    }

    static void UpdateTeacher()
    {
        try
        {
            Console.Write("Enter teacher ID: ");
            var teacherId = int.Parse(Console.ReadLine());
            Console.Write("Enter new teacher name: ");
            var name = Console.ReadLine();
            Console.Write("Enter new teacher surname: ");
            var surname = Console.ReadLine();
            Console.Write("Enter new teacher department: ");
            var department = Console.ReadLine();

            var teacher = new Teacher
            {
                Id = teacherId,
                Name = name, 
                Surname = surname, 
                Department = department,
            };
            
            _teacherRepository.UpdateTeacher(teacher);
            Console.WriteLine("Teacher updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating teacher: " + ex.Message);
        }
    }

    static void UpdateCourse()
    {
        try
        {
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter new course title: ");
            var title = Console.ReadLine();
            Console.Write("Enter new course description: ");
            var description = Console.ReadLine();
            Console.Write("Enter new teacher ID: ");
            var teacherId = int.Parse(s: Console.ReadLine());

            var course = new Courses
            {
                Id = courseId,
                Title = title, 
                Description = description,
                TeacherId = teacherId
            };
            
            _courseRepository.UpdateCourse(course);
            Console.WriteLine("Course updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating course: " + ex.Message);
        }
    }

    static void UpdateExam()
    {
        try
        {
            Console.Write("Enter exam ID: ");
            var examId = int.Parse(Console.ReadLine());
            Console.Write("Enter new exam date (yyyy-mm-dd): ");
            var date = DateTime.Parse(Console.ReadLine ());
            Console.Write("Enter new course ID: ");
            var courseId = int.Parse(Console.ReadLine());
            Console.Write("Enter new max score: ");
            var maxScore = int.Parse(Console.ReadLine());

            var exam = new Exams
            {
                Id = examId,
                Date = date, 
                CourseId = courseId,
                MaxScore = maxScore
            };
            
            _examRepository.AddExam(exam);
            Console.WriteLine("Exam updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating exam: " + ex.Message);
        }
    }

    static void UpdateGrade()
    {
        try
        {
            Console.Write("Enter grade ID: ");
            var gradeId = int.Parse(Console.ReadLine());
            Console.Write("Enter new student ID: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter new exam ID: ");
            var examId = int.Parse(Console.ReadLine());
            Console.Write("Enter new score: ");
            var score = int.Parse(Console.ReadLine());

            var grade = new Grades
            {
                Id = gradeId,
                StudentId = studentId,
                ExamId = examId,
                Score = score
            };
            
            _gradeRepository.AddGrade(grade);
            Console.WriteLine("Grade updated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating grade: " + ex.Message);
        }
    }

    static void DeleteRecord()
    {
        Console.WriteLine("What type of record do you want to delete?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Course");
        Console.WriteLine("4. Exam");
        Console.WriteLine("5. Grade");
        Console.WriteLine("0. Exit");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                DeleteStudent();
                break;
            case "2":
                DeleteTeacher();
                break;
            case "3":
                DeleteCourse();
                break;
            case "4":
                DeleteExam();
                break;
            case "5":
                DeleteGrade();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void DeleteStudent()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());

            var student = new Student
            {
                Id = studentId
            };
            
            _studentRepository.Delete(student);
            Console.WriteLine("Student deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting student: " + ex.Message);
        }
    }

    private static void DeleteTeacher()
    {
        try
        {
            Console.Write("Enter teacher ID: ");
            var teacherId = int.Parse(Console.ReadLine());

            var teacher = new Teacher
            {
                Id = teacherId
            };
            
            _teacherRepository.DeleteTeacher(teacher);
            Console.WriteLine("Teacher deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting teacher: " + ex.Message);
        }
    }

    static void DeleteCourse()
    {
        try
        {
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());

            var course = new Courses
            {
                Id = courseId
            };
            
            _courseRepository.DeleteCourse(course);
            Console.WriteLine("Course deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting course: " + ex.Message);
        }
    }

    static void DeleteExam()
    {
        try
        {
            Console.Write("Enter exam ID: ");
            var examId = int.Parse(Console .ReadLine());

            var exam = new Exams
            {
                Id = examId
            };
            
            _examRepository.DeleteExam(exam);
            Console.WriteLine("Exam deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting exam: " + ex.Message);
        }
    }

    static void DeleteGrade()
    {
        try
        {
            Console.Write("Enter grade ID: ");
            var gradeId = int.Parse(Console.ReadLine());

            var grade = new Grades
            {
                Id = gradeId
            };
            
            _gradeRepository.DeleteGrade(grade);
            Console.WriteLine("Grade deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting grade: " + ex.Message);
        }
    }

    static void PrintList<T>(List<T> objects)
    {
        foreach (var item in objects)
        {
            Console.WriteLine(item);
        }
    }

    static void GetStudentsByDepartment()
    {
        try
        {
            Console.Write("Enter department: ");
            
            var department = Console.ReadLine();
            
            var students = _studentRepository.GetStudentsByDepartmentId(department);
            PrintList(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving students by department: " + ex.Message);
        }
    }

    static void GetCoursesByTeacher()
    {
        try
        {
            Console.Write("Enter teacher ID: ");
            var teacherId = int.Parse(Console.ReadLine());
            
            var teacher = _courseRepository.GetCoursesByTeacher(teacherId);
            PrintList(teacher);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving courses by teacher: " + ex.Message);
        }
    }

    static void GetStudentsEnrolledInCourse()
    {
        try
        {
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());

           var students = _studentRepository.GetStudentsByEnrolledInCourse(courseId);
           PrintList(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving students enrolled in course: " + ex.Message);
        }
    }

    static void GetStudentGradesForCourse()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());

            var grades = _gradeRepository.GetStudentsGradesByCourseId(studentId, courseId);
            PrintList(grades);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving student grades for course: " + ex.Message);
        }
    }

    static void GetStudentAverageGradeForCourse()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter course ID: ");
            var courseId = int.Parse(Console.ReadLine());
            
            var grade = _gradeRepository.GetStudentAverageGradeByCourseId(studentId, courseId);
            Console.WriteLine($"Average grade = {grade}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving student average grade for course: " + ex.Message);
        }
    }

    static void GetStudentOverallAverageGrade()
    {
        try
        {
            Console.Write("Enter student ID: ");
            var studentId = int.Parse(Console.ReadLine());

            var grade = _gradeRepository.GetStudentAverageGradeInGeneral(studentId);
            Console.WriteLine($"Average grade = {grade}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving student overall average grade: " + ex.Message);
        }
    }

    static void GetDepartmentAverageGrade()
    {
        try
        {
            Console.Write("Enter department: ");
            var department = Console.ReadLine();

            var grade = _gradeRepository.GetDepartmentAverageGrade(department);
            Console.WriteLine($"Average grade = {grade}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving department average grade: " + ex.Message);
        }
    }
}