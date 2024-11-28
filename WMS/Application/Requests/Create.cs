using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Requests
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Request Request { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Request).SetValidator(new RequestValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly WMSContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(WMSContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x =>
                    x.UserName == _userAccessor.GetUserName());

                var requestor = new RequestToRequestors
                {
                    Employee = user,
                    Request = request.Request,
                    IsNew = true,
                };

                request.Request.Requestors.Add(requestor);

                _context.Requests.Add(request.Request);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create request");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}