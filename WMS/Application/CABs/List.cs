using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.CABs
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<CABDto>>> { 
            public BoardParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<CABDto>>>
        {
            private readonly IMapper _mapper;
            protected readonly WMSContext _context;
            protected readonly IUserAccessor _userAccessor;
            public Handler(WMSContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<PagedList<CABDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.CABs
                    .OrderBy(d => d.RequestName)
                    .ProjectTo<CABDto>(_mapper.ConfigurationProvider,
                        new { currentUsername = _userAccessor.GetUserName() })
                    .AsQueryable();

                return Result<PagedList<CABDto>>.Success(
                    await PagedList<CABDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }

   
}