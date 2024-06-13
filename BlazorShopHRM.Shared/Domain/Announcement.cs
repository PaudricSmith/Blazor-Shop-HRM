using System.ComponentModel.DataAnnotations;


namespace BlazorShopHRM.Shared.Domain
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title length cannot exceed 100 characters!")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(5000, ErrorMessage = "Content length cannot exceed 5000 characters!")]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime DatePosted { get; set; }
    }
}
