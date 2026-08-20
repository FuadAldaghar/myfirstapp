using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.Models;
namespace MyFirstApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Projects
        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Technologies)
                .Include(p => p.ProjectDetails)
                .ToList();

            return View(projects);
        }

        // GET: /Projects/Details/5
        public IActionResult Details(int id)
        {
             var projects = _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Technologies)
                .Include(p => p.ProjectDetails)
                .ToList();

            return View(projects);
          
        }

        // GET: /Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: /Projects/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // GET: /Projects/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}