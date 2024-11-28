using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Dashboard.RequestCount
{
    public enum Title {
         Request, 
         Change, 
         Project
    }

    public class List
    {
        public class Query : IRequest<Result<List<RequestCountDto>>>
        {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<RequestCountDto>>>
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

            public async Task<Result<List<RequestCountDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countAll = await _context.Requests.CountAsync();

                var countApproved = await _context.Requests.CountAsync(e => e.ApprovalStatusId == 2);

                var countChange = await _context.Requests.CountAsync(e => e.ApprovalStatusId == 2 && e.RequestTypeId == 2);

                var projectChange = await _context.Requests.CountAsync(e => e.ApprovalStatusId == 2 && e.RequestTypeId == 1);

                RequestCountDto result = new RequestCountDto();

                List<RequestCountDto> responses = new List<RequestCountDto>();

                
                int count = 1;
                foreach(var title in Enum.GetNames(typeof(Title)))
                {
                    result = new RequestCountDto();
                    result.id = count++;
                    result.Title = title.ToString();
                    result.startAngle = -110;
                    result.endAngle = 110;
                    if(title == "Request") {
                        result.Value = countAll;
                    } else if(title == "Change") {
                        result.Value = countChange;
                    } else if(title == "Project") {
                        result.Value = projectChange;
                    } else {
                        result.Value = 0;
                    }
                    result.ValueMax = countAll;
                    responses.Add(result);
                }

                return Result<List<RequestCountDto>>.Success(responses);
                    
            }
        }
    }
}