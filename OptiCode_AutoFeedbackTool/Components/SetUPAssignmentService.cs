using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SetUpAssignmentService
{
    private readonly List<SetupAssignment_> assignments = new List<SetupAssignment_>();

    public Task SaveAssignmentAsync(SetupAssignment_ assignment)
    {
        // Here, you can add logic to save the assignment to a database or any storage.
        // For simplicity, we're adding it to an in-memory list.

        assignments.Add(assignment);
        return Task.CompletedTask;
    }

    public Task<List<SetupAssignment_>> GetAssignmentsAsync()
    {
        // Return a copy of the current assignments list
        return Task.FromResult(new List<SetupAssignment_>(assignments));
    }

    public Task<SetupAssignment_> GetAssignmentByIdAsync(int id)
    {
        // Find the assignment by ID. Assuming ID is the index in the list for simplicity.
        if (id < 0 || id >= assignments.Count)
        {
            return Task.FromResult<SetupAssignment_>(null);
        }
        return Task.FromResult(assignments[id]);
    }

    public Task DeleteAssignmentAsync(int id)
    {
        // Remove the assignment by ID. 
        // In this simple implementation, we assume ID corresponds to the index in the list.
        if (id >= 0 && id < assignments.Count)
        {
            assignments.RemoveAt(id);
        }
        return Task.CompletedTask;
    }
}
