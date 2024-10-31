using OptiCode_AutoFeedbackTool.Components.Pages;

public class AssignmentService
{
    public async Task<List<PrevAssignment>> GetAssignmentsAsync()
    {
        return await Task.FromResult(new List<PrevAssignment>
        {
            new PrevAssignment { AssignmentNumber = 1, Topic = "Introduction to Algorithms", SubmissionDate = DateTime.Now.AddDays(-10), Grade = "A", ReportUrl = "/reports/report1.pdf" },
            new PrevAssignment { AssignmentNumber = 2, Topic = "Data Structures", SubmissionDate = DateTime.Now.AddDays(-7), Grade = "B+", ReportUrl = "/reports/report2.pdf" },
            new PrevAssignment { AssignmentNumber = 3, Topic = "Object-Oriented Programming", SubmissionDate = DateTime.Now.AddDays(-5), Grade = "A-", ReportUrl = "/reports/report3.pdf" }
        });
    }
}
