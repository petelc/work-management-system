using Domain;
using FluentValidation;

namespace Application.Projects
{
    public class ProjectValidators : AbstractValidator<Project>
    {
        public ProjectValidators()
        {
            RuleFor(x => x.project).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
        }
    }
}