using Business_Exam.Context;
using Business_Exam.Models;
using Business_Exam.ViewModels.NewsAndBlogsViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business_Exam.Controllers
{
    public class HomeController : Controller
    {
        BusinessDbContext _dbContext { get; }

        public HomeController(BusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var dataFromDb = await _dbContext.NewsAndBlogs.Select(t => new NewsAndBlogs
            {
                Heading = t.Heading,
                Description = t.Description,
                ImageUrl = t.ImageUrl,
            }).ToListAsync();

            return View(dataFromDb);
        }
    }
}