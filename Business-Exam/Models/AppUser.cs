using Microsoft.AspNetCore.Identity;

namespace Business_Exam.Models
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}
