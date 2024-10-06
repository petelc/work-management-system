using Domain;
using FluentValidation;

namespace Application.Requests
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(x => x.RequestTitle).NotEmpty().WithMessage("Request Title cannot be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(x => x.RequestType).NotEmpty().WithMessage("Please provide a request type");
            RuleFor(x => x.Requestors).NotEmpty().WithMessage("Please provide who is making this request");
        }
    }
}