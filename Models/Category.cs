using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    //?
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}