using Npgsql;

namespace UniversityDimDimich2.UniversityDimDimich2;

class Program
{
    private static readonly string ConnectionString = "Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nUniversity Database Management System");
            Console.WriteLine("1. Create new database");
            Console.WriteLine("2. Add new record");
            Console.WriteLine("3. Update record");
            Console.WriteLine("4. Delete record");
            Console.WriteLine("5. Get students by department");
            Console.WriteLine("6. Get courses by teacher");
            Console.WriteLine("7. Get students enrolled in a course");
            Console.WriteLine("8. Get student grades for a course");
            Console.WriteLine("9. Get student average grade for a course");
            Console.WriteLine("10. Get student overall average grade");
            Console.WriteLine("11. Get department average grade");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine() ?? throw new InvalidOperationException();

            switch (choice)
            {
                case "1":
                    CreateNewDatabase();
                    break;
                case "2":
                    AddNewRecord();
                    break;
                case "3":
                    UpdateRecord();
                    break;
                case "4":
                    DeleteRecord();
                    break;
                case "5":
                    GetStudentsByDepartment();
                    break;
                case "6":
                    GetCoursesByTeacher();
                    break;
                case "7":
                    GetStudentsEnrolledInCourse();
                    break;
                case "8":
                    GetStudentGradesForCourse();
                    break;
                case "9":
                    GetStudentAverageGradeForCourse();
                    break;
                case "10":
                    GetStudentOverallAverageGrade();
                    break;
                case "11":
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
    
    // static void CreateNewDatabase()
    // {
    //     try
    //     {
    //         // Connect to the default postgres database
    //         using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=university;"))
    //         {
    //             conn.Open();
    //
    //             // Create a separate connection for termination
    //             using (var terminateConn = new NpgsqlConnection("Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=postgres;"))
    //             {
    //                 terminateConn.Open();
    //                 using (var terminateCmd = new NpgsqlCommand())
    //                 {
    //                     terminateCmd.Connection = terminateConn;
    //
    //                     // Terminate all connections to the template1 database
    //                     terminateCmd.CommandText = "SELECT pg_terminate_backend(pg_stat_activity.pid) " +
    //                                               "FROM pg_stat_activity " +
    //                                               "WHERE pg_stat_activity.datname = 'template1' " +
    //                                               "AND pid <> pg_backend_pid();";
    //                     terminateCmd.ExecuteNonQuery();
    //
    //                     // Terminate all connections to the university database
    //                     terminateCmd.CommandText = "SELECT pg_terminate_backend(pg_stat_activity.pid) " +
    //                                               "FROM pg_stat_activity " +
    //                                               "WHERE pg_stat_activity.datname = 'university' " +
    //                                               "AND pid <> pg_backend_pid();";
    //                     terminateCmd.ExecuteNonQuery();
    //                 }
    //             }
    //
    //             using (var cmd = new NpgsqlCommand())
    //             {
    //                 cmd.Connection = conn;
    //
    //                 // Drop existing database if it exists
    //                 cmd.CommandText = "DROP DATABASE IF EXISTS university;";
    //                 cmd.ExecuteNonQuery();
    //
    //                 // Create a new database
    //                 cmd.CommandText = "CREATE DATABASE university;";
    //                 cmd.ExecuteNonQuery();
    //             }
    //         }
    //         Console.WriteLine("Database deleted and new database created.");
    //         CreateTables(); // Create tables in the new database
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Error creating new database: " + ex.Message);
    //     }
    // }
        
    static void CreateNewDatabase()
    {
        try
        {
            // Connect to the default postgres database
            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=fedor;Password=1k2j3$h4g5f6b7n-bk2L;Database=postgres;"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
    
                    // Terminate all connections to the template1 database
                    cmd.CommandText = "SELECT pg_terminate_backend(pg_stat_activity.pid) " +
                                      "FROM pg_stat_activity " +
                                      "WHERE pg_stat_activity.datname = 'template1' " +
                                      "AND pid <> pg_backend_pid();";
                    cmd.ExecuteNonQuery();
    
                    // Terminate all connections to the university database
                    cmd.CommandText = "SELECT pg_terminate_backend(pg_stat_activity.pid) " +
                                      "FROM pg_stat_activity " +
                                      "WHERE pg_stat_activity.datname = 'university' " +
                                      "AND pid <> pg_backend_pid();";
                    cmd.ExecuteNonQuery();
    
                    // Drop existing database if it exists
                    cmd.CommandText = "DROP DATABASE IF EXISTS university;";
                    cmd.ExecuteNonQuery();
    
                    // Create a new database
                    cmd.CommandText = "CREATE DATABASE university;";
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Database deleted and new database created.");
            CreateTables(); // Create tables in the new database
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating new database: " + ex.Message);
        }
    }
    
    static void CreateTables()
    {
        using (var conn = new NpgsqlConnection(ConnectionString))
        {
            conn.Open();    
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = conn;
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
        Console.WriteLine("0. Exit");

        string choice = Console.ReadLine() ?? throw new InvalidOperationException();

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
            string name = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter student surname: ");
            string surname = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter student department: ");
            string department = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter student date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Students (Name, Surname, Department, DateOfBirth) VALUES (@Name, @Surname, @Department, @DateOfBirth)";
                    cmd.Parameters.AddWithValue("name", name ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("surname", surname ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("department", department ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("dateOfBirth", dateOfBirth);
                    cmd.ExecuteNonQuery();
                }
            }
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
            string name = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter teacher surname: ");
            string surname = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter teacher department: ");
            string department = Console.ReadLine() ?? throw new InvalidOperationException();

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Teachers (Name, Surname, Department) VALUES (@name, @surname, @department)";
                    cmd.Parameters.AddWithValue("name", name ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("surname", surname ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("department", department ?? throw new InvalidOperationException());
                    cmd.ExecuteNonQuery();
                }
            }
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
            string title = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter course description: ");
            string description = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter teacher ID: ");
            int teacherId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Courses (Title, Description, TeacherID) VALUES (@title, @description, @teacherID)";
                    cmd.Parameters.AddWithValue("title", title ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("description", description ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("teacherID", teacherId);
                    cmd.ExecuteNonQuery();
                }
            }
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
            DateTime date = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter course ID: ");
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter max score: ");
            int maxScore = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter exam ID: ");
            int examId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter score: ");
            int score = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Grades (StudentID, ExamID, Score) VALUES (@StudentID, @examID, @score)";
                    cmd.Parameters.AddWithValue("studentID", studentId);
                    cmd.Parameters.AddWithValue("examID", examId);
                    cmd.Parameters.AddWithValue("score", score);
                    cmd.ExecuteNonQuery();
                }
            }
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

        string choice = Console.ReadLine() ?? throw new InvalidOperationException();

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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new student name: ");
            string name = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new student surname: ");
            string surname = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new student department: ");
            string department = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new student date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int teacherId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new teacher name: ");
            string name = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new teacher surname: ");
            string surname = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new teacher department: ");
            string department = Console.ReadLine() ?? throw new InvalidOperationException();

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Teachers SET Name = @name, Surname = @surname, Department = @department WHERE ID = @teacherID";
                    cmd.Parameters.AddWithValue("name", name ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("surname", surname ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("department", department ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("teacherID", teacherId);
                    cmd.ExecuteNonQuery();
                }
            }
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
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new course title: ");
            string title = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new course description: ");
            string description = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.Write("Enter new teacher ID: ");
            int teacherId = int.Parse(s: Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Courses SET Title = @title, Description = @description, TeacherID = @teacherID WHERE ID = @courseID";
                    cmd.Parameters.AddWithValue("title", title ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("description", description ?? throw new InvalidOperationException());
                    cmd.Parameters.AddWithValue("teacherID", teacherId);
                    cmd.Parameters.AddWithValue("courseID", courseId);
                    cmd.ExecuteNonQuery();
                }
            }
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
            int examId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new exam date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine () ?? throw new InvalidOperationException());
            Console.Write("Enter new course ID: ");
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new max score: ");
            int maxScore = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int gradeId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new student ID: ");
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new exam ID: ");
            int examId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter new score: ");
            int score = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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

        string choice = Console.ReadLine() ?? throw new InvalidOperationException();

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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int teacherId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int examId = int.Parse(Console .ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
            int gradeId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
        catch (Exception ex)
        {
            Console.WriteLine("Error deleting grade: " + ex.Message);
        }
    }

    static void GetStudentsByDepartment()
    {
        try
        {
            Console.Write("Enter department: ");
            string department = Console.ReadLine() ?? throw new InvalidOperationException();

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Students WHERE Department = @department";
                    cmd.Parameters.AddWithValue("department", department ?? throw new InvalidOperationException());

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No students found in the specified department.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Department: {reader["Department"]}, DateOfBirth: {reader["DateOfBirth"]}");
                            }
                        }
                    }
                }
            }
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
            int teacherId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Courses WHERE TeacherID = @teacherID";
                    cmd.Parameters.AddWithValue("teacherID", teacherId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No courses found for the specified teacher.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, Title: {reader["Title"]}, Description: {reader["Description"]}, TeacherID: {reader["TeacherID"]}");
                            }
                        }
                    }
                }
            }
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
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No students enrolled in the specified course.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Department: {reader["Department"]}, DateOfBirth: {reader["DateOfBirth"]}");
                            }
                        }
                    }
                }
            }
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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter course ID: ");
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No grades found for the specified student and course.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Score: {reader["Score"]}, Exam Date: {reader["Date"]}");
                            }
                        }
                    }
                }
            }
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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("Enter course ID: ");
            int courseId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
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

                    object? result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine("No grades found for the specified student and course.");
                    }
                    else
                    {
                        Console.WriteLine($"Average grade: {result}");
                    }
                }
            }
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
            int studentId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT AVG(g.Score) FROM Grades g WHERE g.StudentID = @studentID";
                    cmd.Parameters.AddWithValue("studentID", studentId);

                    object? result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine("No grades found for the specified student.");
                    }
                    else
                    {
                        Console.WriteLine($"Overall average grade: {result}");
                    }
                }
            }
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
            string department = Console.ReadLine() ?? throw new InvalidOperationException();

            using (var conn = new NpgsqlConnection(ConnectionString))
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
                    cmd.Parameters.AddWithValue("department", department ?? throw new InvalidOperationException());

                    object? result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine("No grades found for the specified department.");
                    }
                    else
                    {
                        Console.WriteLine($"Department average grade: {result}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error retrieving department average grade: " + ex.Message);
        }
    }
}