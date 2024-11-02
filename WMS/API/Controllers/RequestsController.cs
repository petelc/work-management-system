using Application.Requests;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using SQLitePCL;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RequestsController : BaseApiController
    {
        private readonly WMSContext _context;
        private readonly IMapper _mapper;

        public RequestsController(WMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRequests([FromQuery] RequestParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { RequestId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(Request request)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Request = request }));
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetRequestTypes()
        {
            var types = await _context.RequestTypes.Select(p => p.RequestTypeName).Distinct().ToListAsync();
            return Ok(new { types });
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var ApprovalStatus = await _context.Requests.Select(p => p.ApprovalStatus).Distinct().ToListAsync();
            var types = await _context.Requests.Select(p => p.RequestType).Distinct().ToListAsync();

            return Ok(new { ApprovalStatus, types });
        }
    }
}