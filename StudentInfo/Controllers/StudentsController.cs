using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentInfo.Data;
using StudentInfo.Models;

namespace StudentInfo.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List ()
        {
            var students = await _dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student std)
        {
            var student = await _dbContext.Students.FindAsync(std.Id);

            if(student != null)
            {
                student.Name = std.Name;
                student.Email = std.Email;
                student.Phone = std.Phone;
                student.Subscribed = std.Subscribed;

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student std)
        {
            var student = await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == std.Id);
            if(student != null)
            {
                _dbContext.Students.Remove(std);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
