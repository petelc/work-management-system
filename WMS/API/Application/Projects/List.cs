using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Projects
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ProjectDto>>>
        {
            public ProjectParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProjectDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<PagedList<ProjectDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Projects
                    .OrderBy(x => x.project).AsQueryable();

                return Result<PagedList<ProjectDto>>.Success(
                    await PagedList<ProjectDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));


            }
        }
    }
}