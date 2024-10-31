public class LAssignment
{
    public int AssignmentNumber { get; set; }
    public string Topic { get; set; }
    public DateTime DueDate { get; set; }
    public int SubmissionCount { get; set; }
    public double AverageGrade { get; set; }
    public string Status { get; set; } = "Open";
}
