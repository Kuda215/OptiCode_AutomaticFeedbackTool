public class PrevAssignment
{
    public int AssignmentNumber { get; set; }  // Unique identifier for the assignment
    public string Topic { get; set; }            // Topic or title of the assignment
    public DateTime SubmissionDate { get; set; } // Date the assignment was submitted
    public string Grade { get; set; }             // Grade awarded for the assignment
    public string ReportUrl { get; set; }        // URL for downloading the assignment report
}