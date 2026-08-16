using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Validation;

public class ProjectValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        var project = validationContext.ObjectInstance as Models.Project;

        if (project == null)
        {
            return ValidationResult.Success;
        }

        if (project.IsPublic &&
            string.IsNullOrWhiteSpace(project.GitHubUrl))
        {
            return new ValidationResult(
                "Public projects must have a GitHub URL."
            );
        }
        else if (!project.IsPublic &&
            !string.IsNullOrWhiteSpace(project.GitHubUrl))
        {
            return new ValidationResult(
                "private projects must not have a GitHub URL."
            );
        }

        return ValidationResult.Success;
    }
}