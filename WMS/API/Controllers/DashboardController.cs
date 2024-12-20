using Application.Dashboard.RequestCount;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class DashboardController : BaseApiController
    {
        private readonly WMSContext _context;
        private readonly IMapper _mapper;

        public DashboardController(WMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("req_count")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRequestCounts()
        {
            return HandleResult(await Mediator.Send(new List.Query{ }));
        }

    }
}