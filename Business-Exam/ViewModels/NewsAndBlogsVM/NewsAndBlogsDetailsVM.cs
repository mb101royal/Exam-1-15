using System.ComponentModel.DataAnnotations;

namespace Business_Exam.ViewModels.NewsAndBlogsViewModel
{
    public class NewsAndBlogsDetailsVM
    {
        public int Id { get; set; }
        [Required]
        public string ImageTitle{ get; set; }
        [Required, MaxLength(64)]
        public string Heading { get; set; }
        [Required, MaxLength(128)]
        public string Description { get; set; }
    }
}
