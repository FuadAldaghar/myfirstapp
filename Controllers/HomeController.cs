using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //routing test
[Route("test")]
public IActionResult Test()
{
    return Content("Routing is working!");
}
    // private static List<Project> projects = new();
    private static List<Project> projects = new List<Project>
    {
        new Project
        {   Id=1,
            Name = "N",
            Description = "تطبيق ملاحظات باستخدام ASP.NET Core",
            GitHubUrl = "https://github.com/FuadAldaghar/NotesAppPyaspdotnet",
            IsPublic=true,
            ProjectType="Personal",
            License="MIT",
            Category="Web Development", 
               TechnologiesCount = 10
        },
        new Project
        {Id=2,
            Name = "A",
            Description = "وصف المشروع الثاني",
            GitHubUrl = "https://github.com/FuadAldaghar/AnotherProject" ,
              IsPublic=true,
            ProjectType="Personal",
            License="MIT",
            Category="Web Development", 
              TechnologiesCount = 10 
        }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // ViewData["name"]="fuad aldaghar";
    //     var project = new Project
    // {
    //     Name = "NotesApp",
    //     Description = "تطبيق ملاحظات باستخدام ASP.NET Core",
    //     GitHubUrl = "https://github.com/FuadAldaghar/NotesAppPyaspdotnet"
    // };

 
        // ViewBag.project = project;
       
        return View(projects);
    }

[HttpGet]
public IActionResult Create()
{
    return View();
}

[HttpPost]
public IActionResult Create(Project project)
{
    if (!ModelState.IsValid)
    {
        return View(project);
    }

    // حفظ الصورة
    // if (image != null && image.Length > 0)
    // {
    //     var uploadsFolder = Path.Combine(
    //         Directory.GetCurrentDirectory(),
    //         "wwwroot/images"
    //     );

    //     if (!Directory.Exists(uploadsFolder))
    //     {
    //         Directory.CreateDirectory(uploadsFolder);
    //     }

    //     var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

    //     var filePath = Path.Combine(uploadsFolder, fileName);

    //     using (var stream = new FileStream(filePath, FileMode.Create))
    //     {
    //         image.CopyTo(stream);
    //     }

    //     project.ImagePath = "/images/" + fileName;
    // }

    project.Id = projects.Max(p => p.Id) + 1;

    projects.Add(project);

    return RedirectToAction("Index");
}
//edit project 
[HttpGet]
public IActionResult Edit(int id)
{
    var project = projects.Find(p => p.Id == id);
    if (project == null)
    {
        return NotFound();
    }
    return View(project);
}
[HttpPost]
public IActionResult Edit(Project project)
{//validation
    if (!ModelState.IsValid)
    {
        return View(project);
    }

    var existingProject = projects.Find(p => p.Id == project.Id);
    if (existingProject == null)
    {
        return NotFound();
    }
    existingProject.Name = project.Name;
    existingProject.Description = project.Description;
    existingProject.GitHubUrl = project.GitHubUrl;
    existingProject.Category = project.Category;
    existingProject.IsPublic = project.IsPublic;
    existingProject.ProjectType = project.ProjectType;
    existingProject.License = project.License;
    existingProject.TechnologiesCount = project.TechnologiesCount;
    return RedirectToAction("Index");
}
//delete project 
[HttpPost]
public IActionResult Delete(int id)
{
    var project = projects.Find(p => p.Id == id);
    if (project == null)
    {
        return NotFound();
    }
    projects.Remove(project);
    return RedirectToAction("Index");
}
// [HttpPost]
// public IActionResult Delete(Project project)
// {
//     var existingProject = projects.Find(p => p.Id == project.Id);
//     if (existingProject == null)
//     {
//         return NotFound();
//     }
//     projects.Remove(existingProject);
//     return RedirectToAction("Index");
// }


//Details
[Route("Details/{id}")]
public IActionResult Details(int id)
{
   

    var project = projects.FirstOrDefault(p => p.Id == id);

    if (project == null)
    {
        return NotFound();
    }

    return View(project);
}
//

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
