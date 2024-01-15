using Business_Exam.Context;
using Business_Exam.Models;
using Business_Exam.ViewModels.NewsAndBlogsViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Business_Exam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsAndBlogsController : Controller
    {
        BusinessDbContext _dbContext { get; }

        public NewsAndBlogsController(BusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _dbContext.NewsAndBlogs.Select(t => new NewsAndBlogsDetailsVM
            {
                Id = t.Id,
                Description = t.Description,
                Heading = t.Heading,
                ImageTitle = t.ImageUrl
            }).ToListAsync();

            return View(data);
        }

        [Authorize(Roles = "GrandMaster,SuperAdmin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "GrandMaster,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(NewsAndBlogsCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new(vm.Image.FileName);
            string fileName = vm.ImageTitle + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (FileStream stream = new(fileNameWithPath, FileMode.Create))
            {
                vm.Image.CopyTo(stream);
            }

            NewsAndBlogs newNewsAndBlogs = new()
            {
                Heading = vm.Heading,
                Description = vm.Description,
                ImageUrl = fileName,
            };

            await _dbContext.AddAsync(newNewsAndBlogs);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "GrandMaster,SuperAdmin")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            return View();
        }

        [Authorize(Roles = "GrandMaster,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, NewsAndBlogsUpdateVM vm)
        {
            if (id == null || id < 1) return BadRequest();

            var dataFromDb = await _dbContext.NewsAndBlogs.FindAsync(id);

            if (dataFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(vm);

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new(vm.Image.FileName);
            string fileName = vm.ImageTitle + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                vm.Image.CopyTo(stream);
            }

            NewsAndBlogs editedNewsAndBlogs = new()
            {
                Heading = vm.Heading,
                Description = vm.Description,
                ImageUrl= fileName,
            };

            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "GrandMaster,SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            var dataFromDb = await _dbContext.NewsAndBlogs.FindAsync(id);

            if (dataFromDb == null) return NotFound();

            //without image file :(
            _dbContext.Remove(dataFromDb);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
