using Npgsql;
using UniversityDimDimich2.Repositories.Interfaces;

namespace UniversityDimDimich2.Repositories.Implementations;

public class GeneralDbRepository : IGeneralDbRepository
{
    private static readonly string ConnectionStringPostgres = "Host=localhost;Port=5432;Username=fedor;" +
                                                              "Password=1k2j3$h4g5f6b7n-bk2L;Database=postgres;";
    private static readonly string ConnectionStringUniversity = "Host=localhost;Port=5432;Username=fedor;" +
                                                                "Password=1k2j3$h4g5f6b7n-bk2L;Database=university;";

    public void CreateDatabase()
    {
        try
        {
            // Connect to the default postgres database
            using (var conn = new NpgsqlConnection(ConnectionStringPostgres))
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

    public void CreateTables()
    {
        using (var conn = new NpgsqlConnection(ConnectionStringUniversity))
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
}