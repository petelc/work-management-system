using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;

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
            private readonly UserManager<Employee> _userManager; // Add UserManager
            private readonly IUtilities _utilities;

            public Handler(WMSContext context, IUserAccessor userAccessor, UserManager<Employee> userManager, IUtilities utilities) // Modify constructor
            {
                _context = context;
                _userAccessor = userAccessor;
                _userManager = userManager; // Assign UserManager
                _utilities = utilities;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var p = request.Request;
                

                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == p.Requestor.Id);
                request.Request.Requestor = user;


                var type = await _context.RequestTypes.FirstOrDefaultAsync(x => x.RequestTypeId == request.Request.RequestType.RequestTypeId);
                request.Request.RequestType = type;

                var status = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == request.Request.Status.StatusId);
                request.Request.Status = status;

                var approvalStatus = await _context.ApprovalStatuses.FirstOrDefaultAsync(x => x.ApprovalStatusId == request.Request.ApprovalStatus.ApprovalStatusId);
                request.Request.ApprovalStatus = approvalStatus;

                _context.Requests.Add(request.Request);

                var result = await _context.SaveChangesAsync() > 0;
                

                if (!result) return Result<Unit>.Failure("Failed to create request");

                // Optionally, you can return the ID as part of the result
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}