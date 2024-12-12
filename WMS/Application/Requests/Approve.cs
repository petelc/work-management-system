using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.Requests
{
    public class Approve
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Request Request { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly WMSContext _context;

            public Handler(WMSContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var approval = await _context.Requests
                    .FirstOrDefaultAsync(x => x.RequestId == request.Request.RequestId);

                if (approval == null) return null;

                approval.ApprovalStatus = request.Request.ApprovalStatus; 

                _context.Requests.Update(approval);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to approve request");

                return Result<Unit>.Success(Unit.Value);
            }
        }
        
    }
}