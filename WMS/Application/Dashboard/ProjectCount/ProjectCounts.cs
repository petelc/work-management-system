using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Dashboard.ProjectCount
{
    public class ProjectCounts
    {
        public class Query : IRequest<Result<ProjectCountDto>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<ProjectCountDto>>
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
            
            public async Task<Result<ProjectCountDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countAll = await _context.Requests.CountAsync();

                var countApproved = await _context.Requests.CountAsync(
                    e => e.ApprovalStatusId == 2 && e.RequestTypeId == 1);

                ProjectCountDto result = new ProjectCountDto();
                result.Title = "Projects";
                result.startAngle = -110;
                result.endAngle = 110;
                result.Value = countApproved;
                result.ValueMax = countAll;

                return Result<ProjectCountDto>.Success(result);
            }
        }
    }
}