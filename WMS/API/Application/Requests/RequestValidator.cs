using FluentValidation;
using Domain;

namespace Application.Requests
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.request).NotEmpty();
            RuleFor(x => x.description).NotEmpty();
        }
    }
}