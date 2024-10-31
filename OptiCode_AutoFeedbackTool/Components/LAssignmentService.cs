public class LAssignmentService
{
    // Sample data
    private List<LAssignment> assignments = new List<LAssignment>
    {
        new LAssignment { AssignmentNumber = 1, Topic = "Introduction to Programming", DueDate = DateTime.Now.AddDays(7), SubmissionCount = 10, AverageGrade = 85.0 },
        new LAssignment { AssignmentNumber = 2, Topic = "Data Structures", DueDate = DateTime.Now.AddDays(14), SubmissionCount = 8, AverageGrade = 78.5 }
    };

    public Task<List<LAssignment>> GetAssignmentsAsync()
    {
        return Task.FromResult(assignments);
    }
}
