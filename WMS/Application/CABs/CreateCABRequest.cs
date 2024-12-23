using Application.Core;
using MediatR;
using Domain;
using Persistence;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.CABs
{
    public class CreateCABRequest
    {
        public class Command : IRequest<Result<Unit>>
        {
            // NOTE: This should be a CAB object not a Request object
            public CAB cab { get; set; }
            //public Request Request { get; set; }
        }

        // todo: Implement Command Validator

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly WMSContext _context;
            private IUserAccessor _userAccessor;
            private UserManager<Employee> _userManager;

            public Handler(WMSContext contex, IUserAccessor userAccessor, UserManager<Employee> userManager)
            {
                _context = contex;
                _userAccessor = userAccessor;
                _userManager = userManager;
            }
            

            public async Task<Result<Unit>> Handle(Command cab, CancellationToken cancellationToken)
            {
                //var r = request.Request;
                var board = cab.cab;

                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == board.MemberRef);
                cab.cab.Member = user;

                var request = await _context.Requests.FirstOrDefaultAsync(x => x.RequestId == board.RequestRef);
                cab.cab.Request = request;

                var change = await _context.Changes.FirstOrDefaultAsync(x => x.ChangeId == board.ChangeRef);
                cab.cab.Change = change;

                var project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == board.ProjectRef);
                cab.cab.Project = project;

                _context.CABs.Add(cab.cab);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to add request to CAB");

                
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}