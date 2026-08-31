using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.Models;
using MyFirstApp.Services;
namespace MyFirstApp.Controllers
{
    public class ProjectsController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly ProjectService _projectService;
        //private readonly ProjectService _projectService2;
        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
            //_projectService2 = projectService2;
        }

        //public ProjectsController(AppDbContext context)
        //{
        //    _context = context;
        //     _projectService = new ProjectService(context);
        //}

        // GET: /Projects
        public IActionResult Index()
        {
            //Console.WriteLine($"Service_______________________________________________________________________1: {_projectService.Id}");
            //Console.WriteLine($"Sece_______________________________________________________________________2: {_projectService2.Id}");
            var projects = _projectService.GetAllProjects();
            return View(projects);
        }

     
        public IActionResult Details(int id)
        {

            //   return  View("Index");
            var project = _projectService.GetProjectById(id);



            return View(project);
          
        }

     [HttpGet]
public IActionResult Create()
{
            //ViewBag.Categories = new SelectList(
            //    _context.Categories,
            //    "Id",
            //    "Name"
            //);
            //ViewBag.Technologies = new SelectList(
            //    _context.Technologies,
            //    "Id",
            //    "Name"
            //);
            ViewBag.Categories = new SelectList(_projectService.GetCategories(), "Id", "Name");
            ViewBag.Technologies = new SelectList(_projectService.GetTechnologies(), "Id", "Name");


            return View();
}
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Project project, int[] technologyIds)
{


            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_projectService.GetCategories(), "Id", "Name");
                ViewBag.Technologies = new SelectList(_projectService.GetTechnologies(), "Id", "Name");

                return View(project);
            }
            _projectService.CreateProject(project, technologyIds);

    //project.ProjectDetails ??= new ProjectDetails();

    //var technologies = _context.Technologies
    //    .Where(t => technologyIds.Contains(t.Id))
    //    .ToList();

    //project.Technologies = technologies;

    //_context.Projects.Add(project);

    //_context.SaveChanges();

    return RedirectToAction(nameof(Index));
}



        // GET: /Projects/Edit/5
        public IActionResult Edit(int id)
        {
            //var project=_context.Projects
            //.Include(p => p.Category)
            // .Include(p => p.Technologies)
            // .Include(p => p.ProjectDetails)
            // .Where(p => p.Id == id)
            // .FirstOrDefault();
            var project = _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            ViewBag.Categories =new SelectList(_projectService.GetCategories(), "Id", "Name");

            ViewBag.Technologies =new SelectList(_projectService.GetTechnologies(), "Id", "Name");

            return View(project);
        }
        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Project project, int[] technologyIds)
{
    if (!ModelState.IsValid)
    {
                //ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
                //ViewBag.Technologies = new SelectList(_context.Technologies, "Id", "Name");
                ViewBag.Categories = new SelectList(_projectService.GetCategories(), "Id", "Name");

                ViewBag.Technologies = new SelectList(_projectService.GetTechnologies(), "Id", "Name");
                return View(project);
    }
    if(!_projectService.UpdateProject(project, technologyIds))
            {
                return NotFound();
            }

    //var existingProject = _context.Projects
    //    .Include(p => p.Technologies)
    //    .Include(p => p.ProjectDetails)
    //    .FirstOrDefault(p => p.Id == project.Id);

    //if (existingProject == null)
    //{
    //    return NotFound();
    //}

    //// Update simple properties
    //existingProject.Name = project.Name;
    //existingProject.Description = project.Description;
    //existingProject.GitHubUrl = project.GitHubUrl;
    //existingProject.CategoryId = project.CategoryId;
    //existingProject.IsPublic = project.IsPublic;
    //existingProject.ProjectType = project.ProjectType;
    //existingProject.License = project.License;
    //existingProject.TechnologiesCount = project.TechnologiesCount;

    //// Update ProjectDetails
    //existingProject.ProjectDetails ??= new ProjectDetails();
    //existingProject.ProjectDetails.Client = project.ProjectDetails.Client;
    //existingProject.ProjectDetails.StartDate = project.ProjectDetails.StartDate;
    //existingProject.ProjectDetails.EndDate = project.ProjectDetails.EndDate;
    //existingProject.ProjectDetails.Budget = project.ProjectDetails.Budget;

    //// Update technologies (many-to-many)
    //existingProject.Technologies.Clear();
    //var technologies = _context.Technologies
    //    .Where(t => technologyIds.Contains(t.Id))
    //    .ToList();

    //existingProject.Technologies = technologies;

    //_context.SaveChanges();

    return RedirectToAction(nameof(Index));
}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //_context.Projects.Where(p =>p.Id==id).ExecuteDelete();
            //var project=_context.Projects.Find(id);
            //if(project!=null)
            //{_context.Projects.Remove(project);
            //    _context.SaveChanges();
            //}

            var deleted = _projectService.DeleteProject(id);

            if (!deleted)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}