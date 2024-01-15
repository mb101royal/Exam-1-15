using System.ComponentModel.DataAnnotations;

namespace Business_Exam.ViewModels.AuthVM
{
    public class Register
    {
        [Required, MaxLength(128)]
        public string Fullname { get; set; }
        [Required, MaxLength(64)]
        public string UsernameOrEmail { get; set; }
        [Required, MinLength(6), MaxLength(64), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$")]
        public string Password { get; set; }
        [Required, MinLength(6), MaxLength(64), RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,}$"), Compare("PasswordConfirmed"),]
        public string PasswordConfirmed { get; set; }
    }
}
