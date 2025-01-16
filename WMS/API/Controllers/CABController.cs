using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Application.CABs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CABController : BaseApiController
    {
        // todo: Get all submitted requests sent to the CAB
        // todo: Get a specific request based on ID
        // todo: Add submitted requests to Change or Project table
        // todo: Come up with a way to get Board Members approval/disapproval
        // todo: Come up with a way to allow Board Members to add comments to requests
        // todo: Come up with a way to allow Board Members to add attachments to requests
        // todo: MORE TO COME 
        private readonly WMSContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for CABController
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CABController(WMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all of the submitted requests
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRequests([FromQuery] BoardParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        /// <summary>
        /// Gets a specific request based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { CABId = id }));
        }
        
        /// <summary>
        /// Creates a board entry from submitted request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest(CAB cab)
        {
            return HandleResult(await Mediator.Send(new CreateCABRequest.Command { cab = cab }));
        }
    }
}