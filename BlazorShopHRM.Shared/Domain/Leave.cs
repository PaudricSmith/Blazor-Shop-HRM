using BlazorShopHRM.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorShopHRM.Shared.Domain
{
    public class Leave
    {
        public int LeaveId { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public LeaveType LeaveType { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Reason length cannot exceed 1000 characters!")]
        public string Reason { get; set; } = string.Empty;
    }
}
