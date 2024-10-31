using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentService
{
    private List<Student> students;

    public StudentService()
    {
        // Initialize the list of students
        students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Alice Smith",
                Grades = new List<Grade>
                {
                    new Grade { AssignmentNumber = 1, Score = 85 },
                    new Grade { AssignmentNumber = 2, Score = 90 },
                }
            },
            new Student
            {
                Id = 2,
                Name = "Bob Johnson",
                Grades = new List<Grade>
                {
                    new Grade { AssignmentNumber = 1, Score = 75 },
                    new Grade { AssignmentNumber = 2, Score = 80 },
                }
            }
        };
    }

    public Task<List<Student>> GetStudentsAsync()
    {
        return Task.FromResult(students);
    }
}
