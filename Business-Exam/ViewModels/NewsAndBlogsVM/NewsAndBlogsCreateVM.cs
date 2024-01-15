using System.ComponentModel.DataAnnotations;

namespace Business_Exam.ViewModels.NewsAndBlogsViewModel
{
    public class NewsAndBlogsCreateVM
    {
        [Required]
        public IFormFile Image{ get; set; }
        public string ImageTitle { get; set; }
        [Required, MaxLength(64)]
        public string Heading { get; set; }
        [Required, MaxLength(128)]
        public string Description { get; set; }
    }
}
