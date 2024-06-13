using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorShopHRM.Shared.Domain
{
    public class PerformanceReview
    {
        public int PerformanceReviewId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Comments length cannot exceed 2000 characters!")]
        public string Comments { get; set; } = string.Empty;

        [Required]
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5!")]
        public double Score { get; set; }
    }
}
