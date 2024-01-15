using System.ComponentModel.DataAnnotations;

namespace Business_Exam.Models
{
    public class NewsAndBlogs
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required, MaxLength(64)]
        public string Heading { get; set; }
        [Required, MaxLength(128)]
        public string Description { get; set; }
    }
}
