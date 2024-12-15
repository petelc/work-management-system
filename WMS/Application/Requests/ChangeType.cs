using MediatR;
using Application.Core;
using Domain;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Requests
{
    public class ChangeType
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
                var changeType = await _context.Requests
                    .FirstOrDefaultAsync(x => x.RequestId == request.Request.RequestId);

                if (changeType == null) return null;

                changeType.RequestType = request.Request.RequestType;

                _context.Requests.Update(changeType);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to change request type");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}