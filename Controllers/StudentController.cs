using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueOcktopus.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlueOcktopus.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var s = await _context.Students.ToListAsync();
            return View(s);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student s)
        {
            if (ModelState.IsValid)
            {


                await _context.Students.AddAsync(s);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");



            }
            return View(s);
        }

        public async Task<IActionResult> Update(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Student s)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(s);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(s);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Student s, int id)
        {
            var a = await _context.Students.FindAsync(id);
            if (a != null)
            {
                _context.Students.Remove(a);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var a = await _context.Students.FindAsync(id);

            return View(a);
        }


    }
}
