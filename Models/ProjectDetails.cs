using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models;

public class ProjectDetails
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    [StringLength(150)]
    public string? Client { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal? Budget { get; set; }

    public Project? Project { get; set; }
}