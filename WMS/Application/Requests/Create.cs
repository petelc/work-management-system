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
                
                // NOTE: This gets the user from the UserManager and assigns it to the Requestor property
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == p.Requestor.Id);
                request.Request.Requestor = user;

                // NOTE: This gets the request type from the context and assigns it to the RequestType property
                var type = await _context.RequestTypes.FirstOrDefaultAsync(x => x.RequestTypeId == request.Request.RequestType.RequestTypeId);
                request.Request.RequestType = type;

                // NOTE: This gets the status from the context and assigns it to the Status property
                var status = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusId == request.Request.Status.StatusId);
                request.Request.Status = status;

                // NOTE: This gets the approval status from the context and assigns it to the ApprovalStatus property
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