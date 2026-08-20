using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class TechnologiesController : Controller
    {
        private readonly AppDbContext _context;

        public TechnologiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Technologies
        // Use Case: معرفة جميع التقنيات الموجودة في النظام
        public IActionResult Index()
        {
            var technologies = _context.Technologies
                .Include(t => t.Projects)
                .OrderBy(t => t.Name)
                .ToList();

            return View(technologies);
        }

        // GET: /Technologies/Create
        // Use Case: إنشاء تقنية جديدة
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Technology technology)
        {
            if (ModelState.IsValid)
            {
                _context.Technologies.Add(technology);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // GET: /Technologies/Edit/5
        public IActionResult Edit(int id)
        {
            var technology = _context.Technologies.Find(id);

            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        [HttpPost]
        public IActionResult Edit(Technology technology)
        {
            if (ModelState.IsValid)
            {
                _context.Technologies.Update(technology);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(technology);
        }

        // POST: /Technologies/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var technology = _context.Technologies.Find(id);

            if (technology == null)
            {
                return NotFound();
            }

            _context.Technologies.Remove(technology);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        

        public IActionResult TechnologyProjects(int id)
        {      
                var technologyprojects = _context.Projects.Where(p =>p.Technologies.Any(T=>T.Id ==id))
                .Include(p => p.Category)
                 .Include(p => p.Technologies)
                 .Include(p => p.ProjectDetails)
                 .ToList();
              
            return View(technologyprojects.ToList());
        }
    }
}