using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.Models;

namespace MyFirstApp.Services
{
    public class ProjectService
    {
        private readonly AppDbContext _context;
        //public Guid Id { get; } = Guid.NewGuid();
        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // Get All Projects
        // =========================
        public List<Project> GetAllProjects()
        {
            return _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Technologies)
                .Include(p => p.ProjectDetails)
                .ToList();
        }

        // =========================
        // Get Project By Id
        // =========================
        public Project? GetProjectById(int id)
        {
            return _context.Projects
                .Include(p => p.Category)
                .Include(p => p.Technologies)
                .Include(p => p.ProjectDetails)
                .FirstOrDefault(p => p.Id == id);

          
        }

        // =========================
        // Create Project
        // =========================
        public void CreateProject(Project project, int[] technologyIds)
        {
            project.ProjectDetails ??= new ProjectDetails();

            var technologies = _context.Technologies
                .Where(t => technologyIds.Contains(t.Id))
                .ToList();

            project.Technologies = technologies;

            _context.Projects.Add(project);

            _context.SaveChanges();
        }

        // =========================
        // Update Project
        // =========================
        public bool UpdateProject(Project project, int[] technologyIds)
        {
            var existingProject = _context.Projects
                .Include(p => p.ProjectDetails)
                .Include(p => p.Technologies)
                .FirstOrDefault(p => p.Id == project.Id);

            if (existingProject == null)
            {
                return false;
            }

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.GitHubUrl = project.GitHubUrl;
            existingProject.CategoryId = project.CategoryId;

            if (existingProject.ProjectDetails == null)
            {
                existingProject.ProjectDetails = new ProjectDetails();
            }

            if (project.ProjectDetails != null)
            {
                existingProject.ProjectDetails.Client = project.ProjectDetails.Client;
                existingProject.ProjectDetails.StartDate = project.ProjectDetails.StartDate;
                existingProject.ProjectDetails.EndDate = project.ProjectDetails.EndDate;
                existingProject.ProjectDetails.Budget = project.ProjectDetails.Budget;
            }

            existingProject.Technologies.Clear();

            var technologies = _context.Technologies
                .Where(t => technologyIds.Contains(t.Id))
                .ToList();

            foreach (var technology in technologies)
            {
                existingProject.Technologies.Add(technology);
            }

            _context.SaveChanges();

            return true;
        }

        // =========================
        // Delete Project
        // =========================
        public bool DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return false;
            }

            _context.Projects.Remove(project);

            _context.SaveChanges();

            return true;
        }

        // =========================
        // Get Categories
        // =========================
        public List<Category> GetCategories()
        {
            return _context.Categories
                .ToList();
        }

        // =========================
        // Get Technologies
        // =========================
        public List<Technology> GetTechnologies()
        {
            return _context.Technologies
                .ToList();
        }
    }
}