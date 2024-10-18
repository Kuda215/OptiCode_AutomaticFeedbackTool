using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OptiCode_AutoFeedbackTool.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Column("Role")]
        [MaxLength(15)]
        public string? Role { get; set; }

        [Column("Surname")]
        [MaxLength(100)]
        public string? Surname { get; set; }

        [Column("Student_number")]
        [MaxLength(20)]
        public string? StudentNumber { get; set; }

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; }

        [Column("LastLogin")]
        public DateTime? LastLogin { get; set; }

    }
}
