using System.ComponentModel.DataAnnotations;
namespace MyFirstApp.Models;    
public class Project
{   
    public int Id { get; set; }

    [Required]
    [RegularExpression( @"^[A-Z]+$", 
    ErrorMessage = "اسم المشروع يجب أن يحتوي على أحرف إنجليزية كبيرة فقط")]
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

    [Range(1, 20, ErrorMessage = "عدد التقنيات يجب أن يكون بين 1 و20")]
    public int TechnologiesCount { get; set; }
}