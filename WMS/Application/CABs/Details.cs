using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.CABs
{
    public class Details
    {
        public class Query : IRequest<Result<CABDto>>
        {
            public int CABId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CABDto>>
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


            public async Task<Result<CABDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var board = await _context.CABs
                    .ProjectTo<CABDto>(_mapper.ConfigurationProvider,
                        new { currentUsername = _userAccessor.GetUserName() })
                    .FirstOrDefaultAsync(x => x.CABId == request.CABId);
                    
                return Result<CABDto>.Success(board);
            }
        }
    }
}