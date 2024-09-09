using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Application.Core;
using Domain;

namespace wmsApi.Controllers
{
    public class RequestsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetRequests([FromQuery] RequestParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }
    }
}