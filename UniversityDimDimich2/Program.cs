using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using Npgsql.Replication.PgOutput.Messages;

class Program
{
    private static string _connectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    static void Main(string[] args)
    {
        CreateTables();

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
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

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
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateTables()
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        ID SERIAL PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL,
                        Surname VARCHAR(100) NOT NULL,
                        Department VARCHAR(100) NOT NULL,
                        DateOfBirth DATE NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Teachers (
                        ID SERIAL PRIMARY KEY,
                        Name VARCHAR(100) NOT NULL,
                        Surname VARCHAR(100) NOT NULL,
                        Department VARCHAR(100) NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Courses (
                        ID SERIAL PRIMARY KEY,
                        Title VARCHAR(100) NOT NULL,
                        Description TEXT,
                        TeacherID INT REFERENCES Teachers(ID)
                    );

                    CREATE TABLE IF NOT EXISTS Exams (
                        ID SERIAL PRIMARY KEY,
                        Date DATE NOT NULL,
                        CourseID INT REFERENCES Courses(ID),
                        MaxScore INT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Grades (
                        ID SERIAL PRIMARY KEY,
                        StudentID INT REFERENCES Students(ID),
                        ExamID INT REFERENCES Exams(ID),
                        Score INT NOT NULL
                    );";
                cmd.ExecuteNonQuery();
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

        string choice = Console.ReadLine();

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
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter student surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter student department: ");
        string department = Console.ReadLine();
        Console.Write("Enter student date of birth (yyyy-mm-dd): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Students (Name, Surname, Department, DateOfBirth) VALUES (@name, @surname, @department, @dateOfBirth)";
 cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("department", department);
                cmd.Parameters.AddWithValue("dateOfBirth", dateOfBirth);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Student added");
    }

    static void AddTeacher()
    {
        Console.Write("Enter teacher name: ");
        string name = Console.ReadLine();
        Console.Write("Enter teacher surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter teacher department: ");
        string department = Console.ReadLine();

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Teachers (Name, Surname, Department) VALUES (@name, @surname, @department)";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("department", department);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Teacher added");
    }

    static void AddCourse()
    {
        Console.Write("Enter course title: ");
        string title = Console.ReadLine();
        Console.Write("Enter course description: ");
        string description = Console.ReadLine();
        Console.Write("Enter teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Courses (Title, Description, TeacherID) VALUES (@title, @description, @teacherID)";
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("teacherID", teacherId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Course added");
    }

    static void AddExam()
    {
        Console.Write("Enter exam date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());
        Console.Write("Enter max score: ");
        int maxScore = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Exams (Date, CourseID, MaxScore) VALUES (@date, @courseID, @maxScore)";
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("courseID", courseId);
                cmd.Parameters.AddWithValue("maxScore", maxScore);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Exam added");
    }

    static void AddGrade()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter exam ID: ");
        int examId = int.Parse(Console.ReadLine());
        Console.Write("Enter score: ");
        int score = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Grades (StudentID, ExamID, Score) VALUES (@studentID, @examID, @score)";
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.Parameters.AddWithValue("examID", examId);
                cmd.Parameters.AddWithValue("score", score);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Grade added");
    }

    static void UpdateRecord()
    {
        Console.WriteLine("What type of record do you want to update?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Course");
        Console.WriteLine("4. Exam");
        Console.WriteLine("5. Grade");

        string choice = Console.ReadLine();

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
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void UpdateStudent()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter new student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter new student surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter new student department: ");
        string department = Console.ReadLine();
        Console.Write("Enter new student date of birth (yyyy-mm-dd): ");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Students SET Name = @name, Surname = @surname, Department = @department, DateOfBirth = @dateOfBirth WHERE ID = @studentID";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("department", department);
                cmd.Parameters.AddWithValue("dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Student updated");
    }

    static void UpdateTeacher()
    {
        Console.Write("Enter teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());
        Console.Write("Enter new teacher name: ");
        string name = Console.ReadLine();
        Console.Write("Enter new teacher surname: ");
        string surname = Console.ReadLine();
        Console.Write("Enter new teacher department: ");
        string department = Console.ReadLine();

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Teachers SET Name = @name, Surname = @surname, Department = @department WHERE ID = @teacherID";
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("department", department);
                cmd.Parameters.AddWithValue("teacherID", teacherId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Teacher updated");
    }

    static void UpdateCourse()
    {
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());
        Console.Write("Enter new course title: ");
        string title = Console.ReadLine();
        Console.Write("Enter new course description: ");
        string description = Console.ReadLine();
        Console.Write("Enter new teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Courses SET Title = @title, Description = @description, TeacherID = @teacherID WHERE ID = @courseID";
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("description", description);
                cmd.Parameters.AddWithValue("teacherID", teacherId);
                cmd.Parameters.AddWithValue("courseID", courseId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Course updated");
    }

    static void UpdateExam()
    {
        Console.Write("Enter exam ID: ");
        int examId = int.Parse(Console.ReadLine());
        Console.Write("Enter new exam date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter new course ID: ");
        int courseId = int.Parse(Console.ReadLine());
        Console.Write("Enter new max score: ");
        int maxScore = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Exams SET Date = @date, CourseID = @courseID, MaxScore = @maxScore WHERE ID = @examID";
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("courseID", courseId);
                cmd.Parameters.AddWithValue("maxScore", maxScore);
                cmd.Parameters.AddWithValue("examID", examId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Exam updated");
    }

    static void UpdateGrade()
    {
        Console.Write("Enter grade ID: ");
        int gradeId = int.Parse(Console.ReadLine());
        Console.Write("Enter new student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter new exam ID: ");
        int examId = int.Parse(Console.ReadLine());
        Console.Write("Enter new score: ");
        int score = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Grades SET StudentID = @studentID, ExamID = @examID, Score = @score WHERE ID = @gradeID";
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.Parameters.AddWithValue("examID", examId);
                cmd.Parameters.AddWithValue("score", score);
                cmd.Parameters.AddWithValue("gradeID", gradeId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Grade updated");
    }

    static void DeleteRecord()
    {
        Console.WriteLine("What type of record do you want to delete?");
        Console.WriteLine("1. Student");
        Console.WriteLine("2. Teacher");
        Console.WriteLine("3. Course");
        Console.WriteLine("4. Exam");
        Console.WriteLine("5. Grade");

        string choice = Console.ReadLine();

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
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Students WHERE ID = @studentID";
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Student deleted");
    }

    static void DeleteTeacher()
    {
        Console.Write("Enter teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Teachers WHERE ID = @teacherID";
                cmd.Parameters.AddWithValue("teacherID", teacherId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Teacher deleted");
    }

    static void DeleteCourse()
    {
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Courses WHERE ID = @courseID";
                cmd.Parameters.AddWithValue("courseID", courseId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Course deleted");
    }

    static void DeleteExam()
    {
        Console.Write("Enter exam ID: ");
        int examId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Exams WHERE ID = @examID";
                cmd.Parameters.AddWithValue("examID", examId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Exam deleted");
    }

    static void DeleteGrade()
    {
        Console.Write("Enter grade ID: ");
        int gradeId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Grades WHERE ID = @gradeID";
                cmd.Parameters.AddWithValue("gradeID", gradeId);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Grade deleted");
    }

    static void GetStudentsByDepartment()
    {
        Console.Write("Enter department: ");
        string department = Console.ReadLine();

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Students WHERE Department = @department";
                cmd.Parameters.AddWithValue("department", department);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Department: {reader["Department"]}, DateOfBirth: {reader["DateOfBirth"]}");
                    }
                }
            }
        }
    }

    static void GetCoursesByTeacher()
    {
        Console.Write("Enter teacher ID: ");
        int teacherId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Courses WHERE TeacherID = @teacherID";
                cmd.Parameters.AddWithValue("teacherID", teacherId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Title: {reader["Title"]}, Description: {reader["Description"]}, TeacherID: {reader["TeacherID"]}");
                    }
                }
            }
        }
    }

    static void GetStudentsEnrolledInCourse()
    {
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT s.* 
                    FROM Students s 
                    JOIN Grades g ON s.ID = g.StudentID 
                    JOIN Exams e ON g.ExamID = e.ID 
                    WHERE e.CourseID = @courseID";
                cmd.Parameters.AddWithValue("courseID", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Department: {reader["Department"]}, DateOfBirth: {reader["DateOfBirth"]}");
                    }
                }
            }
        }
    }

    static void GetStudentGradesForCourse()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT g.Score, e.Date 
                    FROM Grades g 
                    JOIN Exams e ON g.ExamID = e.ID 
                    WHERE g.StudentID = @studentID AND e.CourseID = @courseID";
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.Parameters.AddWithValue("courseID", courseId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Score: {reader["Score"]}, Exam Date: {reader["Date"]}");
                    }
                }
            }
        }
    }

    static void GetStudentAverageGradeForCourse()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());
        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT AVG(g.Score) 
                    FROM Grades g 
                    JOIN Exams e ON g.ExamID = e.ID 
                    WHERE g.StudentID = @studentID AND e.CourseID = @courseID";
                cmd.Parameters.AddWithValue("studentID", studentId);
                cmd.Parameters.AddWithValue("courseID", courseId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine($"Average grade: {result}");
                }
                else
                {
                    Console.WriteLine("No grades found.");
                }
            }
        }
    }

    static void GetStudentOverallAverageGrade()
    {
        Console.Write("Enter student ID: ");
        int studentId = int.Parse(Console.ReadLine());

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT AVG(g.Score) FROM Grades g WHERE g.StudentID = @studentID";
                cmd.Parameters.AddWithValue("studentID", studentId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine($"Overall average grade: {result}");
                }
                else
                {
                    Console.WriteLine("No grades found.");
                }
            }
        }
    }

    static void GetDepartmentAverageGrade()
    {
        Console.Write("Enter department: ");
        string department = Console.ReadLine();

        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
                    SELECT AVG(g.Score) 
                    FROM Grades g 
                    JOIN Students s ON g.StudentID = s.ID 
                    WHERE s.Department = @department";
                cmd.Parameters.AddWithValue("department", department);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    Console.WriteLine($"Department average grade: {result}");
                }
                else
                {
                    Console.WriteLine("No grades found.");
                }
            }
        }
    }
}