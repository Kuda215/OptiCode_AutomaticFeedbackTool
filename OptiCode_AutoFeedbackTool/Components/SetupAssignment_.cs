
using System.ComponentModel.DataAnnotations;

public class SetupAssignment_
{
    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public string Description { get; set; }

    public Requirements Requirements { get; set; } = new Requirements();
}