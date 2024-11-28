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


        /// <summary>
        /// Gets all of the submitted requests
        /// </summary>
        /// <param name="param">paging information</param>
        /// <returns>List of all requests</returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRequests([FromQuery] RequestParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        /// <summary>
        /// gets a specific request based on ID
        /// </summary>
        /// <param name="id">Id of Request</param>
        /// <returns>Specific request</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { RequestId = id }));
        }

        /// <summary>
        /// Creates a request from an user
        /// </summary>
        /// <param name="request">Request form data</param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest(Request request)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Request = request }));
        }

        /// <summary>
        /// Gets the request types 
        /// </summary>
        /// <returns>request types</returns>
        [HttpGet("types")]
        public async Task<IActionResult> GetRequestTypes()
        {
            var types = await _context.RequestTypes.Select(p => new {p.RequestTypeId, p.RequestTypeName}).Distinct().ToListAsync();
            return Ok(new { types });
        }


        /// <summary>
        /// gets the requests based on different filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var ApprovalStatus = await _context.Requests.Select(p => p.ApprovalStatus).Distinct().ToListAsync();
            var types = await _context.Requests.Select(p => p.RequestType).Distinct().ToListAsync();

            return Ok(new { ApprovalStatus, types });
        }
    }
}