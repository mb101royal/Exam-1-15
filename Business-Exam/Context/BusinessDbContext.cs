using Business_Exam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business_Exam.Context
{
    public class BusinessDbContext : IdentityDbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options) { }

        public DbSet<NewsAndBlogs> NewsAndBlogs { get; set; }
    }
}
