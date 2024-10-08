using System.Security.Cryptography.X509Certificates;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Requests
{
    public class Details
    {
        public class Query : IRequest<Result<RequestDto>>
        {
            public int RequestId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<RequestDto>>
        {
            private readonly WMSContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(WMSContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<RequestDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var req = await _context.Requests
                    .ProjectTo<RequestDto>(_mapper.ConfigurationProvider,
                        new { currentUsername = _userAccessor.GetUserName() })
                    .FirstOrDefaultAsync(x => x.RequestId == request.RequestId);

                return Result<RequestDto>.Success(req);
            }
        }
    }
}