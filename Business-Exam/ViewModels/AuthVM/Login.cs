using System.ComponentModel.DataAnnotations;

namespace Business_Exam.ViewModels.AuthVM
{
    public class Login
    {
        [Required, MaxLength(64)]
        public string UsernameOrEmail { get; set; }
        [Required, MinLength(6), MaxLength(64), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$")]
        public string Password { get; set; }
    }
}
