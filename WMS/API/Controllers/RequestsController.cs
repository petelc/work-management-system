using Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RequestsController : BaseApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetRequests([FromQuery] RequestParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }
    }
}