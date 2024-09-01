using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<RequestDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Requests
                    .OrderBy(x => x.request)
                    .ProjectTo<RequestDto>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() }).AsQueryable();

                return Result<PagedList<RequestDto>>.Success(
                    await PagedList<RequestDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}