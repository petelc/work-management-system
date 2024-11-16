using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Dashboard.ChangeCount
{
    public class ChangeCounts
    {
        public class Query : IRequest<Result<ChangeCountDto>> {}

        public class Handler : IRequestHandler<Query, Result<ChangeCountDto>>
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
            
            public async Task<Result<ChangeCountDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countAll = await _context.Requests.CountAsync();

                var countApproved = await _context.Requests.CountAsync(
                    e => e.ApprovalStatusId == 2 && e.RequestTypeId == 2);

                ChangeCountDto result = new ChangeCountDto();
                result.Title = "Changes";
                result.startAngle = -110;
                result.endAngle = 110;
                result.Value = countApproved;
                result.ValueMax = countAll;

                return Result<ChangeCountDto>.Success(result);
            }
        }
    }
}