using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}