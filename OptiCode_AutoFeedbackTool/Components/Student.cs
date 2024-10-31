using System.Collections.Generic;

public class Student
{
    public int Id { get; set; }             // Unique identifier for the student
    public string Name { get; set; }         // Name of the student
    public List<Grade> Grades { get; set; }  // List of grades for assignments

    public Student()
    {
        Grades = new List<Grade>();          // Initialize the grades list
    }
}

public class Grade
{
    public int AssignmentNumber { get; set; } // The assignment number
    public double Score { get; set; }         // The score received for the assignment
}
