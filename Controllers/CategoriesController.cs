using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Categories
        // Use Case: معرفة جميع التصنيفات الموجودة في النظام
        public IActionResult Index()
        {
            var categories = _context.Categories
                .Include(c => c.Projects)
                .OrderBy(c => c.Name)
                .ToList();

            return View(categories);
        }
        //  [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // [HttpPost]
        public IActionResult Create(Category category)
        {
            // if(ModelState.IsValid)
            // {
            // _context.Categories.Add(category);
            // _context.SaveChanges();
            // return RedirectToAction(nameof(Index));
            // }
            // return View(category);

            return RedirectToAction(nameof(Index));
        }



        // GET: /Categories/Details/5
        // (لتنفيذ "اختيار أحدها لإجراء عملية أخرى" - use case قادم)
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: /Categories/Edit/5
        // (لتنفيذ "اختيار أحدها لإجراء عملية أخرى" - use case قادم)
        public IActionResult Edit(int id)
        {

            return View();
        }



        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
