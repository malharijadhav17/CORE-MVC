using CORE_MVC.Models;
using CORE_MVC.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CORE_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._context = dbContext;
            this._webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var Result = _context.Students.OrderByDescending(s => s.SId).ToList();
            return View(Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile SProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            else
            {

                if (SProfile != null)
                {
                    string UplodeFolder = Path.Combine(_webHostEnvironment.WebRootPath, "StudentProfile");
                    string UniqueFileName = Guid.NewGuid() + "-" + SProfile.FileName;
                    string FilePath = Path.Combine(UplodeFolder, UniqueFileName);
                    using (var fileStream = new FileStream(FilePath, FileMode.Create))
                    {
                        SProfile.CopyTo(fileStream);
                    }

                    student.SProfile = "/StudentProfile/" + UniqueFileName;

                }
                else
                {
                    student.SProfile = null;
                }

                student.CreatedDate = DateTime.Now;
                student.UpdatedDate = DateTime.Now;

                _context.Students.Add(student);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Result = _context.Students.Find(id);

            if(Result == null)
            {
                return RedirectToAction("Index", "Student");
            }

            ViewData["SProfile"] = Result.SProfile;

            return View(Result);
        }

        [HttpPost]
        public IActionResult Edit(Student student, IFormFile SProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            else
            {
                var data = _context.Students.AsNoTracking().FirstOrDefault(s => s.SId == student.SId);

                if (data != null)
                {
                    if (SProfile != null)
                    {
                        string UplodeFolder = Path.Combine(_webHostEnvironment.WebRootPath, "StudentProfile");
                        string UniqueFileName = Guid.NewGuid() + "-" + SProfile.FileName;
                        string FilePath = Path.Combine(UplodeFolder, UniqueFileName);
                        using (var fileStream = new FileStream(FilePath, FileMode.Create))
                        {
                            SProfile.CopyTo(fileStream);
                        }

                        student.SProfile = "/StudentProfile/" + UniqueFileName;

                    }
                    else
                    {
                        student.SProfile = data.SProfile;
                    }

                    student.UpdatedDate = DateTime.Now;
                    student.CreatedDate = data.CreatedDate;
                    student.CreatedUser = data.CreatedUser;

                    _context.Students.Update(student);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Student");
        }

        public IActionResult Delete(int id)
        {
            var Result = _context.Students.Find(id);

            if(Result != null)
            {
                _context.Students.Remove(Result);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Student");
        }

    }
}
