using Application.Requests;
using Domain;
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
    }
}