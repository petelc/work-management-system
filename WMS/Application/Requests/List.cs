using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Requests
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<RequestDto>>>
        {
            public RequestParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<RequestDto>>>
        {
            private readonly IMapper _mapper;
            private readonly WMSContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(WMSContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<PagedList<RequestDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Requests
                    .OrderBy(d => d.RequestTitle)
                    .ProjectTo<RequestDto>(_mapper.ConfigurationProvider,
                        new { currentUsername = _userAccessor.GetUserName() })
                    .AsQueryable();

                return Result<PagedList<RequestDto>>.Success(
                    await PagedList<RequestDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}