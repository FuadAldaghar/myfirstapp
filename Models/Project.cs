using System.ComponentModel.DataAnnotations;
namespace MyFirstApp.Models;    
public class Project
{   public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [StringLength(200)]
    public string Description { get; set; }
    [Required]
    [Url]
    public string GitHubUrl { get; set; }


/////////////////
      public string Category { get; set; }

      public bool IsPublic { get; set; }

      public string ProjectType { get; set; }

      public string License { get; set; }

    //   public string ImagePath { get; set; }
}